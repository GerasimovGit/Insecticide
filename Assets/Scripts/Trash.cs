using System.Collections;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _object;
    [SerializeField] private float _fadeInSpeed;
    [SerializeField] private ParticleSystem _particle;

    public void OnInteract()
    {
        Debug.Log("interacting");
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color color = _object.color;
        float timeElapsed = 0;
        _particle.Play();
        while (timeElapsed < _fadeInSpeed)
        {
            color.a = Mathf.Lerp(color.a, 0f, timeElapsed / _fadeInSpeed);
            _object.color = color;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        

        
        //Destroy(gameObject);
    }
}