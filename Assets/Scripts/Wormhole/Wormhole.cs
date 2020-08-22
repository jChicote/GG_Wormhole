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

    private void FixedUpdate()
    {
        _wormholeRenderer.Render();
        _cameraTracker.Reposition();
    }

    private bool CheckWhenInCameraView()
    {
        return true;
    }
}
