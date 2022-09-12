using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public event Action DamageTake;
        public event Action Died;

        public void TakeDamage()
        {
            DamageTake?.Invoke();
        }

        public void Die()
        {
            Died?.Invoke();
        }
    }
}