using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoCaida : MonoBehaviour
{
    public float fallDamageThreshold = 5f;  // Velocidad de caída para aplicar daño
    private bool isFalling = false;
    private float fallStartY;

    public PlayerDamage playerD;

    private void Update()
    {
        // Detectar si el personaje está cayendo
        if (GetComponent<Rigidbody2D>().velocity.y < 0 && !isFalling)
        {
            isFalling = true;
            fallStartY = transform.position.y;
        }

        // Cuando aterriza, calcular el daño
        if (isFalling && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            float fallDistance = fallStartY - transform.position.y;
            if (fallDistance > fallDamageThreshold)
            {
                ApplyDamage();
            }
            isFalling = false;
        }
    }

    void ApplyDamage()
    {
        playerD.DamageToPlayerPublic();
    }
}
