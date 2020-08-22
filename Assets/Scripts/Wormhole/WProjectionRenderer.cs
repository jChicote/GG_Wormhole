using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NOTES:
 * - Needs to cull wormhole when not in view.
 * 
 */


public class WProjectionRenderer : MonoBehaviour
{
    private RenderTexture _renderTexture;
    private Camera _sourceCamera;
    private Camera _destinationCamera;
    private MeshRenderer _sourceWormholeMesh;

    private Wormhole _destinationWormhole;

    public void Init(Camera sourceCamera, Camera destinationCamera, MeshRenderer sourceWormholeMesh)
    {
        this._destinationCamera = destinationCamera;
        this._sourceWormholeMesh = sourceWormholeMesh;
        this._sourceCamera = sourceCamera;
        _destinationWormhole = this.GetComponent<Wormhole>().linkedWormhole;
        _sourceWormholeMesh.material.SetInt("displayMask", 1);
        Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        //RenderProjection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Render();
    }

    void Render()
    {
        //_sourceWormholeMesh.enabled = false;

        CreateRenderTexture();

        _destinationWormhole.wormholeBody.material.SetInt("displayMask", 0);
        _sourceCamera.Render();
        _destinationWormhole.wormholeBody.material.SetInt("displayMask", 1);

        //_sourceWormholeMesh.enabled = true;
    }

    void CreateRenderTexture()
    {
        if (_renderTexture == null || _renderTexture.width != Screen.width || _renderTexture.height != Screen.height)
        {
            if (_renderTexture != null)
            {
                _renderTexture.Release();
            }

            _renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
            _destinationCamera.targetTexture = _renderTexture;

            _sourceWormholeMesh.material.SetTexture("_MainTex", _renderTexture);
        }
    }
}
