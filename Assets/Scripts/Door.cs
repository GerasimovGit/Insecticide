using System.Collections;
using Hero;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen;
    private readonly float lerpDuration = 0.4f;

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

        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        _isOpen = true;
    }
}