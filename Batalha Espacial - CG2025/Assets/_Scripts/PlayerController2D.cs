using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    [Header("Vida")]
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    Vector2 movement;
    Vector2 mousePos;

    [Header("Efeitos")]
    public GameObject explosionPrefab;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider) healthSlider.value = currentHealth;
    }

    void Update()
    {
        // Input de Movimento (WASD)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Input do Mouse (Posição)
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // Movimentação Física
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotação (Olhar para o mouse - 360 graus)
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; // -90 para ajustar o sprite se ele estiver virado pra cima
        rb.rotation = angle;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthSlider) healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
    if (explosionPrefab != null)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
    GameManager.Instance.GameOver(false, "GAME OVER! Você foi abatido."); 

    Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TiroInimigo"))
        {
            TakeDamage(GameBalance.GetDamageToPlayer());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("Asteroid") || other.CompareTag("Boss"))
        {
            TakeDamage(25); // Regra: 25% de dano na colisão
            
            // Se não for o Boss, o objeto colidido explode
            if (!other.CompareTag("Boss"))
            {
                // Tenta acessar o script do inimigo/asteroide para matar ele corretamente
                EnemyBase enemy = other.GetComponent<EnemyBase>();
                if (enemy) enemy.Die();
                else Destroy(other.gameObject);
            }
        }
    }
}