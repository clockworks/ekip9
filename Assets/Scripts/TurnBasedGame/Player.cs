using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class Player : MonoBehaviour
    {
        public int Index;
        public Character SelectedCharacter;
        public Character SelectedOpponentCharacter;
        public Player Opponent;
        public List<Character> Characters;

        public void Initialize(Player opponent)
        {
            Opponent = opponent;
        }

        public virtual void StartTurn()
        {
            if (Index == 0)
            {
                GameManager.Instance.PlayerInputController.IsActive = true;
            }
        }

        public virtual void StopTurn()
        {
            if (Index == 0)
            {
                GameManager.Instance.PlayerInputController.IsActive = false;
            }
        }

        public void SetCharacters(List<Character> characters)
        {
            if (Characters != null)
            {
                for (int i = 0; i < Characters.Count; i++)
                {
                    Characters[i].SetActive(false);
                }
            }

            Characters = characters;

            for (int i = 0; i < Characters.Count; i++)
            {
                Characters[i].SetActive(true);
            }
        }
    }
}