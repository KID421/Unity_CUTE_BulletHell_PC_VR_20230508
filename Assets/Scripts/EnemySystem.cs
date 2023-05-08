using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("子彈")]
        private GameObject prefabBullet;
        [SerializeField, Header("速度"), Range(0, 5000)]
        private float bulletSpeed;
        [SerializeField, Header("生成間隔"), Range(0, 10)] 
        private float bulletInterval;
        [SerializeField, Header("生成子彈位置")]
        private Transform bulletSpawnPoint;
        #endregion

        #region 事件
        private void Awake()
        {
            InvokeRepeating("Fire", 0, bulletInterval);
        } 
        #endregion

        #region 方法
        /// <summary>
        /// 發射子彈
        /// </summary>
        private void Fire()
        {
            AudioClip sound = SoundSystem.instance.soundFire;
            SoundSystem.instance.PlaySound(sound, 0.7f, 1.2f);

            GameObject tempBullet = Instantiate(prefabBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        }
        #endregion
    }
}
