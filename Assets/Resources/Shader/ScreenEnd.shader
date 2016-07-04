Shader "Unlit/ScreenEnd"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_VignetteTex("VignettexTex",2D)="white"{}
		_VisualTex("VisualTex",2D)="white"{}
		_ScreenColor("ScreenColor",Color)=(1,0,1,1)
		_Brightness ("Brightness", Range(0, 2)) = 1 
		_Contrast("Contrast",Range(0,4))=2
		_AlphaTest("AlphaTest",Range(0,8))=0.5
		_Distortion ("Distortion", Float) = 0.2
		_MainDistortion("MainDistortion",Float)=0.2  
		_Scale("Scale",Float)=0.5
		_MainScale("MainScale",Float)=0.8

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _VignetteTex;
			sampler2D _VisualTex;
			float4 _MainTex_ST;
			fixed _Brightness;
			fixed4 _ScreenColor;
			fixed _Contrast;
			fixed _AlphaTest;
			fixed _Distortion; 
			fixed _Scale;
			fixed _MainDistortion;
			fixed _MainScale;

			float2 barrelDistortion(float2 coord) 
			{    
				float2 h = coord.xy - float2(0.5, 0.5);  
                float r2 = h.x * h.x + h.y * h.y;  
                float f = 1.0 + r2 * (_MainDistortion * sqrt(r2)); 
                return f * _MainScale * h + 0.5;  
            } 

            float2 barrelDistortion2(float2 coord) 
			{    
				float2 h=coord.xy;
				return h/_Scale-(1/_Scale/2-0.5);
            } 

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				half2 distortedUV = barrelDistortion(i.uv);
				half2 distortedUV2 = barrelDistortion2(i.uv);
				fixed4 renderTex=tex2D(_MainTex,i.uv);
				fixed4 col = tex2D(_VignetteTex, distortedUV);
				fixed4 rg=tex2D(_VisualTex,distortedUV2);
				rg=pow(rg,_AlphaTest*0.5);

				fixed lum = dot(fixed3(0.299, 0.587, 0.114), renderTex.rgb); //可以将图片变成黑白色
                lum -= _Brightness;  
                fixed4 finalColor = (lum * 2) + _ScreenColor;  
                //fixed4 finalColor = _Brightness+ _ScreenColor;  
                finalColor=pow(finalColor,_Contrast*0.5);
                finalColor*=rg*col;

				return finalColor;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
