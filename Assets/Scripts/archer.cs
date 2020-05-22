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
    [SerializeField] private LineRenderer line;
    [SerializeField] private float attackRange = 100f;
    [SerializeField] private GameObject arrow;

    private Vector2 velocity;
    private float arrowSpeed = 80f;
    private Vector3 direction;
    private Touch shootTouch;
    private Touch joystickTouch;
    private bool shooted = false;
    private bool touchedAtLeastOnce = false;

    private void PreparingShooting()
    {
        var distanceToCamera = transform.position.z - cam.transform.position.z;
        var mousePos = new Vector3(shootTouch.position.x, shootTouch.position.y, distanceToCamera);
        direction = cam.ScreenToWorldPoint(mousePos) - transform.position;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);
        if (shootTouch.phase == TouchPhase.Ended && !shooted)
        {
            Shoot();
            shooted = true;
        }
        if(shootTouch.phase != TouchPhase.Ended && touchedAtLeastOnce)
        {
            line.SetPosition(1, transform.position + direction.normalized * attackRange);
            shooted = false;
        }
    }

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            if(joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                joystickTouch = Input.GetTouch(0);
            }
            else
            {
                shootTouch = Input.GetTouch(0);
                touchedAtLeastOnce = true;
            }
        }
        else if(Input.touchCount == 2)
        {
            if(joystickTouch.phase == TouchPhase.Moved || joystickTouch.phase == TouchPhase.Stationary)
            {
                shootTouch = Input.GetTouch(1);
                touchedAtLeastOnce = true;
            }
            else if (shootTouch.phase == TouchPhase.Moved || shootTouch.phase == TouchPhase.Stationary)
            {
                joystickTouch = Input.GetTouch(1);
            }
        }

        //к этому моменту разобарлись где какой палец
        PreparingShooting();
    }

    void FixedUpdate()
    {
        velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        rb.velocity = velocity;
    }

    private void Shoot()
    {
        var from = transform.position;
        var ar = Instantiate(arrow, from, transform.rotation);
        var obj = ar.GetComponent<arrow>();
        obj.setStartPosition(from);
        obj.setAttackRange(attackRange);
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
