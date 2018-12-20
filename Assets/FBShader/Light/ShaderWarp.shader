// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// 扭曲
Shader "Custom/ShaderWarp" {
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
				//float angle = length(v.vertex)*_SinTime.w;
				/* 旋转绕Y轴 方法一
				float4x4 m =
				{
					float4(cos(angle),0,sin(angle),0),
					float4(0,1,0,0),
					float4(-sin(angle),0,cos(angle),0),
					float4(0,0,0,1),
				};

				float4 newVert = mul(m, v.vertex);
				*/

				/* 旋转绕Y轴方法二
				float x = cos(angle)*v.vertex.x + sin(angle)*v.vertex.z;
				float z = cos(angle)*v.vertex.z - sin(angle)*v.vertex.x;
				v.vertex.x = x;
				v.vertex.z = z;
				*/

				float angle = v.vertex.z+_Time.y;
				float4x4 m =
				{
					float4(sin(angle)/8+0.5,0,0,0),
					float4(0,1,0,0),
					float4(0,0,1,0),
					float4(0,0,0,1),
				};
				float4 newVert = mul(m, v.vertex);

				v2f o;
				// 旋转绕Y轴方法一 o.pos = UnityObjectToClipPos(newVert);
				// 旋转绕Y轴方法二 o.pos = UnityObjectToClipPos(v.vertex);
				o.pos = UnityObjectToClipPos(newVert);
				o.color = fixed4(1, 0, 0, 1);
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
