using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// ��q�t��
    /// </summary>
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        protected float hp;
        [SerializeField, Header("�|�y���ˮ`������W��")]
        private string nameGetDamage;
        [SerializeField, Header("��q�Ϥ�")]
        private Image imgHealth;

        protected float maxHp => hp;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains(nameGetDamage)) GetDamage(collision.gameObject.GetComponent<Bullet>());
        }

        /// <summary>
        /// ����ˮ`
        /// </summary>
        /// <param name="damage">�ˮ`</param>
        protected virtual void GetDamage(Bullet bullet)
        {
            print(1);

            hp -= bullet.damage;
            imgHealth.fillAmount = hp / maxHp;

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// ���`
        /// </summary>
        protected virtual void Dead()
        {

        }
    }
}
