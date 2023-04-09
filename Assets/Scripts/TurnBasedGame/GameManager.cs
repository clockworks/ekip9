using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        public SnakeController SnakeController;
        public TurnPanel TurnPanel;
        public GameOverPanel GameOverPanel;
        public Camera GameOverCamera;
        public bool IsPlayerWin;
        public bool IsGameFinished;
        public int BonusHealth;

        public Level ActiveLevel;

        private void InitFields()
        {
            IsGameFinished = false;
            Player = GameObject.Find("PlayerController").GetComponent<Player>();
            SnakeController = GameObject.Find("Snake").GetComponent<SnakeController>();
            TurnPanel = GameObject.FindObjectsOfType<TurnPanel>(true)[0];
            GameOverPanel = GameObject.FindObjectsOfType<GameOverPanel>(true)[0];
        }

        void OnEnable()
        {
            Debug.Log("OnEnable called");
            SceneManager.sceneLoaded += (x, y) => InitFields();
        }

        public void Initialize(Level level)
        {
            IsGameFinished = false;
            TurnPanel.ShowHide(true);
            ActiveLevel = level;
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
                StartCoroutine(WaitAndExecute(() => { SwitchTurn(); }, 4f));
            }
        }

        public void SwitchTurn()
        {
            if (IsGameFinished)
            {
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


        public void GameFinished()
        {
            if (IsPlayerWin)
            {
                if (ActiveLevel.isLast)
                {
                    GameOverPanel.ShowHide(true);
                    return;
                }
                
                TurnPanel.ShowHide(false);
                for (int i = 0; i < ActiveLevel.AddedCharacterTypes.Count; i++)
                {
                    SnakeController.AddBodyPart(ActiveLevel.AddedCharacterTypes[i]);
                }

                SnakeController.gameObject.SetActive(true);
                ActiveLevel.gameObject.SetActive(false);
            }
            else
            {
                StopAllCoroutines();
                SceneManager.LoadScene(0);
            }
        }

        public void CheckGameFinish()
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

            if (IsGameFinished)
            {
                TurnPanel.TurnText.text = IsPlayerWin ? "Win!" : "Lose!";
                StartCoroutine(TimerCoroutine(GameFinished, 3));
            }
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
            TurnPanel.TimerText.gameObject.SetActive(false);
            action?.Invoke();
        }
    }
}