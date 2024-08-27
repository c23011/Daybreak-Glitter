using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameControllerScript : MonoBehaviour
{
    public int FrameRate;
    void Start()
    {
        Application.targetFrameRate = FrameRate;
    }
}
