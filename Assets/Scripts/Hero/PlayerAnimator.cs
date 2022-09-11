using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        private Animator _animator;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(IsMoving, _playerMover.IsMoving);
        }
    }
}