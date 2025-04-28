using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class PlaceSpacecraft : MonoBehaviour
{
    [SerializeField] private Camera m_CameraToFace;
    [SerializeField] private GameObject spacecraftToPlace;
    [SerializeField] private bool onlyPlaceOnce = true;

    private bool hasPlaced = false;

    private void Awake()
    {
        if (m_CameraToFace == null)
            m_CameraToFace = Camera.main;

        if (spacecraftToPlace != null)
            spacecraftToPlace.SetActive(false);
    }

    public bool TryPlaceSpacecraft(Vector3 spawnPoint, Vector3 surfaceNormal)
    {
        if (onlyPlaceOnce && hasPlaced)
            return false;

        if (spacecraftToPlace == null)
        {
            Debug.LogError("No spacecraft assigned to PlaceSpacecraft.");
            return false;
        }

        spacecraftToPlace.SetActive(true);
        spacecraftToPlace.transform.position = spawnPoint + Vector3.up * 0.05f;

        var facePosition = m_CameraToFace.transform.position;
        var forward = facePosition - spawnPoint;
        BurstMathUtility.ProjectOnPlane(forward, surfaceNormal, out var projectedForward);
        spacecraftToPlace.transform.rotation = Quaternion.LookRotation(projectedForward, surfaceNormal);

        hasPlaced = true;

        return true;
    }

}
