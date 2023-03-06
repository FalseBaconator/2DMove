using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Animator anim;
    public Collider2D col;
    public Rigidbody2D rb;

    public float speedMin;
    public float speed;

    Vector2 Dir;
    float mag;

    float lastX;
    float lastY;
    float X;
    float Y;

    // Update is called once per frame
    void Update()
    {

        Dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mag = Mathf.Clamp(Dir.magnitude, 0.0f, 1.0f);
        Dir.Normalize();
        rb.velocity = Dir * mag * speed * Time.deltaTime;
        anim.SetFloat("X", Dir.x);
        anim.SetFloat("Y", Dir.y);
        anim.SetFloat("Speed", mag);

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            rb.velocity = new Vector2(0, 0);
        }

        if(Mathf.Abs(rb.velocity.x) >= speedMin || Mathf.Abs(rb.velocity.y) >= speedMin)
        {
            anim.SetFloat("LastX", anim.GetFloat("X"));
            anim.SetFloat("LastY", anim.GetFloat("Y"));
        }
    }
}
