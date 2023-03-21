using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private bool _isActive;
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    public void Work()
    {
        _isActive = true;
        int spawnInterval = 2;

        StartCoroutine(Spawn(spawnInterval));
    }

    public void End()
    {
        _isActive = false;
    }

    private IEnumerator Spawn(int spawnInterval)
    {
        int pointNumber = Random.Range(0, _spawnPoints.Length);
        WaitForSeconds waitForSeconds = new WaitForSeconds(spawnInterval);

        while (_isActive)
        {
            Enemy enemy = Instantiate(_prefab, _spawnPoints[pointNumber].position, Quaternion.identity);
            enemy.Init(_player.transform);
            pointNumber = GetNextNumber(pointNumber, _spawnPoints.Length);

            yield return waitForSeconds;
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
