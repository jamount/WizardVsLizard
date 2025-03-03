﻿using UnityEngine;
public class EnergyBlastBullet : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    public int damage = 1;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
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
