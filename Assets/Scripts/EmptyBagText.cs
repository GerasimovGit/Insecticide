using System.Collections;
using TMPro;
using UnityEngine;
using Weapons;

public class EmptyBagText : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private EmptyBagArea _emptyBagArea;
    [SerializeField] private float _fadeInSpeed;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _weapon.ResourceEnded += OnResourceEnded;
        _emptyBagArea.ResourceAdded += OnResourceFull;
    }

    private void OnDisable()
    {
        _weapon.ResourceEnded -= OnResourceEnded;
        _emptyBagArea.ResourceAdded -= OnResourceFull;
    }

    private void OnResourceFull()
    {
        StopExistCoroutine();
        StartCoroutine(FadeIn());
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
        _coroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color color = _text.color;
        Vector3 scale = _rectTransform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < _fadeInSpeed)
        {
            color.a = Mathf.Lerp(color.a, 1f, timeElapsed / _fadeInSpeed);
            scale = Vector3.Lerp(scale, Vector3.one, timeElapsed / _fadeInSpeed);
            _text.color = color;
            _rectTransform.localScale = scale;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        Color color = _text.color;
        Vector3 scale = _rectTransform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < _fadeInSpeed)
        {
            color.a = Mathf.Lerp(color.a, 0f, timeElapsed / (_fadeInSpeed * 0.5f));
            scale = Vector3.Lerp(scale, Vector3.zero, timeElapsed / (_fadeInSpeed * 0.5f));
            _text.color = color;
            _rectTransform.localScale = scale;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}