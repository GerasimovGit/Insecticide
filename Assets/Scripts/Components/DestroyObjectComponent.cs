using UnityEngine;

namespace Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}