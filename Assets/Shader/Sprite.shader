Shader "Unlit/Sprite"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Cutoff("Cutoff Value",Range(0,1))=0.5
		_MainColor("MainColor",Color)=(0.1,0.3,0.9,1)

		// required for UI.Mask
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			// required for UI.Mask
	        Stencil
	        {
	            Ref  [_Stencil]
	            Comp [_StencilComp]
	            Pass [_StencilOp] 
	            ReadMask [_StencilReadMask]
	            WriteMask [_StencilWriteMask]
	        }
	        ColorMask [_ColorMask]


			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{ 
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color:COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float4 color:COLOR;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainColor;
			float _Cutoff;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.color=v.color*_MainColor;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 cc=i.color;
				cc.a=0;
				fixed4 col = tex2D(_MainTex, i.uv);
				cc.a*=tex2D(_MainTex, i.uv).a;
				cc.rgb*=col.rgb;
				UNITY_OPAQUE_ALPHA(cc.a);
				//cc.r*=cc.a;
				//cc.rgb=col.rgb*_MainColor.rgb*_Cutoff;
				//float cc=dot(col.xyz,_MainColor.rgb);
				//col.xyz=float3(cc,cc,cc);
				return cc;
			}
			ENDCG
		}
	}
}
