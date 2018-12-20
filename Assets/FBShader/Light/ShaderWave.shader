// 扭曲
Shader "Custom/ShaderWave" {
	SubShader {
		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
				
			};

			v2f vert(appdata_base v)
			{
				
				// A*sin(w*x+t)  波形公式
				//横波
				//v.vertex.y += 0.2*sin(v.vertex.x * 0.5 + _Time.y);
				//纵波
				//v.vertex.y += 0.2*sin(v.vertex.z * 0.5 + _Time.y);
				//斜波
				//v.vertex.y += 0.2*sin((v.vertex.x + v.vertex.z)* 0.5 + _Time.y);
				//水波
				v.vertex.y += 0.2*sin((v.vertex.x + v.vertex.z) + _Time.y);
				v.vertex.y += 0.3*sin((v.vertex.x + v.vertex.z)* 1 + _Time.w);

				//由外向内圆形波
				//v.vertex.y += 0.2*sin(length(v.vertex.xz) * 0.5 + _Time.y);
				//由内向外圆形波
				//v.vertex.y += 0.2*sin(-length(v.vertex.xz) * 1 + _Time.y);
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = fixed4(v.vertex.y, v.vertex.y, v.vertex.y, 1);
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				return IN.color;
			}
			ENDCG
		}

		
	}
	
}
