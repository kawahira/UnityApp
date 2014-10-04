using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Custom/RetroPC")]
public class RetroPC : ImageEffectBase {
    public Texture textureRamp;
    public float rampOffset;
    public Vector3 colorBalance;
    public Vector3 colorDownRate;
    public int ditherMesh;
    public int ditherPattern;
    public int ditherMode;
    public bool monochrome;
    public bool compatible;
    // Called by camera to apply image effect
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        material.SetTexture("_RampTex", textureRamp);
        material.SetFloat("_RampOffset", rampOffset);
        Graphics.Blit(source, destination, material);
    }
}