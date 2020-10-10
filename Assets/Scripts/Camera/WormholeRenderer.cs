using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormholeRenderer : MonoBehaviour
{
    public float maxTurnAngle = 3.6f;
    public float maxLatitude = 1.8f;

    private Camera mainCamera;
    private Transform wormholeTransform;
    private Material wormholeMaterial;

    private Vector3 wormholePosition;
    private Vector3 cameraPosition;
    private Vector2 relativeCylindricalPos;
    private Vector3 relativeSphericalPos;

    private float cylindricalAngle;
    private float elevationAngle;
    private float longitudeValue;
    private float latitudeValue;


    public void Init(Camera camera, Transform wormholeTransform, Material material)
    {
        this.mainCamera = camera;
        this.wormholeMaterial = material;
        this.wormholeTransform = wormholeTransform;
    }

    // 3.6 is the max
    // 0 is the min

    public void SetProjectionLongitude()
    {
        wormholePosition = wormholeTransform.position;
        cameraPosition = mainCamera.transform.position;

        relativeCylindricalPos = new Vector3(cameraPosition.x - wormholePosition.x, cameraPosition.z - wormholePosition.z);

        cylindricalAngle = Mathf.Atan(relativeCylindricalPos.y / relativeCylindricalPos.x);
        //Debug.Log(">> relative pos at: " + relativeCylindricalPos + ", camera POs at: " + cameraPosition + ", cylindricalAngle at: " + cylindricalAngle * Mathf.Rad2Deg);
        longitudeValue = (cylindricalAngle * Mathf.Rad2Deg / 100) * maxTurnAngle;
        //Debug.Log(">> Longitude at: " + longitudeValue + ", cylindricalAngle at: " + cylindricalAngle);

        wormholeMaterial.SetFloat("_Longitude", longitudeValue);
    }

    // 3.6 is the max
    // 0 is the min

    public void SetProjectionLatitude()
    {
        wormholePosition = wormholeTransform.position;
        cameraPosition = mainCamera.transform.position;

        //relativeCylindricalPos = new Vector3(cameraPosition.x - wormholePosition.x, cameraPosition.y - wormholePosition.y);

        relativeSphericalPos = new Vector3(cameraPosition.x - wormholePosition.x, cameraPosition.y - wormholePosition.y, cameraPosition.z - wormholePosition.z);
        //elevationAngle = Mathf.Atan((Mathf.Sqrt(Mathf.Pow(relativeSphericalPos.x, 2)) + Mathf.Sqrt(Mathf.Pow(relativeSphericalPos.y, 2))) / relativeSphericalPos.z);

        Vector2 relativePos = new Vector2(cameraPosition.x - wormholePosition.x, cameraPosition.z - wormholePosition.z);
        float relativeElevation = cameraPosition.y - wormholePosition.y;

        int negPosValue = relativeElevation > 0 ? 1 : -1;

        float distance = Vector3.Distance(wormholePosition, cameraPosition);

        elevationAngle = Mathf.Acos(Vector2.Distance(Vector2.zero, relativePos)/ distance) * negPosValue;
        Debug.Log(">> Latitude at: " + elevationAngle);

        //elevationAngle = Mathf.Atan(relativeCylindricalPos.y / relativeCylindricalPos.x);
        latitudeValue = (elevationAngle * Mathf.Rad2Deg / 100) * maxLatitude;

        wormholeMaterial.SetFloat("_Latitude", latitudeValue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
