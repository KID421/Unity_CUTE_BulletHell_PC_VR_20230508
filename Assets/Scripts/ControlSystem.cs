using UnityEngine;

namespace KID
{
    /// <summary>
    /// 控制系統 PC 與 VR 版本
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("子彈")]
        private GameObject prefabBullet;
        [SerializeField, Header("速度"), Range(0, 5000)]
        private float bulletSpeed;
        [SerializeField, Header("生成子彈位置")]
        private Transform bulletSpawnPoint;
        #endregion

        #region 事件
        private void Update()
        {
            // PC 版本
            if (Input.GetKeyDown(KeyCode.Mouse0)) Fire();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 發射子彈
        /// </summary>
        public void Fire()
        {
            AudioClip sound = SoundSystem.instance.soundFire;
            SoundSystem.instance.PlaySound(sound, 0.7f, 1.2f);

            GameObject tempBullet = Instantiate(prefabBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        } 
        #endregion
    }
}
