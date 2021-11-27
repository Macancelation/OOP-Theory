using UnityEngine;


public class EnemigoAmarillo : Enemigo
{
    protected override void MyFixedUpdate()
    {
        MoverEnemigo(Vector3.left);
    }
}
