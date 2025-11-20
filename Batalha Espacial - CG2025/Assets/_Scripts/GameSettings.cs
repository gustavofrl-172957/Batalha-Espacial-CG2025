using UnityEngine;

// Classe estática: os dados sobrevivem à troca de cenas
public static class GameSettings
{
    public enum Difficulty { Facil, Medio, Dificil }
    
    // Variáveis para guardar o estado
    public static Difficulty SelectedDifficulty = Difficulty.Medio;
    public static int SelectedLevel = 1; // 1, 2 ou 3
    
    // Pontuação temporária da sessão
    public static int CurrentScore = 0;
}