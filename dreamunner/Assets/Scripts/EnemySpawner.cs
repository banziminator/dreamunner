using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyVariants;
    [SerializeField] private float startTimeBtwSpawn = 2f;
    [SerializeField] private float decreaseTime = 0.1f;
    [SerializeField] private float minTime = 0.65f;

    private float timeBtwSpawn;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, enemyVariants.Length);
            Instantiate(enemyVariants[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}