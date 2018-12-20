Shader "Custom/ColorChangeSurfaceShader" {
	Properties {
		_MainColor("MainColor",COLOR) = (1,1,1,1)
		_SubColor("SubColor",COLOR) = (1,1,1,1)
		_Center("Center",range(-1,1)) = 0
		_R("R",range(0,0.5)) = 0.2

		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
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
		sampler2D _MainTex;
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		struct Input {
			float2 uv_MainTex;
			float x;
		};

		void vert(inout appdata_full v,out Input o)
		{
			o.uv_MainTex = v.texcoord.xy;
			o.x = v.vertex.x;
		}

		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
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
