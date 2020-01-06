using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }
public class HealthSystem : MonoBehaviour
{
    public float health = 100;
    public float maxHealth;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;
    public void TakeDamage(int damage)
    {
        health -= damage;
        onDamaged.Invoke(Convert.ToInt32(health));
        if (health < 1)
        {
            onDie.Invoke();
        }
    }
    public void RegenHealth(int regenRate)
    {

            health += regenRate * Time.deltaTime;
        if(health > 100)
        {
            health = 100;
        }
        onDamaged.Invoke(Convert.ToInt32(health));
        
        
    }
}