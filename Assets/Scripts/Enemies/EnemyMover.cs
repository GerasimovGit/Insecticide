using UnityEngine;

namespace Enemies
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _path;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private int _currentPoint;
        private Vector3 _direction;
        private Transform[] _points;
        private Quaternion _rotation;

        private bool _isMoving => _direction.magnitude > Constants.Epsilon;

        private void Awake()
        {
            SetPoints();
        }

        private void Start()
        {
            _currentPoint = Random.Range(0, _points.Length);
        }

        private void FixedUpdate()
        {
            DoPatrol(out Vector3 direction);
            SetDirection(direction);
            RotateToDirection();
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
                int point = Random.Range(0, _points.Length);
                _currentPoint = point;
            }
        }

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        private void RotateToDirection()
        {
            if (!_isMoving) return;

            _rotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, Time.deltaTime * _rotationSpeed);
        }
    }
}