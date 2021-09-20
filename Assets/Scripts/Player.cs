using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float playerSize = 1;



    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetKeyDown("space") && groundedPlayer)
        {
            playerVelocity.y = 0;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log(playerVelocity.y);
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime;          
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void UpgradeStats(float speed = 0 , float jump = 0, float size = 0)
    {
        playerSpeed += speed;
        jumpHeight += jump;
        playerSize += size;

        if (jumpHeight <= 0)
        {
            jumpHeight = 1;
        }
        if (playerSpeed <= 0)
        {
            playerSpeed = 1;
        }

        if (playerSize <= 0)
        {
            playerSize = 1;
        }


        if (size != 0)
        {
            this.gameObject.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
        }
        

    }

}