Shader "Hidden/RetroPC" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_RampTex ("Base (RGB)", 2D) = "grayscaleRamp" {}
}

SubShader {
	Pass {
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
				
CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 
#include "UnityCG.cginc"

#if(Dither_Ptn == 1)
	// Bayer型
	float4x4 Dither = { 0.9375f ,0.4375f ,0.8125f ,0.3125f 
	                   ,0.1875f ,0.6875f ,0.0625f ,0.5625f 
	                   ,0.7500f ,0.2500f ,0.8750f ,0.3750f 
	                   ,0.0000f ,0.5000f ,0.1250f ,0.6250f };
#elif(Dither_Ptn == 2)
	// ハーフトーン型
	float4x4 Dither = { 0.3125f ,0.6875f ,0.5625f ,0.4375f 
	                   ,0.1875f ,0.9375f ,0.8125f ,0.0625f 
	                   ,0.5000f ,0.3750f ,0.2500f ,0.6250f 
	                   ,0.7500f ,0.0000f ,0.1250f ,0.8750f };
#elif(Dither_Ptn == 3)
	// Screw型
	float4x4 Dither = { 0.1250f ,0.5000f ,0.5625f ,0.1875f 
	                   ,0.4375f ,0.8750f ,0.9375f ,0.6250f 
	                   ,0.3750f ,0.8125f ,0.7500f ,0.6875f 
	                   ,0.0625f ,0.3125f ,0.2500f ,0.0000f };
#elif(Dither_Ptn == 4)
	// Screw変形型
	float4x4 Dither = { 0.0000f ,0.6875f ,0.4375f ,0.1875f 
	                   ,0.2500f ,0.9375f ,0.8750f ,0.6250f 
	                   ,0.5000f ,0.7500f ,0.8125f ,0.3750f 
	                   ,0.0625f ,0.3125f ,0.5625f ,0.1250f };
#elif(Dither_Ptn == 5)
	// 中間強調型
	float4x4 Dither = { 0.1875f ,0.6875f ,0.4375f ,0.0625f 
	                   ,0.2500f ,0.9375f ,0.8125f ,0.5625f 
	                   ,0.5000f ,0.7500f ,0.8750f ,0.3125f 
	                   ,0.0000f ,0.3750f ,0.6250f ,0.1250f };
#elif(Dither_Ptn == 6)
	// Dot Concentrate型
	float4x4 Dither = { 0.1250f ,0.6875f ,0.4375f ,0.0625f 
	                   ,0.3125f ,0.9375f ,0.8750f ,0.5000f 
	                   ,0.5625f ,0.7500f ,0.8125f ,0.2500f 
	                   ,0.0000f ,0.3750f ,0.6250f ,0.1250f };
#elif(Dither_Ptn == 7)
	// 2x2型
	float4x4 Dither = { 0.7500f ,0.2500f ,0.7500f ,0.2500f 
	                   ,0.0000f ,0.5000f ,0.0000f ,0.5000f 
	                   ,0.7500f ,0.2500f ,0.7500f ,0.2500f 
	                   ,0.0000f ,0.5000f ,0.0000f ,0.5000f };
#elif(Dither_Ptn == 8)
	// 閾値型
	float4x4 Dither = { 0.5000f ,0.5000f ,0.5000f ,0.5000f 
	                   ,0.5000f ,0.5000f ,0.5000f ,0.5000f 
	                   ,0.5000f ,0.5000f ,0.5000f ,0.5000f 
	                   ,0.5000f ,0.5000f ,0.5000f ,0.5000f };
#endif

uniform sampler2D _MainTex;
uniform sampler2D _RampTex;
uniform half _RampOffset;

fixed4 frag (v2f_img i) : SV_Target
{
	fixed4 original = tex2D(_MainTex, i.uv);
	fixed grayscale = Luminance(original.rgb);
	half2 remap = half2 (grayscale + _RampOffset, .5);
	fixed4 output = tex2D(_RampTex, remap);
	output.a = original.a;
	return output;
}
ENDCG

	}
}

Fallback off

}