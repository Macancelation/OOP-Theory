using System.Collections;
using UnityEngine;


public class Boos : Enemigo
{
    public GameObject[] municiones;
    public Transform[] cañones;
    protected override void MyStart()
    {
        InvokeRepeating("Bala", 5, 1);
        InvokeRepeating("Bala1", 5, 1);
        InvokeRepeating("Bala2", 5, 2);
    }

    void Bala()
    {
        Instantiate(municiones[0], cañones[0].position, municiones[0].transform.rotation);
    }
    void Bala1()
    {
        Instantiate(municiones[1], cañones[1].position, municiones[1].transform.rotation);
    }
    void Bala2()
    {
        Instantiate(municiones[2], cañones[2].position, municiones[2].transform.rotation);
    }
}
