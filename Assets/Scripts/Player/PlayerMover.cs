using Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        private Camera _camera;
        private PlayerInput _playerInput;

        private void Awake()
        {
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

            bool isMoving = _playerInput.Axis.sqrMagnitude > Constants.Epsilon;

            if (isMoving)
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