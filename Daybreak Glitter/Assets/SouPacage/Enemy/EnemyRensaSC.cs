using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRensaSC : MonoBehaviour
{
    public GameObject RensaPos;
    public GameObject RensaCollider;
 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            RensaPos.SetActive(true);
            RensaCollider.SetActive(false);
        }
    }
}
