using UnityEngine;

namespace CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private void LateUpdate()
        {
            if (_target == null)
                return;

            Follow();
        }

        private void Follow()
        {
            Quaternion rotation = GetRotation();
            Vector3 position = GetPosition(rotation);
            transform.rotation = rotation;
            transform.position = position;
        }

        private Quaternion GetRotation()
        {
            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            return rotation;
        }

        private Vector3 GetPosition(Quaternion rotation)
        {
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();
            return position;
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _target.position;
            followingPosition.y += _offsetY;
            return followingPosition;
        }
    }
}