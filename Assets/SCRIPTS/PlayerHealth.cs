using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public string deathScene = "End Screen";
    public Image[] healthBars;
    public Sprite fullHealth;
    public Sprite halfHealth;
    public Sprite noHealth;

    // Start() is for when the game starts; it sets DIRK's currentHealth = maxHealth and Updates the HealthUI. (Hearts)
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    //TakeDamage(int damage) allows DIRK to take damage and die from the slugs and Big Bertha
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player endured" + damage + "damage! Health:" + currentHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }
    //Die() for when DIRK dies; it loads the End Screen and the player can now retry at the Tutorial_Level
    void Die()
    {
        Debug.Log("DIRK has DIED!! Loading:" + deathScene);
        SceneManager.LoadScene(deathScene);
    }
    //UpdateHealthUI() updates the hearts so that when you take damage, it updates the hearts automatically.
    void UpdateHealthUI()
    {
        if (healthBars == null || healthBars.Length == 0) return;

        float healthPercentage = (float)currentHealth / maxHealth;
        int fullHearts = Mathf.FloorToInt(healthPercentage * healthBars.Length);
        bool hasPartial = (healthPercentage *healthBars.Length) > fullHearts;
        //To further iterate taking damage and hearts updating automatically for DIRK.
        for (int i = 0; i < healthBars.Length; i++) 
        {
            if (i < fullHearts)
            {
                healthBars[i].sprite = fullHealth;
            }
            else if (i == fullHearts && hasPartial)
            {
                healthBars[i].sprite = halfHealth;
            }
            else
            {
                healthBars[i].sprite = noHealth;
            }
        }
        }
    }


    

