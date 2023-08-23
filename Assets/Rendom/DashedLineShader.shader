Shader "Custom/DottedLineShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _DotSize ("Dot Size", Range(0.01, 1)) = 0.1
        _GapSize ("Gap Size", Range(0.01, 1)) = 0.1
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
            };
            
            float _DotSize;
            float _GapSize;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.vertex.xy / i.vertex.w;
                
                float modVal = fmod(uv.x, (_DotSize + _GapSize));
                if (modVal > _DotSize)
                    discard;
                
                fixed4 col = (1,1,1,1);
                return col;
            }
            ENDCG
        }
    }
}
