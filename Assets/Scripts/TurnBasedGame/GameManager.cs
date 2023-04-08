using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class GameManager : MonoBehaviour
    {
        public const int DEFAULT_TURN_DURATION = 10;

        public Player Player;
        public OpponentAI Opponent;
        public bool IsPlayerTurn;
        public Timer GameTimer;
        public PlayerInputController PlayerInputController;

        public void Initialize()
        {
            PlayerInputController.SetOnPlayerCharacterSelected(OnPlayerSelected);
        }
        
        public void StartTimer()
        {
            
        }

        public void SwitchTurn()
        {
            if (IsPlayerTurn)
            {
                Opponent.StartTurn();
            }

            IsPlayerTurn = !IsPlayerTurn;
        }

        private void OnPlayerSelected(Character selectedCharacter)
        {
            Player.SelectedCharacter = selectedCharacter;
        }
    }
}