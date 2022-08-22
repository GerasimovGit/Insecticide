using System.Collections;
using DefaultNamespace;
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
        _emptyBagArea.Triggered += OnResourceFull;
    }

    private void OnDisable()
    {
        _weapon.ResourceEnded -= OnResourceEnded;
        _emptyBagArea.Triggered -= OnResourceFull;
    }

    private void OnResourceFull()
    {
        StopExistCoroutine();
        Hide();
    }

    private void StopExistCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Hide()
    {
        Color textColor = _text.color;
        textColor.a = 0f;
        _text.color = textColor;
        _rectTransform.localScale = Vector3.zero;
    }

    private void OnResourceEnded()
    {
        _coroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("fadeOutText");
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
}