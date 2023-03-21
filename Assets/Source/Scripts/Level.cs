using UnityEngine;

public class Level : MonoBehaviour // *для ментора* - хотел попытаться реализовать код с точкой входа для избежания ошибок при спавне игрока. Если возможно, хотел бы получить фитбек по этой реализации
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Player _playerTemplate;
    [SerializeField] private Transform _playerSpawnPoint;

    private void Start()
    {
        Player player = Instantiate(_playerTemplate, _playerSpawnPoint.position, Quaternion.identity);
        _spawner.Init(player);
        _spawner.StartSpawner();
    }
}
