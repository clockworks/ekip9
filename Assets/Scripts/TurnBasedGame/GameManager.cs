using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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
        public TurnPanel TurnPanel;
        public bool IsPlayerWin;
        public bool IsGameFinished;

        public void Initialize()
        {
            TurnPanel.ShowHide(true);
            IsPlayerTurn = true;
            PlayerInputController.IsActive = true;
            PlayerInputController.IsActive = true;
            Player.Initialize(Opponent);
            Opponent.Initialize(Player);
            Player.StartTurn();
        }

        public void ActionExecuted(int actionPoint, bool isPlayer)
        {
            if (isPlayer)
            {
                Player.DecreaseActionPoint(actionPoint);
            }

            if ((IsPlayerTurn && Player.ActionPoint <= 0))
            {
                StartCoroutine(GameManager.Instance.WaitAndExecute(() => { SwitchTurn(); }, 4f));
            }
        }

        public void SwitchTurn()
        {
            IsGameFinished = CheckGameFinish();

            if (IsGameFinished)
            {
                TurnPanel.TurnText.text = IsPlayerWin ? "Win!" : "Lose!";
                StartCoroutine(TimerCoroutine(null,3));
                return;
            }

            if (IsPlayerTurn)
                Player.StopTurn();
            else
                Opponent.StopTurn();

            IsPlayerTurn = !IsPlayerTurn;

            if (IsPlayerTurn)
                Player.StartTurn();
            else
                Opponent.StartTurn();
        }


        public bool CheckGameFinish()
        {
            IsGameFinished = false;

            if (Player.AliveCharacters.Count == 0)
            {
                IsGameFinished = true;
                IsPlayerWin = false;
            }
            else if (Opponent.AliveCharacters.Count == 0)
            {
                IsGameFinished = true;
                IsPlayerWin = true;
            }

            return IsGameFinished;
        }

        public IEnumerator WaitAndExecute(Action action, float duration)
        {
            yield return new WaitForSecondsRealtime(duration);
            action.Invoke();
        }

        public IEnumerator TimerCoroutine(Action action, int duration)
        {
            TurnPanel.TimerText.text = duration.ToString();
            TurnPanel.TimerText.gameObject.SetActive(true);
            
            for (int i = duration; i >= 0; i--)
            {
                TurnPanel.TimerText.text = i.ToString();
                yield return new WaitForSecondsRealtime(1);
            }

            action?.Invoke();
        }
    }
}