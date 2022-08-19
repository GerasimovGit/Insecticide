using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour
    { 
        public event Action DamageTaken;

        public void TakeDamage()
        {
            DamageTaken?.Invoke();
        }
    }
}