using UnityEngine;

namespace KID
{
    /// <summary>
    /// ����t�� PC �P VR ����
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�l�u")]
        private GameObject prefabBullet;
        [SerializeField, Header("�t��"), Range(0, 5000)]
        private float bulletSpeed;
        [SerializeField, Header("�ͦ��l�u��m")]
        private Transform bulletSpawnPoint;
        #endregion

        #region �ƥ�
        private void Update()
        {
            // PC ����
            if (Input.GetKeyDown(KeyCode.Mouse0)) Fire();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �o�g�l�u
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
