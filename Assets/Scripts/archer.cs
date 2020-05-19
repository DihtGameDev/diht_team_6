using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class archer : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed = 30f;
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 velocity;
    private float arrowSpeed = 50f;
    public Vector3 direction;
    public Vector3 mousePos;
    public GameObject arrow;
    

    void FixedUpdate()
    {
        velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        rb.velocity = velocity;

        if (Input.GetMouseButtonUp(0))
        {
            var distanceToCamera = transform.position.z - cam.transform.position.z;
            mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera);
            direction = cam.ScreenToWorldPoint(mousePos) - transform.position;
            Shoot();
        }
    }

    private void Shoot()
    {
        var from = transform.position;
        var ar = Instantiate(arrow, from, transform.rotation);
        var arrowRb = ar.GetComponent<Rigidbody2D>();
        arrowRb.velocity = direction.normalized * arrowSpeed;
        var angle = Vector3.Angle(Vector3.right, direction);
        if(direction.y < 0)
        {
            angle = -1 * angle;
        }
        arrowRb.transform.Rotate(Vector3.forward, angle);
    }
}
