using System;
using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class PlayerInputController : MonoBehaviour
    {
        private const float RAYCAST_DISTANCE = 50;

        [SerializeField] private Camera viewCamera;
        [SerializeField] private LayerMask hitLayer;

        [SerializeField] private Transform playerSelection;
        [SerializeField] private Transform opponnetSelection;

        private RaycastHit _hitInfo;
        public bool IsActive;

        private void Update()
        {
            if (IsActive && Input.GetMouseButtonDown(0))
            {
                Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * RAYCAST_DISTANCE, Color.red);

                if (Physics.Raycast(ray, out _hitInfo, RAYCAST_DISTANCE, hitLayer))
                {
                    Character character = _hitInfo.collider.GetComponent<Character>();
                    var player = GameManager.Instance.Player;
                    if (character.IsPlayer)
                    {
                        player.SelectedCharacter?.Deselect();
                        player.SelectedCharacter = character;
                        player.SelectedCharacter.Select();

                        playerSelection.transform.position = character.transform.position;
                    }
                    else
                    {
                        player.SelectedOpponentCharacter?.Deselect();
                        player.SelectedOpponentCharacter = character;
                        player.SelectedOpponentCharacter.Select();

                        opponnetSelection.transform.position = character.transform.position;
                    }

                    player.SelectedCharacter?.UpdateView(player.SelectedOpponentCharacter != null);
                }
            }
        }

        public void SetActiveOpponentSelection(bool isSelectionActive)
        {
            opponnetSelection.gameObject.SetActive(isSelectionActive);
            var player = GameManager.Instance.Player;
            player.SelectedOpponentCharacter?.Deselect();
            player.SelectedOpponentCharacter = null;
        }
    }
}