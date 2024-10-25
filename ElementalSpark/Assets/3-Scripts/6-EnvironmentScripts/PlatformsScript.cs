using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsScript : MonoBehaviour
{
    public Vector3 posicionInicial; // Define la posici�n inicial en el inspector
    public Vector3 posicionFinal;   // Define la posici�n final en el inspector
    public float velocidad = 2f;    // Velocidad de movimiento
    public float tiempoEspera = 2f; // Tiempo en segundos que esperar� en cada posici�n

    private bool moviendoHaciaFinal = true;

    private void Start()
    {
        // Comienza en la posici�n inicial
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
                // Mueve el objeto hacia la posici�n objetivo
                transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
                yield return null;
            }

            // Cambia la direcci�n de movimiento
            moviendoHaciaFinal = !moviendoHaciaFinal;

            // Espera en la posici�n actual
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
