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
        public List<Ability> Abilities;
        public bool IsPlayer;
        public int Damage;
        public int ActionPoint = 1;
        public TextMeshPro HPText;
        public Animator Animator;
        public GameObject Model;

        public Button AttackButton;
        public Canvas Canvas;
        public Transform AttackPoint;
        public Character TargetCharacter;

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
        }

        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            HPText.text = HP.ToString();
            Death();
        }

        public virtual void Death()
        {
            if (HP <= 0)
            {
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