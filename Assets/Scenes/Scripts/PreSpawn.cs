using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PreSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject prefabBody;
    [SerializeField] 
    public GameObject prefabRight;
    [SerializeField] 
    public GameObject prefabLeft;
    [SerializeField]
    private ARRaycastManager raycastManager;
    //private ARPlaneManager planeManager;

    Camera arCam;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedBody = null;
    private GameObject spawnedRight = null;
    private GameObject spawnedLeft = null;

    // Start is called before the first frame update
    void Start()
    {
        arCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
        {
            if (spawnedBody == null)
            {
                Pose hitPose = hits[0].pose;
                Vector3 camPosition = arCam.transform.position;
                Vector3 camForward = arCam.transform.forward;
                Quaternion camRotation = arCam.transform.rotation;
                Vector3 spawnPosition = camPosition + camForward * 1.5f + new Vector3(0, 0.3f, 0); // spawn the prefab away from the camera
                Vector3 spawnPosition2 = camPosition + camForward * 1.5f + new Vector3(0.5f, 0, 1f);
                Vector3 spawnPosition3 = camPosition + camForward * 1.5f + new Vector3(1.5f, 0.75f, 0);

                spawnedBody = Instantiate(prefabBody, spawnPosition, camRotation);
                spawnedRight = Instantiate(prefabRight, spawnPosition2, camRotation);
                spawnedLeft = Instantiate(prefabLeft, spawnPosition3, camRotation);

                spawnedBody.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                spawnedRight.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                spawnedLeft.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                // spawnedObject.transform.position = new Vector3(0, 0.3f, 0);

                spawnedBody.transform.rotation = Quaternion.Euler(0, 0, 90);
                spawnedRight.transform.rotation = Quaternion.Euler(0, 0, 90);
                spawnedLeft.transform.rotation = Quaternion.Euler(0, 0, 90);

/*                Collider objectCollider = spawnedBody.GetComponent<Collider>();
                if (objectCollider != null)
                {
                    objectCollider.enabled = false; // Disable the collider temporarily
                }

                // Check for Rigidbody and disable gravity or constraints
                Rigidbody objectRigidbody = spawnedBody.GetComponent<Rigidbody>();
                if (objectRigidbody != null)
                {
                    objectRigidbody.useGravity = false; // Disable gravity to prevent falling
                    objectRigidbody.isKinematic = true; // Make the object kinematic to avoid physics interactions
                }*/
            }
        }
    }
}
