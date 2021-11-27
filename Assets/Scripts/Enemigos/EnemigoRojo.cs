using UnityEngine;


public class EnemigoRojo : Enemigo
{
    float secuencia;
    Transform player;
    public float tiempo;
    protected override void MyStart()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void MyFixedUpdate()
    {
        Vector3 target = (player.position - transform.position).normalized;
        MoverEnemigo(target, tiempo);
    }

    void MoverEnemigo(Vector3 a, float tiempo)
    {
        secuencia += Time.fixedDeltaTime;
        MoverEnemigo(a);
        if (secuencia >= tiempo) Destroy(gameObject);
    }
}
