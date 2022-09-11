using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public event Action DamageTaken;
        public event Action Died;

        public void TakeDamage()
        {
            DamageTaken?.Invoke();
        }

        public void Die()
        {
            Died?.Invoke();
        }
    }
}