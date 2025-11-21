using UnityEngine;

public class PlayerShooting2D : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) // Fire1 é Ctrl ou Clique
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        if(shootSound && audioSource) audioSource.PlayOneShot(shootSound);
    }
}