using DefaultNamespace.TurnBasedGame;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Boss : Character
    {
        public override void Attack()
        {
            base.Attack();
            Animator.SetTrigger("Move");
            Model.transform.DOMove(TargetCharacter.AttackPoint.position, 1)
                .OnComplete(() =>
                    {
                        Animator.SetTrigger("Attack");
                        StartCoroutine(GameManager.Instance.WaitAndExecute(() =>
                                                                           {
                                                                               TargetCharacter.TakeDamage(Damage);
                                                                               if (IsPlayer)
                                                                               {
                                                                                   AttackButton.interactable = false;
                                                                               }
                                                                               Model.transform.localPosition = Vector3.zero;
                                                                           },
                                                                           2.5f
                                       )
                        );
                    }
                );
        }
    }
}