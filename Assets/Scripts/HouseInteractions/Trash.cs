using System.Collections;
using UnityEngine;

namespace HouseInteractions
{
    public class Trash : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _object;
        [SerializeField] private float _fadeInSpeed;
        [SerializeField] private ParticleSystem _particle;

        public void OnInteract()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            float timeElapsed = 0;
            _particle.Play();
            while (timeElapsed < _fadeInSpeed)
            {
                foreach (var spriteRenderer in _object)
                {
                    var spriteRendererColor = spriteRenderer.color;
                    spriteRendererColor.a = Mathf.Lerp(spriteRendererColor.a, 0f, timeElapsed / _fadeInSpeed);
                    spriteRenderer.color = spriteRendererColor;
                }
            
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}