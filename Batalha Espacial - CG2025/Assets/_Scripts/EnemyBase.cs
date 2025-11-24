using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Configurações")]
    public int hp = 10;
    public int points = 100;
    public float speed = 3f;
    public bool isAsteroid = false; // Marque TRUE no prefab do Asteroide

    [Header("Ataque")]
    public GameObject projectilePrefab; // Arraste o TiroInimigo
    public Transform firePoint;         // Ponto de saida do tiro
    public float fireRate = 2f;
    private float nextFireTime;
    public bool canShoot = false;       // GameManager define isso

    [Header("Efeitos")]
    public GameObject explosionPrefab;

    private Vector3 moveDirection;

    void Start()
    {
        // 1. Configura HP Baseado na Tag (Usando as novas Tags)
        if (!isAsteroid)
        {
            string type = gameObject.tag == "EnemyBig" ? "Big" : "Small"; 
            hp = GameBalance.GetEnemyHP(type);

            // 2. Aumenta Velocidade na Dificuldade/Fase
            float levelSpeedBonus = (GameSettings.SelectedLevel - 1) * 0.5f;
            speed += levelSpeedBonus; 
            
            if (GameSettings.SelectedDifficulty == GameSettings.Difficulty.Dificil)
                speed *= 1.2f;
        }

        // Define direção inicial:
        // Acha o player para calcular uma trajetória diagonal inicial
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && !isAsteroid)
        {
            // Calcula vetor direção apenas uma vez (não persegue, apenas mira)
            Vector3 direction = (player.transform.position - transform.position).normalized;
            // Adiciona variação para não ser perfeito
            moveDirection = direction + new Vector3(Random.Range(-0.2f, 0.2f), 0, 0);
        }
        else
        {
            moveDirection = Vector3.down; // Desce reto se for asteroide ou player sumiu
        }
    }

    void Update()
    {
        // Movimento
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotação do Asteroide
        if (isAsteroid) transform.Rotate(0, 0, 50 * Time.deltaTime);

        // Tiro
        if (canShoot && !isAsteroid && Time.time > nextFireTime)
        {
            Shoot();
        }

        // Limpeza de Memória (Se sair da tela)
        if (Mathf.Abs(transform.position.y) > 10f || Mathf.Abs(transform.position.x) > 12f)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if(projectilePrefab && firePoint)
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0) Die();
    }

    public void Die()
    {
        if (GameManager.Instance != null)
        {
            string typeToRegister = isAsteroid ? "Asteroid" : gameObject.tag;
            GameManager.Instance.RegisterKill(typeToRegister, points);
        }

        if (explosionPrefab) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Colisão com o TIRO DO JOGADOR
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TiroPlayer"))
        {
            Projectile2D p = other.GetComponent<Projectile2D>();
            TakeDamage(p != null ? p.damage : 10);
            Destroy(other.gameObject);
        }
    }
}