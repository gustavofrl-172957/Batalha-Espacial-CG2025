using UnityEngine;

public class BossController : MonoBehaviour
{
    public int hp = 500;
    public int points = 1000;
    public float speed = 3f;
    
    public GameObject projectilePrefab;
    public Transform[] firePoints; // Array para múltiplos canhões
    public GameObject explosionPrefab;

    private bool movingRight = true;

    void Start()
    {
        hp = GameBalance.GetEnemyHP("Boss");
        InvokeRepeating("Shoot", 1f, 1.5f); // Atira a cada 1.5s
    }

    void Update()
    {
        // Movimento lateral 
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > 6f) movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -6f) movingRight = true;
        }
    }

    void Shoot()
    {
        foreach (Transform t in firePoints)
        {
            if(projectilePrefab) Instantiate(projectilePrefab, t.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        // Atualiza barra de vida do Boss (via GameManager)
        if (GameManager.Instance) GameManager.Instance.UpdateBossUI(hp);

        if (hp <= 0) Die();
    }

    void Die()
    {
        GameManager.Instance.RegisterKill("Boss", points); // Vitória!
        if (explosionPrefab) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Projectile2D p = other.GetComponent<Projectile2D>();
            TakeDamage(p != null ? p.damage : 10);
            Destroy(other.gameObject);
        }
    }
}