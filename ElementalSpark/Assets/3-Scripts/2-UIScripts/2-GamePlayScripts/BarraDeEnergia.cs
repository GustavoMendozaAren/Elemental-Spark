using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeEnergia : MonoBehaviour
{
    public GameObject[] barras;
    public GameObject panelPoderEspecial;

    private void Update()
    {
        ActualizarBarrasDeEnergia();
    }

    private void ActualizarBarrasDeEnergia()
    {
        if(VariablesEstaticas.barrasDeErgia == 1)
        {
            barras[0].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 2)
        {
            barras[1].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 3)
        {
            barras[2].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 4)
        {
            barras[3].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 5)
        {
            barras[4].SetActive(true);
            panelPoderEspecial.SetActive(false);
        }
        if (VariablesEstaticas.barrasDeErgia == 6)
        {
            barras[5].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 7)
        {
            barras[6].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 8)
        {
            barras[7].SetActive(true);
        }
        if (VariablesEstaticas.barrasDeErgia == 9)
        {
            barras[9].SetActive(true);
        }
    }

    private void ReiniciarBarrasBarras()
    {
        if (VariablesEstaticas.barrasDeErgia >= 9)
        {
            for (int i = 0; i < barras.Length; i++)
            {
                barras[i].SetActive(false);
            }

            VariablesEstaticas.barrasDeErgia = 0;
        }
    }

    public void UsarPoderEspecialBoton()
    {
        ReiniciarBarrasBarras();
        panelPoderEspecial.SetActive(true);
    }
}
