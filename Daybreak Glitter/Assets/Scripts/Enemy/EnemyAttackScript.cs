using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public float attackDamage;
    PlayerMoveScript PlayerMoveSC; 
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
            PlayerMoveSC.nowPlayerHP -= attackDamage;

            Debug.Log(PlayerMoveSC.nowPlayerHP);
        }
    }
}
