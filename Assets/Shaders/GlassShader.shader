Shader "Unlit/GlassShader"
{
    Properties
    {
        _NormalTex ("Normal Map", 2D) = "white" {}
		_RefractionStrength("Refract Strength", range(-1,1)) = 0.35
		_BlurStrength("Blur Strength", range(0,10)) = 8
		_Color("Tint Color", COLOR) = (1,1,1,1)
    }
    SubShader
    {
		ZWrite On
        LOD 100
		// GrabPass tutorial used:  http://tinkering.ee/unity/asset-unity-refractive-shader/

		GrabPass {
			"_BackgroundTexture"
		}
		CGINCLUDE
        #include "UnityCG.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
			float4 normal : NORMAL;
			float4 tangent : TANGENT;
        };

        struct v2f
        {
            float2 uv[5] : TEXCOORD0;
            float4 vertex : SV_POSITION;
			float3 normal : NORMAL;
			float4 tangent : TANGENT;
			float4 screenPos[5] : TEXCOORD5;
        };

        sampler2D _NormalTex;
		sampler2D _BackgroundTexture;
		half4 _BackgroundTexture_TexelSize;
        float4 _NormalTex_ST;
		float _RefractionStrength;
		float _BlurStrength;
		float4 _Color;

		// Tutorials used for general logic
		// (The shader logic was based on both tutorials but the logic
		// has become intertwined ,modified, and spread over the 2 vertex and 1 fragment shaders therefore i'll just state them at the start):
		// https://www.youtube.com/watch?v=inht8WYX-A4&t=2s
		// https://blog.titanwolf.in/a?ID=01500-3606b309-752d-4891-942a-57b4fe27451a
		// the vertex shader code for the horizontal pass
        v2f vertHorizontal (appdata v)
        {
				
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
			// pass normal and tangent values
			o.normal = v.normal;
			o.tangent = v.tangent;
			// get uv coordinates of the current pixel and at the pixels 1 and 2 spaces away horizontally,
			// where a space is the length of 1 background texture pixel
			o.uv[0] = TRANSFORM_TEX(v.uv, _NormalTex);
			o.uv[1] = o.uv[0] + float2(_BackgroundTexture_TexelSize.x, 0) * _BlurStrength;
			o.uv[2] = o.uv[0] - float2(_BackgroundTexture_TexelSize.x, 0) * _BlurStrength;
			o.uv[3] = o.uv[0] + float2(_BackgroundTexture_TexelSize.x * 2, 0) * _BlurStrength;
			o.uv[4] = o.uv[0] - float2(_BackgroundTexture_TexelSize.x * 2, 0) * _BlurStrength;
			// get screen coordinates of the current pixel and at the pixels 1 and 2 spaces away horizontally,
			// where a space is the length of 1 background texture pixel
			float4 baseScreenPos = ComputeScreenPos(o.vertex);
			o.screenPos[0] = baseScreenPos;
			o.screenPos[1] = baseScreenPos + float4(_BackgroundTexture_TexelSize.x, 0, 0, 0) * _BlurStrength;
			o.screenPos[2] = baseScreenPos - float4(_BackgroundTexture_TexelSize.x, 0, 0, 0) * _BlurStrength;
			o.screenPos[3] = baseScreenPos + float4(_BackgroundTexture_TexelSize.x * 2, 0, 0, 0) * _BlurStrength;
			o.screenPos[4] = baseScreenPos - float4(_BackgroundTexture_TexelSize.x * 2, 0, 0, 0) * _BlurStrength;
            return o;
        }

		// the vertex shader code for the vertical pass
		v2f vertVertical (appdata v) {
			v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
			o.normal = v.normal;
			o.tangent = v.tangent;
			// get uv coordinates of the current pixel and at the pixels 1 and 2 spaces away vertically,
			// where a space is the length of 1 background texture pixel
			o.uv[0] = TRANSFORM_TEX(v.uv, _NormalTex);
			o.uv[1] = o.uv[0] + float2(_BackgroundTexture_TexelSize.y, 0) * _BlurStrength;
			o.uv[2] = o.uv[0] - float2(_BackgroundTexture_TexelSize.y, 0) * _BlurStrength;
			o.uv[3] = o.uv[0] + float2(_BackgroundTexture_TexelSize.y * 2, 0) * _BlurStrength;
			o.uv[4] = o.uv[0] - float2(_BackgroundTexture_TexelSize.y * 2, 0) * _BlurStrength;
			// get screen coordinates of the current pixel and at the pixels 1 and 2 spaces away vertically,
			// where a space is the length of 1 background texture pixel
			float4 baseScreenPos = ComputeScreenPos(o.vertex);
			o.screenPos[0] = baseScreenPos;
			o.screenPos[1] = baseScreenPos + float4(_BackgroundTexture_TexelSize.y, 0, 0, 0) * _BlurStrength;
			o.screenPos[2] = baseScreenPos - float4(_BackgroundTexture_TexelSize.y, 0, 0, 0) * _BlurStrength;
			o.screenPos[3] = baseScreenPos + float4(_BackgroundTexture_TexelSize.y * 2, 0, 0, 0) * _BlurStrength;
			o.screenPos[4] = baseScreenPos - float4(_BackgroundTexture_TexelSize.y * 2, 0, 0, 0) * _BlurStrength;
            return o;
		}


        fixed4 frag (v2f i) : SV_Target
        {
			// weights from gaussian blur 5x5 matrix
			float weights[5] = {0.4026, 0.2442, 0.2442, 0.0545,  0.0545};

			float3 grabSum = 0;
			// code for converting normal in tanget space to object space, from code in https://www.fatalerrors.org/a/unity-shader-normal-mapping-for-bump-mapping.html
			float3x3 tangent2Object =
			{
			    i.tangent.xyz*i.tangent.w,
			    cross(i.tangent*i.tangent.w, i.normal),
			    i.normal
			};
			// for each pixel, get the normal at the pixel, add to screen position to get
			// refracted pixel position, then obtain the color at that position
			// then multiply the color by the weight of that pixel and add it to the final color
			for (int j=0; j < 5; j++) {
				float3 normal = UnpackNormal(tex2D(_NormalTex, i.uv[j]));
				
				// convert normals in tangent space to screen space
				tangent2Object=transpose(tangent2Object);
				normal = mul(tangent2Object, normal);

				// get the color of the pixel
				float3 projNormal = normalize(UnityObjectToClipPos(normal));
				float4 grabPos = i.screenPos[j] + float4(projNormal.xyz, 0) * _RefractionStrength;
				float3 grabColor = tex2Dproj(_BackgroundTexture, grabPos).rgb * weights[j];
				grabSum += grabColor;
			}
			// return the final color of the pixel
			return float4(grabSum.rgb, 1)*_Color;
        }
		ENDCG
		// the horizontal pass, blurs pixel horizontally
		Pass {
			NAME "GLASS_HORIZONTAL"
			CGPROGRAM
            #pragma vertex vertHorizontal
            #pragma fragment frag
			ENDCG
		}
		// the vertical pass, blurs pixel vertically
		Pass {
			NAME "GLASS_VERTICAL"
			CGPROGRAM
            #pragma vertex vertVertical
            #pragma fragment frag
			ENDCG
		}
    }
}
