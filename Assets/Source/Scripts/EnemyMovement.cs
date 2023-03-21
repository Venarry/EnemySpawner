using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;

    private CharacterController _characterController;
    private Transform _target;

    public event Action TargetReached;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        if (_target == null)
            throw new Exception();

        Vector3 moveDirection = (_target.position - transform.position).normalized;
        _characterController.Move(moveDirection * _speed);

        float reachedDistance = 1.5f;

        if(Vector3.Distance(transform.position, _target.position) < reachedDistance)
        {
            TargetReached?.Invoke();
        }
    }
}
