using System.Collections.Generic;
using DefaultNamespace.TurnBasedGame;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Character : MonoBehaviour
    {
        public int HP;
        public List<Ability> Abilities;
        public bool IsPlayer;

        public void Select()
        {
            
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}