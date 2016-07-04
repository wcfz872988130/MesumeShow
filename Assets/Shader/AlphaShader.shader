Shader "Cookbook/SimpleAlpha" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainColor("MainColor",Color)=(0.1,0.3,0.9,1)
		_TransVal ("Transparency Value", Range(0,1)) = 0.5
	}
	
	SubShader 
	{
		Tags { "RenderType"="Opaque"}
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		float _TransVal;
		float4 _MainColor;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c;
			//o.Albedo = c.rgb*_MainColor.rgb;
			o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb*_MainColor;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
