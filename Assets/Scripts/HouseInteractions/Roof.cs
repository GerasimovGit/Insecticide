using UnityEngine;
using Zones;

namespace HouseInteractions
{
    public class Roof : MonoBehaviour
    {
        [SerializeField] private CleaningZone _cleaningZone;

        private void OnEnable()
        {
            _cleaningZone.PlayerEntered += ChangeVisibility;
        }

        private void OnDisable()
        {
            _cleaningZone.PlayerEntered -= ChangeVisibility;
        }

        private void ChangeVisibility(bool isPlayerEntered)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(isPlayerEntered != true);
            }
        }
    }
}