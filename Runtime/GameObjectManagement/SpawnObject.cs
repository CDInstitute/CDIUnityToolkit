using UnityEngine;

namespace CDI.Toolkit.GameObjectManagement
{
    /// <summary>
    /// A simple script to spawn an object at a spawn point.
    /// </summary>
    public class SpawnObject : MonoBehaviour
    {
        [Tooltip("The object to spawn.")]
        public GameObject objectToSpawn;
        
        [Tooltip("The spawn point to spawn the object at.")]
        public Transform spawnPoint;

        /// <summary>
        /// Spawn the object.
        /// </summary>
        public void Spawn()
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}