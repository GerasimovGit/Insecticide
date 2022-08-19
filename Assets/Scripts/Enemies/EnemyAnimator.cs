﻿using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Enemy),typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Hit = Animator.StringToHash("Hit");
        
        private Animator _animator;
        private Enemy _enemy;

        private void OnEnable()
        {
            _enemy.DamageTaken += OnDamageTaken;
        }

        private void OnDisable()
        {
            _enemy.DamageTaken -= OnDamageTaken;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemy = GetComponent<Enemy>();
        }

        public void OnDamageTaken()
        {
            _animator.SetTrigger(Hit);
            Debug.Log("taking damage");
        }
    }
}