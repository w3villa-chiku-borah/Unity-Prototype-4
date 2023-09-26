using UnityEngine;

public class SpwanManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject powerUP;
    public float spawnRange = 9;
    private float enemyCount;
     int numberofenemy = 1;
    // Start is called before the first frame update
    void Start()
    {
         SpawnEnemyWave(numberofenemy);
        Instantiate(powerUP, new Vector3(0 , 0.82f, 4), enemy.transform.rotation);
        
    }

    void SpawnEnemyWave( int enemiestospawn)
    {
        for (int i = 0; i < enemiestospawn ; i++)
        {
        Instantiate(enemy , GetRandomSpawnPos(), enemy.transform.rotation);
       
        }
    }

    // Update is called once per frame
    void Update()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0 ) 
        {
            numberofenemy++;
            SpawnEnemyWave(numberofenemy);
            Instantiate(powerUP, new Vector3(spawnX , 0.82f , spawnZ), enemy.transform.rotation);
        }

        Debug.Log(enemyCount);


    }

    private Vector3 GetRandomSpawnPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spwanRandomPos = new Vector3(spawnX, 0, spawnZ);
        return spwanRandomPos;
    }
}
