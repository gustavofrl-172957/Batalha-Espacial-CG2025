using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI rankingText;

    private void Start()
    {
        if (rankingText != null)
        {
            RankingList ranking = RankingData.LoadRanking(); 
            string rankingStr = "TOP 5 PILOTOS\n\n";

            if (ranking.entries.Count == 0)
            {
                rankingStr += "Nenhum registro ainda!";
            }
            else
            {
                for (int i = 0; i < ranking.entries.Count; i++)
                {
                    RankingEntry entry = ranking.entries[i];
                    
                    rankingStr += string.Format("{0}. {1} - {2} Pts | {3}s (L{4}-{5})\n", 
                                                i + 1, 
                                                entry.playerName.Length > 10 ? entry.playerName.Substring(0, 10) + "..." : entry.playerName,
                                                entry.score.ToString("N0"), 
                                                entry.time.ToString("F2"),
                                                entry.level,
                                                entry.difficulty.ToString().Substring(0, 1));
                }
            }
            rankingText.text = rankingStr;
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