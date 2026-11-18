using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Runtime
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemyConfig[] enemyConfigs;
        private int currentEnemyId = -1;

        [SerializeField] private Weapon weapon;
        [SerializeField] private WeaponConfig[] weaponConfigs;
        private int currentWeaponId = -1;

        [SerializeField] private Button gradeWeaponButton;
        [SerializeField] private TMP_Text gradeWeaponText;

        [SerializeField] private int balance = 0;
        [SerializeField] private TMP_Text moneyText;

        private void Awake()
        {
            enemy.OnDead += SetNextEnemy;
            gradeWeaponButton.onClick.AddListener(ByeNextWeapon);
        }

        private void Start()
        {
            SetNextEnemy();
            ByeNextWeapon();
        }

        private void SetNextEnemy()
        {
            if (currentEnemyId >= enemyConfigs.Length - 1)
            {
                return;
            }

            currentEnemyId++;

            enemy.SetEnemy(enemyConfigs[currentEnemyId]);

            balance += TakeDrop(currentEnemyId);
            moneyText.text = balance.ToString();
        }

        private void ByeNextWeapon()
        {
            if (currentWeaponId >= weaponConfigs.Length - 1)
            {
                return;
            }

            if (balance < weaponConfigs[currentWeaponId + 1].cost)
            {
                return;
            }

            currentWeaponId++;

            balance -= weaponConfigs[currentWeaponId].cost;

            weapon.SetWeapon(weaponConfigs[currentWeaponId]);

            if (currentWeaponId + 1 < weaponConfigs.Length)
            {
                gradeWeaponText.text = $"Grade: {weaponConfigs[currentWeaponId + 1].cost}";
            }
            else
            {
                gradeWeaponText.text = $"Zero";
            }
        }

        private int TakeDrop(int id)
        {
            int drop = Random.Range(1, id * 5);

            return drop;
        }

        private void OnDestroy()
        {
            enemy.OnDead -= SetNextEnemy;
            gradeWeaponButton.onClick.RemoveListener(ByeNextWeapon);
        }
    }
}
