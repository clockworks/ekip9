using System;
using DG.Tweening;
using UnityEngine;
using System.Collections;

namespace DefaultNamespace
{
    public class Knight : Character
    {
        public override void Attack()
        {
            base.Attack();

            Model.transform.DOMove(TargetCharacter.AttackPoint.position, 1)
                .OnStart(() => { Animator.SetTrigger("Move"); })
                .OnComplete(() =>
                    {
                        Animator.SetTrigger("Attack");
                        StartCoroutine(WaitAndExecute(() =>
                                                      {
                                                          TargetCharacter.TakeDamage(Damage);
                                                          Model.transform.localPosition = Vector3.zero;
                                                      },
                                                      1
                                       )
                        );
                    }
                );
        }

        private IEnumerator WaitAndExecute(Action action, float duration)
        {
            yield return new WaitForSecondsRealtime(duration);
            action.Invoke();
        }
    }
}