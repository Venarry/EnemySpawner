using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        _enemyMovement.TargetReached += Death;
    }

    private void OnDisable()
    {
        _enemyMovement.TargetReached -= Death;
    }

    public void Init(Transform target)
    {
        _enemyMovement.SetTarget(target);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
