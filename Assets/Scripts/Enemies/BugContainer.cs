using System.Collections;
using Effects;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(ParticlesEffects))]
    public class BugContainer : MonoBehaviour
    {
        private readonly string _emojiId = "Emoji";
        private readonly string _cloudsId = "Clouds";
    
        [SerializeField] private Enemy[] _enemies;

        private ParticlesEffects _particles;

        private void Awake()
        {
            _particles = GetComponent<ParticlesEffects>();
        }

        public void TakeDamage()
        {
            if (_enemies == null) return;

            foreach (var enemy in _enemies)
            {
                enemy.TakeDamage();
            }
        }

        public void Die()
        {
            if (_enemies == null) return;

            foreach (var enemy in _enemies)
            {
                enemy.Die();
            }
        
            PlayEffect(_emojiId);

            StartCoroutine(HideAfterDelay());
        }

        private IEnumerator HideAfterDelay()
        {
            yield return new WaitForSeconds(1.5f);
        
            foreach (var enemy in _enemies)
            {
                enemy.gameObject.SetActive(false);
            }
        
            PlayEffect(_cloudsId);
        
        }

        private void PlayEffect(string id)
        {
            _particles.Play(id);
        }
    }
}