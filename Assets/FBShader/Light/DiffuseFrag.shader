Shader "Custom/DiffuseFrag"{
	properties
	{
		_MainColor("MainColor",color) = (1,1,1,1)
		_SpecularColor("SpecularColor",color) = (1,1,1,1)
		_Shininess("Shininess",range(1,64)) = 8
	}
		SubShader{

			Pass{

				Tags { "lightmode" = "forwardbase"}  //小写 否则报错：无法接受点光源 光的方向会出错

				CGPROGRAM
				#pragma multi_compile_fwdbase
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				#include "Lighting.cginc"
				#include "UnityShaderVariables.cginc"

				float4 _MainColor;
			float4 _SpecularColor;
			float _Shininess;


			struct v2f{
				float4 pos : POSITION;
				float3 normal:NORMAL;
				float4 vertex: COLOR;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);				
				o.normal = v.normal;
				o.vertex = v.vertex;
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				//Ambient Color
				fixed4 col = UNITY_LIGHTMODEL_AMBIENT;

				float3 N= UnityObjectToWorldNormal(IN.normal);
				float3 L= normalize(WorldSpaceLightDir(IN.vertex));

				//Diffuse Color
				float diffuseScale = saturate(dot(N, L));
				col += _LightColor0 * _MainColor * diffuseScale;

				//Specular Color
				float3 V = normalize(WorldSpaceViewDir(IN.vertex));
				float3 R = 2 * dot(N, L)*N - L;
				float specularScale = saturate(dot(R, V));
				col += _SpecularColor * pow(specularScale, _Shininess);

				float3 wpos = mul(unity_ObjectToWorld, IN.vertex).xyz;
				//Compute 4 points light
				col.rgb += Shade4PointLights(
					unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
					unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
					unity_4LightAtten0,
					wpos,N
				);

				return col;
			}
	
			ENDCG
		}
	}
}
