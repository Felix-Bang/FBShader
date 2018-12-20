// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/UVAnimation03" {
	properties{
		_MainTex("MainTex",2D) = ""{}
		_BlurryX("BlurryX",range(0,0.1)) = 0.01
		_BlurryY("BlurryY",range(0,0.1)) = 0.01
	}

	SubShader{
		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#include "UnityCG.cginc"
			
			sampler _MainTex;
			float4 _MainTex_ST;   //Unity自动生成(不能省略)
			float _BlurryX;
			float _BlurryY;

			struct v2f {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
				float z : TEXCOORD1;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.z = mul(unity_ObjectToWorld, v.vertex).z;
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				//模糊
			
				/*方法一
				float2 uv = IN.uv;
				fixed4 color = tex2D(_MainTex, uv);
				uv.x = IN.uv.x + _BlurryX;
				color.rgb += tex2D(_MainTex,uv);
				uv.x = IN.uv.x - _BlurryX;
				color.rgb += tex2D(_MainTex, uv);
				uv.y = IN.uv.y + _BlurryY;
				color.rgb += tex2D(_MainTex, uv);
				uv.y = IN.uv.y - _BlurryY;
				color.rgb += tex2D(_MainTex, uv);

				color.rgb /= 5;
				*/

				//方法二
				//fixed4 color = tex2D(_MainTex, IN.uv,float2(_BlurryX,_BlurryX),float2(_BlurryY,_BlurryY));
				//方法三
				/*
				float dx = ddx(IN.uv.x)*10;
				float2 dssx = float2(dx,dx);
				float dy = ddx(IN.uv.y);
				float2 dssy = float2(dy, dy) * 10;
				fixed4 color = tex2D(_MainTex, IN.uv, dssx, dssy);
				*/

				//绕z轴旋转动态模糊
				float2 dsdx = ddx(IN.z) * 10;
				float2 dsdy = ddx(IN.z) * 10;
				fixed4 color = tex2D(_MainTex, IN.uv, dsdx, dsdy);
				return color;
			}

			ENDCG
		}
	}

}
