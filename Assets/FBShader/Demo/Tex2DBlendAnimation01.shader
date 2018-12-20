// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Tex2DBlendAnimation01" {
	properties{
		_MainTex("MainTex",2D) = ""{}
		_F("F",range(1,10))=4
	}

	SubShader{
		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler _MainTex;
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
				float2 uv = IN.uv;
				float offset_uv= 0.05 * sin(IN.uv *_F +_Time.x*1.5);
				uv += offset_uv;
				fixed4 color01 = tex2D(_MainTex, uv);
				uv = IN.uv;
				uv -= offset_uv;
				fixed4 color02 = tex2D(_MainTex, uv);
				fixed4 color = (color01 + color02)/2;
				return color;
			}

			ENDCG
		}
	}

}
