using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class OpponentAI : Player
    {
        public void Play()
        {
            int randomCharacterIndex = Random.Range(0, Characters.Count);
            SelectedCharacter = Characters[randomCharacterIndex];
        }

        public override void StartTurn()
        {
            Play();
        }
    }
}