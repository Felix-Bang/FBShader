Shader "Custom/AlphaBlend01" {
	
	SubShader{
		Tags{"Queue" = "Transparent"}
		Pass{
			blend srcalpha oneminussrcalpha
			ZWrite off
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
			
				fixed4 color = fixed4(1,0,0,0.5);
				return color;
			}

			ENDCG
		}
	}

}
