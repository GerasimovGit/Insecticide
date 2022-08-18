using Enemies;
using UnityEngine;
using Weapons;

namespace DefaultNamespace
{
    public class BugContainer : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Weapon _weapon;
        

        public void TakeDamage()
        {
            if (GetComponentInChildren<Enemy>() == null)
            {
                Destroy(gameObject);
                return;
            }

            if (_enemies != null)
                foreach (var enemy in _enemies)
                {
                    enemy.TakeDamage(_weapon.Damage);
                }
        }
    }
}