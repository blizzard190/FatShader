Shader "Custom/ClothingDoubleFatShader"
{
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_ShadowColor("Shadow Color", Color) = (0.8, 0.8, 1, 1)
		_EdgeThickness("Outline Thickness", Float) = 1

		_Amount("Extrusion Amount", Range(-1,1)) = 0.5
		_FalloffSampler("Falloff Control", 2D) = "white" {}
		_RimLightSampler("RimLight Control", 2D) = "white" {}
		_SpecularReflectionSampler("Specular / Reflection Mask", 2D) = "white" {}
		_EnvMapSampler("Environment Map", 2D) = "" {}
		_NormalMapSampler("Normal Map", 2D) = "" {}

	}

		SubShader{
		  Tags {
			"RenderType" = "Opaque"
			"Queue" = "Geometry"
			"LightMode" = "ForwardBase"
		  }

			Pass
			{
			Cull Back
			ZTest LEqual
CGPROGRAM
#pragma multi_compile_fwdbase
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#include "AutoLight.cginc"
#define ENABLE_NORMAL_MAP
#include "Assets/unity-chan!/Unity-chan! Model/Art/UnityChanShader/Shader/CharaMain.cg"
ENDCG
			}
			Pass
			{
			Cull Front
			ZTest Less
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#include "Assets/unity-chan!/Unity-chan! Model/Art/UnityChanShader/Shader/CharaOutline.cg"
ENDCG
			}

		  CGPROGRAM
		  #pragma surface surf Lambert vertex:vert

		  struct Input {
			  float2 uv_MainTex;
		  };

		  float _Amount;

		  void vert(inout appdata_full v) {
			  v.vertex.xyz += v.normal * _Amount;
		  }

		  sampler2D _MainTex;

		  void surf(Input IN, inout SurfaceOutput o) {
			  o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		  }

		  ENDCG
	}
		Fallback "Transparent / Cutout / Diffuse"
}
