using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject AttackObj;
    public EnemySearchScript enemySearchScript;
    public float enemyMoveSpeed;
    public float attackDistance;
    public float attackEndTime;
    public float countTimer;
    public bool MoveSW;
    public bool AttackSW;
    GameObject PlayerObj;
    Rigidbody EnemyRb;

    Vector3 DistancePos;

    void Start()
    {
        EnemyRb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveSWChange();

        if (MoveSW == true)
        {
            PlayerObj = enemySearchScript.PlayerObj;
            DistancePos = PlayerObj.transform.position - this.transform.position;

            EnemyRb.constraints = RigidbodyConstraints.None;
            EnemyRb.constraints = RigidbodyConstraints.FreezeRotationX;
            EnemyRb.constraints = RigidbodyConstraints.FreezeRotationZ;

            if (Mathf.Abs(DistancePos.x) <= attackDistance && Mathf.Abs(DistancePos.z) <= attackDistance)
            {
                AttackSW = true;
                MoveSW = false;
                Attack();
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
        AttackSW = false;
        countTimer = 0.0f;
        AttackObj.SetActive(false);
        MoveSW = true;
    }

    void Attack()
    {
        if (AttackSW == true)
        {
            EnemyRb.constraints = RigidbodyConstraints.FreezeAll;
            AttackObj.SetActive(true);
        }

        if (countTimer < attackEndTime)
        {
            countTimer += Time.deltaTime;
        }
        else
        {
            AttackEnd();
        }
    }

    void MoveSWChange()
    {
        if (enemySearchScript.SearchSW == true)
        {
            MoveSW = true;
        }

        if (enemySearchScript.SearchSW == false)
        {
            MoveSW = false;
        }
    }
}
