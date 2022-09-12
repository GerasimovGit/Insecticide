using Effects;
using UnityEngine;
using Zones;

namespace Hero
{
    [RequireComponent(typeof(ParticlesEffects))]
    [RequireComponent(typeof(Player))]
    public class PlayerEffects : MonoBehaviour
    {
        private readonly string _shootId = "Shoot";
        private readonly string _windId = "Wind";
        
        [SerializeField] private CleaningZone _cleaningZone;

        private Player _player;
        private ParticlesEffects _particles;

        private void Awake()
        {
            _particles = GetComponent<ParticlesEffects>();
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _cleaningZone.PlayerEntered += PlayShootEffect;
            _player.ResourceEnded += OnResourceEnded;
            _player.ResourceGained += OnResourceGained;
        }

        private void OnDisable()
        {
            _cleaningZone.PlayerEntered -= PlayShootEffect;
            _player.ResourceEnded -= OnResourceEnded;
            _player.ResourceGained -= OnResourceGained;
        }

        private void PlayShootEffect(bool isEnteredToClearZone)
        {
            if (_player.IsAbleToSoot && isEnteredToClearZone)
            {
                _particles.Play(_shootId);
            }
            else if (!_player.IsAbleToSoot || isEnteredToClearZone == false)
            {
                _particles.Stop(_shootId);
            }
        }

        private void OnResourceEnded()
        {
            _particles.Stop(_shootId);
            _particles.Play(_windId);
        }

        private void OnResourceGained()
        {
            _particles.Stop(_windId);
        }
    }
}