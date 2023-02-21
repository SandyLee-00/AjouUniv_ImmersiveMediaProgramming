using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//spawnedObject.transform.position = hitPose.position + Vector3.up * (spawnedObject.transform.localScale.y/2);
//


[RequireComponent(typeof(ARRaycastManager))]

public class task2 : MonoBehaviour
{

    private ARRaycastManager arRaycastManager;
    private ARPlaneManager planeManager;

    public GameObject[] objectToInstantiate;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Vector2 touchPosition;
    public float dx;
    public float dy;
    public float dz;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        planeManager.planesChanged += planesChanged;
    }
    private void OnDisable()
    {
        planeManager.planesChanged -= planesChanged;
    }

    private void planesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (ARPlane plane in args.added)
        {
            Debug.Log("Plane pos : " + plane.transform.position);
        }
    }


    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }


    void Update()
    {
        if (TryGetTouchPosition(out touchPosition))
        {
            Debug.Log("touch");
            raycastAndCreate();
        }

    }

    private void raycastAndCreate()
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);


        if (arRaycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            hitPose.position.x += dx;
            hitPose.position.y += dy;
            hitPose.position.z += dz;

            Debug.Log("hitpose : " + hitPose.position.x + hitPose.position.y + hitPose.position.z);

            int prefeb_num = Random.Range(0, 2);
            Instantiate(objectToInstantiate[prefeb_num], hitPose.position, hitPose.rotation);
        }

        //if (Physics.Raycast(ray, hits, 100))
        //{
        //    Pose hitPose = hits[0].pose;
        //    hitPose.position.x += dx;
        //    hitPose.position.y += dy;
        //    hitPose.position.z += dz;

        //    int prefeb_num = Random.Range(0, 2);
        //    Instantiate(objectToInstantiate[prefeb_num], hitPose.position, hitPose.rotation);
        //}

    }
}
