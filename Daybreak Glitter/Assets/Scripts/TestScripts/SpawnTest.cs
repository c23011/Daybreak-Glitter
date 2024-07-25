using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public GameObject TestEnemy;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(TestEnemy,
                        new Vector3(TestEnemy.transform.position.x,
                                    3.0f,
                                    TestEnemy.transform.position.z),
                        Quaternion.identity);
        }
    }
}
