using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Summary:
/*
    The purpose of this script is to position the camera relative
    to the wormhole transform. This also mimics the instance of
    the main camera, ensuring matching projections of the scene.
*/

public class ProjectionCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera sourceCamera;

    public Camera destinationCamera;
    public Transform destination;

    public GameObject wormholeSphere;


    void Start() 
    {
        mainCamera = GameManager.instance.mainCamera;
        sourceCamera = this.gameObject.GetComponentInChildren<Camera>();
    }

    void FixedUpdate() {
        SetCameraRelativePosition();
    }

    public void SetCameraRelativePosition() {
        Vector3 relativePos = transform.InverseTransformPoint(mainCamera.transform.position);
        destinationCamera.transform.position = destination.TransformPoint(relativePos);
    }

    //Draws the camera relative position to parent
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(destinationCamera.transform.position, 0.5f);
    }
}
