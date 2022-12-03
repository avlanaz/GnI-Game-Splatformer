Shader "Unlit/Lava"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MainTint("Color", Color) = (1, 1, 1, 1)
        _BumpTex("Bump", 2D) = "white" {}

        _DisplacementMap("Height Map", 2D) = "white" {}
		_DisplacementMagnitude("Displacement Magnitude", float) = 0
		_FlowSpeedX("X Flow", float) = 0
		_FlowSpeedY("Y Flow", float) = 0

        _BumpIntense("Intensity", range(0, 100)) = 1
        _ScrollX("Flow Speed", Range(-1, 1)) = -0.1
        _Noise("Noise", Range(0, 0.5))= 0.02
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
                
            };

            sampler2D _MainTex;
            sampler2D _BumpTex;
            float4 _MainTex_ST;
            float4 _BumpTex_ST;
            fixed _ScrollX;
            fixed _BumpIntense;
            float4 _MainTint;
            fixed _Noise;
            fixed _Speed;
            sampler2D _DisplacementMap;
			float _DisplacementMagnitude;
			float _FlowSpeedX;
			float _FlowSpeedY;


            v2f vert (appdata v)
            {
                v2f o;
                float2 adjustedUv = v.uv;
				adjustedUv += float2(_FlowSpeedX * _Time.y, _FlowSpeedY * _Time.y);
				float4 displacementColor = tex2Dlod(_DisplacementMap, float4(adjustedUv.xy, 0.0, 0.0));
				// float3(0.21, 0.72, 0.07) is the luminosity method to convert rgb to grayscale as found here: https://www.johndcook.com/blog/2009/08/24/algorithms-convert-color-grayscale/
				float displacementHeight = dot(float3(0.21, 0.72, 0.07), displacementColor.rgb) * _DisplacementMagnitude;
				o.vertex = UnityObjectToClipPos(v.vertex + float4(v.normal * displacementHeight, 0.0));
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // change the color by their height
                o.color.xyz = float4(v.normal+displacementHeight, 0.0) * 0.8 + 0.8;
                o.color.w = 1.0;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                //let uv do the sin wave moment based on the time
                //in the sine function, add the bump texture to make the lave scale by the bump
                fixed4 bump = tex2D(_BumpTex, uv);
                float bump_scale = _Noise * sin(-uv.y + _BumpIntense * bump + _Time.y);
                uv = uv + uv*bump_scale;
                //make uv.x continuous moving,  so the lava can flow
                uv.x = uv.x + _ScrollX * _Time.y;
                fixed4 col = tex2D(_MainTex, uv) * i.color*_MainTint;

                return col;
            }
            ENDCG
        }
    }
}
