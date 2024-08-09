using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerRensa : MonoBehaviour
{
    public GameObject Player;
    public GameObject Shotpos;

    public PlayerMoveScript playermoveSC;

    //ÉiÉCÉtån
    public GameObject knife;
    public GameObject ShotPos;
    public float knifeSpeed;



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rensa"))
        {
            Shotpos.transform.LookAt(other.transform.position);
            GameObject newknife = Instantiate(knife, ShotPos.transform.position, Quaternion.identity);
            Rigidbody knifeRB = newknife.GetComponent<Rigidbody>();
            knifeRB.AddForce(Shotpos.transform.forward * knifeSpeed);
            Destroy(this, 0.5f);
            //Player.transform.position = other.transform.position;
        }
    }
}
