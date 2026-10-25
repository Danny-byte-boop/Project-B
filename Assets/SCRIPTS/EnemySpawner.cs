using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class EnemySpawner : MonoBehaviour
{
    //four GameObjects for my slugs to spawn
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    //# of enemies that spawn per wave
    public int enemiesPerWave = 4;
    //how many spawn at a time during the wave
    public float spawnInterval = 2f;
    //Takes into account DIRK and how far the enemies have to be from DIRK.
    public Transform player; 
    public float minDistanceFromPlayer = 5f;
    //This creates a GameObject for the main boss, "BIG BERTHA."
    public GameObject BigBertha;
    //This instantiates for win screen menu
    public string winScreen = "Win Screen";
    //Maximum waves is set to 5 and after that BIG BERTHA spawns in. 
    public int maximumWaves = 5;
    //Creates a private integer for enemies spawned
    private int enemiesSpawned = 0;
    //Creates a private integer for enemies alive
    private int enemiesAlive = 0;
    //Creates a private integer number of waves
    private int wave = 1;
    //Creates a bool statement to instantiate that the boss hasn't spawned yet.
    private bool bossHasSpawned = false;
    //Creates another bool statement to instantiate that the waves are not present yet.
    private bool wavesSpawned = false;
    //Two AudioSources for fighting the slugs, and the boss fight
    public AudioSource waveMusic;
    public AudioSource bossMusic;
    //Start() waveMusic plays when you Start level 1.
    void Start()
    {
        waveMusic.Play();
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (bossHasSpawned || wavesSpawned)
            return;
        if (enemiesSpawned >= enemiesPerWave)
            return;
        // Spawns all four (two of them are just dark blue slugs) types at DIFFERENT random positions
        GameObject e1 = Instantiate(enemyPrefab1, GetRandomPosition(), Quaternion.identity);
        GameObject e2 = Instantiate(enemyPrefab2, GetRandomPosition(), Quaternion.identity);
        GameObject e3 = Instantiate(enemyPrefab3, GetRandomPosition(), Quaternion.identity);
        GameObject e4 = Instantiate(enemyPrefab4, GetRandomPosition(), Quaternion.identity);

        // Setup script for each enemy
        SetupEnemy(e1);
        SetupEnemy(e2);
        SetupEnemy(e3);
        SetupEnemy(e4);

        enemiesSpawned += 4;
        enemiesAlive += 4;
        //if statement so that it stops spawning in enemies more than required.
        if (enemiesSpawned < enemiesPerWave)
            Invoke(nameof(SpawnEnemy), spawnInterval);
        
    }
    
    //Gets a random position for each slug within the scene
    Vector3 GetRandomPosition()
    {
        Vector3 pos;
        int attempts = 0;

        do
        {
            float x = Random.Range(-7f, 7f);
            float y = -2.0f;
            pos = new Vector3(x, y, 0f);
            attempts++;
        }
        while (Vector2.Distance(pos, player.position) < minDistanceFromPlayer && attempts < 10);

        return pos;
    }
    //SetupEnemy(GameObject enemy) sets up the slugs 
    void SetupEnemy(GameObject enemy)
    {
        EnemyWave enemyScript = enemy.GetComponent<EnemyWave>();
        if (enemyScript == null)
            enemyScript = enemy.AddComponent<EnemyWave>();

        enemyScript.spawner = this;
    }
    //
    public void EnemyDefeated()
    {
        enemiesAlive--;
        if (bossHasSpawned)
            return;
        if (enemiesAlive <= 0 && enemiesSpawned >= enemiesPerWave)
        {
            if (wave == maximumWaves)
            {
                // This is the last wave of slugs, and it spawns the boss instead
                Debug.Log("Final wave cleared! Spawning Big Bertha...");
                //Increments so future checks know that we have moved past wave 5
                wave++;
                wavesSpawned = true;
                BigBerthaSpawned();
            }
            else
            {
                wave++;
                enemiesSpawned = 0;
                Debug.Log("Wave " + wave + " starting!");
                CancelInvoke(nameof(SpawnEnemy));
                Invoke(nameof(SpawnEnemy), 3f);
            }
        }
    }
    //The spawning of BigBertha, the main boss of the game.
    public void BigBerthaSpawned()
    {
        if (bossHasSpawned) return;
        bossHasSpawned = true;
        wavesSpawned = true;
        CancelInvoke(nameof(SpawnEnemy));
        waveMusic.Stop();
        bossMusic.Play();
        Debug.Log("BIG BERTHA INCOMING");

        Vector3 BossPos = new Vector3(8f, -1.5f, 0f);
        GameObject boss = Instantiate(BigBertha, BossPos, Quaternion.identity);

        SetupEnemy(boss);
    }
    //When Big Bertha is defeated; the game brings up the Win Screen.
    public void BossDefeated()
    {
        Debug.Log("BIG BERTHA HAS BEEN DEFEATED FOR NOW....");
        SceneManager.LoadSceneAsync("Win Screen");
    }
}

    

