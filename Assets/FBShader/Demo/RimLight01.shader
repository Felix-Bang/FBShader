Shader "Custom/RimLight01" {
	properties{
		_Shininess("Shininess",range(1,8)) = 2
	}

	SubShader{
		Tags{"queue"="transparent"}

		Pass{
			Blend SrcAlpha OneMinusSrcAlpha
			zwrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float _Shininess;

			struct v2f {
				float4 pos:POSITION;
				float3 normal:TEXCOORD0;
				float4 vertex:TEXCOORD1;

			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				o.vertex = v.vertex;
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				float3 N = UnityObjectToWorldNormal(IN.normal);
				float3 V = normalize(WorldSpaceViewDir(IN.vertex));

				float bright = 1 - saturate(dot(N, V));
				bright = pow(bright, _Shininess);
				return fixed4(1, 1, 1, 1)*bright;
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
