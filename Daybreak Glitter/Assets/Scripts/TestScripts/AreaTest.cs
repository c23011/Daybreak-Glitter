using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTest : MonoBehaviour
{
    public GameObject[] Enemys;
    public int EnemyNum;
    public bool ClearSW;
    public int clearReleaseEnemyCount;
    void Start()
    {
        EnemyNum = 0;
        ClearSW = false;
    }

    void Update()
    {
        Invoke("AreaClear",0.1f);
        if (EnemyNum < 0)
        {
            EnemyNum = 0;
        }
    }

    void AreaClear()
    {
        if (EnemyNum <= 0)
        {
            if (ClearSW == false)
            {
                ClearSW = true;
            }
        }

        if (ClearSW == true)
        {
            if (EnemyNum >= clearReleaseEnemyCount)
            {
                ClearSW = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyNum--;
        }
    }
}
