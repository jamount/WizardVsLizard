using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBombBullet : MonoBehaviour
{
    public float moveSpeed = 70.0f;
    //public int damage = 3;

    public GameObject blast;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(blast, transform.position, transform.rotation);
        //other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Die();

    }
    private void OnBecameInvisible()
    {
        Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

