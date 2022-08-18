using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health;

        private Animator _animator;

        public Vector3 Direction { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            SetDirection(Direction);
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
            transform.forward = direction;
        }

        public void TakeDamage(float damage)
        {
            if (_health > 0)
            {
                _health -= damage;
                _animator.SetTrigger("Hit");
                Debug.Log("taking damage");
            }

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}