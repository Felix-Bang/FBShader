// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Shader3DColorChange" {

	SubShader{

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float4x4 mvp;


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
				
				//根据自身坐标显示不同颜色
				if (v.vertex.x > 0)
					o.color = fixed4(1,0,0,1);
				else
					o.color = fixed4(0, 1, 0, 1);

				//随时间变化
				if (v.vertex.x == 0.5 && v.vertex.y == 0.5 && v.vertex.z == -0.5)
					o.color = fixed4(_SinTime.y / 2 + 0.5, _CosTime.w / 2 + 0.5, _SinTime.w / 2 + 0.5, 1);
				
				/* 在世界坐标中的变化
				float4 wpos = mul(unity_ObjectToWorld, v.vertex);
				if (wpos.x > 0)
					o.color = fixed4(1, 0, 0, 1);
				else
					o.color = fixed4(0, 1, 0, 1);
				*/

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
