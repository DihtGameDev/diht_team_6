using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "archer")
        {
            Debug.Log("name = " + collision.name);
            var box = collision.GetComponent<box>();
            if (box != null)
            {
                box.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }

}
