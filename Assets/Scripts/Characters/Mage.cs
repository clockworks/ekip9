﻿using DefaultNamespace.TurnBasedGame;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Mage : Character
    {
        public override void Attack()
        {
            base.Attack();
            Animator.SetTrigger("Attack");
            StartCoroutine(GameManager.Instance.WaitAndExecute(SpawnProjectile, 0.8f));
        }

        private void SpawnProjectile()
        {
            var projectile = Instantiate(Projectile, Model.transform.position, Quaternion.identity);
            projectile.transform.DOLookAt(TargetCharacter.transform.position, .1f);
            projectile.transform.DOMove(TargetCharacter.transform.position, 1f)
                .OnComplete(() =>
                    {
                        Destroy(projectile);
                        TargetCharacter.TakeDamage(Damage);
                    }
                );
        }
    }
}