using System.Collections;
using UnityEngine;

public class ScaleLerper : MonoBehaviour
{
    [SerializeField] private float _changeScaleSpeed;
    [SerializeField] private float _changeScaleTime;
    [SerializeField] private float _changeScaleCount;
    [SerializeField] private Vector3 _minScale;

    [SerializeField] private bool _activate;

    private Vector3 _defaultScale;
        
    private IEnumerator Start()
    {
        _defaultScale = transform.localScale;

            
        while (_activate == true)
        {

            yield return RepeatLerp(_defaultScale, _minScale, _changeScaleTime);
            //yield return RepeatLerp(_minScale, _defaultScale, _changeScaleTime);
        }
    }
        
    private IEnumerator RepeatLerp(Vector3 maxScale, Vector3 minScale, float time)
    {
        float timeElapsed = 0.0f;
        float rate = (1.0f / time) * _changeScaleSpeed;
        
        while (timeElapsed < 1.0f)
        {
            Debug.Log("Scaling");
            transform.localScale = Vector3.Lerp(maxScale, minScale, timeElapsed);
            timeElapsed += Time.deltaTime * rate;
            yield return null;
        }
    }
}