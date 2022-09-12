using DG.Tweening;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyAnimations : MonoBehaviour
    {
        private const float ChangeScaleValue = 1.5f;
        private const float DieRotationAngleZ = 180f;
        private const float OffsetPositionY = 0.1f;

        [SerializeField] private Ease _easeType;

        [Space] [Header("Hit")] 
        [SerializeField] private float _hitDuration;
        [SerializeField] private int _hitTicksCount;

        [Space] [Header("Die")] 
        [SerializeField] private float _dieBodyRotateDuration;

        private Enemy _enemy;
        private Quaternion _dieRotation;
        private Vector3 _originalScale;
        private Vector3 _targetScale;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void Start()
        {
            _originalScale = transform.localScale;
            _targetScale = CalculateNewScale();
        }

        private void OnEnable()
        {
            _enemy.DamageTake += OnDamageTake;
            _enemy.Died += OnDie;
        }

        private void OnDisable()
        {
            _enemy.DamageTake -= OnDamageTake;
            _enemy.Died -= OnDie;
        }

        private Vector3 CalculateNewScale()
        {
            return _originalScale * ChangeScaleValue;
        }

        private void OnDie()
        {
            _dieRotation = SetRotationAngle();
            RotateBody();
            MoveYPosition();
        }

        private void RotateBody()
        {
            transform.DORotateQuaternion(_dieRotation, _dieBodyRotateDuration)
                .SetEase(_easeType);
        }

        private void MoveYPosition()
        {
            transform.DOMoveY(transform.position.y + OffsetPositionY, _dieBodyRotateDuration);
        }

        private Quaternion SetRotationAngle()
        {
            return transform.rotation * Quaternion.Euler(0, 0, DieRotationAngleZ);
        }

        private void OnDamageTake()
        {
            ChangeScale();
        }

        private void ChangeScale()
        {
            transform.DOScale(_targetScale, _hitDuration)
                .SetEase(_easeType)
                .SetLoops(_hitTicksCount, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    transform.DOScale(_originalScale, _hitDuration)
                        .SetEase(_easeType);
                });
        }
    }
}