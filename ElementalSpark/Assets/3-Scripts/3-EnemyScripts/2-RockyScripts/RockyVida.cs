using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyVida : MonoBehaviour
{
    public int vidaMaxima = 3;  // Vida m�xima del enemigo
    private int vidaActual;
    private Animator anim;
    public RockyScript rockyScript;

    private void Start()
    {
        vidaActual = vidaMaxima;  // Inicializa la vida actual al m�ximo al empezar
        anim = GetComponent<Animator>();
    }

    public void ReducirVida(int cantidadDeDano)
    {
        vidaActual -= cantidadDeDano;  // Reduce la vida seg�n el da�o recibido
        Debug.Log("Vida del enemigo: " + vidaActual);

        // Si la vida llega a cero o menos, destruye el enemigo
        if (vidaActual <= 0)
        {
            Muerte();
            VariablesEstaticas.barrasDeErgia++;
        }
    }

    private void Muerte()
    {
        anim.SetBool("Dead", true);
        rockyScript.enabled = false;
        StartCoroutine(DesactivarEnemigo());
    }

    private IEnumerator DesactivarEnemigo()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);

    }
}
