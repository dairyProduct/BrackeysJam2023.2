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
    Vector2 movement;
    public Transform direction;
    Rigidbody2D myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }


    private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        myRb.velocity = (transform.up * movement.y + transform.right * movement.x) * speed;
        //myRb.velocity = ((direction * movement.y) + (Vector2)(transform.right * movement.x)) * speed;
    }


}
