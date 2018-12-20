// 改变定点位置信息改变
Shader "Custom/ShaderVertChange" {
	Properties
	{
		_R("R",range(0,5)) = 1
		_OX("OX",range(-5,5)) = 0
	}


	SubShader{

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float dis;
			float r;
			float _R;
			float _OX;
			struct v2f
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
				
			};

			v2f vert(appdata_base v)
			{
				float4 wpos = mul(unity_ObjectToWorld, v.vertex);


				// 顶点位置变化在转化之前进行
				float2 xy = wpos.xz;
				float d = _R - length(xy-float2(_OX,0));  //计算xy到圆心的长度
				d = d < 0 ? 0 : d;
				float height = 1;
				float4 uppos = float4(v.vertex.x, height*d, v.vertex.z, v.vertex.w);
				v2f o;
				// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
				// 变化不可逆
				o.pos = UnityObjectToClipPos(uppos);
				o.color = fixed4(uppos.y, uppos.y, uppos.y, 1);
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
