using UnityEngine;
using System.Collections;

public class ScreenEnd : MonoBehaviour {
	
	#region
	private Material curMaterial;
	public Shader screenEnd;
	public Texture2D vignetteTexture;
	public Texture2D visualTexture;
	public float contrast=2.0f;
	public float brightness=1.0f;
	public float alphaTest=0.5f;
	public float distortion = 0.2f;
	public float maindistortion=0.2f;
	public float scale = 0.8f;  
	public float mainscale=0.8f;
	public Color ScreenColor=Color.white;
	#endregion

	#region Properties
	public Material material
	{
		get 
		{
			if(curMaterial==null)
			{
				curMaterial=new Material(screenEnd);
				curMaterial.hideFlags=HideFlags.HideAndDontSave;
			}
			return curMaterial;
		}
	}
	#endregion

	// Use this for initialization
	void Start () {
		if (SystemInfo.supportsImageEffects == false) {  
			enabled = false;  
			return;  
		}  

		if (screenEnd != null && screenEnd.isSupported == false) {  
			enabled = false;  
		}  
	}

	void OnRenderImage(RenderTexture sourceTexture,RenderTexture destTexture)
	{
		if(screenEnd!=null)
		{
			material.SetColor ("_ScreenColor",ScreenColor);
			material.SetFloat ("_Contrast",contrast);
			material.SetFloat ("_Brightness",brightness);
			material.SetFloat ("_AlphaTest",alphaTest);
			material.SetFloat ("_Distortion",distortion);
			material.SetFloat ("_Scale",scale);
			material.SetFloat ("_MainDistortion",maindistortion);
			material.SetFloat ("_MainScale",mainscale);
			if (vignetteTexture) 
			{
				material.SetTexture ("_VignetteTex",vignetteTexture);
			}
			if(visualTexture)
			{
				material.SetTexture ("_VisualTex",visualTexture);
			}
			Graphics.Blit (sourceTexture,destTexture,material);
		}
		else{}
	}
	
	// Update is called once per frame
	void Update () {
		contrast = Mathf.Clamp (contrast,0.0f,4.0f);
		brightness = Mathf.Clamp (brightness,0.0f,2.0f);
		alphaTest = Mathf.Clamp (alphaTest,0.0f,8.0f);
	}

	void OnDisable()
	{
		if(curMaterial!=null)
		{
			Destroy (curMaterial);
		}
	}
}
