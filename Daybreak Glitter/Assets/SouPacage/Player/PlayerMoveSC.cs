using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSC : MonoBehaviour
{
    //�v���C���[�n
    public GameObject Player;
    [SerializeField] Rigidbody PlayerRB;
    [SerializeField] float PlayerSpeed;

    //�G�t�F�N�g�n



    //��ѓ���n
    public GameObject knife;
    public GameObject KnifeRethicle;
    public float knifeSpeed;
    public GameObject ShotPos;

    //SE�n
    public AudioClip Tobi;
    AudioSource audioSource;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        /* if (Input.GetMouseButtonDown(1))
         {
             KnifeRethicle.SetActive(true);
         }*/
        if (Input.GetMouseButtonUp(1))
        {
            TobiAtack();
            audioSource.PlayOneShot(Tobi);
            //KnifeRethicle.SetActive(false);
        }
    }
    public void TobiAtack()
    {
        GameObject newknife = Instantiate(knife, ShotPos.transform.position, Quaternion.identity);
        Rigidbody knifeRB = newknife.GetComponent<Rigidbody>();
        knifeRB.AddForce(this.transform.forward * knifeSpeed);
        Destroy(newknife, 3);
    }


}
