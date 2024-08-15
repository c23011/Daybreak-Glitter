using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeTextureScript : MonoBehaviour
{
    public Material TestMaterial;
    public Texture TestTexture;
    void Start()
    {
        TestMaterial = this.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        TestMaterial.mainTexture = TestTexture;
    }
}
