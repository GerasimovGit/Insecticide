using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void DestroyWithDelay(float delay)
        {
            StartCoroutine(WaitToDestroy(delay));
        }

        private IEnumerator WaitToDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }
    }
}