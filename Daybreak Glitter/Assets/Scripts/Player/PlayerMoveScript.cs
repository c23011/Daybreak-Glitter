using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public float playerMoveSpeed;
    float playerMoveX;
    float playerMoveZ;
    void Start()
    {
        
    }

    void Update()
    {
        playerMoveX = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
        playerMoveZ = Input.GetAxisRaw("Vertical")   * playerMoveSpeed;

        PlayerRB.AddForce(playerMoveX, 0.0f, playerMoveZ);
        PlayerRB.velocity = new Vector3(playerMoveX,-1.5f, playerMoveZ);
    }
}
