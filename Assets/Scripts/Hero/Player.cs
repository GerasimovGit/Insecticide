using System;
using System.Collections;
using ColliderBased;
using UnityEngine;
using Weapons;

namespace Hero
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CircleOverlap _circleOverlap;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private float _shootCooldown;

        private float _nextShootAttackTime;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        public bool IsAbleToSoot => _weapon.IsOutOfResource == false;

        public event Action ResourceEnded;
        public event Action ResourceGained;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_shootCooldown);
        }

        public void TrySoot()
        {
            _coroutine = StartCoroutine(Shoot());
        }

        public void StopShoot()
        {
            StopCurrentCoroutine();
        }

        private void StopCurrentCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator Shoot()
        {
            while (_weapon.IsOutOfResource == false)
            {
                _circleOverlap.Check();
                _weapon.Fire();
                yield return _waitForSeconds;
            }

            ResourceEnded?.Invoke();
        }

        public void AddResource()
        {
            ResourceGained?.Invoke();
            _weapon.AddResource();
        }
    }
}