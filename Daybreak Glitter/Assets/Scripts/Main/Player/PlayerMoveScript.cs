using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{   
    public Rigidbody PlayerRB;
    public float maxPlayerHP;
    public float nowPlayerHP;
    public float playerMoveSpeed;
    public float playerDashSpeed;

    public float maxDashTime;
    float nowDashTime;
    public bool MoveSW;
    public bool DashSW;
    public bool ReflectSW;

    Vector3 lastVelocity;
    public float maxReflectTime;
    float nowReflectTime;

    public GameObject InstLightPrefab;
    public Vector3 LightDirectionPos;
    Transform LightInstPos;
    GameObject NowInstLight;
    float lightInstTimer;
    public float maxLightInstTime;
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
            if (Input.GetKey(KeyCode.W))
            {
                PlayerRB.velocity = transform.forward * playerMoveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                PlayerRB.velocity = -transform.forward * playerMoveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                PlayerRB.velocity = transform.right * playerMoveSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerRB.velocity = -transform.right * playerMoveSpeed;
            }
        }

        Dash();
        Reflect();

        lightInstTimer += Time.deltaTime;
        LightInstPos = this.transform;
        if (lightInstTimer >= maxLightInstTime)
        {
            LightInstPos.transform.position += LightDirectionPos;
            NowInstLight = Instantiate(InstLightPrefab,LightInstPos);
            LightInstPos.transform.position -= LightDirectionPos;
            NowInstLight.transform.parent = null;
            lightInstTimer = 0;
        }
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
        }

        if (DashSW == true && ReflectSW == false)
        {
            PlayerRB.velocity = transform.forward * playerDashSpeed;
            PlayerRB.constraints = RigidbodyConstraints.FreezeRotationY;
            if (nowDashTime > 0)
            {
                nowDashTime -= Time.deltaTime;
                if (nowDashTime <= 0)
                {
                    PlayerRB.constraints = RigidbodyConstraints.None;
                    PlayerRB.constraints = RigidbodyConstraints.FreezeRotationZ;
                    PlayerRB.constraints = RigidbodyConstraints.FreezeRotationX;

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
                if (nowReflectTime <= 0)
                {
                    MoveSW = true;
                    ReflectSW = false;
                    nowReflectTime = maxReflectTime;
                }
            }
        }
    }
}
