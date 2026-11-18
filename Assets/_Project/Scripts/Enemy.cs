using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Runtime
{
    public class Enemy : MonoBehaviour
    {
        private int health;
        [SerializeField] private Image image;

        public event Action OnDead;

        public void SetEnemy(EnemyConfig config)
        {
            health = config.health;
            image.sprite = config.sprite;
        }

        public void HitEnemy(int damage)
        {
            if (IsDead())
            {
                return;
            }

            health -= damage;

            IsDead();
        }

        private bool IsDead()
        {
            if (health <= 0)
            {
                OnDead?.Invoke();
                return true;
            }

            return false;
        }
    }
}
