using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WProjectionRenderer : MonoBehaviour
{
    private RenderTexture _projectionTexture;
    private Camera _sourceCamera;
    private Camera _destinationCamera;

    private Wormhole _destinationWormhole;

    void Init(Camera sourceCamera, Camera destinationCamera)
    {
        this._sourceCamera = sourceCamera;
        this._destinationCamera = destinationCamera;
        _destinationWormhole = this.GetComponent<Wormhole>().linkedWormhole;
    }

    // Start is called before the first frame update
    void Start()
    {
        //RenderProjection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void RenderProjection()
    {
        CreateRenderTexture();
    }

    void CreateRenderTexture()
    {
        _projectionTexture = new RenderTexture(Screen.width, Screen.height, 0);
        _destinationCamera.targetTexture = _projectionTexture;
        _destinationWormhole.wormholeBody.material.SetTexture("_MainTex", _projectionTexture);
        
    }
}
