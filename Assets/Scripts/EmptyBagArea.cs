using System;
using Hero;
using UnityEngine;

public class EmptyBagArea : MonoBehaviour
{
    public event Action ResourceAdded;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddResource();
            ResourceAdded?.Invoke();
        }
    }
}