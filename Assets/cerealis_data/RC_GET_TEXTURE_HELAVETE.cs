using UnityEngine;

public class RC_GET_TEXTURE_HELAVETE : MonoBehaviour
{
    public Camera RenderCamera_3;
    public Material Material_3;


    [Space(20)]
    public bool FreezeEnable = false;
    private bool SkinnedMesh;

    private RenderTexture _rt;

    void Start()
    {
        if (FreezeEnable && RenderCamera_3) RenderCamera_3.enabled = false;
        if (GetComponent<SkinnedMeshRenderer>()) SkinnedMesh = true;
    }

    private void Update()
    {
        updateMaterial(RenderCamera_3, Material_3);
    }

    void onGUI()
    {
        if (RenderCamera_3)
        {
            if (FreezeEnable) RenderCamera_3.enabled = false;
            else RenderCamera_3.enabled = true;
        }
    }

    private void updateMaterial(Camera RenderCamera, Material Material)
    {
        if (!RenderCamera) return;

        if (!_rt && RenderCamera.targetTexture)
        {
            _rt = RenderCamera.targetTexture;

            if (SkinnedMesh) Material.SetTexture("_MainTex", RenderCamera.targetTexture);
            else Material.SetTexture("_MainTex", RenderCamera.targetTexture);
        }

        if (_rt && _rt != RenderCamera.targetTexture) Destroy(_rt);
    }
}