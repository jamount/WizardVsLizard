using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManaSystem : MonoBehaviour
{
    public float mana;




    public OnDamagedEvent onUseMana;
    

 

    public void TakeMana(int cost)
    {
        if (mana >= cost)
        {
            mana -= cost;
            onUseMana.Invoke(Convert.ToInt32(mana));
        }


    }
}
    
