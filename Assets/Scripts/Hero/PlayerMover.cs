using GameInput;
using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        [SerializeField] private float _speedWhenOutOfResource;

        private Camera _camera;
        private Player _player;
        private PlayerInput _playerInput;

        public bool IsMoving => _playerInput.Axis.sqrMagnitude > Constants.Epsilon;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;

            if (IsMoving)
            {
                movementVector = SetMovementVector();
                RotateToDirection(movementVector);
            }

            movementVector += Physics.gravity;

            if (_player.IsAbleToSoot)
            {
                SetMovementSpeed(movementVector, _speed);
            }
            else
            {
                SetMovementSpeed(movementVector, _speedWhenOutOfResource);
            }
        }

        private Vector3 SetMovementVector()
        {
            Vector3 movementVector = _camera.transform.TransformDirection(_playerInput.Axis);
            movementVector.y = 0;
            movementVector.Normalize();
            return movementVector;
        }

        private void RotateToDirection(Vector3 movementVector)
        {
            transform.forward = movementVector;
        }

        private void SetMovementSpeed(Vector3 movementVector, float speed)
        {
            _characterController.Move(speed * movementVector * Time.deltaTime);
        }
    }
}