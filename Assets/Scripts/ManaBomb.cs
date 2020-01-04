using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ManaBomb : MonoBehaviour
{
    public Slider manaBar;
    public Animator mBarBackground;
    public GameObject bombPrefab;
    public GameObject bombCharging;
    public Transform bombSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    public int manaCost;
    public float charge = 0;

    public bool bombFired = false;

    public Transform bomb;

    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {

        isFiring = true;
        Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
        SendMessage("TakeMana", manaCost);


        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!isFiring)
            {
                if (manaBar.value >= manaCost)
                {

                    Fire();

                   
                   
                    
                    

                    
                }
                else
                {
                    mBarBackground.SetTrigger("ManaEmpty");
                }

            }
        }

      
    }

}
