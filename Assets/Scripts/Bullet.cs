using UnityEngine;

namespace KID
{
    /// <summary>
    /// ¤l¼u
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// ¶Ë®`­È
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
