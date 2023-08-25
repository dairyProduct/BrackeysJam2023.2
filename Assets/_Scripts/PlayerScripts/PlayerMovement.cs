using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeedDivisor;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashTime = .1f;
    public float dashCD = .5f;
    [SerializeField] float rotationSpeed;
    Vector2 movement;
    public Transform holder;
    Rigidbody2D myRb;
    public TrailRenderer trailRenderer;

    bool dashing;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if(Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Dash());
        }
    }


    private void FixedUpdate()
    {
        if(dashing) return;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        myRb.velocity = movement * speed;
        //myRb.velocity = ((-holder.right * movement.y) + (holder.up * movement.x)) * speed;
    }

    IEnumerator Dash() {
        dashing = true;
        trailRenderer.enabled = true;
        myRb.velocity = movement * dashSpeed;
        yield return new WaitForSeconds(dashTime);
        trailRenderer.enabled = false;
        dashing = false;
    }


}
