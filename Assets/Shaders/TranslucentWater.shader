Shader "TranslucentWater" {
	Properties
	{
		_Color1("Color 1", Color) = (0,0,0,1)
		_Color2("Color 2 ", Color) = (1,1,1,1)
	}

		SubShader{
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
			LOD 100
			Cull Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"



				float4 _CameraDepthTexture_TexelSize;
				sampler2D _CameraDepthTexture;

				float4 _Color1;
				float4 _Color2;


				struct appdata {
					float4 vertex : POSITION;
				};

				struct v2f {
					float4 screen_pos : TEXCOORD0;
					float4 eye_pos : TEXCOORD1;
					float4 vertex : SV_POSITION;
				};




				v2f vert(appdata v) {
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);

					o.eye_pos = mul(UNITY_MATRIX_MV, v.vertex);
					o.screen_pos = ComputeScreenPos(o.vertex);

					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					
					float2 screen_uv = i.screen_pos.xy / i.screen_pos.w;

					#if UNITY_UV_STARTS_AT_TOP
					if (_CameraDepthTexture_TexelSize.y < 0) {
						screen_uv.y = 1 - screen_uv.y;
					}
					#endif

					float surface_depth = -i.eye_pos.z;
					float bg_depth = LinearEyeDepth(tex2D(_CameraDepthTexture, screen_uv));
					float fog_depth = bg_depth - surface_depth;

					fog_depth = ceil(fog_depth - 0.5);
					fog_depth = saturate(fog_depth);
					float4 real_color = lerp(_Color2, _Color1, fog_depth);
					return real_color;
				}
				ENDCG
			}
	}
}