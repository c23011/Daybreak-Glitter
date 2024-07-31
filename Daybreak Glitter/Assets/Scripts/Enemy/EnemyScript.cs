using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemySearchScript enemySearchScript;
    GameObject PlayerObj;
    Rigidbody EnemyRb;

    Vector3 DistancePos;

    void Start()
    {
        EnemyRb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (enemySearchScript.SearchSW == true)
        {
            PlayerObj = enemySearchScript.PlayerObj;
            DistancePos = PlayerObj.transform.position - this.transform.position;
            Debug.Log(DistancePos);
            EnemyRb.velocity = DistancePos;
        }
    }
}
