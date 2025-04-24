using System;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class SpawnSpacecraft : MonoBehaviour
    {
        [SerializeField] Camera m_CameraToFace;
        [SerializeField] List<GameObject> m_ObjectPrefabs = new List<GameObject>();
        [SerializeField] GameObject m_SpawnVisualizationPrefab;
        [SerializeField] int m_SpawnOptionIndex = -1;
        [SerializeField] bool m_OnlySpawnInView = true;
        [SerializeField] float m_ViewportPeriphery = 0.15f;
        [SerializeField] bool m_ApplyRandomAngleAtSpawn = true;
        [SerializeField] float m_SpawnAngleRange = 45f;
        [SerializeField] bool m_SpawnAsChildren;

        public event Action<GameObject> objectSpawned;

        private bool hasSpawnedObject = false;

        void Awake()
        {
            if (m_CameraToFace == null)
                m_CameraToFace = Camera.main;
        }

        public bool TrySpawnObject(Vector3 spawnPoint, Vector3 spawnNormal)
        {
            if (hasSpawnedObject)
                return false;

            if (m_OnlySpawnInView)
            {
                var inViewMin = m_ViewportPeriphery;
                var inViewMax = 1f - m_ViewportPeriphery;
                var pointInViewportSpace = m_CameraToFace.WorldToViewportPoint(spawnPoint);
                if (pointInViewportSpace.z < 0f || pointInViewportSpace.x > inViewMax || pointInViewportSpace.x < inViewMin ||
                    pointInViewportSpace.y > inViewMax || pointInViewportSpace.y < inViewMin)
                {
                    return false;
                }
            }

            var objectIndex = (m_SpawnOptionIndex < 0 || m_SpawnOptionIndex >= m_ObjectPrefabs.Count)
                ? UnityEngine.Random.Range(0, m_ObjectPrefabs.Count)
                : m_SpawnOptionIndex;

            var newObject = Instantiate(m_ObjectPrefabs[objectIndex]);
            if (m_SpawnAsChildren)
                newObject.transform.parent = transform;

            newObject.transform.position = spawnPoint;
            var facePosition = m_CameraToFace.transform.position;
            var forward = facePosition - spawnPoint;
            BurstMathUtility.ProjectOnPlane(forward, spawnNormal, out var projectedForward);
            newObject.transform.rotation = Quaternion.LookRotation(projectedForward, spawnNormal);

            if (m_ApplyRandomAngleAtSpawn)
            {
                var randomRotation = UnityEngine.Random.Range(-m_SpawnAngleRange, m_SpawnAngleRange);
                newObject.transform.Rotate(Vector3.up, randomRotation);
            }

            if (m_SpawnVisualizationPrefab != null)
            {
                var visualizationTrans = Instantiate(m_SpawnVisualizationPrefab).transform;
                visualizationTrans.position = spawnPoint;
                visualizationTrans.rotation = newObject.transform.rotation;
            }

            objectSpawned?.Invoke(newObject);
            hasSpawnedObject = true;
            return true;
        }
    }
}
