using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CDI.Toolkit.VFXManagement
{
    public static class ParticleSystemExtensions
    {
        public static void SetMaxParticles(this ParticleSystem particleSystem, int maxParticles)
        {
            var main = particleSystem.main;
            main.maxParticles = maxParticles;
        }

        public static void SetMaxParticles(this IEnumerable<ParticleSystem> particleSystems, int maxParticles)
            => particleSystems.ToList().ForEach(particleSystem => particleSystem.SetMaxParticles(maxParticles));
    }
}