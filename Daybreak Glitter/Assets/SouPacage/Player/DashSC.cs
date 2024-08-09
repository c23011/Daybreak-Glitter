using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSC : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody PlayerRB;
    [SerializeField]float DashSP;   
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerRB.AddForce(transform.forward * DashSP);
            Invoke("Stop", 0.2f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            PlayerRB.velocity = Vector3.zero;
            PlayerRB.AddForce(-transform.forward * 500);
        }
    }

    void Stop()
    {
        PlayerRB.velocity = Vector3.zero;
    }
}
