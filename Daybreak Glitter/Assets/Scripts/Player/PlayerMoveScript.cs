using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public float playerMoveSpeed;
    float playerMoveX;
    float playerMoveZ;
    Vector3 lastVelocity;
    bool ReflectSW;

    public float dashTime;
    public bool MoveSW;
    public bool DashSW;
    void Start()
    {
        MoveSW = true;
    }

    void Update()
    {
        if (MoveSW == true)
        {
            playerMoveX = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
            playerMoveZ = Input.GetAxisRaw("Vertical") * playerMoveSpeed;

            PlayerRB.velocity = new Vector3(playerMoveX, 0.0f, playerMoveZ);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                DashSW = true;
                MoveSW = false;
                Debug.Log("Dash!");
            }
        }

        if (DashSW == true)
        {
            PlayerRB.velocity = new Vector3(playerMoveX*10, 0.0f, playerMoveZ*10);
            Invoke("falseSW",dashTime);
        }
    }

    void falseSW()
    {
        DashSW = false;
        MoveSW = true;
    }

    void FixedUpdate()
    {
        lastVelocity = PlayerRB.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            ReflectSW = true;
        }

        if (ReflectSW == true)
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, collision.contacts[0].normal);//反射ベクトル計算
            PlayerRB.velocity = refrectVec;
            Debug.Log(refrectVec);
        }

        DashSW = false;
    }
}
