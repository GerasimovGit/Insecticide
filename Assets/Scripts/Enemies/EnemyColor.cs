using System;
using System.Collections;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyColor : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderer;
        [SerializeField] private float _colorChangeSpeed;
        [SerializeField] private Color _targetColor;

        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            _enemy.Died += OnEnemyDied;
        }

        private void OnDisable()
        {
            _enemy.Died -= OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            float timeElapsed = 0;

            while (timeElapsed < _colorChangeSpeed)
            {
                foreach (var target in _renderer)
                {
                    target.material.color =
                        Color.Lerp(target.material.color, _targetColor, timeElapsed / _colorChangeSpeed);
                }

                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}