Shader "Custom/Azimuthal"
{
    Properties
    {

        //Failed attempt

        _MainTex ("Texture", 2D) = "white" {}
        _Lambda ("Lamba X Position", Range(0, 20)) = 0
        _Phi ("Phi Y Position", Range(0, 20)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma target 5.0
            //#pragma glsl_es2
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
                //output.fragment = TRANSFORM_TEX(input.uv, _MainTex);

                output.fragment = ComputeScreenPos(output.position); //Gets screen-position of output's position
                return output;
            }

            float square(float a) : SV_Target
            {
                return a * a;
            }

            //FRAGMENT SHADER: Renders the shader's fragment to the screen.
            half4 frag (vertOutput i) : SV_Target
            {
                float2 texUV = i.fragment.xy ; //This is the incoming texture coordinates

                //float x = TAU * (texUV.x - 0.5);
                //float y = TAU * (texUV.y - 0.5);

                float x = TAU * (texUV.x - 0.5);
                float y = TAU * (texUV.y - 0.5);

                //Calculates the angular distance from the center
                float c = sqrt(square(x) + square(y));

                float phi = asin( cos(c) * sin(_Phi) + y * sin(c) * cos(_Phi) / c);
                float lambda = _Lambda + atan2((c * cos(_Phi) * cos(c) - y * sin(_Phi) * sin(c)),  x * sin(c));

                //Remaps the texture coordinates

                float s = (lambda/TAU) + 0.5;
                float t = (phi/PI) + 0.5;

                float2 fragPosition = (s, t);
                float4 boundStep = smoothstep(PI - 0.05, PI, c);

                //Develops texture map

                float4 fragmentResult = tex2D(_MainTex, texUV);
                return fragmentResult;

                //float2 resultUV = i.fragment.xy / i.fragment.w;
                //float4 resultFrag = tex2D(_MainTex, resultUV);
                //return resultFrag; 
            }
            ENDCG
        }
    }

    Fallback "Standard"
}
