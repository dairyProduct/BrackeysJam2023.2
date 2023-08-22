using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeedDivisor;
    [SerializeField] float dashSpeed;
    [SerializeField] float rotationSpeed;
    float inputHorizontal;
    float inputVertical;
    Vector2 movementInput;
    Rigidbody2D myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(inputHorizontal, inputVertical);
    }


    private void FixedUpdate()
    {
        setPlayerVelocity();
        rotateTowardsInput();
    }


    private void setPlayerVelocity()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {

            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= maxSpeedDivisor;
                inputVertical *= maxSpeedDivisor;
            }
            myRb.velocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
        }

        else
        {
            myRb.velocity = new Vector2(0f, 0f);
        }
    }

    private void rotateTowardsInput()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, movementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
            myRb.MoveRotation(rotation);
        }
    }


}
