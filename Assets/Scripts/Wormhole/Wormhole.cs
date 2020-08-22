using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public Wormhole linkedWormhole;
    public Camera mainCamera;

    //Public variables for projection
    public Camera localCamera;
    public MeshRenderer wormholeBody;

    //Private Variables
    private WCameraPositioning _cameraTracker;
    private WProjectionRenderer _wormholeRenderer;

    void Awake()
    {
        this.wormholeBody = this.GetComponent<MeshRenderer>();
        this.localCamera = this.GetComponentInChildren<Camera>();
        this._cameraTracker = this.gameObject.AddComponent<WCameraPositioning>();
        this._wormholeRenderer = this.gameObject.GetComponent<WProjectionRenderer>();

        _cameraTracker.Init(mainCamera, localCamera, linkedWormhole.localCamera, transform, linkedWormhole.transform);
        _wormholeRenderer.Init(localCamera, linkedWormhole.localCamera, wormholeBody);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //CullWhenOutsideView();
    }

    void CullWhenOutsideView()
    {
        Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward);
        Vector3 dirToWormhole = transform.position - mainCamera.transform.position;

        if (Vector3.Dot(forward, dirToWormhole) > 0f)
        {
            wormholeBody.material.SetInt("displayMask", 1);
        } else
        {
            wormholeBody.material.SetInt("displayMask", 0);
        }
    }

}
