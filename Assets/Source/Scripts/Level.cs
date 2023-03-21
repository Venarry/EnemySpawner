using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Player _playerTemplate;
    [SerializeField] private Transform _playerSpawnPoint;

    private void Start()
    {
        Player player = Instantiate(_playerTemplate, _playerSpawnPoint.position, Quaternion.identity);
        _spawner.Init(player);
        _spawner.Work();
    }
}
