using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip Music;
        public AudioSource Source;

        public Image SoundButtonImage;
        public Sprite OpenSprite;
        public Sprite CloseSprite;
        private bool isMusicActive = true;

        public void OnSoundButtonClicked()
        {
            isMusicActive = !isMusicActive;
            Sprite sprite = isMusicActive ? OpenSprite : CloseSprite;
            SoundButtonImage.sprite = sprite;

            if (!isMusicActive)
            {
                Source.Pause();
            }
            else
            {
                Source.Play();
            }
        }
    }
}