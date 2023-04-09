using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public enum CharacterType
    {
        Knight,
        Archer,
        Mage
    }

    public class GameManager : Singleton<GameManager>
    {
        public List<GameObject> CharacterPrefabs;

        public Player Player;
        public OpponentAI Opponent;
        public bool IsPlayerTurn;
        public PlayerInputController PlayerInputController;

        public void Initialize()
        {
            IsPlayerTurn = true;
            PlayerInputController.IsActive = true;
            Player.Initialize(Opponent); 
            Opponent.Initialize(Player);
            Player.StartTurn();
        }

        public void StartTimer()
        {
        }

        public void SwitchTurn()
        {
            if (IsPlayerTurn)
            {
                Player.StartTurn();
            }
            else
            {
                Opponent.StartTurn();
            }

            IsPlayerTurn = !IsPlayerTurn;
        }
    }
}