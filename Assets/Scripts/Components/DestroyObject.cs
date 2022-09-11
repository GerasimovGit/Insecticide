using UnityEngine;

namespace Components
{
    public class DestroyObject : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void DestroyWithDelay(float delay)
        {
            Destroy(gameObject, delay);
        }
    }
}