using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    float x, z;
    float speed = 0.3f;
    [SerializeField] float LimitSpeed; //プレイヤーの速度制限

    public GameObject cam;
    Quaternion cameraRot, characterRot;

    public Rigidbody PlayerRB;
    public float PlayerSP;
    //float Xsensityvity = 3f;// Ysensityvity = 3f;

    bool cursorLock = true;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    // Start is called before the first frame update

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X");// * Ysensityvity;


        characterRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;


        UpdateCursorLock();

        if (Input.GetKey(KeyCode.W))
        {
            PlayerRB.AddForce(transform.forward * PlayerSP);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerRB.AddForce(-transform.forward * PlayerSP);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerRB.AddForce(transform.right * PlayerSP);
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerRB.AddForce(-transform.right * PlayerSP);
        }
        if (PlayerRB.velocity.magnitude > LimitSpeed)
        {
            PlayerRB.velocity = new Vector3(PlayerRB.velocity.x / 1.1f, PlayerRB.velocity.y, PlayerRB.velocity.z / 1.1f);
        }

        if (!Input.anyKey)　//プレイヤーが移動をやめたらいい感じに止まるようにする
        {
            LimitSpeed = 10;
        }
        else
        {
            LimitSpeed = 30;
        }
    }


    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 1f);

        return q;
    }
}