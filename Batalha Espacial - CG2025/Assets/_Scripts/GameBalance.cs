using UnityEngine;

public static class GameBalance
{
    // Retorna quanto de vida o inimigo tem baseado na dificuldade
    public static int GetEnemyHP(string enemyType)
    {
        // Multiplicador baseado na dificuldade
        float multiplier = 1.0f;
        
        switch (GameSettings.SelectedDifficulty)
        {
            case GameSettings.Difficulty.Facil: multiplier = 0.5f; break;
            case GameSettings.Difficulty.Medio: multiplier = 1.0f; break;
            case GameSettings.Difficulty.Dificil: multiplier = 2.0f; break;
        }

        if (enemyType == "Small") return Mathf.CeilToInt(10 * multiplier);
        if (enemyType == "Big") return Mathf.CeilToInt(30 * multiplier);
        if (enemyType == "Boss") return Mathf.CeilToInt(100 * multiplier);
        
        return 10;
    }

    // Retorna o dano que o jogador sofre ao colidir ou levar tiro
    public static int GetDamageToPlayer()
    {
        switch (GameSettings.SelectedDifficulty)
        {
            case GameSettings.Difficulty.Facil: return 10;
            case GameSettings.Difficulty.Medio: return 20;
            case GameSettings.Difficulty.Dificil: return 40;
            default: return 20;
        }
    }
}