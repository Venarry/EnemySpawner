using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        _enemyMovement.TargetReached += Die;
    }

    private void OnDisable()
    {
        _enemyMovement.TargetReached -= Die;
    }

    public void Init(Transform target)
    {
        _enemyMovement.SetTarget(target);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
