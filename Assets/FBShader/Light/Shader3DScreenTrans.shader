Shader "Custom/Shader3DScreenTrans" {

	SubShader{

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float dis;
			float r;


			struct v2f
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
				
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
				o.pos = UnityObjectToClipPos(v.vertex);
				float x = o.pos.x / o.pos.w;
				/* 随屏幕位置变化而变化
				if (x <= -1)
					o.color = fixed4(1,0,0,1);
				else if (x >= 1)
					o.color = fixed4(0, 1, 0, 1);
				else
					o.color = fixed4(x / 2 + 0.5, x / 2 + 0.5, x / 2 + 0.5, 1);
				*/

				// 动态设置某一范围的颜色
				if (x>dis && x <= dis+r)
					o.color = fixed4(1, 0, 0, 1);
				else
					o.color = fixed4(x / 2 + 0.5, x / 2 + 0.5, x / 2 + 0.5, 1);

			

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
