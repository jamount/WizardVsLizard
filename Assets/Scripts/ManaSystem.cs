using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManaSystem : MonoBehaviour
{
    public float mana;
    public float maxMana;



    public OnDamagedEvent onUseMana;
    
    

 

    public void TakeMana(int cost)
    {
        if (mana >= cost)
        {
            mana -= cost;
            onUseMana.Invoke(Convert.ToInt32(mana));
        }


    }
    public void RegenMana(int regenRate)
    {
        if (mana <= maxMana)
        {
            mana += regenRate * Time.deltaTime;
            onUseMana.Invoke(Convert.ToInt32(mana));
        }
    }
}
    
