using UnityEngine;

namespace KID
{
    public class HealthEnemy : HealthSystem
    {
        protected override void Dead()
        {
            base.Dead();
            Destroy(gameObject);
        }
    }
}
