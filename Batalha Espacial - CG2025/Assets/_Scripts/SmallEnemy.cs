using UnityEngine;

public class SmallEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        // Pega HP da tabela de balanceamento
        hp = GameBalance.GetEnemyHP("Small"); 
        speed = 4f; // Velocidade base
    }

    protected override void MoveBehaviour()
    {
        // Desce em linha reta
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}