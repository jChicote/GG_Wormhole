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

    private Wormhole _linkedWormhole;

    public void Init(Camera sourceCamera, Camera destinationCamera, MeshRenderer sourceWormholeMesh)
    {
        this._destinationCamera = destinationCamera;
        this._sourceWormholeMesh = sourceWormholeMesh;
        this._sourceCamera = sourceCamera;
        _linkedWormhole = this.GetComponent<Wormhole>().linkedWormhole;
        _sourceWormholeMesh.material.SetInt("displayMask", 1);

        _destinationCamera.enabled = false;
    }

    public void Render()
    {
        CreateRenderTexture();

        _linkedWormhole.wormholeBody.enabled = false;
        _destinationCamera.Render();
        _linkedWormhole.wormholeBody.enabled = true;
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
