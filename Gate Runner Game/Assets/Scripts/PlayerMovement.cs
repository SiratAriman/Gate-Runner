using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed;
    [SerializeField] private float SideSpeed;
    private Transform Player;
    private Rigidbody Rb;
    [SerializeField] private float JumpForce;
    private void Start()
    {
        Player = transform;
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(ForwardSpeed * Time.deltaTime * Vector3.forward);
        
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < LevelBoundry.RightBoundry)
            {
                transform.Translate(SideSpeed * Time.deltaTime * Vector3.right);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > LevelBoundry.LeftBoundry)
            {
                transform.Translate(SideSpeed * Time.deltaTime * Vector3.left);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ramp")
        {
            Rb.AddForce(JumpForce * Vector3.up);
        }
        if (collision.collider.tag == "Obstacle")
        {
            Dead();
        }
    }
    public void Dead()
    {
        this.enabled = false;
    }
}