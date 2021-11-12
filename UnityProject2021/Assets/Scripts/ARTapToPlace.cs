using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARTapToPlace : MonoBehaviour
{
    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    void Start()
    {
       arOrigin = FindObjectOfType<ARSessionOrigin>();

    }


    void Update()
    {
        UpdatePlacementPose();
    }

    private void UpdatePlacementPose()
    {
    
    }
}
