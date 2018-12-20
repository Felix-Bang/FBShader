// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/Cube" {
	properties{
		_Cube("CubeMap",cube) = ""{}
	}

	SubShader{
		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			samplerCUBE _Cube;

			struct v2f {
				float4 pos:POSITION;
				float3 R:TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				float3 V = -WorldSpaceViewDir(v.vertex);
				float3 N = mul(v.normal, (float3x3)unity_WorldToObject);
				N = normalize(N);
				o.R = reflect(V,N);
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				fixed4 color = texCUBE(_Cube,IN.R);
				return color;
			}

			ENDCG
		}
	}

}
