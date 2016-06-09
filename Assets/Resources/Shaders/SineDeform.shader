Shader "Unlit/SineDeform"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_SpeedX("SpeedX", float) = 3.0
		_SpeedY("SpeedY", float) = 3.0
		_Scale("Scale", range(0.005, 0.2)) = 0.03
		_TileX("TileX", float) = 5
		_TileY("TileY", float) = 5
	}
	SubShader
	{
		Lighting Off
		Tags { "RenderType"="Opaque" }
		LOD 200

			CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _MainTex;
			float4 uv_MainTex_ST;

			float _SpeedX;
			float _SpeedY;
			float _Scale;
			float _TileX;
			float _TileY;

			struct Input
			{
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutput o)
			{
				float2 uv = IN.uv_MainTex;
				uv.x += sin((uv.x + uv.y)*_TileX + _Time.g * _SpeedX)* _Scale;
				uv.x += cos(uv.y * _TileY + _Time.g * _SpeedY) * _Scale;

				half4 c = tex2D (_MainTex, uv);
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}
			ENDCG
	}
	FallBack "Diffuse"
}
