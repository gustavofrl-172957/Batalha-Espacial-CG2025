using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 8f;
    
    // Limites da tela
    public float xMin = -8f, xMax = 8f, yMin = -4.5f, yMax = 4.5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Setas ou A/D
        float moveY = Input.GetAxis("Vertical");   // Setas ou W/S

        Vector3 movement = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Mantém o jogador dentro da tela
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(newX, newY, 0);
    }
}