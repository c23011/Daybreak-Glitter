using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public int maxAttackCount;
    public int nowAttackCount;
    public int lastAttackCount;
    public float maxAttackDistanceTime;
    public float nowAttackTime;

    public GameObject[] Attacks;
    public bool AttackSW;
    void Start()
    {
        
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (AttackSW == true)
        {
            nowAttackTime += Time.deltaTime;

            if (nowAttackTime < maxAttackDistanceTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (nowAttackCount < maxAttackCount)
                    {
                        nowAttackCount++;
                        nowAttackTime = 0.0f;
                        Attacks[nowAttackCount].SetActive(true);
                        Attacks[lastAttackCount].SetActive(false);
                        lastAttackCount = nowAttackCount;
                    }
                }
            }

            AttackEnd();
        }

        if (AttackSW == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nowAttackCount++;
                Attacks[nowAttackCount].SetActive(true);
                lastAttackCount = nowAttackCount;
                AttackSW = true;
            }
        }
    }

    void AttackEnd()
    {
        if (nowAttackTime >= maxAttackDistanceTime)
        {
            Attacks[lastAttackCount].SetActive(false);
            AttackSW = false;
            nowAttackCount = 0;
            lastAttackCount = 0;

            nowAttackTime = 0.0f;
        }
    }
}
