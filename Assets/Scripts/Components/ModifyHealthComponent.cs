using UnityEngine;

namespace Components
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;

        public void ModifyHealth(GameObject target)
        {
            if (target.gameObject.TryGetComponent(out Health health))
            {
                health.ModifyHealth(_hpDelta);
            }
        }
    }
}