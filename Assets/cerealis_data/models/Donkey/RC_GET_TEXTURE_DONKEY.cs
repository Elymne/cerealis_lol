using UnityEngine;

public class RC_GET_TEXTURE_DONKEY : MonoBehaviour
{

    public Camera RenderCamera_1;
    public Camera RenderCamera_2;
    public Camera RenderCamera_3;

    public Material Material_1;
    public Material Material_2;
    public Material Material_3;


    [Space(20)]
    public bool FreezeEnable = false;
    private bool SkinnedMesh;

    private RenderTexture _rt;

    void Start()
    {
        if (FreezeEnable && RenderCamera_1) RenderCamera_1.enabled = false;
        if (FreezeEnable && RenderCamera_2) RenderCamera_2.enabled = false;
        if (FreezeEnable && RenderCamera_3) RenderCamera_3.enabled = false;
        if (GetComponent<SkinnedMeshRenderer>()) SkinnedMesh = true;
    }

    private void Update()
    {
        updateMaterial(RenderCamera_1, Material_1);
        //updateMaterial(RenderCamera_2, Material_2);
        updateMaterial(RenderCamera_3, Material_3);
    }

    void onGUI()
    {
        if (RenderCamera_1)
        {
            if (FreezeEnable) RenderCamera_1.enabled = false;
            else RenderCamera_1.enabled = true;
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