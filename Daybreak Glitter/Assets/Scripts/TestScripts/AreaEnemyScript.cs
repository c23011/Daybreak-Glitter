using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemyScript : MonoBehaviour
{
    int HP;
    int areaCount;
    AreaTest areaTestSC;
    bool AreaCountSW;

    void Start()
    {
        HP = 1;
        areaCount = 1;
    }

    void Update()
    {
        if (HP <= 0)
        {
            if (AreaCountSW == true)
            {
                areaTestSC.EnemyNum -= 1;
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            HP--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Area")
        {
            areaTestSC = other.gameObject.GetComponent<AreaTest>();
            areaTestSC.EnemyNum += areaCount;
            Debug.Log(areaTestSC.EnemyNum);
            areaCount = 0;
            AreaCountSW = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Area")
        {
            areaCount = 1;
        }
    }
}
