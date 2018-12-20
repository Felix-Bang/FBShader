// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DiffuseShader02"{

	SubShader {
		
		Pass{

			Tags { "LightModel" = "ForwardBase"}

			CGPROGRAM
			#pragma multi_compile_fwdbase
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityShaderVariables.cginc"

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
				N = normalize(N);
				
				// 方法二：将光照向量转化到局部坐标
				//L = mul(unity_WorldToObject, float4(L, 0)).xyz;

				float NDotL = saturate(dot(N,L));  //将点积的结果限定到0-1
				o.color = _LightColor0 * NDotL;
			
			    //float3 wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//o.color.rgb = ShadeVertexLights(v.vertex,v.normal);
				/*o.color.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
					unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
					unity_4LightAtten0,
					wpos,
					N); 点光源不成功*/

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
