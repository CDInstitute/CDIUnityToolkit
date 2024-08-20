using System.Collections.Generic;
using UnityEngine;

namespace CDI.Toolkit.VFXManagement
{
    /// <summary>
    /// A controller for managing particle systems.
    /// </summary>
    public class ParticleSystemController : MonoBehaviour
    {
        [SerializeField, Tooltip("The particle systems to manage")]
        private List<ParticleSystem> particleSystems = new();

        [SerializeField, Tooltip("The amount of particles to diminish to")]
        private int diminishAmount = 0;

        [SerializeField, Tooltip("The amount of particles to flourish to")]
        private int flourishAmount = 300;

        /// <summary>
        /// Diminishes the particle systems.
        /// </summary>
        public void Diminish()
            => particleSystems.SetMaxParticles(diminishAmount);

        /// <summary>
        /// Flourishes the particle systems.
        /// </summary>
        public void Flourish()
            => particleSystems.SetMaxParticles(flourishAmount);
    }
}