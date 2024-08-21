using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemyScript : MonoBehaviour
{
    int HP;
    int areaCount;
    public AreaTest areaTestSC;
    bool AreaCountSW;
    public int AreaIn;//0¨–¢N“ü 1¨N“ü 2¨N“üŒvZÏ

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

        if (AreaIn == 1)
        {
            areaTestSC.EnemyNum += areaCount;
            areaCount = 0;
            AreaCountSW = true;
            AreaIn = 2;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            HP--;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Area")
        {
            areaTestSC = other.gameObject.GetComponent<AreaTest>();

            if (AreaIn == 0)
            {
                AreaIn = 1;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Area")
        {
            areaCount = 1;
            AreaIn = 0;
        }
    }
}
