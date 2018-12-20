Shader "Custom/UVAnimation02" {
	properties{
		_MainTex("MainTex",2D) = ""{}
		_F("F",range(1,30)) = 10
		_A("A",range(0,0.1)) = 0.01
		_R("R",range(0,1)) = 0
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
			float _A;
			float _R;

			struct v2f {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				//IN.uv += _Time.x;
				//IN.uv.x += 0.02 * sin(IN.uv.x * 3.14 * _F + _Time.y);
				//IN.uv.y += 0.02 * sin(IN.uv.y * 3.14 * _F + _Time.y);
				IN.uv += 0.005 * sin(IN.uv * 3.14 * _F + _Time.y);

				float2 uv = IN.uv;
				float dis = distance(uv, float2(0.5,0.5));
				float scale=0;
				
				_A *= saturate( 1- dis / _R);
				scale = _A * sin(-dis * 3.14*_F + _Time.y * 10);
				uv = uv + uv * scale;
			

				fixed4 color = tex2D(_MainTex, uv);
				return color;
			}

			ENDCG
		}
	}

}
