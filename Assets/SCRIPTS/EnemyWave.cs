using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public EnemySpawner spawner;
    // Die() calls on the tag, "Boss", attached to Big Bertha so it knows to go to Win Screen.
    //Also, Die() destroys the GameObject of both slugs and Big Bertha when DIRK defeats it.
    public void Die()
    {
        if (spawner != null)
        {
            if (gameObject.CompareTag("Boss"))
            {
                spawner.BossDefeated();
            }
            else
            {
                spawner.EnemyDefeated();
            }
        }

        Destroy(gameObject);
    }
}
