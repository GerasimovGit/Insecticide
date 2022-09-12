using System.Collections;
using Hero;
using UnityEngine;

namespace HouseInteractions
{
    public class Door : MonoBehaviour
    {
        private bool _isOpen;
        private readonly float _lerpDuration = 0.4f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                if (_isOpen == false)
                {
                    StartCoroutine(Open());
                }
            }
        }

        private IEnumerator Open()
        {
            float timeElapsed = 0;
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, -95, 0);

            while (timeElapsed < _lerpDuration)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / _lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.rotation = targetRotation;
            _isOpen = true;
        }
    }
}