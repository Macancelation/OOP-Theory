using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * velocidad * Time.fixedDeltaTime);
    }
}
