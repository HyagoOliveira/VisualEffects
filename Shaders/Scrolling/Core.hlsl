#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

float2 GetScrollingUV(float2 uv, float2 speed)
{
    float2 velocity = speed * _Time.yy;
    return uv + velocity;
}