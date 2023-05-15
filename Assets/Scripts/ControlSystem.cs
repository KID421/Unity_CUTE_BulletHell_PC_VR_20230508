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
        [Header("�˴� VR �Y���ۤU�ϰ�")]
        [SerializeField] private Vector3 boxCheckVRHeadSize;
        [SerializeField] private Vector3 boxCheckVRHeadOffset;
        [SerializeField, Header("�n�������ϼh")] private LayerMask layerHead;

        /// <summary>
        /// �ۤU Y ��m
        /// </summary>
        private float crouchPosition = 0;
        /// <summary>
        /// ��l Y ��m
        /// </summary>
        private float originalPosition = 1;

        private bool isCrouch;

        private bool hasWeapon;
        #endregion

        #region �ƥ�
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawCube(
                transform.position + transform.TransformDirection(boxCheckVRHeadOffset),
                boxCheckVRHeadSize);
        }

        private void Update()
        {
            // PC ����
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isCrouch) Fire();
            if (Input.GetKeyDown(KeyCode.LeftControl)) Crouch();

            CheckVRHeadInCrouchArea();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �֦��Z��
        /// </summary>
        public void HasWeapon()
        {
            hasWeapon = true;
        }

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

        private void CheckVRHeadInCrouchArea()
        {
            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(boxCheckVRHeadOffset),
                boxCheckVRHeadSize / 2, Quaternion.identity, layerHead);

            if (hits.Length > 0)
            {
                isCrouch = true;
            }
            else
            {
                isCrouch = false;
            }
        }
        #endregion
    }
}
