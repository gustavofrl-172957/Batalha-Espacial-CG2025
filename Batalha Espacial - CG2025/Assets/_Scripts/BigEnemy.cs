using UnityEngine;

public class BigEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        hp = GameBalance.GetEnemyHP("Big");
        speed = 2f;
        scoreValue = 300;
    }

    protected override void MoveBehaviour()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}