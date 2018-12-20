// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/SpecularBlinnPhongShader"{
	properties
	{
		_SpecularColor("SpecularColor",color) = (1,1,1,1)
		_Shininess("Shininess",range(1,64)) = 8
	}
	SubShader{

		Pass{

			Tags { "lightmode" = "forwardbase"}

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
				float3 N = UnityObjectToWorldNormal(v.normal);
				float3 L = -normalize(WorldSpaceLightDir(v.vertex));
				float3 V = normalize(WorldSpaceViewDir(v.vertex));
				//AMBIENT Color
				o.color = UNITY_LIGHTMODEL_AMBIENT;

				//Diffuse Color
				float NDotL = saturate(dot(N,L));  //将点积的结果限定到0-1
				o.color += _LightColor0 * NDotL;
						
				//Specular Color
				float3 H = L + V;
				
				H = normalize(H);
			
				float specularScale = pow(saturate(dot(H, N)), _Shininess);
				o.color.rgb += _SpecularColor * specularScale;
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				return IN.color;
			}
	
			ENDCG
		}
	}
}
