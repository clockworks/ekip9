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

        public void Initialize()
        {
            GameManager.Instance.Opponent = OpponentAI;
            GameManager.Instance.Player.SetCharacters(PlayerCharacters);
            GameManager.Instance.Opponent.SetCharacters(OpponnentChacarters);
            Camera.gameObject.SetActive(true);
        }
    }
}