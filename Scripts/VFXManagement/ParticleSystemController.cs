using System.Collections.Generic;
using UnityEngine;

namespace CDI.Toolkit.VFXManagement
{
    public class ParticleSystemController : MonoBehaviour
    {
        [SerializeField]
        private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

        [SerializeField]
        private int diminishAmount = 0;

        [SerializeField]
        private int flourishAmount = 300;

        public void Diminish()
            => particleSystems.SetMaxParticles(diminishAmount);

        public void Flourish()
            => particleSystems.SetMaxParticles(flourishAmount);
    }
}