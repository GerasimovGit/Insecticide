using System.Collections;
using Enemies;
using UnityEngine;

public class BugContainer : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private ParticleSystem _emoji;
    [SerializeField] private ParticleSystem _clouds;

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
        
        _emoji.Play();

        StartCoroutine(PlayAfterDelay());
    }

    private IEnumerator PlayAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        
        _clouds.Play();
        
    }
}