using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapData : MonoBehaviour
{
    public Material mat;
    public int soap_particle_count;
    public int soap_particle_total;

    private void Start()
    {
        soap_particle_total = soap_particle_count;
    }
}
