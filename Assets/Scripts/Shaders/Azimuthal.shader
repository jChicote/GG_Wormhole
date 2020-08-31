Shader "Custom/Azimuthal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Lambda ("Lamba X Position", Range(0, 20)) = 0
        _Phi ("Phi Y Position", Range(0, 20)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma target 5.0
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct vertOutput
            {
                float4 position : SV_POSITION;
                float4 fragment : TEXCOORD0;
            };

            float _Lambda; //Modifiable x-value to rotate along its longitude
            float _Phi;

            float PI = 3.1415926535897931; //circle ratio mathematical constant
            float TAU = 6.2831853071795862; //circle constant as the ratio between circumference and radius >> 2*PI

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //VERTEX SHADER: Calculates the vertex data
            vertOutput vert (appdata input)
            {
                vertOutput output;
                output.position = UnityObjectToClipPos(input.vertex);
                //output.uv = TRANSFORM_TEX(input.uv, _MainTex);

                output.fragment = ComputeScreenPos(output.position); //Gets screen-position of output's position
                return output;
            }

            //FRAGMENT SHADER: Renders the shader's fragment to the screen.
            half4 frag (vertOutput i) : SV_Target
            {
                float2 refUV = i.fragment.xy / i.fragment.w;

                float x = TAU* (refUV.x - 0.5);
                float y = TAU* (refUV.y - 0.5);

                //_Phi

                float c = sqrt(x*x + y*y);
                float phi = asin( cos(c) * sin(_Phi) + y * sin(c) * cos(_Phi) / c);
                float lambda = _Lambda + atan2( x * sin(c), (c * cos(_Phi) * cos(c) - y * sin(_Phi) * sin(c)));

                //Remaps the texture coordinates

                float x_coor = (lambda/TAU) + 0.5;
                float y_coor = (phi/PI) + 0.5;

                float2 fragPosition = (x_coor, y_coor);
                float4 boundStep = smoothstep(PI - 0.5, PI, c);

                //Develops texture map

                float4 fragmentResult = tex2D(_MainTex, fragPosition);
                return fragmentResult;

                //float2 resultUV = i.fragment.xy / i.fragment.w;
                //float4 resultFrag = tex2D(_MainTex, resultUV);
                //return resultFrag; 
            }
            ENDCG
        }
    }

    Fallback "Unlit/FallBack"
}
