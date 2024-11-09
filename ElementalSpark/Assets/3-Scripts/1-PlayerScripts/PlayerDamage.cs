using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    
    public int startHealth = 5;
    private int i;

    public GameObject[] healthBars;
    public GameObject deadPanel;

    private void Start()
    {
        i = healthBars.Length;
    }
    private void DeadFunction() 
    {
        if (i == 0)
        {
            deadPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy") 
        {
            DamageToPlayer();
        }
    }

    private void DamageToPlayer() 
    {
        healthBars[i - 1].SetActive(false);
        i = i - 1;
        DeadFunction();
    }

    public void DamageToPlayerPublic()
    {
        DamageToPlayer();
    }


}
