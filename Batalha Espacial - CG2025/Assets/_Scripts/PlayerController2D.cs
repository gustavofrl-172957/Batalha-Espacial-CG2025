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
        if (cam == null) cam = Camera.main;
        if (rb == null) rb = GetComponent<Rigidbody2D>();

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
        Vector2 newPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        newPos.x = Mathf.Clamp(newPos.x, -8f, 8f);
        newPos.y = Mathf.Clamp(newPos.y, -4.5f, 4.5f);

        rb.MovePosition(newPos);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
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
        // Verifica TAGs especificas de inimigos
        else if (other.CompareTag("EnemySmall") || other.CompareTag("EnemyBig") || other.CompareTag("Asteroid") || other.CompareTag("Boss"))
        {
            TakeDamage(25); // Regra: 25% de dano na colisão (25% de 100 HP)
            
            // Se for Boss, ele não morre. Se for qualquer outra coisa, ele explode.
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