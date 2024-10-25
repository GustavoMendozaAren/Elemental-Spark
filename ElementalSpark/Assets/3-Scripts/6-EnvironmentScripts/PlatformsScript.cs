using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsScript : MonoBehaviour
{
    public Vector3 posicionInicial; // Define la posición inicial en el inspector
    public Vector3 posicionFinal;   // Define la posición final en el inspector
    public float velocidad = 2f;    // Velocidad de movimiento
    public float tiempoEspera = 2f; // Tiempo en segundos que esperará en cada posición

    private bool moviendoHaciaFinal = true;

    private void Start()
    {
        // Comienza en la posición inicial
        transform.position = posicionInicial;
        StartCoroutine(MoverEntrePosiciones());
    }

    private IEnumerator MoverEntrePosiciones()
    {
        while (true)
        {
            Vector3 objetivo = moviendoHaciaFinal ? posicionFinal : posicionInicial;
            while (Vector3.Distance(transform.position, objetivo) > 0.01f)
            {
                // Mueve el objeto hacia la posición objetivo
                transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
                yield return null;
            }

            // Cambia la dirección de movimiento
            moviendoHaciaFinal = !moviendoHaciaFinal;

            // Espera en la posición actual
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
