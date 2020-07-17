using UnityEngine;

namespace Characters.Player.Data
{
    public class PlayerInput
    {
        public bool AttackInput => Input.GetMouseButtonDown(0) && Time.timeScale > 0f;
        public bool AdvancedAttackInput => Input.GetMouseButtonDown(1) && Time.timeScale > 0f;
        public float VerticalInput => Time.timeScale > 0f ? Input.GetAxisRaw("Vertical") : 0f;
        public float HorizontalInput => Time.timeScale > 0f ? Input.GetAxisRaw("Horizontal") : 0f;
        public float MouseHorizontalPosition => Time.timeScale > 0f ? Input.mousePosition.x : 0f;
    }
}