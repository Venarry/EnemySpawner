using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Transform[] _spawnPoints;

    private bool _isActive;
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    public void StartSpawner()
    {
        _isActive = true;
        int spawnInterval = 2;

        StartCoroutine(Spawn(spawnInterval));
    }

    public void EndSpawner()
    {
        _isActive = false;
    }

    private IEnumerator Spawn(int spawnInterval)
    {
        int pointNumber = Random.Range(0, _spawnPoints.Length);

        while (_isActive)
        {
            Enemy enemy = Instantiate(_enemyTemplate, _spawnPoints[pointNumber].position, Quaternion.identity);
            enemy.Init(_player.transform);
            pointNumber = GetNextNumber(pointNumber, _spawnPoints.Length);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private int GetNextNumber(int currentValue, int maxValue)
    {
        currentValue++;

        if (currentValue >= maxValue)
            currentValue = 0;

        return currentValue;
    }
}
