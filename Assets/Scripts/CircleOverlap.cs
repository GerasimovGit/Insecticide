using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CircleOverlap : MonoBehaviour
{
    private readonly Collider[] _interactionResult = new Collider[10];
    
    [SerializeField] private Transform _interactPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private string[] _tags;
    [SerializeField] private OnOverlapEvent _onOverlap;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = HandlesUtils.tranparentRed;
        Gizmos.DrawSphere(_interactPoint.position, _radius);
    }

    public void Check()
    {
        var size = Physics.OverlapSphereNonAlloc(_interactPoint.position,
            _radius,
            _interactionResult, _mask);

        for (var i = 0; i < size; i++)
        {
            var overlapResult = _interactionResult[i];

            var isInTags = _tags.Any(tag => overlapResult.CompareTag(tag));
            if (isInTags) _onOverlap?.Invoke(_interactionResult[i].gameObject);
        }
    }

    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {
    }
}