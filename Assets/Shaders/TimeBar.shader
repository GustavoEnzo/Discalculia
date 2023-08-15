Shader "Unlit/TimeBar"
{
    Properties
    {
        _percentage("percent", Range(0,1)) = 1
        _color0("ColorMax", Color) = (1,1,1,1)
        _color1("ColorMidium", Color) = (1,1,1,1)
        _color2("ColorMin", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _color0;
            fixed4 _color1;
            fixed4 _color2;
            float _percentage;

            fixed4 col;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {   
                float g = step(i.uv.x - _percentage, 0);

                if(_percentage > .7)
                    col = fixed4(_color0.rgb, g);
                else if(_percentage <= .7 && _percentage >= .2 )
                    col = fixed4(_color1.rgb, g);
                else if(_percentage <= .2)
                    col = fixed4(_color2.rgb, g);

                
                return col;
            }
            ENDCG
        }
    }
}
