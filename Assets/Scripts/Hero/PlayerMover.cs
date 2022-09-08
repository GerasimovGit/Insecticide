using System;
using GameInput;
using UnityEngine;
using Weapons;

namespace Hero
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private Weapon _weapon;
        
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

            if (_weapon.IsOutOfResource)
            {
                _characterController.Move(_movementSpeed * 0.35f * movementVector * Time.deltaTime);
            }

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}