using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class DirectionalIndicator : MonoBehaviour
    {
        private readonly Vector3 _defaultScale = Vector3.zero;
        private readonly Vector3 _targetScale = Vector3.one;
    
        [SerializeField] private Transform _target;
        [SerializeField] private Player _player;
        [SerializeField] private float _changeScaleDuration;

        private Coroutine _coroutine;

        private void Start()
        {
            transform.localScale = _defaultScale;
        }

        private void OnEnable()
        {
            _player.ResourceEnded += OnResourceEnded;
            _player.ResourceGained += OnResourceGained;
        }

        private void OnDisable()
        {
            _player.ResourceEnded -= OnResourceEnded;
            _player.ResourceGained -= OnResourceGained;
        }

        private void OnResourceEnded()
        {
            _coroutine = StartCoroutine(Look());
            ChangeScale(_targetScale);
        }

        private void OnResourceGained()
        {
            StopCurrentCoroutine();
            ChangeScale(_defaultScale);
        }

        private void ChangeScale(Vector3 targetScale)
        {
            transform.DOScale(targetScale, _changeScaleDuration)
                .SetEase(Ease.Linear);
        }

        private IEnumerator Look()
        {
            while (_player.IsAbleToSoot == false)
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

        private void StopCurrentCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }
}