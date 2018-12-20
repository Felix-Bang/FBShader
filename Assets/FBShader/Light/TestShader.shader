Shader "FBShader/TestShader"
{
	properties
	{
		_MainColor("Main Color",color) = (1,1,1,1)
	}

	SubShader
	{
	

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "Sbin/sbin.cginc"

			float4 _MainColor;
			uniform float4 _SecondColor;
			/* 数据的输入输出01

			//float4 vert(in float2 objPos:POSITION,out float4 pos : POSITION,out float2 opos : POSITION) :COLOR
			//若opos未赋值，默认不输出；
			//若opos被赋值，则会报错语义重复（Shader error in 'FBShader/TestShader': Duplicate system value semantic definition: output semantic 'POSITION' and output semantic 'POSITION' at line 17 (on d3d11)）。
		    //无法输出两个相同语义变量（pos和ops均为POSITION，COLOR也不行，因为函数已有COLOR返回）。
			//若要输出相同数据类型，需要使用不同语义（POSITION  TEXCOORD0）。
			float4 vert(in float2 objPos:POSITION,out float4 pos : POSITION,out float2 opos: TEXCOORD0):COLOR
			{
				pos = float4(objPos,0,1);
				opos = objPos;
				return pos;
			}

			fixed4 frag(in float2 opos:TEXCOORD0 ,in float4 col:COLOR):COLOR
			{
				float arr[2] = {0.5,0.5};  //必须指定维度
				col.y = Func2(arr);
				return col;
			}
			*/

			
			//结构体必须在使用之前就申明，否则报错（unrecognized identifier 'v2f'）
			//写法一：
			struct v2f
			{
				float4 pos : POSITION;
				float2 objPos : TEXCOORD0;
				fixed4 col : COLOR;
			};

			//写法二：
			//typedef struct 
			//{
			//	float4 pos: POSITION;
			//	float2 objPos:TEXCOORD0;
			//}v2f;


			
			struct appdata_base
			{
				float2 pos : POSITION;
				float4 col : COLOR;
			};

		

			v2f vert(in appdata_base v)
			{
				v2f o;
				o.pos = float4(v.pos, 0, 1);
				o.col = v.col;
				return o;
			}

			fixed4 frag(v2f o):COLOR
			{
				//return fixed4(o.objPos,0,1);
				//return _MainColor * _SecondColor;
				//return _MainColor * 0.5 + _SecondColor*0.5;
				return lerp(_MainColor, _SecondColor ,0.7);
			}
			

		

		
		
			ENDCG
		}
	}		
}
