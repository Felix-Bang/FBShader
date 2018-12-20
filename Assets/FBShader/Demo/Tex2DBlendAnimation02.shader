// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Tex2DBlendAnimation02" {
	properties{
		_MainTex("MainTex",2D) = ""{}
		_SubTex("SubTex",2D) = ""{}
		_F("F",range(1,10))=4
	}

	SubShader{
		Pass{
			colormask rg


			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler _MainTex;
			sampler _SubTex;
			float4 _MainTex_ST;   //Unity自动生成(不能省略)
			float _F;

			struct v2f {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;			
			};

			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord.xy;		
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				fixed4 mainColor = tex2D(_MainTex, IN.uv);
				float offset_uv = 0.05 * sin(IN.uv *_F + _Time.z);

				float2 uv = IN.uv + offset_uv;
				
				fixed4 color01 = tex2D(_SubTex, uv);
				uv.y += 0.5;
				mainColor.rgb *= color01.g;
				mainColor *= 2;

				uv = IN.uv - offset_uv;
				
				fixed4 color02 = tex2D(_SubTex, uv);
				uv.y += 0.5;
				mainColor.rgb *= color02.g;
				mainColor *= 4;
				return mainColor;
			}

			ENDCG
		}
	}

}
