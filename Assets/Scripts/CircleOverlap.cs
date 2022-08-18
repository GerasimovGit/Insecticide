using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class CircleOverlap : MonoBehaviour
{
    [SerializeField] private Transform _interactPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _mask;
    private readonly Collider[] _interactionResult = new Collider[10];

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

            if (overlapResult.gameObject.TryGetComponent(out BugContainer bugContainer))
            {
                bugContainer.TakeDamage();
            }
        }
    }
}