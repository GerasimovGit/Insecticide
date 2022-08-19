using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Enemy), typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Hit = Animator.StringToHash("Hit");

        private Animator _animator;
        private Enemy _enemy;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            _enemy.DamageTaken += OnDamageTaken;
            _enemy.Died += OnDied;
        }

        private void OnDisable()
        {
            _enemy.DamageTaken -= OnDamageTaken;
            _enemy.Died += OnDied;
        }

        private void OnDied()
        {
        }

        private void OnDamageTaken()
        {
            _animator.SetTrigger(Hit);
            Debug.Log("taking damage");
        }
    }
}