// Outline unlit Shader to be used by the URP.
Shader "ActionCode/Outline_Unlit"
{
    Properties
    { 
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)

        [Space]
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineThickness ("Outline Thickness", Range(0.0, 0.2)) = 0.1
    }

    SubShader
    {
        LOD 100
        Tags 
        { 
            "Queue" = "Transparent"
            "RenderType" = "Opaque" 
            "RenderPipeline" = "UniversalPipeline" 
        }

        Pass // Outline
        {
            Tags { "LightMode" = "SRPDefaultUnlit" }

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
            };  
            
            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _OutlineColor;
                float _OutlineThickness;
            CBUFFER_END

            float4 outline(float4 vertexPos, float thickness)
            {
                float thicknessUnit = 1 + thickness;
                float4x4 scale = float4x4
                (
                    thicknessUnit, 0, 0, 0,
                    0, thicknessUnit, 0, 0,
                    0, 0, thicknessUnit, 0,
                    0, 0, 0, thicknessUnit
                );

                return mul(scale, vertexPos);
            }

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                float4 vertexPos = outline(IN.positionOS, _OutlineThickness);
                
                OUT.positionHCS = TransformObjectToHClip(vertexPos);
                
                return OUT;
            }

            half4 frag() : SV_Target
            {
                return _OutlineColor;
            }
            ENDHLSL
        }

        Pass // Texture
        {
            Tags { "LightMode" = "UniversalForward" }
            
            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                half4 _BaseColor;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                return color * _BaseColor;
            }
            ENDHLSL
        }
    }
}
