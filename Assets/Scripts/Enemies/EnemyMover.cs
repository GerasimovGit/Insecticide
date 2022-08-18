using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _path;
        [SerializeField] private float _speed;

        private int _currentPoint;
        private int _direction;
        private Enemy _enemy;
        private Transform[] _points;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            SetPoints();
        }

        private void Start()
        {
            _currentPoint = Random.Range(0, _points.Length);
        }

        private void FixedUpdate()
        {
            DoPatrol(out Vector3 direction);
            _enemy.SetDirection(direction.normalized);
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
    }
}