using UnityEngine;

namespace KID
{
    public class HealthPlayer : HealthSystem
    {
        protected override void Dead()
        {
            base.Dead();
            print("ª±®a¦º¤`");
        }
    }
}
