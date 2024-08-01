using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float maxPlayerHP;
    public float nowPlayerHP;
    public Rigidbody PlayerRB;
    public float playerMoveSpeed;
    float playerMoveX;
    float playerMoveZ;
    Vector3 lastVelocity;
    public float maxReflectTime;
    float nowReflectTime;

    public float maxDashTime;
    float nowDashTime;
    public bool MoveSW;
    public bool DashSW;
    public bool ReflectSW;

    GameObject WallObj;

    void Start()
    {
        MoveSW = true;
        nowReflectTime = maxReflectTime;
        nowPlayerHP = maxPlayerHP;
    }

    void Update()
    {
        if (MoveSW == true)
        {
            playerMoveX = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
            playerMoveZ = Input.GetAxisRaw("Vertical") * playerMoveSpeed;
            PlayerRB.velocity = new Vector3(playerMoveX, PlayerRB.velocity.y, playerMoveZ);
        }

        Dash();
        Reflect();
    }

    void FixedUpdate()
    {
        lastVelocity = PlayerRB.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            DashSW = false;
            ReflectSW = true;
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, collision.contacts[0].normal);//反射ベクトル計算
            nowReflectTime = maxReflectTime;
            PlayerRB.velocity = refrectVec;
        }
    }

    void Dash()
    {
        if (DashSW == false && Input.GetKeyDown(KeyCode.Space))
        {
            DashSW = true;
            MoveSW = false;
            Debug.Log("Dash!");
        }

        if (DashSW == true && ReflectSW == false)
        {
            PlayerRB.velocity = new Vector3(playerMoveX * 10, PlayerRB.velocity.y, playerMoveZ * 10);
                
            if (nowDashTime > 0)
            {
                nowDashTime -= Time.deltaTime;
                if (nowDashTime <= 0)
                {
                    DashSW = false;
                }
            }
        }

        if (DashSW == false && ReflectSW == false)
        {
            nowDashTime = maxDashTime;
            MoveSW = true;
        }
    }

    void Reflect()
    {
        if (ReflectSW == true)
        {
            DashSW = false;

            if (nowReflectTime > 0)
            {
                nowReflectTime -= Time.deltaTime;
                Debug.Log(nowReflectTime);
                if (nowReflectTime <= 0)
                {
                    Debug.Log("bhefsdi");
                    ReflectSW = false;
                    nowReflectTime = maxReflectTime;
                }
            }
        }
    }
}
