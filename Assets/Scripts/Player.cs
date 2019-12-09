using UnityEngine;
public class Player : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public delegate void UpdateMana(int newMana);
    public static event UpdateMana OnUpdateMana;
    public int mRegenRate = 5;
    public int hRegenRate = 1;


    private Animator gunAnim;
    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }
        
        
        SendMessage("RegenMana", mRegenRate);
        SendMessage("RegenHealth", hRegenRate);
        
       
    }
    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    public void SendManaData(int mana)
    {
        if (OnUpdateMana != null)
        {
            OnUpdateMana(mana);
        }
    }

}
