// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/BlueFragment"
{
    SubShader
    {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            //Struct for the input of the position of the vert
            struct vertInput {
                float4 pos : POSITION;
            };
            
            //Struct for the output of the calc
            struct vertOutput {
                float4 pos : SV_POSITION;
            };

            //This runs the vert function above
            vertOutput vert(vertInput input) {
                vertOutput o;
                o.pos = UnityObjectToClipPos(input.pos);
                return o;
            }

            //This runs the frag function above
            half4 frag(vertOutput output) : COLOR {
                return half4(1.0, 0.0, 0.0, 1.0); 
            }

            ENDCG
        }
    }
    //FallBack "Diffuse"
}