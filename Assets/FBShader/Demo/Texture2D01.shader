Shader "Custom/Texture2D01" {
	properties{
		_MainTex("MainTex",2D) = ""{}
	}

	SubShader{
		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler _MainTex;
			float4 _MainTex_ST;   //Unity自动生成(不能省略)
			

			struct v2f {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				//o.uv = v.texcoord.xy*_MainTex_ST.xy + _MainTex_ST.zw;
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);


				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				fixed4 color = tex2D(_MainTex,IN.uv);
				return color;
			}

			ENDCG
		}
	}

}
