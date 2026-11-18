using UnityEngine;

namespace Clicker.Runtime
{
    [CreateAssetMenu(menuName = "Clicker/Configs/Weapon")]
    public class WeaponConfig : ScriptableObject
    {
        public int damage;
        public Sprite sprite;
        public int cost;
    }
}
