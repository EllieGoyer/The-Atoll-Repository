Shader "Custom/TransparentShadowReceiver"
{
    SubShader
    {
		Tags { "Queue" = "AlphaTest" }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			Name "ShadowPass"
			Cull Back
			ZWrite Off
			LOD 100
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			#include "UnityCG.cginc"
			#include "AutoLight.cginc"

			float4 _CameraDepthTexture_TexelSize, _FoamNoise_ST;
			sampler2D _CameraDepthTexture, _WaterBackground, _FoamNoise;

			struct v2f {
				float4 pos : SV_POSITION;
				LIGHTING_COORDS(0, 1)
			};

			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				float attenuation = LIGHT_ATTENUATION(i);

				return fixed4(0, 0, 0, 1 - attenuation);
			}
			ENDCG
		}
    }
    FallBack "VertexLit"
}
