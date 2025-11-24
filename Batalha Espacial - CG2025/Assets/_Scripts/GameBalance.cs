using UnityEngine;

public static class GameBalance
{
    public enum Difficulty { Facil, Medio, Dificil }

    public static int GetEnemyHP(string enemyType)
    {
        float difficultyMultiplier = 1.0f;
        
        // 1. Multiplicador de Dificuldade
        switch (GameSettings.SelectedDifficulty)
        {
            case GameSettings.Difficulty.Facil: difficultyMultiplier = 0.5f; break; 
            case GameSettings.Difficulty.Medio: difficultyMultiplier = 1.0f; break;
            case GameSettings.Difficulty.Dificil: difficultyMultiplier = 2.0f; break; 
        }
        
        // 2. Multiplicador de FASE (Progressão): Inimigos mais fortes a cada nível
        // Nível 1 = 1x, Nível 2 = 1.2x, Nível 3 = 1.4x
        float levelMultiplier = 1f + (GameSettings.SelectedLevel - 1) * 0.2f; 

        float finalMultiplier = difficultyMultiplier * levelMultiplier;

        // Valores Base
        if (enemyType == "Small") return Mathf.CeilToInt(20 * finalMultiplier);
        if (enemyType == "Big") return Mathf.CeilToInt(60 * finalMultiplier);   
        if (enemyType == "Boss") return Mathf.CeilToInt(500 * finalMultiplier); 
        
        return 10;
    }

    public static int GetDamageToPlayer()
    {
        // Retorna o dano que o Player toma (aumenta com dificuldade)
        switch (GameSettings.SelectedDifficulty)
        {
            case GameSettings.Difficulty.Facil: return 10;
            case GameSettings.Difficulty.Medio: return 20;
            case GameSettings.Difficulty.Dificil: return 40; 
            default: return 20;
        }
    }
}