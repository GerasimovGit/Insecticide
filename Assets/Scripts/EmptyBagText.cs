using System.Collections;
using UnityEngine;
using Weapons;

public class EmptyBagText : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private EmptyBagArea _emptyBagArea;
    [SerializeField] private float _fadeInSpeed;

    private Coroutine _coroutine;
    private Vector3 _defaultScale;

    private void Start()
    {
        _defaultScale = _rectTransform.localScale;
        _rectTransform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        _weapon.ResourceEnded += OnResourceEnded;
        _emptyBagArea.EnteredChargeArea += OnResourceFull;
    }

    private void OnDisable()
    {
        _weapon.ResourceEnded -= OnResourceEnded;
        _emptyBagArea.EnteredChargeArea -= OnResourceFull;
    }

    private void OnResourceFull()
    {
        StopExistCoroutine();
        StartCoroutine(Fade(Vector3.zero));
    }

    private void StopExistCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void OnResourceEnded()
    {
        _coroutine = StartCoroutine(Fade(_defaultScale));
    }

    private IEnumerator Fade(Vector3 endScale)
    {
        Vector3 scale = _rectTransform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < _fadeInSpeed)
        {
            _rectTransform.localScale = Vector3.Lerp(scale, endScale, timeElapsed / _fadeInSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
    }
}