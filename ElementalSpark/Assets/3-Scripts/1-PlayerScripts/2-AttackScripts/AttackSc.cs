using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSc : MonoBehaviour
{
    public Collider2D _collision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision = _collision;
        if (_collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Attacked");
        }

    }
}
