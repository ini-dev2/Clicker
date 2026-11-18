using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Runtime
{
    public class Weapon : MonoBehaviour
    {
        public int Damage { get; private set; }

        [SerializeField] private Image image;

        public void SetWeapon(WeaponConfig config)
        {
            Damage = config.damage;
            image.sprite = config.sprite;
        }
    }
}
