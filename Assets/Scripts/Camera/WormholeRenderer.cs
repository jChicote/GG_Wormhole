using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class WormholeRenderer : MonoBehaviour
{
    [Header("Primary Variables")]
    public bool isViewable = true;

    [Header("Azimuthal Position")]
    public float maxTurnAngle = 3.6f;
    public float maxLatitude = 1.8f;

    [Header("Azimuthal Camera Projection")]
    public Camera azimuthalCamera;
    public RenderTexture azimuthalRenderEquirect;
    private RenderTexture cameraCubemap;

    [Header("Wormhole Attributes")]
    public float lensingRadius;
    public float wormholeRadius;
    public float aspectRatio = 0.5f;

    //[Header("Switches")]
    //public bool isModifiable;

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

    void Awake()
    {
        cameraCubemap = new RenderTexture(1024, 1024, 24, RenderTextureFormat.ARGB32);
        cameraCubemap.dimension = TextureDimension.Cube;
    }


    public void Init(Camera camera, Transform wormholeTransform, Material material)
    {
        this.mainCamera = camera;
        this.wormholeMaterial = material;
        this.wormholeTransform = wormholeTransform;
    }

    public void RenderWormhole(float distanceToCam, Vector2 screenPosition)
    {
        ApplyAttributes(distanceToCam, screenPosition);
        SetProjectionLongitude();
        SetProjectionLatitude();
    }

    public void ApplyAttributes(float distanceToCam, Vector2 screenPosition)
    {
        wormholeMaterial.SetFloat("_Ratio", aspectRatio);
        wormholeMaterial.SetVector("_Position", screenPosition);
        wormholeMaterial.SetFloat("_Distance", distanceToCam);
        wormholeMaterial.SetFloat("_LensingRadius", lensingRadius);
        wormholeMaterial.SetFloat("_WormholeRadius", wormholeRadius);
    }

    private void FixedUpdate()
    {
        CheckIsInView();
        SetEquirectangularCameraTexture();
    }

    //Deprecated as OnRenderImage throws error, resorted to FixedUpdate instead
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //SetEquirectangularCameraTexture();
    }

    /// <summary>
    /// Calculates the dot product from the wormhole to the camera
    /// </summary>
    public void CheckIsInView()
    {
        Vector3 wormholeDir = (transform.position - mainCamera.transform.position).normalized;
        Vector3 cameraForward = mainCamera.transform.forward.normalized;

        if (Vector3.Dot(cameraForward, wormholeDir) > 0.3f)
        {
            isViewable = true;
            wormholeMaterial.SetFloat("_IsViewable", 1);
        }
        else
        {
            isViewable = false;
            wormholeMaterial.SetFloat("IsViewable", 0);
        }
    }

    public void SetEquirectangularCameraTexture()
    {
        if (!isViewable) return;
        azimuthalCamera.RenderToCubemap(cameraCubemap, 63, Camera.MonoOrStereoscopicEye.Mono);
        cameraCubemap.ConvertToEquirect(azimuthalRenderEquirect, Camera.MonoOrStereoscopicEye.Mono);
    }

    //Summary: This sets the longitude of the projection
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

    // Summary: This sets the latitude of the projection
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
        //Debug.Log(">> Latitude at: " + elevationAngle);
        //elevationAngle = Mathf.Atan(relativeCylindricalPos.y / relativeCylindricalPos.x);
        latitudeValue = (elevationAngle * Mathf.Rad2Deg / 100) * maxLatitude;

        wormholeMaterial.SetFloat("_Latitude", latitudeValue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, wormholeRadius);
    }
}
