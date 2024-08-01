using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject AttackObj;
    public EnemySearchScript enemySearchScript;
    public float enemyMoveSpeed;
    public float attackDistance;
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

            if (DistancePos.x <= Mathf.Abs(attackDistance) && DistancePos.z <= Mathf.Abs(attackDistance))
            {
                AttackObj.SetActive(true);
            }

            DistancePos *= enemyMoveSpeed;
            DistancePosCalculation();
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

    void AttackEnd()
    {
        AttackObj.SetActive(false);
    }
}
