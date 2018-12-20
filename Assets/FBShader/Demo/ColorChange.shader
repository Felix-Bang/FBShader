Shader "Custom/ColorChange" {
	properties{
		_MainColor("MainColor",COLOR) = (1,1,1,1)
		_SubColor("SubColor",COLOR) = (1,1,1,1)
		_Center("Center",range(-1,1)) = 0
		_R("R",range(0,0.5)) = 0.2
	}

	SubShader{
		

		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			fixed4 _MainColor;
			fixed4 _SubColor;
			float _Center;
			float _R;

			struct v2f {
				float4 pos:POSITION;
				float y:TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				//顶点中处理自动渐变
				//if (v.vertex.y > 0)
				//	o.col = _MainColor;
				//else
				//	o.col = _SubColor;
				o.y= v.vertex.y;
				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				float d = IN.y - _Center;   //顶点距离中心的距离
				float s = abs(d);           //顶点距离中心的距离
				d = d / s;                  //若d>0则在中心之上，若d<0则在中心之下

				float f = s / _R;            //若f>= 1则不需要过度，若f<1则需要过度
				f = saturate(f);             //将f限定到（0，1）
				d *= f;
				d = d / 2 + 0.5;             //将d限定到（0，1）
				return lerp(_MainColor, _SubColor, d);
				//尽量避免使用if...else...
				//if (IN.y > _Center)
				//	return _MainColor;
				//else
				//	return _SubColor;
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
