using System;
using Hero;
using UnityEngine;

public class EmptyBagArea : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    public event Action EnteredChargeArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddResource();
            EnteredChargeArea?.Invoke();
            _coin.AddCoins(transform.position,3);
        }
    }
}