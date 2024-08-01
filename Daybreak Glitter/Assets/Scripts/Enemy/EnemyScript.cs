using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemySearchScript enemySearchScript;
    public float enemyMoveSpeed;
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
            DistancePos *= enemyMoveSpeed;
            DistancePosCalculation();
            Debug.Log(DistancePos);
            EnemyRb.velocity = DistancePos;
        }
    }

    void DistancePosCalculation()
    {
        DistancePos.y = 0;

        if (DistancePos.x >= 1.0f)
        {
            DistancePos.x = 1.0f * enemyMoveSpeed;
        }

        if (DistancePos.x <= -1.0f)
        {
            DistancePos.x = -1.0f * enemyMoveSpeed;
        }

        if (DistancePos.z >= 1.0f)
        {
            DistancePos.z = 1.0f * enemyMoveSpeed;
        }

        if (DistancePos.z <= -1.0f)
        {
            DistancePos.z = -1.0f * enemyMoveSpeed;
        }
    }
}
