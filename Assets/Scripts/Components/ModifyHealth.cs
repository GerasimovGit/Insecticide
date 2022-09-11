using UnityEngine;

namespace Components
{
    public class ModifyHealth : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;

        public void Modify(GameObject target)
        {
            if (target.gameObject.TryGetComponent(out Health health))
            {
                health.ModifyHealth(_hpDelta);
            }
        }
    }
}