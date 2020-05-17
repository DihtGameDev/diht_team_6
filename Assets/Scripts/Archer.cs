using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer : MonoBehaviour
{
    public Joystick joystick;
    protected float speed = 30f;
    protected  Vector2 velocity;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        rb.velocity = velocity;

    }
}
