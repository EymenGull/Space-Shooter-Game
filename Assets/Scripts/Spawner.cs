using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool stopSpawning = false;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private GameObject _speedupPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;
    [SerializeField]
    private GameObject _asteroidPrefab;
    private float enemyBornTime = 5f;
    private static float _enemySpeedIncrease = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyBorn());
        StartCoroutine(TripleShotRoutine());
        StartCoroutine(SpeedUpRoutine());
        StartCoroutine(ShieldRoutine());
        StartCoroutine(AsteroidBorn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator EnemyBorn()
    {
        while (stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(-9.0f, 9.0f), 10, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            Enemy _enemy = newEnemy.GetComponent<Enemy>();
            _enemy.SetSpeed(_enemySpeedIncrease);
            _enemySpeedIncrease += 0.5f;
            enemyBornTime *= 0.95f;
            yield return new WaitForSeconds(enemyBornTime);
        }

    }

    IEnumerator AsteroidBorn()
    {
        while (stopSpawning == false)
        {
            Instantiate(_asteroidPrefab, new Vector3(Random.Range(-6.0f, 6.0f), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10.5f, 20.0f));
        }

    }

    IEnumerator TripleShotRoutine()
    {
        while (stopSpawning == false)
        {
            Instantiate(_tripleshotPrefab, new Vector3(Random.Range(-9.0f, 9.0f), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }

    IEnumerator SpeedUpRoutine()
    {
        while (stopSpawning == false)
        {
            Instantiate(_speedupPrefab, new Vector3(Random.Range(-9.0f, 9.0f), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }

    IEnumerator ShieldRoutine()
    {
        while (stopSpawning == false)
        {
            Instantiate(_shieldPrefab, new Vector3(Random.Range(-9.0f, 9.0f), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(12f, 18f));
        }
    }

    public void DeadController()
    {
        stopSpawning = true;
    }
}
