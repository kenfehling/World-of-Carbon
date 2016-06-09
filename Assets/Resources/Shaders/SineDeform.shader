Shader "Unlit/SineDeform"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : POSITION;
				float3 color: COLOR0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (inout appdata_full v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				float sPhase = _Time * 20.0;
				o.pos.y += sin(sPhase + v.vertex.y) * 0.2;
				return o;
			}
			
			half4 frag (v2f i) : COLOR
			{
				return half4(i.color, 1);
			}
			ENDCG
		}
	}
}
