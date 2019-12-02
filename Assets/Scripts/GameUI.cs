using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Slider manaBar;
    public Text scoreText;
    public int playerScore = 0;
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        Player.OnUpdateMana += UpdateManaBar;
        AddScore.OnSendScore += UpdateScore;
    }
    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
    }
    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateManaBar (int mana)
    {
        manaBar.value = mana;
    }
    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = "SCORE: " + playerScore.ToString();
    }
}
