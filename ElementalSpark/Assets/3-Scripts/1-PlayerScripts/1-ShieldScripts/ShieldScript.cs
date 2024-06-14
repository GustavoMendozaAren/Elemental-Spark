using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject energySphere;
    private bool sphereActivated = false;

    private void Update()
    {
        if (sphereActivated)
        {
            energySphere.SetActive(true);
        }
        else 
        {
            energySphere.SetActive(false);
        }
    }

    public void EnergySphereButtonActivated() 
    { 
        sphereActivated = true;
    }
    public void EnergySphereButtonDeactivated()
    {
        sphereActivated = false;
    }

}
