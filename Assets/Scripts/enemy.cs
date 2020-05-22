using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 60;
    [SerializeField] private float speedToChangeDirection = 30;
    [SerializeField] private float Health = 2;


    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody != null && collision.rigidbody.tag == "Player")
        {
            Debug.Log("damage to archer");
            var archer = collision.rigidbody.GetComponent<archer>();
            if (archer != null)
            {
                archer.TakeDamage(1);
            }
        }
    }


    void Update()
    {
        if(rb.velocity.magnitude <= speedToChangeDirection)
        {
            var direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            direction.x *= speed;
            direction.y *= speed;
            rb.velocity = direction;
        }
    }
}
