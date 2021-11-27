using UnityEngine;


public class EnemigoVerde : Enemigo
{
    Transform player;
    Vector3 target;
    protected override void MyStart()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position - transform.position;
    }
    protected override void MyFixedUpdate()
    {
        MoverEnemigo(target.normalized);
    }
}
