using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCambioDireccion : MonoBehaviour
{
    public RockyScript rockyS;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rockyS.CambiardireccionPublico();
        }
        if (collision.CompareTag("Enemy"))
        {
            rockyS.CambiardireccionPublico();
        }
    }
}
