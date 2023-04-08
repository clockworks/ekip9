using System;
using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class PlayerInputController : MonoBehaviour
    {
        private const float RAYCAST_DISTANCE = 50;

        [SerializeField] private Camera viewCamera;
        [SerializeField] private LayerMask hitLayer;

        private RaycastHit _hitInfo;
        private Action<Character> _playerCharacterSelected;

        public void SetOnPlayerCharacterSelected(Action<Character> onPlayerCharacterSelected)
        {
            _playerCharacterSelected = onPlayerCharacterSelected;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * RAYCAST_DISTANCE, Color.red);

                if (Physics.Raycast(ray, out _hitInfo, RAYCAST_DISTANCE, hitLayer))
                {
                    Character character = _hitInfo.collider.GetComponent<Character>();
                    if (character != null)
                    {
                        character.Select();
                        _playerCharacterSelected.Invoke(character);
                    }
                }
            }
        }
    }
}