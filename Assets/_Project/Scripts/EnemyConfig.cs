using UnityEngine;

namespace Clicker.Runtime
{
    [CreateAssetMenu(menuName = "Clicker/Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        public int health;
        public Sprite sprite;
    }
}
