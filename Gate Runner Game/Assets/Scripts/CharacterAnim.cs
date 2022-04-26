using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    public static Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ramp")
        {
            Anim.SetTrigger("IsJumping");
        }
        if (collision.collider.tag == "Ground")
        {
            Anim.SetTrigger("IsRolling");
        }
        if (collision.collider.tag == "Obstacle")
        {
            Anim.SetTrigger("Dead");
        }
    }

}