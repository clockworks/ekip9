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
        public List<Character> AliveCharacters;
        public int ActionPoint;

        public void Initialize(Player opponent)
        {
            Opponent = opponent;
            AliveCharacters = Characters;
        }

        public virtual void StartTurn()
        {
            ActionPoint = 4;

            GameManager.Instance.TurnPanel.ShowTurnText(Index == 0);
            
            if (Index == 0)
            {
                GameManager.Instance.TurnPanel.ActionPointChange(ActionPoint);
                GameManager.Instance.PlayerInputController.IsActive = true;
            }
            
            for (int i = 0; i < AliveCharacters.Count; i++)
            {
                if (GameManager.Instance.BonusHealth > 0)
                {
                    AliveCharacters[i].HP++;
                    GameManager.Instance.BonusHealth--;
                }
                
                AliveCharacters[i].Initialize();
            }
        }

        public virtual void StopTurn()
        {
            if (Index == 0)
            {
                GameManager.Instance.PlayerInputController.Disable();
                SelectedCharacter = null;
                SelectedOpponentCharacter = null;
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

        public void DecreaseActionPoint(int actionPoint)
        {
            ActionPoint -= actionPoint;
            if (Index == 0)
            {
                GameManager.Instance.TurnPanel.ActionPointChange(ActionPoint);
            }
        }
    }
}