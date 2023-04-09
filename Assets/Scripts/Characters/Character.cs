using System;
using System.Collections.Generic;
using DefaultNamespace.TurnBasedGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public abstract class Character : MonoBehaviour
    {
        public int HP;
        public bool IsPlayer;
        public int Damage;
        public int AttackActionPoint = 2;
        public TextMeshPro HPText;
        public Animator Animator;
        public GameObject Model;

        public Button AttackButton;
        public Canvas Canvas;
        public Transform AttackPoint;
        public Character TargetCharacter;
        public GameObject Projectile;

        private void Awake()
        {
            HPText.text = HP.ToString();
            Animator.SetTrigger("Idle");
        }

        public void Select()
        {
            if (IsPlayer)
                Canvas.gameObject.SetActive(true);
        }

        public void Deselect()
        {
            if (IsPlayer)
                Canvas.gameObject.SetActive(false);
        }

        public void UpdateView(bool isAttackButtonActive)
        {
            AttackButton.interactable = isAttackButtonActive;
        }

        public virtual void Attack()
        {
            var character = IsPlayer
                ? GameManager.Instance.Player.SelectedOpponentCharacter
                : GameManager.Instance.Opponent.SelectedOpponentCharacter;
            TargetCharacter = character;

            if (IsPlayer)
            {
                AttackButton.interactable = false;
                GameManager.Instance.ActionExecuted(AttackActionPoint, IsPlayer);
                GameManager.Instance.PlayerInputController.opponnetSelection.position = new Vector3(0, 30, 0);
                GameManager.Instance.PlayerInputController.playerSelection.position = new Vector3(0, 30, 0);
            }
            
            GameManager.Instance.Player.SelectedOpponentCharacter = null;
            GameManager.Instance.Opponent.SelectedOpponentCharacter = null;
        }

        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            HPText.text = HP.ToString();
            Kill();
        }

        public virtual void Kill()
        {
            if (HP <= 0)
            {
                var player = IsPlayer ? GameManager.Instance.Player : GameManager.Instance.Opponent;
                player.AliveCharacters.Remove(this);
                GameManager.Instance.PlayerInputController.opponnetSelection.transform.position = new Vector3(0, 30, 0);
                GameManager.Instance.Player.SelectedOpponentCharacter = null;
                GameManager.Instance.CheckGameFinish();
                Destroy(this.gameObject);
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
            HPText.text = HP.ToString();
            HPText.gameObject.SetActive(isActive);
            Animator.SetTrigger("Idle");
        }
    }
}