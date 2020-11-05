using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTextureRenderer : MonoBehaviour
{
    public Material lensingMaterial;
    //public RenderTexture renderTexture;
    //public Shader wormholeShader;
    //public MeshRenderer meshRenderer;
    public WormholeRenderer wormholeRenderer;

    public Camera mainCam;

    public RectTransform parentCanvas;
    public Vector2 screenPos;
    public Vector4 wormholePosVect;

    public RenderTexture referenceTexture;

    public float ratio = 0.5f;

    public Transform targetWormhole;
    private Material testInstance;

    private Vector3 wormholePosition;

    private float wormholeDistance;

    private bool isViewable = false;

    private void Awake()
    {
        wormholeRenderer = targetWormhole.GetComponent<WormholeRenderer>();
        wormholeRenderer.Init(mainCam, targetWormhole, lensingMaterial);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        CheckInForwardDirection();
        FindIn2D();
        FindDistance();

        wormholeRenderer.RenderWormhole(wormholeDistance, screenPos);

        transform.LookAt(targetWormhole);
    }

    void FindIn2D()
    {
        wormholePosition = targetWormhole.position;

        screenPos = RectTransformUtility.WorldToScreenPoint(mainCam, wormholePosition);
        screenPos.x = parentCanvas.rect.width * (screenPos.x / referenceTexture.width) * 1;
        screenPos.y = parentCanvas.rect.height * (screenPos.y / referenceTexture.height) * 1;

        screenPos.x = screenPos.x / parentCanvas.rect.width;
        screenPos.y = screenPos.y / parentCanvas.rect.height;

        //Debug.Log(screenPos.x / parentCanvas.rect.width);
        //Debug.Log(">> Texture's dimensions: " + new Vector2(referenceTexture.width, referenceTexture.height));

        wormholePosVect = new Vector4(screenPos.x, screenPos.y, 0, 0);
    }

    void FindDistance()
    {
        wormholeDistance = Vector3.Magnitude(targetWormhole.position - transform.position) - targetWormhole.localScale.x;
    }

    void CheckInForwardDirection()
    {
        Vector3 wormholeDir = (targetWormhole.position - mainCam.transform.position).normalized;
        Vector3 cameraForward = mainCam.transform.forward.normalized;

        //Debug.Log(">> Bool value: " + lensingMaterial.GetFloat("_IsViewable"));
        //Debug.Log(">> Dot Product: " + Vector3.Dot(cameraForward, wormholeDir));

        if (Vector3.Dot(cameraForward, wormholeDir) > 0.3f)
        {
            isViewable = true;
            lensingMaterial.SetFloat("_IsViewable", 1);
        }
        else
        {
            isViewable = false;
            lensingMaterial.SetFloat("IsViewable", 0);
        }
    }
}
