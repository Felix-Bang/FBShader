Shader "Custom/AlphaBlend03" {
	
	SubShader{
		Tags{"Queue" = "Transparent"}
		//用于显示被遮挡的部分
		Pass{
			blend srcalpha oneminussrcalpha
			//防止第二次渲染覆盖第一次渲染 
			//方法一 第一次ZWrite off 
			//方法二 第二次渲染ZTest less
			ZWrite off 
			ZTest greater     //渲染挡住部分

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
		
			struct v2f {
				float4 pos:POSITION;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				fixed4 color = fixed4(1,1,0,0.5);
				return color;
			}

			ENDCG
		}

		//用于显示未被遮挡的部分
		Pass{
			ZWrite on  //默认
			ZTest lequal   //渲染未挡住部分

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f {
				float4 pos:POSITION;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				fixed4 color = fixed4(1,0,0,1);
				return color;
			}

			ENDCG
		}
	}

}
