Shader "TranslucentWater" {
	Properties
	{
		_WaterColor("Water Color", Color) = (0,0,0,1)
		_WaterDepth("Water Depth", Range(0,1)) = 0.75
		_FoamColor("Foam Color", Color) = (1,1,1,1)
		_FoamDepth("Foam Depth", Range(0,1)) = 0.05
		_FoamNoise("Foam Noise", 2D) = "white" {}

		_Movement("Movement", Vector) = (0,0,0,0)
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

				float4 _CameraDepthTexture_TexelSize, _FoamNoise_ST;
				sampler2D _CameraDepthTexture, _WaterBackground, _FoamNoise;


				float4 _WaterColor;
				float4 _FoamColor;
				float _WaterDepth;
				float _FoamDepth;
				float2 _Movement;

				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
					float3 normal : NORMAL;
				};

				struct v2f {
					float4 world_pos : TEXCOORD4;
					float4 screen_pos : TEXCOORD0;
					float3 eye_pos : TEXCOORD1;
					float4 vertex : SV_POSITION;
					float2 depth : TEXCOORD2;
					float2 uv : TEXCOORD3;
					float4 tint : COLOR;
				};

				v2f vert(appdata v) {
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					UNITY_TRANSFER_DEPTH(o.depth);
					o.eye_pos = UnityObjectToViewPos(v.vertex);
					o.screen_pos = ComputeScreenPos(o.vertex);
					o.world_pos = mul(unity_ObjectToWorld, v.vertex);
					o.uv = v.uv * _FoamNoise_ST.xy + (_FoamNoise_ST.zw + float2(o.world_pos.x / _FoamNoise_ST.x, o.world_pos.z / _FoamNoise_ST.y));
						//TRANSFORM_TEX(v.uv, _FoamNoise);
					o.tint.xyz = UnityObjectToWorldNormal(v.normal);
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


					float4 foamStrength = tex2D(_FoamNoise, i.uv + frac((_Time.x / 5) + float2(0.005, 0.005)));


					col = lerp(col, float4(_WaterColor.r * 1.2, _WaterColor.g * 1.2, _WaterColor.b * 1.2, 1), 
						((frac(i.tint.g * tex2D(_FoamNoise, (i.uv / 20) + frac(_Time.x / 30)).r) + frac(i.tint.g * tex2D(_FoamNoise, (i.uv / 20) - frac(_Time.x / 30)).r) +
							frac(i.tint.g * tex2D(_FoamNoise, (i.uv/100) + frac(_Time.x / 15)))) 
						% (0.5 * fade_depth)) * fade_depth);

					//	Foam Coloring
					float foam_depth = saturate(fade_depth - (1 - _FoamDepth));
					if (fade_depth < _FoamDepth * (1 - (foamStrength.r * foamStrength.r)))
					{
						col = _FoamColor;
					}

					return col;
				}
				ENDCG
			}
	}
}