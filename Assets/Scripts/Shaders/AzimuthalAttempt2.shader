Shader "Custom/AzimuthalAttempt2"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Lambda ("Lamba X Position", Range(0, 20)) = 0
        _Phi ("Phi Y Position", Range(0, 20)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 5.0

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct vertOutput
            {
                float4 position : SV_POSITION;
                float2 fragment : TEXCOORD0;
            };

            fixed4 _Color;
            float _Lambda; //Modifiable x-value to rotate along its longitude
            float _Phi;

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //VERTEX SHADER: Calculates the vertex data
            vertOutput vert (appdata input)
            {
                vertOutput output;
                output.position = UnityObjectToClipPos(input.vertex);
                output.fragment = TRANSFORM_TEX(input.uv, _MainTex);

                //output.fragment = ComputeScreenPos(output.position); //Gets screen-position of output's position

                return output;
            }

            half4 frag (vertOutput i) : SV_Target
            {
                float2 texUV = i.fragment.xy; //This is the incoming texture coordinates

                //float2 resultUV = i.fragment.xy / i.fragment.w;

                float4 resultFrag = tex2D(_MainTex, resultUV);

                //return resultFrag; 
            }

            ENDCG
        }
    }

    FallBack "Diffuse"
}
