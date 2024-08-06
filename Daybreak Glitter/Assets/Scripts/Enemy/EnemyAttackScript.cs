using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public float attackDamage;
    PlayerMoveScript PlayerMoveSC;
    bool DamageSW;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMoveSC = other.GetComponent<PlayerMoveScript>();
            if (DamageSW == false)
            {
                PlayerMoveSC.nowPlayerHP -= attackDamage;
                DamageSW = true;
            }
        }
    }
}
