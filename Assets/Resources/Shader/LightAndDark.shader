Shader "Custom/LightAndDark" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Speed ("Speed", Range(0,10)) = 2
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed _Speed;
		fixed4 _Color;


		void surf (Input IN, inout SurfaceOutput o) {
			float changeValue = _Speed * _Time * 1000000000;

			fixed4 c;

			if(int(changeValue)%2==0)
				c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			else
				c = _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
