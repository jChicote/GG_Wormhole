using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Summary:
/*
    The purpose of this script is to position the camera relative to its
    reference object.
*/

public class WCameraPositioning : MonoBehaviour
{
    public Camera mainCamera;
    public Camera destinationCamera;
    public Transform destination;

    public void Init(Camera mainCamera, Camera linkedCamera, Transform linkedWormholeTransform)
    {
        this.destination = linkedWormholeTransform;
        this.mainCamera = mainCamera;
        this.destinationCamera = linkedCamera;
    }

    void FixedUpdate() {

        MatrixRelativeTransform();
        //SetCameraRelativePosition();
        //SetCameraRelativeRotation();
    }


    //Summary: produces relative matrix of the destination camera in world space
    //
    public void MatrixRelativeTransform()
    {
        Matrix4x4 relativeProjectionMatrix = destination.transform.localToWorldMatrix * transform.worldToLocalMatrix * mainCamera.transform.localToWorldMatrix;
        destinationCamera.transform.SetPositionAndRotation(relativeProjectionMatrix.GetColumn(3), relativeProjectionMatrix.rotation);
        Debug.Log(">> Relative position: " + relativeProjectionMatrix.GetColumn(3));
    }


    //Summary: the transform point equivalent of the matrix version.
    //
    public void SetCameraRelativePosition() {
        Vector3 relativePos = transform.InverseTransformPoint(mainCamera.transform.position);
        destinationCamera.transform.position = destination.TransformPoint(relativePos);
    }

    //Summary: the transform rotation equivalent of the matrix version.
    //
    public void SetCameraRelativeRotation() {
        Quaternion relativeRot = Quaternion.Inverse(transform.rotation) * mainCamera.transform.rotation;
        destinationCamera.transform.rotation = destination.rotation * relativeRot;
    }

    //Draws the camera relative position to parent
    //
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(destinationCamera.transform.position, 0.5f);
    }
}
