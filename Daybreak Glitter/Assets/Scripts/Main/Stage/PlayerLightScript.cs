using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightScript : MonoBehaviour
{
    public Light LightIntensity;
    public float Bllightness;
    public float maxBllightness;
    public float minBllightness;

    bool BllightSW;
    void Start()
    {
        
    }

    void Update()
    {
        if (LightIntensity.intensity >= maxBllightness)
        {
            BllightSW = true;
        }

        if (LightIntensity.intensity <= minBllightness)
        {
            BllightSW = false;
        }

        ChangeBllight();
        Destroy(this.gameObject, 5.0f);
    }

    void ChangeBllight()
    {
        if (BllightSW == true)
        {
            LightIntensity.intensity -= Bllightness;
        }

        if (BllightSW == false)
        {
            LightIntensity.intensity += Bllightness;

        }
    }
}
