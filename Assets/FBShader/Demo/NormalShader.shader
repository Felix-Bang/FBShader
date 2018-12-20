Shader "Custom/NormalShader"{
	Properties{
	_BumpTex("NoramalMap",2D) = ""{}
	}
	SubShader {
		Tags { "queue" = "Geometry"}
		Pass{
			Tags { "LightModel" = "ForwardBase"}

			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			
			sampler2D _BumpTex;

			struct v2f{
				float4 pos : POSITION;
				float2 uv:TEXCOORD0;
				float3 wpos:TEXCOORD1;
				float3 lightDir:TEXCOORD2;
			};

			v2f vert(appdata_tan v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);				
			    o.wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = v.texcoord.xy;
				//float3 BNormal = cross(v.tangent.xyz, v.normal);
				//float3x3 rotation = float3x3(v.tangent.xyz, BNormal, v.normal);
				TANGENT_SPACE_ROTATION;
				o.lightDir = mul(rotation, _WorldSpaceLightPos0.xyz);
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				float3 L = normalize(IN.lightDir);
				float3 N = UnpackNormal(tex2D(_BumpTex, IN.uv));
				N = normalize(N);
				float NDotL = saturate(dot(N,L));
				fixed4 col = _LightColor0 * NDotL;
				col.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
					unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
					unity_4LightAtten0,
					IN.wpos,
					N);

				return col + UNITY_LIGHTMODEL_AMBIENT;
			}
	
			ENDCG
		}
		//----------------------------------
		Pass{
			Tags { "LightModel" = "ForwardAdd"}
			//Blend one one 

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			sampler2D _BumpTex;

			struct v2f {
				float4 pos : POSITION;
				float2 uv:TEXCOORD0;
				float3 wpos:TEXCOORD1;
				float3 lightDir:TEXCOORD2;
			};

			v2f vert(appdata_tan v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = v.texcoord.xy;
	
				TANGENT_SPACE_ROTATION;
				o.lightDir = mul(rotation, _WorldSpaceLightPos0.xyz);
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				float3 L = normalize(IN.lightDir);
				float3 N = UnpackNormal(tex2D(_BumpTex, IN.uv));
				N = normalize(N);
				float NDotL = saturate(dot(N,L));
				
				
				float atten = 1;
				if (_WorldSpaceLightPos0.w != 0)
				{
					atten = 1.0 / length(IN.lightDir);
				}
				fixed4 col = _LightColor0 * NDotL*atten;

				col.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
					unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
					unity_4LightAtten0,
					IN.wpos,
					N);


				return col + UNITY_LIGHTMODEL_AMBIENT;
			}

			ENDCG
		}
	}
}
