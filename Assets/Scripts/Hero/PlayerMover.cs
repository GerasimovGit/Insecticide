using GameInput;
using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        
        private Animator _animator;
        private Camera _camera;
        private PlayerInput _playerInput;
        
        private bool _isMoving => _playerInput.Axis.sqrMagnitude > Constants.Epsilon;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            _animator.SetBool("isMoving", _isMoving);
        }

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;

            if (_isMoving)
            {
                movementVector = _camera.transform.TransformDirection(_playerInput.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}