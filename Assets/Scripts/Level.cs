using System.Collections.Generic;
using DefaultNamespace.TurnBasedGame;
using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        public List<Character> PlayerCharacters;
        public List<Character> OpponnentChacarters;
        public Camera Camera;
        public OpponentAI OpponentAI;
        public PlayerInputController PlayerInputController;
        public List<CharacterType> AddedCharacterTypes;

        public void Initialize()
        {
            this.gameObject.SetActive(true);
            GameManager.Instance.Opponent = OpponentAI;
            GameManager.Instance.Player.SetCharacters(PlayerCharacters);
            GameManager.Instance.Opponent.SetCharacters(OpponnentChacarters);
            GameManager.Instance.PlayerInputController = PlayerInputController;
            GameManager.Instance.Initialize(this);
            Camera.gameObject.SetActive(true);
        }
    }
}