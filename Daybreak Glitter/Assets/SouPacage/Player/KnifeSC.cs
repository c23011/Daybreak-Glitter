using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeSC : MonoBehaviour
{
    //íeån
    public GameObject Knife;
    public GameObject Player;

    public Rigidbody KnifeRB;
    public MeshRenderer KnifeMesh;


    //SEån

    //ÉGÉtÉFÉNÉgån
    public GameObject ModoPos;
    //public GameObject Trail;


    public AudioClip Attack1;
    public AudioClip Attack2;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("Player");
        KnifeRB = GetComponent<Rigidbody>();
        KnifeMesh = GetComponent<MeshRenderer>();
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
            GameObject Camera = GameObject.Find("Main Camera");
            Camera.transform.parent = null;
            Vector3 hitPos = other.contacts[0].point;
            Player.transform.position = new Vector3(hitPos.x, 1, hitPos.z);

            //Ç§ÇÈÇ≥Ç∑Ç¨å„Ç≈ïtÇØÇÈ  audioSource.PlayOneShot(Attack1);
            //  audioSource.PlayOneShot(Attack2);
          
            Invoke("CameraTuiju", 1);
        }   
    }

    void CameraTuiju()
    {
        GameObject Camera = GameObject.Find("Main Camera");
        Camera.transform.parent = Player.transform;
        GameObject ModoPos = GameObject.Find("ModoPos");
        Camera.transform.position = ModoPos.transform.position;
        Camera.transform.rotation = ModoPos.transform.rotation;
    }
    /* void trailfalse()
     {
         Trail.SetActive(false);
     }*/
}
