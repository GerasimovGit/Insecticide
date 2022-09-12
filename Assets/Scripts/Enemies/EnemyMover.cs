using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _path;
        [SerializeField] private float _speed;

        private int _currentPoint;
        private bool _isDead;
        private Enemy _enemy;
        private Transform[] _points;
        private Vector3 _direction;
        private Quaternion _rotation;

        private bool _isMoving => _direction.magnitude > Constants.Epsilon;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            SetPoints();
        }

        private void Start()
        {
            _currentPoint = GetRandomPoint();
        }

        private void FixedUpdate()
        {
            if (_isDead) return;
            DoPatrol(out Vector3 direction);
            SetDirection(direction);
            RotateToDirection();
        }

        private void OnEnable()
        {
            _enemy.Died += OnDie;
        }

        private void OnDisable()
        {
            _enemy.Died -= OnDie;
        }

        private void OnDie()
        {
            _isDead = true;
        }

        private int GetRandomPoint()
        {
            return Random.Range(0, _points.Length);
        }

        private void SetPoints()
        {
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }
        }

        private void DoPatrol(out Vector3 direction)
        {
            Transform target = _points[_currentPoint];
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            direction = transform.position - target.position;

            if (transform.position == target.position)
            {
                int point = GetRandomPoint();
                _currentPoint = point;
            }
        }

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        private void RotateToDirection()
        {
            if (_isMoving == false) return;

            _rotation = Quaternion.LookRotation(_direction);
            transform.rotation = _rotation;
        }
    }
}