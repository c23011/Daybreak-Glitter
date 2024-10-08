using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchScript : MonoBehaviour
{
    public GameObject PlayerObj;
    public GameObject EnemyObj;

    public bool SearchSW;
    void Start()
    {
        
    }

    void Update()
    {
        if (SearchSW == true)
        {
            EnemyObj.transform.LookAt(PlayerObj.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerObj = other.gameObject;

            SearchSW = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SearchSW = false;
        }
    }
}
