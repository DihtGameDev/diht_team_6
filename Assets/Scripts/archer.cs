using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private float Health = 3;

    private Vector2 velocity;
    [SerializeField] private Rigidbody2D rb;

    void FixedUpdate()
    {
        velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        rb.velocity = velocity;

    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene(""); //загрузить сцену проигрыша

        }
    }
}
