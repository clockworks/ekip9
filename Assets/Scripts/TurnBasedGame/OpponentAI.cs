using System.Collections;
using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class OpponentAI : Player
    {
        public void Play()
        {
            StartCoroutine(AttackSequence());
        }

        public override void StartTurn()
        {
            base.StartTurn();
            Play();
        }

        private IEnumerator AttackSequence()
        {
            for (int i = 0; i < AliveCharacters.Count; i++)
            {
                yield return new WaitForSecondsRealtime(3);
                SelectedCharacter = AliveCharacters[i];
                var playerCharacters = GameManager.Instance.Player.AliveCharacters;
                int randomPlayerCharacterIndex = Random.Range(0, playerCharacters.Count);
                SelectedOpponentCharacter = playerCharacters[randomPlayerCharacterIndex];
                SelectedCharacter.Attack();
            }
            
            GameManager.Instance.SwitchTurn();
        }
    }
}