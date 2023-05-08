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

        /// <summary>
        /// �ۤU Y ��m
        /// </summary>
        private float crouchPosition = 0;
        /// <summary>
        /// �ۤU Y ��m
        /// </summary>
        private float originalPosition = 1;

        private bool isCrouch;
        #endregion

        #region �ƥ�
        private void Update()
        {
            // PC ����
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isCrouch) Fire();
            if (Input.GetKeyDown(KeyCode.LeftControl)) Crouch();
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

        /// <summary>
        /// �ۤU
        /// </summary>
        private void Crouch()
        {
            isCrouch = !isCrouch;
            float positionY = isCrouch ? crouchPosition : originalPosition;
            transform.position = new Vector3(0, positionY, -5);
        }
        #endregion
    }
}
