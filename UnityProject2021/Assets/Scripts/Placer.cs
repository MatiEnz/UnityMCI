using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Placer : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public ARRaycastManager raycastManager;
    public GameObject shootingEngine;
    public GameObject AcceptScreen;
    public static Pose newOrigin;
    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private Pose placementPoseSelected;
    private bool placementPoseIsValid = false;
    private bool userPlaced = false;
    private bool userAccepted = false;
    private bool userRejected = false;

    void Start()
    {
        AcceptScreen.SetActive(false);
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        if(userPlaced == false)
        {
         UpdatePlacementPose();
         UpdatePlacementIndicator();  
        }


        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && userPlaced == false)
        {
            userPlaced = true;
            placementPoseSelected = placementPose;
            AcceptScreen.SetActive(true);
        }

        if(userPlaced && userAccepted)
        {
            PlaceObject();
            newOrigin = placementPoseSelected;
            placementIndicator.SetActive(false);
            shootingEngine.SetActive(true);
            AcceptScreen.SetActive(false);
            enabled = false;   
        }

        if(userPlaced && userRejected)
        {
           userPlaced = false;           
           AcceptScreen.SetActive(false);
           userRejected = false;
        }
    }

     public void userAccept()
    {
            userAccepted = true;
    }
     public void userReject()
    {
            userRejected = true;
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPoseSelected.position, placementPoseSelected.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {

        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
