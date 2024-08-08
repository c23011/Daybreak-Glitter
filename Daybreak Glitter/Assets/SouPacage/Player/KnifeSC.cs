using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeSC : MonoBehaviour
{
    //�e�n
    public GameObject Knife;
    public GameObject Player;

    //SE�n

    //�G�t�F�N�g�n
   // public GameObject Trail;


    public AudioClip Attack1;
    public AudioClip Attack2;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
           // Instantiate(Trail);
          //  Trail.SetActive(true);
            Vector3 hitPos = other.contacts[0].point;
            Player.transform.position = new Vector3(hitPos.x, 1, hitPos.z);
            //Invoke("trailfalse", 1);

            //���邳������ŕt����  audioSource.PlayOneShot(Attack1);
            //  audioSource.PlayOneShot(Attack2);


            Destroy(this.gameObject);
        }
    }
   /* void trailfalse()
    {
        Trail.SetActive(false);
    }*/
}
