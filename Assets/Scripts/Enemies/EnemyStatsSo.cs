using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
    public class EnemyStatsSo : ScriptableObject
    {
        public float health;
        public float speed;
        public float damage;
        public float timeUntilNextShot;
    }
}
