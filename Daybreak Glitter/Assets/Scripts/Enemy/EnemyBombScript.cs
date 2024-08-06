using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombScript : MonoBehaviour
{
    //このスクリプトは爆発の攻撃判定にアタッチする
    public GameObject MyEnemy;
    public float boomTime;
    void Start()
    {
        Invoke("Boom",boomTime);
    }

    void Boom()
    {
        Destroy(MyEnemy);
    }
}
