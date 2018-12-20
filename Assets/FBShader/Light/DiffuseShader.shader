// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DiffuseShader"{

	SubShader {
		
		Pass{

			Tags { "LightModel" = "ForwardBase"}

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			struct v2f{
				float4 pos : POSITION;
				fixed4 color : COLOR;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);				
				float3 N = normalize(v.normal);
				float3 L = normalize(_WorldSpaceLightPos0);
				// 点积要求：法向量与光照向量处于同一个空间坐标系
				
				// 方法一：
				// 等比缩放 法向量局部到世界的变换
				// N = mul(unity_ObjectToWorld,float4(N,0)).xyz;
				// 非等比缩放 法向量局部到世界的变换
				N = mul(float4(N, 0),unity_WorldToObject).xyz;
				N = -normalize(N);
				// 方法二：将光照向量转化到局部坐标
				//L = mul(unity_WorldToObject, float4(L, 0)).xyz;

				float NDotL = saturate(dot(N,L));  //将点积的结果限定到0-1
				o.color = _LightColor0 * NDotL;


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
