using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ĤH�t��
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�l�u")]
        private GameObject prefabBullet;
        [SerializeField, Header("�t��"), Range(0, 5000)]
        private float bulletSpeed;
        [SerializeField, Header("�ͦ����j"), Range(0, 10)] 
        private float bulletInterval;
        [SerializeField, Header("�ͦ��l�u��m")]
        private Transform bulletSpawnPoint;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            InvokeRepeating("Fire", 0, bulletInterval);
        } 
        #endregion

        #region ��k
        /// <summary>
        /// �o�g�l�u
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
