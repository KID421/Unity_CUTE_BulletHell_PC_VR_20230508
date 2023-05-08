using UnityEngine;

namespace KID
{
    /// <summary>
    /// �l�u
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// �ˮ`��
        /// </summary>
        public float damage;

        private void Awake()
        {
            Destroy(gameObject, 3);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
