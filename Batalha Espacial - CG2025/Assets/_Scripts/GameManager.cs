using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Para UI de texto
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Referências")]
    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    public GameObject[] enemyPrefabs;
    
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel; // Painel para ativar quando ganhar/perder
    public TextMeshProUGUI finalMessageText; // Texto dentro do painel ("Vitoria" ou "Derrota")

    // Estado do Jogo
    private int totalEnemiesToSpawn;
    private int enemiesDefeated = 0;
    private float gameTime = 0f;
    private bool isGameActive = true;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // 1. Configura o nível baseado no GameSettings
        SetupLevel();

        // 2. Nasce o Jogador
        if (playerPrefab != null)
            Instantiate(playerPrefab, new Vector3(0, -4, 0), Quaternion.identity);

        // 3. Inicia Spawns
        StartCoroutine(SpawnEnemies());
        
        if(gameOverPanel) gameOverPanel.SetActive(false);
    }

    void SetupLevel()
    {
        totalEnemiesToSpawn = GameSettings.SelectedLevel * 10; 
        
        // Dificuldade - apenas log
        Debug.Log($"Iniciando Nível {GameSettings.SelectedLevel} na dificuldade {GameSettings.SelectedDifficulty}");
    }

    void Update()
    {
        if (!isGameActive) return;

        // Conta o tempo
        gameTime += Time.deltaTime;
        
        // Atualiza UI
        if (timeText) timeText.text = "Tempo: " + gameTime.ToString("F1") + "s";
    }

    IEnumerator SpawnEnemies()
    {
        int spawnedCount = 0;
        
        while (spawnedCount < totalEnemiesToSpawn && isGameActive)
        {
            yield return new WaitForSeconds(2.0f); // Espera 2 segundos entre inimigos

            // Posição aleatória no X (dentro da tela) e fixa no Y (topo)
            float randomX = Random.Range(-7f, 7f);
            Vector3 spawnPos = new Vector3(randomX, 6f, 0f);

            // Escolhe tipo de inimigo aleatório
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.identity);
            
            spawnedCount++;
        }
    }

    // Chamado pelo EnemyBase quando morre
    public void EnemyDefeated()
    {
        enemiesDefeated++;
        AddScore(100);

        // Condição de Vitória: Matou todos os inimigos previstos
        if (enemiesDefeated >= totalEnemiesToSpawn)
        {
            EndGame(true);
        }
    }
    
    // Chamado pelo PlayerHealth quando morre
    public void GameOver()
    {
        EndGame(false);
    }

    public void AddScore(int amount)
    {
        GameSettings.CurrentScore += amount;
        if (scoreText) scoreText.text = "Pontos: " + GameSettings.CurrentScore;
    }

    void EndGame(bool win)
    {
        isGameActive = false;
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
            if (finalMessageText)
                finalMessageText.text = win ? "VITÓRIA!" : "GAME OVER";
        }
        
        // Salva Ranking se ganhou
        if (win)
        {
            float bestTime = PlayerPrefs.GetFloat("BestTime", 999f);
            if (gameTime < bestTime)
            {
                PlayerPrefs.SetFloat("BestTime", gameTime);
            }
        }

        // Volta pro menu após 3 segundos
        Invoke("ReturnToMenu", 3f);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}