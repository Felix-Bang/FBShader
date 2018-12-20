Shader "Custom/WaterEffect" {
	properties{
		_MainTex("MainTex",2D) = ""{}
	}

	SubShader{
		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;	
			sampler2D _WaveTex;

			struct v2f {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				float2 uv = tex2D(_WaveTex,IN.uv).xy;

				uv = uv*2-1;
				uv *= 0.0025;
				IN.uv += uv;
				fixed4 color = tex2D(_MainTex, IN.uv);
				return color;
			}

			ENDCG
		}
	}

}
