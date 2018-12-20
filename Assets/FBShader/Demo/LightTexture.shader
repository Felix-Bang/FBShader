// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable
// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D

Shader "Custom/LightTexture" {
	properties{
		_MainTex("MainTex",2D) = ""{}
	}

	SubShader{
		Pass{
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float4 _MainTex_ST;   //Unity自动生成(不能省略)
			
			// sampler2D unity_Lightmap;    //启用光照贴图后，Unity自动提供 Unity2018直接使用
			// float4 unity_LightmapST;    //光照贴图的uv Unity2018直接使用
			

			struct v2f {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
				float2 uv2:TEXCOORD1;
			};

			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos= UnityObjectToClipPos(v.vertex);
				////第一种方式：
				//o.uv = v.texcoord.xy*_MainTex_ST.xy + _MainTex_ST.zw;
				////第二种方式：内建宏，双方和第一种一样，只是对第一种计算的封装
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv2 = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;

				return o;
			}

			fixed4 frag(v2f IN) :COLOR
			{
				////解密光照贴图计算公式
				float3 lm = DecodeLightmap(UNITY_SAMPLE_TEX2D(unity_Lightmap,IN.uv2));
				fixed4 color = tex2D(_MainTex,IN.uv);//第一个参数：纹理，第二个参数UV向量
				color.rgb *= lm*2; //*提高亮度
				return color;
			}

			ENDCG
		}
	}

}
