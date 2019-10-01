Shader "TranslucentWater" {
	Properties
	{
		_WaterColor("Water Color", Color) = (0,0,0,1)
		_WaterDepth("Water Depth", Range(0,1)) = 0.75
		_FoamColor("Foam Color", Color) = (1,1,1,1)
		_FoamDepth("Foam Depth", Range(0,1)) = 0.05
	}

		SubShader{
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
			LOD 100
			Cull Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			GrabPass { "_WaterBackground" }

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				float4 _CameraDepthTexture_TexelSize;
				sampler2D _CameraDepthTexture, _WaterBackground;

				float4 _WaterColor;
				float4 _FoamColor;
				float _WaterDepth;
				float _FoamDepth;

				struct appdata {
					float4 vertex : POSITION;
				};

				struct v2f {
					float4 screen_pos : TEXCOORD0;
					float4 eye_pos : TEXCOORD1;
					float4 vertex : SV_POSITION;
					float2 depth : TEXCOORD2;
				};

				v2f vert(appdata v) {
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					UNITY_TRANSFER_DEPTH(o.depth);
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

					//	Depth Coloring
					float clip_depth = UNITY_Z_0_FAR_FROM_CLIPSPACE(i.screen_pos.z);
					float back_depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, screen_uv));
					float fade_depth = saturate((back_depth - clip_depth) / (_WaterDepth * 100));
					float4 col = lerp(tex2D(_WaterBackground, screen_uv), _WaterColor, fade_depth);

					//	Foam Coloring
					float foam_depth = saturate(fade_depth - (1 - _FoamDepth));
					if (fade_depth < _FoamDepth)
					{
						col = _FoamColor;
					}

					return col;
				}
				ENDCG
			}
	}
}