using UnityEngine;

namespace CDI.Toolkit.AudioManagement
{
    /// <summary>
    /// A simple script to play a sound effect.
    /// </summary>
    public class PlaySFX : MonoBehaviour
    {
        [Tooltip("The audio source to play the sound effect on.")]
        public AudioSource audioSource;
        
        [Tooltip("The sound effect to play.")]
        public AudioClip sfx;
        
        [Tooltip("The pitch range to play the sound effect at.")]
        public Vector2 pitchRange = new Vector2(0.9f, 1.1f);
        
        [Tooltip("The volume range to play the sound effect at.")]
        public Vector2 volumeRange = new Vector2(0.9f, 1.1f);
        
        [Tooltip("The time range to play the sound effect at.")]
        public Vector2 timeRange = new Vector2(0, 0.1f);

        /// <summary>
        /// Play the sound effect.
        /// </summary>
        public void Play()
        {
            audioSource.PlayOneShot(sfx);
        }

        /// <summary>
        /// Play the sound effect with random pitch, volume, and time.
        /// </summary>
        public void PlayWithVariants()
        {
            audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
            audioSource.volume = Random.Range(volumeRange.x, volumeRange.y);
            audioSource.time = Random.Range(timeRange.x, sfx.length - timeRange.y);
            audioSource.PlayOneShot(sfx);
        }
    }
}