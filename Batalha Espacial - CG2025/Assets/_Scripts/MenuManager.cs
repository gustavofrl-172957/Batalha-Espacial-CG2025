using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI rankingText;

    private void Start()
    {
        // Se tiver um texto de ranking na cena, atualiza ele
        if (rankingText != null)
        {
            float bestTime = PlayerPrefs.GetFloat("BestTime", 0);
            rankingText.text = "Melhor Tempo: " + bestTime.ToString("F2") + "s";
        }
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void SelectLevel(int level)
    {
        GameSettings.SelectedLevel = level;
        SceneManager.LoadScene("DifficultySelect");
    }

    public void SelectDifficulty(int difficultyIndex)
    {
        // 0 = Facil, 1 = Medio, 2 = Dificil
        GameSettings.SelectedDifficulty = (GameSettings.Difficulty)difficultyIndex;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saindo do Jogo...");
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}