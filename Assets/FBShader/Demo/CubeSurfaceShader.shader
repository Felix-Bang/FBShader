Shader "Custom/CubeSurfaceShader" {
	Properties {
		_MainColor("MainColor",COLOR) = (1,1,1,1)
		_SubColor("SubColor",COLOR) = (1,1,1,1)
		_Center("Center",range(-1,1)) = 0
		_R("R",range(0,0.5)) = 0.2

		_Color ("Color", Color) = (1,1,1,1)
		//_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	
		_Cube("Cubemap",cube) = ""{}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM

		#pragma surface surf Standard  vertex:vert fullforwardshadows
		#pragma target 3.0

		fixed4 _MainColor;
		fixed4 _SubColor;
		float _Center;
		float _R;
		samplerCUBE _Cube;
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		struct Input {
			//float2 uv_MainTex;
			float x;
			float3 worldRef1;
		};

		void vert(inout appdata_full v,out Input o)
		{
			//o.uv_MainTex = v.texcoord.xy;
			o.x = v.vertex.x;
			float3 V = -WorldSpaceViewDir(v.vertex);
			float3 N = mul(v.normal, (float3x3)unity_WorldToObject);
			N = normalize(N);
			o.worldRef1 = reflect(V, N);

			
		}

		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = texCUBE (_Cube, IN.worldRef1) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;

			float d = IN.x - _Center;  
			float s = abs(d);           
			d = d / s;                 

			float f = s / _R;          
			f = saturate(f);  
			d *= f;
			d = d / 2 + 0.5; 
			o.Albedo *= lerp(_MainColor, _SubColor, d);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
