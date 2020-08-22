// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Wormhole"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Cull Off

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc" //Built-in include files for declaring helper func and data struct.

            //Struct for the input of the position of the vert
            struct vertInput {
                float4 pos : POSITION;
            };

            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 posFragment : TEXCOORD0;
            };

            sampler2D _MainTex;
            int displayMask;


            //VERTEX SHADER
            vertOutput vert(vertInput v)
            {
                vertOutput o;
                o.pos = UnityObjectToClipPos(v.pos);
                o.posFragment = ComputeScreenPos(o.pos);
                return o;
            }


            //FRAG SHADER
            fixed4 frag(vertOutput output) : SV_TARGET
            {
                float2 uv = output.posFragment.xy / output.posFragment.w;
                fixed4 portalCol = tex2D(_MainTex, uv);
                return portalCol * displayMask;
            }
            
            ENDCG
        }
    }

    Fallback "Standard"
}
