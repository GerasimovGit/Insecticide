using System;
using Hero;
using UnityEngine;

public class CleaningZone : MonoBehaviour
{
    public event Action<bool> PlayerEntered;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Debug.Log("Enter");
            PlayerEntered?.Invoke(true);
            player.TrySoot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Debug.Log("Exit");
            PlayerEntered?.Invoke(false);
        }
    }
}