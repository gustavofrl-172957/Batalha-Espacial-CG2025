using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Fase")]
    public int killsToSpawnBoss = 5;
    public float levelTime = 120f; 
    public GameObject playerPrefab;
    public GameObject bossPrefab;
    public GameObject asteroidPrefab;
    public GameObject[] enemyPrefabs; // Array de inimigos

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI objectivesText; 
    public Slider bossHealthBar;
    public Slider playerHealthSlider;
    public GameObject gameOverPanel;
    public TextMeshProUGUI endMessageText; 
    public TMP_InputField nameInput; 
    public Button submitButton;
    public GameObject restartButton; // Botão voltar

    private float currentTime;
    private int currentKills = 0;
    private bool isBossActive = false;
    private bool isGameRunning = true;

    void Awake() 
    { 
        // Garante que só existe um Manager
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
            return;
        }
        Instance = this; 
    }

    void Start()
    {
        currentTime = levelTime;
        GameSettings.CurrentScore = 0;
        
        SpawnPlayer();
        
        StartCoroutine(SpawnRoutine());
        UpdateUI();

        if(gameOverPanel) gameOverPanel.SetActive(false);
        if(bossHealthBar) bossHealthBar.gameObject.SetActive(false);
    }

    void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            GameObject playerGO = Instantiate(playerPrefab, new Vector3(0, -4, 0), Quaternion.identity);
            PlayerController2D playerScript = playerGO.GetComponent<PlayerController2D>();
            
            if (playerScript != null && playerHealthSlider != null)
            {
                playerScript.healthSlider = playerHealthSlider;
                playerScript.currentHealth = playerScript.maxHealth;
                playerScript.TakeDamage(0); 
            }
        }
    }

    void Update()
    {
        if (!isGameRunning) return;

        currentTime -= Time.deltaTime;
        if(timerText) timerText.text = "Tempo: " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0)
        {
            GameOver(false, "TEMPO ESGOTADO!");
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (isGameRunning && !isBossActive)
        {
            yield return new WaitForSeconds(2f);

            // --- CORREÇÃO DE SEGURANÇA (O ERRO ESTAVA AQUI) ---
            if (enemyPrefabs == null || enemyPrefabs.Length == 0)
            {
                Debug.LogWarning("AVISO: Lista de Inimigos vazia no GameController! Pulando spawn.");
                continue; // Pula este loop e tenta de novo depois
            }
            // --------------------------------------------------

            Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), 7f, 0f);
            GameObject toSpawn = null;

            if (Random.value < 0.3f && asteroidPrefab != null) 
                toSpawn = asteroidPrefab;
            else 
                toSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            if (toSpawn != null)
            {
                GameObject obj = Instantiate(toSpawn, spawnPos, Quaternion.identity);
                
                EnemyBase enemy = obj.GetComponent<EnemyBase>();
                if (enemy && !enemy.isAsteroid) ConfigureEnemyShooting(enemy);
            }
        }
    }

    void ConfigureEnemyShooting(EnemyBase enemy)
    {
        var dif = GameSettings.SelectedDifficulty;
        if (dif == GameSettings.Difficulty.Dificil) enemy.canShoot = true;
        else if (dif == GameSettings.Difficulty.Medio && enemy.points > 200) enemy.canShoot = true;
        else enemy.canShoot = false;
    }

    public void RegisterKill(string type, int points)
    {
        if (!isGameRunning) return;

        GameSettings.CurrentScore += points;
        
        if (type == "Boss")
        {
            CalculateTimeBonus();
            GameOver(true, "VITÓRIA! MISSÃO CUMPRIDA.");
        }
        else if (type != "Asteroid" && !isBossActive)
        {
            currentKills++;
            if (currentKills >= killsToSpawnBoss) SpawnBoss();
        }
        UpdateUI();
    }

    void SpawnBoss()
    {
        isBossActive = true;
        if(bossPrefab) Instantiate(bossPrefab, new Vector3(0, 3.5f, 0), Quaternion.identity);
        
        if(objectivesText) objectivesText.text = "ALERTA: CHEFE DETECTADO!";
        if(bossHealthBar) {
            bossHealthBar.gameObject.SetActive(true);
            bossHealthBar.maxValue = GameBalance.GetEnemyHP("Boss");
            bossHealthBar.value = bossHealthBar.maxValue;
        }
    }

    public void UpdateBossUI(int hp) { if(bossHealthBar) bossHealthBar.value = hp; }

    void CalculateTimeBonus()
    {
        float percent = currentTime / levelTime;
        int bonus = (percent > 0.66f) ? 999 : (percent > 0.33f) ? 667 : 333;
        GameSettings.CurrentScore += bonus;
    }

    public void GameOver(bool win, string message)
    {
        isGameRunning = false;

        Time.timeScale = 0f; 

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerController2D>().enabled = false;
            player.GetComponent<PlayerShooting2D>().enabled = false;
        }

        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
            if(endMessageText) endMessageText.text = message + "\nPontuação: " + GameSettings.CurrentScore;
            
            if (win) 
            {
                if(nameInput) nameInput.gameObject.SetActive(true);
                if(submitButton) submitButton.gameObject.SetActive(true);
                
                if(restartButton) restartButton.SetActive(false); 
            }
            else
            {
                if(nameInput) nameInput.gameObject.SetActive(false);
                if(submitButton) submitButton.gameObject.SetActive(false);
                
                if(restartButton) restartButton.SetActive(true);
            }
        }
    }

    public void SubmitScore()
    {
        string name = (nameInput && nameInput.text.Length > 0) ? nameInput.text : "Piloto";
        int oldHigh = PlayerPrefs.GetInt("HighScore", 0);

        if (GameSettings.CurrentScore > oldHigh)
        {
            PlayerPrefs.SetInt("HighScore", GameSettings.CurrentScore);
            PlayerPrefs.SetString("HighName", name);
            PlayerPrefs.SetFloat("BestTime", levelTime - currentTime);
        }
        
        ReturnToMenu(); 
    }

    public void ReturnToMenu() 
    { 
        Time.timeScale = 1f; 
        
        SceneManager.LoadScene("MainMenu"); 
    }
    
    void UpdateUI()
    {
        if(scoreText) scoreText.text = "Pts: " + GameSettings.CurrentScore;
        if(objectivesText && !isBossActive) objectivesText.text = "Abatidos: " + currentKills + "/" + killsToSpawnBoss;
    }
}