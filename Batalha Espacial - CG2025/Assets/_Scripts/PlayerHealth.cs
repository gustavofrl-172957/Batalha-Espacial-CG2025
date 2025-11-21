using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Chamado quando o player bate em algo ou leva tiro
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("MainMenu"); // Temporário: volta pro menu
    }
    
    // Detecta colisão com Tiros Inimigos ou Naves Inimigas
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(GameBalance.GetDamageToPlayer());
            Destroy(other.gameObject); // Destroi o tiro
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
        {
            TakeDamage(20); // Dano de colisão física
            // O inimigo/asteroide também deve explodir (tratado no script deles)
        }
    }
}