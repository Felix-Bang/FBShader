Shader "Custom/RimLight02" {
	properties{
		_MainColor("MainColor",COLOR) = (1,1,1,1)
		_Shininess("Shininess",range(1,8)) = 2
		_Outer("Outer",range(0,1)) = 0.1
	}

	SubShader{
		Tags{"queue" = "transparent"}

		Pass{
			Blend SrcAlpha OneMinusSrcAlpha
			zwrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
		
			fixed4 _MainColor;
			float _Shininess;
			float _Outer;
			struct v2f {
				float4 pos:POSITION;
				float3 normal:TEXCOORD0;
				float4 vertex:TEXCOORD1;
			};

			v2f vert(appdata_base v)
			{
				v.vertex.xyz += v.normal*_Outer;

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

				float bright = saturate(dot(N, V));  //向外衰减
				bright = pow(bright, _Shininess);
				_MainColor.a *= bright;
				return _MainColor;
			}

			ENDCG
		}
		//=======================================================
			Pass{
			BlendOp RevSub
			Blend DstAlpha One
			zwrite off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			fixed4 _MainColor;

			struct v2f {
				float4 pos:POSITION;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);		
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				return _MainColor;
			}

			ENDCG
		}

		//=======================================================
		Pass{
			Blend SrcAlpha OneMinusSrcAlpha
			zwrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			fixed4 _MainColor;
			float _Shininess;
			float _Outer;
			struct v2f {
				float4 pos:POSITION;
				float3 normal:TEXCOORD0;
				float4 vertex:TEXCOORD1;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				o.vertex = v.vertex;
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				float3 N = UnityObjectToWorldNormal(IN.normal);
				float3 V = normalize(WorldSpaceViewDir(IN.vertex));

				float bright = 1- saturate(dot(N, V));  //向内衰减
				bright = pow(bright, _Shininess);
				return _MainColor * bright;
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
