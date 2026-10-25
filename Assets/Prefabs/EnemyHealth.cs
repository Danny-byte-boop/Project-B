using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //public integers for maxHealth, currentHealth, rewardScore, and contactDamage
    public int maxHealth = 15;
    public int currentHealth;
    public int rewardScore = 10;

    public int contactDamage = 10;
    // Start() sets currentHealth = maxHealth at the start of the game.
    void Start()
    {
        currentHealth = maxHealth;
    }
    //TakeDamage(int damage) is for when the slugs take damage and then if there health hits zero; they die.
    public void TakeDamage(int damage)
    {
        Debug.Log($"{name} took {damage} damage");
        currentHealth -= damage;
        Debug.Log("The Slug is taking" + damage + "damage! Health:" + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    //Calls on another method from EnemyWave script
    void Die()
    {
        Debug.Log("The slug has been SLAIN!!!");
        GetComponent<EnemyWave>().Die();
    }
    //Makes it so DIRK actually takes damage when getting hit by the slugs that have the Collider2D which is
    //all of them
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(contactDamage);
            }
        }
    }
}
