// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/SpecularShader01"{
	properties
	{
		_SpecularColor("SpecularColor",color) = (1,1,1,1)
		_Shininess("Shininess",range(1,64)) = 8
	}
	SubShader{

		Pass{

			Tags { "LightModel" = "ForwardBase"}

			CGPROGRAM
			#pragma multi_compile_fwdbase
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			float4 _SpecularColor;
			float _Shininess;
			struct v2f{
				float4 pos : POSITION;
				fixed4 color : COLOR;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);	
				float3 N = -UnityObjectToWorldNormal(v.normal);
				float3 L = normalize(_WorldSpaceLightPos0);

				//Diffuse Color
				float NDotL = saturate(dot(N,L));  //将点积的结果限定到0-1
				o.color = _LightColor0 * NDotL;

		
				//Specular Color
				float3 I = WorldSpaceLightDir(v.vertex);
				float3 R = reflect(I,N);
				float3 V = WorldSpaceViewDir(v.vertex);
				R = normalize(R);
				V = normalize(V);
				float specularScale = pow(saturate(dot(R, V)), _Shininess);
				o.color.rgb += _SpecularColor * specularScale;
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				return IN.color + UNITY_LIGHTMODEL_AMBIENT;
			}
	
			ENDCG
		}
	}
}
