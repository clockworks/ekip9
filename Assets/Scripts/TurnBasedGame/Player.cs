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
        public Ability SelectedAbility;
        public List<Ability> Abilities;
        public List<Character> Characters;

        public void Initialize(Player opponent)
        {
            Opponent = opponent;
        }

        public virtual void SelectAbility(Ability ability)
        {
            SelectedAbility = ability;
        }

        public virtual void ExecuteAbility()
        {
            SelectedAbility.Execute();
        }

        public virtual void StartTurn()
        {
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