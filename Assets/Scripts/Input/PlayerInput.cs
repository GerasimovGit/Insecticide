using UnityEngine;

namespace Input
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public Vector2 Axis => new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}