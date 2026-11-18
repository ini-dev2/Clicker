using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Runtime
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Button enemyButton;

        [SerializeField] private Enemy enemy;

        [SerializeField] private Weapon weapon;

        private void Awake()
        {
            enemyButton.onClick.AddListener(ClickCallback);
        }

        private void ClickCallback()
        {
            enemy.HitEnemy(weapon.Damage);
        }

        private void OnDestroy()
        {
            enemyButton.onClick.RemoveListener(ClickCallback);
        }
    }
}
