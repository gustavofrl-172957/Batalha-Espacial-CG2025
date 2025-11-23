using UnityEngine;
using System.Collections;
using UnityEditor;

public abstract class EnemyBase : MonoBehaviour
{
    protected int hp;
    protected float speed;
    public int scoreValue = 100; // Pontos que vale este inimigo

    // Prefab da explosão
    public GameObject explosionPrefab; 

    protected virtual void Start()
    {
        // Define HP baseado no tipo (nome da classe ou tag) e dificuldade
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Adiciona pontuação
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreValue);
            GameManager.Instance.EnemyDefeated(); // Avisa que morreu
        }

        // Cria explosão visual
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // Movimento obrigatório para todo inimigo
    protected abstract void MoveBehaviour();

    void Update()
    {
        MoveBehaviour();
        
        // Se sair da tela por baixo (Y < -6), destrói para limpar memória
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    // Colisão com o TIRO DO JOGADOR
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TiroPlayer"))
        {
            // Pega o script do projétil para saber o dano
            Projectile2D projectile = other.GetComponent<Projectile2D>();
            if (projectile != null && !projectile.isEnemyShot)
            {
                TakeDamage(projectile.damage);
                Destroy(other.gameObject); // Destrói o tiro
            }
        }
        // Colisão com o JOGADOR é tratada no script do PlayerHealth
    }
}