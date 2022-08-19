using Enemies;
using UnityEngine;

public class BugContainer : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    public void TakeDamage()
    {
        if (_enemies == null) return;

        foreach (var enemy in _enemies)
        {
            enemy.TakeDamage();
        }
    }
}