using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    [SerializeField] float playerDashSpeed;
    float inputHorizontal;
    float inputVertical;
    Rigidbody2D myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= playerSpeedMax;
                inputVertical *= playerSpeedMax;
            }
            myRb.velocity = new Vector2(inputHorizontal * playerSpeed, inputVertical * playerSpeed);
        }

        else
        {
            myRb.velocity = new Vector2 (0f, 0f);
        }
    }


}
