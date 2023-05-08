using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 5000)]
        protected float hp;
        [SerializeField, Header("會造成傷害的物件名稱")]
        private string nameGetDamage;
        [SerializeField, Header("血量圖片")]
        private Image imgHealth;

        protected float maxHp => hp;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains(nameGetDamage)) GetDamage(collision.gameObject.GetComponent<Bullet>());
        }

        /// <summary>
        /// 受到傷害
        /// </summary>
        /// <param name="damage">傷害</param>
        protected virtual void GetDamage(Bullet bullet)
        {
            print(1);

            hp -= bullet.damage;
            imgHealth.fillAmount = hp / maxHp;

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {

        }
    }
}
