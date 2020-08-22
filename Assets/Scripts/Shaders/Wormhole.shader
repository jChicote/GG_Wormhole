Shader "Custom/Wormhole"
{
    SubShader
    {
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
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            sampler2D _MainTex;


            vertOutput vert(vertInput input)
            {
                vertOutput o;
                o.vertex = UnityObjectToClipPos(input.pos);
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            //Renders frag to pixel
            half4 frag(vertOutput output) : COLOR {
                return half4(1.0, 0.0, 0.0, 1.0); 
            }
            
            ENDCG
        }
    }
}
