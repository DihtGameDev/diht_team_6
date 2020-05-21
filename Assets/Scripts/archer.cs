using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed = 30f;
    private Vector2 velocity;
    [SerializeField] private Rigidbody2D rb;

    void FixedUpdate()
    {
        velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        rb.velocity = velocity;

    }
}
