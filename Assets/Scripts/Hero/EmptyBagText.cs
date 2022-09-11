using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class EmptyBagText : MonoBehaviour
    {
        private readonly Vector3 _targetScale = Vector3.zero;
    
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Player _player;
        [SerializeField] private float _changeScaleDuration;

        private Coroutine _coroutine;
        private Vector3 _defaultScale;

        private void Start()
        {
            _defaultScale = _rectTransform.localScale;
            _rectTransform.localScale = Vector3.zero;
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

        private void OnResourceGained()
        {
            ChangeScale(_targetScale);
        }
    
        private void ChangeScale(Vector3 targetScale)
        {
            transform.DOScale(targetScale, _changeScaleDuration)
                .SetEase(Ease.Linear);
        }

        private void OnResourceEnded()
        {
            ChangeScale(_defaultScale);
        }
    }
}