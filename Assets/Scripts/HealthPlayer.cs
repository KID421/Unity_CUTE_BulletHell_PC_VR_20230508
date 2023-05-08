using TMPro;
using UnityEngine;

namespace KID
{
    public class HealthPlayer : HealthSystem
    {
        [SerializeField, Header("血條文字")]
        private TextMeshProUGUI textHealth;

        protected override void Awake()
        {
            base.Awake();
            textHealth.text = $"HP {hp} / {maxHp}";
        }

        protected override void GetDamage(Bullet bullet)
        {
            base.GetDamage(bullet);
            textHealth.text = $"HP {hp} / {maxHp}";
        }

        protected override void Dead()
        {
            base.Dead();
            print("玩家死亡");
        }
    }
}
