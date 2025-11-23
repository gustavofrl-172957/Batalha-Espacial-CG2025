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
    public float levelTime = 120f; // 2 minutos
    public GameObject playerPrefab;
    public GameObject bossPrefab;
    public GameObject asteroidPrefab;
    public GameObject[] enemyPrefabs; // Array de prefabs (Pequeno, Grande)

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI objectivesText; // "Inimigos: 0/5"
    public Slider bossHealthBar;
    public Slider playerHealthSlider;
    public GameObject gameOverPanel;
    public TextMeshProUGUI endMessageText; // "Vitoria" ou "Derrota"
    public TMP_InputField nameInput; // Para Ranking
    public Button submitButton;

    // Controle Interno
    private float currentTime;
    private int currentKills = 0;
    private bool isBossActive = false;
    private bool isGameRunning = true;

    void Awake() { Instance = this; }

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
                playerScript.TakeDamage(0); // Força a UI a atualizar com o valor máximo
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
            yield return new WaitForSeconds(2f); // Intervalo de Spawn

            // Define Posição Aleatória (Topo ou Lados)
            Vector3 spawnPos = GetRandomSpawnPosition();

            // Decide o que spawnar (30% Asteroide, 70% Inimigo)
            GameObject toSpawn;
            if (Random.value < 0.3f && asteroidPrefab != null) 
                toSpawn = asteroidPrefab;
            else 
                toSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            GameObject obj = Instantiate(toSpawn, spawnPos, Quaternion.identity);
            
            // Configura se atira (Logica da Dificuldade)
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            if (enemy && !enemy.isAsteroid)
            {
                ConfigureEnemyShooting(enemy);
            }
        }
    }

    void ConfigureEnemyShooting(EnemyBase enemy)
    {
        var dif = GameSettings.SelectedDifficulty;
        // Facil: Ninguem atira. Medio: So os grandes (Pontos > 200). Dificil: Todos.
        if (dif == GameSettings.Difficulty.Dificil) enemy.canShoot = true;
        else if (dif == GameSettings.Difficulty.Medio && enemy.points > 200) enemy.canShoot = true;
        else enemy.canShoot = false;
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Spawnar fora da tela
        float x = Random.Range(-9f, 9f);
        return new Vector3(x, 7f, 0f); // Topo
    }

    public void RegisterKill(string type, int points)
    {
        if (!isGameRunning) return;

        GameSettings.CurrentScore += points;
        UpdateUI();

        if (type == "Boss")
        {
            CalculateTimeBonus();
            GameOver(true, "VITÓRIA! MISSÃO CUMPRIDA.");
        }
        else if (type != "Asteroid" && !isBossActive)
        {
            currentKills++;
            if (currentKills >= killsToSpawnBoss)
            {
                SpawnBoss();
            }
        }
        UpdateUI();
    }

    void SpawnBoss()
    {
        isBossActive = true;
        if(bossPrefab) Instantiate(bossPrefab, new Vector3(0, 6, 0), Quaternion.identity);
        
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
        int bonus = 0;
        if (percent > 0.66f) bonus = 999;
        else if (percent > 0.33f) bonus = 667;
        else bonus = 333;
        GameSettings.CurrentScore += bonus;
    }

    public void GameOver(bool win, string message)
    {
        isGameRunning = false;
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
            if(endMessageText) endMessageText.text = message + "\nPontuação: " + GameSettings.CurrentScore;
            
            // So mostra input de nome se ganhou
            if (nameInput) nameInput.gameObject.SetActive(win);
            if (submitButton) submitButton.gameObject.SetActive(win);
        }
    }

    // Chamado pelo botão no UI
    public void SubmitScore()
    {
        string name = nameInput.text;
        if (string.IsNullOrEmpty(name)) name = "Piloto";

        // Salva High Score simples
        int oldHigh = PlayerPrefs.GetInt("HighScore", 0);
        if (GameSettings.CurrentScore > oldHigh)
        {
            PlayerPrefs.SetInt("HighScore", GameSettings.CurrentScore);
            PlayerPrefs.SetString("HighName", name);
            PlayerPrefs.SetFloat("BestTime", levelTime - currentTime);
        }
        SceneManager.LoadScene("MainMenu");
    }
    
    void UpdateUI()
    {
        if(scoreText) scoreText.text = "Pts: " + GameSettings.CurrentScore;
        if(objectivesText && !isBossActive) objectivesText.text = "Inimigos: " + currentKills + "/" + killsToSpawnBoss;
    }
}