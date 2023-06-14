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

Varyings OutlineVertex(Attributes IN)
{
    Varyings OUT;
    float4 vertexPos = outline(IN.positionOS, _OutlineThickness);
                
    OUT.positionHCS = TransformObjectToHClip(vertexPos);
                
    return OUT;
}

half4 OutilineFragment() : SV_Target
{
    return _OutlineColor;
}