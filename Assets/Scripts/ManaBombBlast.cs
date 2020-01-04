using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBombBlast : MonoBehaviour
{
    public int damage = 3;

    private void Start()
    {
        Invoke("Die", 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("!" + other.transform);
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
