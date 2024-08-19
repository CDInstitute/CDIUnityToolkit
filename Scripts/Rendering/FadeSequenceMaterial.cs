using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CDI.CDIToolkit.Rendering
{
    /// <summary>
    /// Fades a material through a sequence of colors
    /// </summary>
    public class FadeSequenceMaterial : MonoBehaviour
    {
        [SerializeField, Tooltip("The material to control")]
        private Material material;

        [SerializeField, Tooltip("The name of the color property to control")]
        private string colorPropertyName = "_Color";

        [SerializeField, Tooltip("Sequence of colors to fade to")]
        private Color[] sequenceColors;
        
        [SerializeField, Tooltip("The duration of the fade")]
        private float fadeDuration = 1.0f;
        
        [SerializeField, Tooltip("Whether to loop the fade sequence")]
        private bool loop = false;
        
        [SerializeField, Tooltip("The delay between fades")]
        private float delay = 0.0f;
        
        [SerializeField, Tooltip("Whether to start the fade sequence on awake")]
        private bool startOnAwake = true;
        
        [SerializeField, Tooltip("Triggered when the fade is complete")]
        private UnityEvent onFadeComplete = new UnityEvent();
        
        /// <summary>
        /// The color of the material
        /// </summary>
        public Color Color
        {
            get => material.GetColor(colorPropertyName);
            set => material.SetColor(colorPropertyName, value);
        }
        
        /// <summary>
        /// Starts the fade sequence
        /// </summary>
        public void FadeSequence()
            => StartCoroutine(FadeSequenceCoroutine());
        
        /// <summary>
        /// Coroutine for the fade sequence
        /// </summary>
        /// <returns>An enumerator for the coroutine</returns>
        public IEnumerator FadeSequenceCoroutine()
        {
            Color = sequenceColors[0];
            yield return new WaitForSeconds(delay);
            
            for(var colorSeqIdx = 0; colorSeqIdx < sequenceColors.Length; ++colorSeqIdx)
            {
                var nextColorSeqIdx = (colorSeqIdx + 1) % sequenceColors.Length;
                yield return FadeColorCoroutine(sequenceColors[colorSeqIdx], sequenceColors[nextColorSeqIdx],
                    fadeDuration);
            }
            
            onFadeComplete?.Invoke();

            if (loop)
            {
                StartCoroutine(FadeSequenceCoroutine());
            }
        }
        
        /// <summary>
        /// Fades the material color to a specific color
        /// </summary>
        /// <param name="color">The color to fade to</param>
        public void FadeColor(Color color)
            => StartCoroutine(FadeColorCoroutine(sequenceColors[0], color, fadeDuration));
        
        /// <summary>
        /// Fades the material color from one color to another
        /// </summary>
        /// <param name="from">The color to fade from</param>
        /// <param name="to">The color to fade to</param>
        /// <param name="duration">The duration of the fade</param>
        /// <returns>An enumerator for the coroutine</returns>
        public IEnumerator FadeColorCoroutine(Color from, Color to, float duration)
        {
            var time = 0.0f;
            
            while (time < duration)
            {
                time += Time.deltaTime;
                Color = Color.Lerp(from, to, time / duration);
                yield return null;
            }
            
            Color = to;
        }

        private void Awake()
        {
            if (startOnAwake)
            {
                FadeSequence();
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines(); 
            Color = sequenceColors[0];
        }
    }
}