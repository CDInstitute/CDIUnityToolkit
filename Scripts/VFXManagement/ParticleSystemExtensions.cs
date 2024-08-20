using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CDI.Toolkit.VFXManagement
{
    /// <summary>
    /// Extensions for <see cref="ParticleSystem"/> operations.
    /// </summary>
    public static class ParticleSystemExtensions
    {
        /// <summary>
        /// Set the maximum amount of particles for a <see cref="ParticleSystem"/>.
        /// </summary>
        /// <param name="particleSystem">The particle system to set the maximum amount of particles for.</param>
        /// <param name="maxParticles">The maximum amount of particles to set for the particle system.</param>
        public static void SetMaxParticles(this ParticleSystem particleSystem, int maxParticles)
        {
            var main = particleSystem.main;
            main.maxParticles = maxParticles;
        }

        /// <summary>
        /// Set the maximum amount of particles for a collection of <see cref="ParticleSystem"/> elements.
        /// </summary>
        /// <param name="particleSystems">The collection of particle systems to set the maximum amount of particles for.</param>
        /// <param name="maxParticles">The maximum amount of particles to set for the particle systems in the collection.</param>
        public static void SetMaxParticles(this IEnumerable<ParticleSystem> particleSystems, int maxParticles)
            => particleSystems.ToList().ForEach(particleSystem => particleSystem.SetMaxParticles(maxParticles));
    }
}