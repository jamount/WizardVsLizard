using UnityEngine;
using UnityEngine.UI;
public class EnergyBlast : MonoBehaviour
{
    public Slider manaBar;
    public Animator mBarBackground;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    public int manaCost;
    
    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {
        
        
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        SendMessage("TakeMana", manaCost);
        

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                if(manaBar.value >= manaCost)
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
