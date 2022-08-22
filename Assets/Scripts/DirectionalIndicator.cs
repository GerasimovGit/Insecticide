using System;
using System.Collections;
using Hero;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(Animator))]
public class DirectionalIndicator : MonoBehaviour
{
    private static readonly int IsOutOfResource = Animator.StringToHash("IsOutOfResource");

    [SerializeField] private Transform _target;
    [SerializeField] private Player _player;
    [SerializeField] private Weapon _weapon;

    private Animator _animator;

    private void OnEnable()
    {
        _weapon.ResourceEnded += OnResourсeEnded;
    }

    private void OnDisable()
    {
        _weapon.ResourceEnded -= OnResourсeEnded;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsOutOfResource, _weapon.IsOutOfResource);
    }

    private void OnResourсeEnded()
    {
        StartCoroutine(Look());
    }

    private IEnumerator Look()
    {
        while (_weapon.IsOutOfResource)
        {
            LookAtTarget();
            yield return null;
        }
    }

    private void LookAtTarget()
    {
        Vector3 targetPosition = _target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
}