using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public int damage = 10;
    public bool isEnemyShot = false; // Se true, machuca o player. Se false, machuca inimigo.

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destrói depois de X segundos para não pesar o jogo
    }

    void Update()
    {
        // Move para cima (Player) ou para baixo (Inimigo)
        Vector3 direction = isEnemyShot ? Vector3.down : Vector3.up;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Apenas destroi o tiro ao bater em algo "sólido"
        if(!other.CompareTag("Background")) // Ignora colisão com fundo
        {
             // O objeto que levou o tiro cuidará de tomar dano
        }
    }
}