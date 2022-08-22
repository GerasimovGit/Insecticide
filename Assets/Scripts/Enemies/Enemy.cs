using System;
using System.Collections;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Renderer _object;
        [SerializeField] private float _fadeInSpeed;
        
        public event Action DamageTaken;
        public event Action Died;

        public void TakeDamage()
        {
            DamageTaken?.Invoke();
        }

        public void Die()
        {
            StartCoroutine(FadeIn());
            Died?.Invoke();
        }
        
        private IEnumerator FadeIn()
        {
            Color color = _object.material.color;
            Color targetColor = new Color(0.3f,0.1f,color.b);
            float timeElapsed = 0;
        
            while (timeElapsed < _fadeInSpeed)
            {
                _object.material.color = Color.Lerp(_object.material.color, targetColor, timeElapsed/ _fadeInSpeed);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}