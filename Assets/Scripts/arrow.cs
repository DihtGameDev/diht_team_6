using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float attackRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "archer")
        {
            var box = collision.GetComponent<box>();
            if (box != null)
            {
                box.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }

    public void setStartPosition(Vector3 pos)
    {
        startPosition = pos;
    }

    public void setAttackRange(float range)
    {
        attackRange = range;
    }

    private void Update()
    {
        if((startPosition - transform.position).magnitude > attackRange)
        {
            Destroy(gameObject);
        }
    }

}
