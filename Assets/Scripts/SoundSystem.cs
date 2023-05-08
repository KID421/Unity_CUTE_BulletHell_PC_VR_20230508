using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���Ĩt��
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        #region ���
        public static SoundSystem instance;

        [Header("����")]
        public AudioClip soundFire;
        public AudioClip soundHurt;
        public AudioClip soundExplosion;

        private AudioSource aud;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            instance = this;
            aud = GetComponent<AudioSource>();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ���񭵮�
        /// </summary>
        /// <param name="sound">����</param>
        /// <param name="min">�̤p���q</param>
        /// <param name="max">�̤j���q</param>
        public void PlaySound(AudioClip sound, float min, float max)
        {
            float volume = Random.Range(min, max);
            aud.PlayOneShot(sound, volume);
        } 
        #endregion
    }
}
