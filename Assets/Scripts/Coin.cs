using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _target;
    [SerializeField] private int _maxCoins;
    [SerializeField] private float _animationDuration;
    [SerializeField] private Ease _easeType;
    [SerializeField] private Camera _camera;
    private readonly Queue<GameObject> _coinsQueue = new();

    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = _target.position;
        PrepareCoins();
    }

    private void PrepareCoins()
    {
        for (int i = 0; i < _maxCoins; i++)
        {
            var coin = Instantiate(_coin, transform, false);
            coin.SetActive(false);
            _coinsQueue.Enqueue(coin);
        }
    }

    public void AddCoins(Vector3 position, int amount)
    {
        Animate(position, amount);
    }

    private void Animate(Vector3 position, int amount)
    {
        if (_coinsQueue.Count > amount)
        {
            StartCoroutine(PlayWithDelay(position, amount));
        }
    }

    private IEnumerator PlayWithDelay(Vector3 position, int coinsToSpawn)
    {
        int count = 0;

        while (count < coinsToSpawn)
        {
            var coin = _coinsQueue.Dequeue();
            coin.SetActive(true);
            var pos = _camera.WorldToScreenPoint(position);
            coin.transform.position = pos;

            coin.transform.DOMove(_targetPosition, _animationDuration)
                .SetEase(_easeType)
                .OnComplete(() =>
                {
                    coin.SetActive(false);
                    _coinsQueue.Enqueue(coin);
                });

            count++;
            yield return new WaitForSeconds(_animationDuration);
        }
    }
}