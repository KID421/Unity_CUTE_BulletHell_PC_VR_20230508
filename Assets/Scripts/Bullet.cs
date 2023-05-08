using UnityEngine;

namespace KID
{
    /// <summary>
    /// 子彈
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// 傷害值
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
