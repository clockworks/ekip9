using DG.Tweening;
using UnityEngine;
using DefaultNamespace.TurnBasedGame;

namespace DefaultNamespace
{
    public class Knight : Character
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
                                                      1
                                       )
                        );
                    }
                );
        }
    }
}