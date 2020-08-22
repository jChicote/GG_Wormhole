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
    public Camera sourceCamera;
    public Camera destinationCamera;

    public Transform sourceBody;
    public Transform destinationTransform;

    Matrix4x4 relativeProjectionMatrix;

    public void Init(Camera mainCamera, Camera localCamera, Camera linkedCamera, Transform linkedWormholeTransform, Transform destinationTransform)
    {
        this.sourceBody = linkedWormholeTransform;
        this.mainCamera = mainCamera;
        this.sourceCamera = localCamera;
        this.destinationCamera = linkedCamera;
        this.destinationTransform = destinationTransform;
    }

    public void Reposition() {

        MatrixRelativeTransform();
        //SetCameraRelativePosition();
        //SetCameraRelativeRotation();
    }


    //Summary: produces relative matrix of the destination camera in world space
    //
    public void MatrixRelativeTransform()
    {
        relativeProjectionMatrix = destinationTransform.transform.localToWorldMatrix * transform.worldToLocalMatrix * mainCamera.transform.localToWorldMatrix;
        destinationCamera.transform.SetPositionAndRotation(relativeProjectionMatrix.GetColumn(3), relativeProjectionMatrix.rotation);
        //Debug.Log(">> Relative position: " + relativeProjectionMatrix.GetColumn(3));
    }

    //NOTICE:
    /*
     * 
     * Transform point calculation won't be used in final ver but do
     * address the understanding of the logic associated with camera 
     * positioning.
     */

    //Summary: the transform point equivalent of the matrix version.
    //
    public void SetCameraRelativePosition() {
        Vector3 relativePos = transform.InverseTransformPoint(mainCamera.transform.position);
        destinationCamera.transform.position = destinationTransform.TransformPoint(relativePos);
    }

    //Summary: the transform rotation equivalent of the matrix version.
    //
    public void SetCameraRelativeRotation() {
        Quaternion relativeRot = Quaternion.Inverse(transform.rotation) * mainCamera.transform.rotation;
        destinationCamera.transform.rotation = sourceBody.rotation * relativeRot;
    }

    //Draws the camera relative position to parent
    //
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(sourceCamera.transform.position, 0.5f);
    }
}
