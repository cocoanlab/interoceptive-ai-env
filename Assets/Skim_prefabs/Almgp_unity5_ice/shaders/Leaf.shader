// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:False,bkdf:True,hqlp:True,rprd:True,enco:True,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.4191176,fgcg:0.402795,fgcb:0.2711937,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:35098,y:30707,varname:node_2865,prsc:2|diff-6343-OUT,spec-3502-OUT,gloss-8629-OUT,normal-4165-OUT,emission-8212-OUT,transm-1443-OUT,lwrap-5910-OUT,difocc-4716-OUT,spcocc-4716-OUT,clip-3919-OUT,voffset-4236-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32250,y:32511,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31921,y:32811,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5019608,c2:0.5019608,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31921,y:32591,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a711b80042416e4fa0834fbdbcdd62b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:31905,y:33060,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32386,y:32538,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32345,y:32661,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_NormalBlend,id:4165,x:32165,y:33078,varname:node_4165,prsc:2|BSE-5964-RGB,DTL-1816-RGB;n:type:ShaderForge.SFN_Tex2d,id:1816,x:31931,y:33306,ptovrint:False,ptlb:normal_detail,ptin:_normal_detail,varname:_normal_detail,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:199ee629711dfab4c9c1adbaa1fa7c90,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:3919,x:34726,y:31014,varname:node_3919,prsc:2|A-7736-A,B-7935-OUT;n:type:ShaderForge.SFN_Slider,id:7935,x:32041,y:32977,ptovrint:False,ptlb:alpha clip,ptin:_alphaclip,varname:_alphaclip,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9228432,max:2;n:type:ShaderForge.SFN_VertexColor,id:7738,x:31731,y:32323,varname:node_7738,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5868,x:32153,y:32258,varname:node_5868,prsc:2|A-3538-OUT,B-4416-OUT;n:type:ShaderForge.SFN_Slider,id:4416,x:32033,y:32456,ptovrint:False,ptlb:AO power,ptin:_AOpower,varname:_AOpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Cubemap,id:594,x:32543,y:32118,ptovrint:False,ptlb:SSS cubemap,ptin:_SSScubemap,varname:_SSScubemap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:70b976a5067e3db489420915ecf6e8ed,pvfc:5|DIR-3582-OUT,MIP-2745-OUT;n:type:ShaderForge.SFN_Slider,id:2745,x:32188,y:32001,ptovrint:False,ptlb:sss cubemap blur,ptin:_ssscubemapblur,varname:_ssscubemapblur,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.897436,max:8;n:type:ShaderForge.SFN_Multiply,id:5592,x:34270,y:30936,varname:node_5592,prsc:2|A-263-OUT,B-594-RGB,C-4716-OUT;n:type:ShaderForge.SFN_Power,id:4716,x:34051,y:31155,varname:node_4716,prsc:2|VAL-5868-OUT,EXP-9875-OUT;n:type:ShaderForge.SFN_Slider,id:9875,x:32250,y:32439,ptovrint:False,ptlb:AO exp,ptin:_AOexp,varname:_AOexp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.835046,max:3;n:type:ShaderForge.SFN_Color,id:3868,x:32546,y:31818,ptovrint:False,ptlb:cubemap sss color,ptin:_cubemapssscolor,varname:_cubemapssscolor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5220588,c2:0.5220588,c3:0.5220588,c4:1;n:type:ShaderForge.SFN_Add,id:263,x:32775,y:31939,varname:node_263,prsc:2|A-3868-RGB,B-3868-RGB;n:type:ShaderForge.SFN_ViewReflectionVector,id:3582,x:32134,y:31813,varname:node_3582,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8629,x:33741,y:30981,varname:node_8629,prsc:2|A-4716-OUT,B-1813-OUT;n:type:ShaderForge.SFN_Tex2d,id:2822,x:31764,y:32016,ptovrint:False,ptlb:AO texture,ptin:_AOtexture,varname:_AOtexture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b2fa2a58a989e57478a95d71feda3949,ntxv:0,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:3538,x:32103,y:31633,ptovrint:False,ptlb:use AO texture,ptin:_useAOtexture,varname:_useAOtexture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-7738-A,B-2822-RGB;n:type:ShaderForge.SFN_NormalVector,id:7784,x:32742,y:31672,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:4236,x:33770,y:31375,varname:node_4236,prsc:2|A-3200-OUT,B-7784-OUT;n:type:ShaderForge.SFN_Multiply,id:3200,x:33692,y:31218,varname:node_3200,prsc:2|A-6298-RGB,B-9217-OUT;n:type:ShaderForge.SFN_Slider,id:9217,x:33173,y:31410,ptovrint:False,ptlb:vertex offset,ptin:_vertexoffset,varname:_vertexoffset,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.018;n:type:ShaderForge.SFN_Tex2d,id:6298,x:33404,y:30913,ptovrint:False,ptlb:wind mask,ptin:_windmask,varname:_windmask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False|UVIN-3635-UVOUT;n:type:ShaderForge.SFN_FragmentPosition,id:5938,x:31702,y:31283,varname:node_5938,prsc:2;n:type:ShaderForge.SFN_Append,id:4783,x:31910,y:31190,varname:node_4783,prsc:2|A-5938-X,B-5938-Z;n:type:ShaderForge.SFN_ValueProperty,id:9232,x:31993,y:31473,ptovrint:False,ptlb:wind  turbulent,ptin:_windturbulent,varname:_windturbulent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4858,x:32107,y:31023,varname:node_4858,prsc:2|A-4783-OUT,B-9232-OUT;n:type:ShaderForge.SFN_Time,id:5361,x:31902,y:30773,varname:node_5361,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5628,x:32279,y:30856,varname:node_5628,prsc:2|A-5361-TSL,B-2907-OUT;n:type:ShaderForge.SFN_Slider,id:2907,x:32007,y:30649,ptovrint:False,ptlb:wind speed,ptin:_windspeed,varname:_windspeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2176561,max:1.5;n:type:ShaderForge.SFN_Panner,id:3635,x:32589,y:30878,varname:node_3635,prsc:2,spu:1,spv:1|UVIN-4858-OUT,DIST-5628-OUT;n:type:ShaderForge.SFN_LightVector,id:6332,x:33574,y:30634,varname:node_6332,prsc:2;n:type:ShaderForge.SFN_Dot,id:8497,x:33774,y:30578,varname:node_8497,prsc:2,dt:3|A-6332-OUT,B-4126-OUT;n:type:ShaderForge.SFN_NormalVector,id:4126,x:33574,y:30482,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:3312,x:34036,y:30630,varname:node_3312,prsc:2|VAL-4634-OUT,EXP-4598-OUT;n:type:ShaderForge.SFN_Slider,id:4598,x:33879,y:30822,ptovrint:False,ptlb:SSS Light Exponent,ptin:_SSSLightExponent,varname:_SSSLightExponent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:2.215395,max:10;n:type:ShaderForge.SFN_Color,id:3743,x:34442,y:30551,ptovrint:False,ptlb:Color SSS by light,ptin:_ColorSSSbylight,varname:_ColorSSSbylight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5441177,c2:0.5058749,c3:0.2920632,c4:1;n:type:ShaderForge.SFN_Multiply,id:2382,x:34259,y:30561,varname:node_2382,prsc:2|A-3743-RGB,B-3312-OUT,C-4716-OUT;n:type:ShaderForge.SFN_Add,id:5383,x:34442,y:30792,varname:node_5383,prsc:2|A-2382-OUT,B-5592-OUT;n:type:ShaderForge.SFN_Clamp01,id:4634,x:33942,y:30529,varname:node_4634,prsc:2|IN-8497-OUT;n:type:ShaderForge.SFN_Vector1,id:3502,x:34462,y:31025,varname:node_3502,prsc:2,v1:0;n:type:ShaderForge.SFN_Clamp01,id:8212,x:34623,y:30741,varname:node_8212,prsc:2|IN-5383-OUT;n:type:ShaderForge.SFN_Slider,id:4261,x:34692,y:30536,ptovrint:False,ptlb:Transmision,ptin:_Transmision,varname:_Transmision,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5950896,max:2;n:type:ShaderForge.SFN_Multiply,id:1443,x:34757,y:30651,varname:node_1443,prsc:2|A-4261-OUT,B-3743-RGB;n:type:ShaderForge.SFN_Slider,id:119,x:34640,y:30359,ptovrint:False,ptlb:LightWrap,ptin:_LightWrap,varname:_LightWrap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8578664,max:2;n:type:ShaderForge.SFN_Multiply,id:5910,x:34986,y:30418,varname:node_5910,prsc:2|A-119-OUT,B-3743-RGB;proporder:5964-6665-7736-358-1813-1816-7935-4416-9875-3868-594-2745-2822-3538-9217-6298-9232-2907-4598-3743-4261-119;pass:END;sub:END;*/

Shader "Almgp/Leaf" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Color ("Color", Color) = (0.5019608,0.5019608,0.5019608,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _normal_detail ("normal_detail", 2D) = "bump" {}
        _alphaclip ("alpha clip", Range(0, 2)) = 0.9228432
        _AOpower ("AO power", Range(0, 2)) = 2
        _AOexp ("AO exp", Range(0.1, 3)) = 1.835046
        _cubemapssscolor ("cubemap sss color", Color) = (0.5220588,0.5220588,0.5220588,1)
        _SSScubemap ("SSS cubemap", Cube) = "_Skybox" {}
        _ssscubemapblur ("sss cubemap blur", Range(0, 8)) = 4.897436
        _AOtexture ("AO texture", 2D) = "white" {}
        [MaterialToggle] _useAOtexture ("use AO texture", Float ) = 0
        _vertexoffset ("vertex offset", Range(0, 0.018)) = 0
        _windmask ("wind mask", 2D) = "white" {}
        _windturbulent ("wind  turbulent", Float ) = 1
        _windspeed ("wind speed", Range(0, 1.5)) = 0.2176561
        _SSSLightExponent ("SSS Light Exponent", Range(0.1, 10)) = 2.215395
        _ColorSSSbylight ("Color SSS by light", Color) = (0.5441177,0.5058749,0.2920632,1)
        _Transmision ("Transmision", Range(0, 2)) = 0.5950896
        _LightWrap ("LightWrap", Range(0, 2)) = 0.8578664
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Gloss;
            uniform sampler2D _normal_detail; uniform float4 _normal_detail_ST;
            uniform float _alphaclip;
            uniform float _AOpower;
            uniform samplerCUBE _SSScubemap;
            uniform float _ssscubemapblur;
            uniform float _AOexp;
            uniform float4 _cubemapssscolor;
            uniform sampler2D _AOtexture; uniform float4 _AOtexture_ST;
            uniform fixed _useAOtexture;
            uniform float _vertexoffset;
            uniform sampler2D _windmask; uniform float4 _windmask_ST;
            uniform float _windturbulent;
            uniform float _windspeed;
            uniform float _SSSLightExponent;
            uniform float4 _ColorSSSbylight;
            uniform float _Transmision;
            uniform float _LightWrap;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_5361 = _Time + _TimeEditor;
                float2 node_3635 = ((float2(mul(unity_ObjectToWorld, v.vertex).r,mul(unity_ObjectToWorld, v.vertex).b)*_windturbulent)+(node_5361.r*_windspeed)*float2(1,1));
                float4 _windmask_var = tex2Dlod(_windmask,float4(TRANSFORM_TEX(node_3635, _windmask),0.0,0));
                v.vertex.xyz += ((_windmask_var.rgb*_vertexoffset)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 _normal_detail_var = UnpackNormal(tex2D(_normal_detail,TRANSFORM_TEX(i.uv0, _normal_detail)));
                float3 node_4165_nrm_base = _BumpMap_var.rgb + float3(0,0,1);
                float3 node_4165_nrm_detail = _normal_detail_var.rgb * float3(-1,-1,1);
                float3 node_4165_nrm_combined = node_4165_nrm_base*dot(node_4165_nrm_base, node_4165_nrm_detail)/node_4165_nrm_base.z - node_4165_nrm_detail;
                float3 node_4165 = node_4165_nrm_combined;
                float3 normalLocal = node_4165;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip((_MainTex_var.a*_alphaclip) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _AOtexture_var = tex2D(_AOtexture,TRANSFORM_TEX(i.uv0, _AOtexture));
                float3 node_4716 = pow((lerp( i.vertexColor.a, _AOtexture_var.rgb, _useAOtexture )*_AOpower),_AOexp);
                float gloss = (node_4716*_Gloss);
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularAO = node_4716.r;
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 diffuseColor = (_MainTex_var.rgb*_Color.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, 0.0, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular) * specularAO;
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = (_LightWrap*_ColorSSSbylight.rgb)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * (_Transmision*_ColorSSSbylight.rgb);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                NdotLWrap = max(float3(0,0,0), NdotLWrap);
                float3 directDiffuse = ((forwardLight+backLight) + ((1 +(fd90 - 1)*pow((1.00001-NdotLWrap), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL))*(0.5-max(w.r,max(w.g,w.b))*0.5) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= node_4716.r; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = saturate(((_ColorSSSbylight.rgb*pow(saturate(abs(dot(lightDirection,i.normalDir))),_SSSLightExponent)*node_4716)+((_cubemapssscolor.rgb+_cubemapssscolor.rgb)*texCUBElod(_SSScubemap,float4(viewReflectDirection,_ssscubemapblur)).rgb*node_4716)));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.4191176,0.402795,0.2711937,1));
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Gloss;
            uniform sampler2D _normal_detail; uniform float4 _normal_detail_ST;
            uniform float _alphaclip;
            uniform float _AOpower;
            uniform samplerCUBE _SSScubemap;
            uniform float _ssscubemapblur;
            uniform float _AOexp;
            uniform float4 _cubemapssscolor;
            uniform sampler2D _AOtexture; uniform float4 _AOtexture_ST;
            uniform fixed _useAOtexture;
            uniform float _vertexoffset;
            uniform sampler2D _windmask; uniform float4 _windmask_ST;
            uniform float _windturbulent;
            uniform float _windspeed;
            uniform float _SSSLightExponent;
            uniform float4 _ColorSSSbylight;
            uniform float _Transmision;
            uniform float _LightWrap;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_5361 = _Time + _TimeEditor;
                float2 node_3635 = ((float2(mul(unity_ObjectToWorld, v.vertex).r,mul(unity_ObjectToWorld, v.vertex).b)*_windturbulent)+(node_5361.r*_windspeed)*float2(1,1));
                float4 _windmask_var = tex2Dlod(_windmask,float4(TRANSFORM_TEX(node_3635, _windmask),0.0,0));
                v.vertex.xyz += ((_windmask_var.rgb*_vertexoffset)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 _normal_detail_var = UnpackNormal(tex2D(_normal_detail,TRANSFORM_TEX(i.uv0, _normal_detail)));
                float3 node_4165_nrm_base = _BumpMap_var.rgb + float3(0,0,1);
                float3 node_4165_nrm_detail = _normal_detail_var.rgb * float3(-1,-1,1);
                float3 node_4165_nrm_combined = node_4165_nrm_base*dot(node_4165_nrm_base, node_4165_nrm_detail)/node_4165_nrm_base.z - node_4165_nrm_detail;
                float3 node_4165 = node_4165_nrm_combined;
                float3 normalLocal = node_4165;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip((_MainTex_var.a*_alphaclip) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _AOtexture_var = tex2D(_AOtexture,TRANSFORM_TEX(i.uv0, _AOtexture));
                float3 node_4716 = pow((lerp( i.vertexColor.a, _AOtexture_var.rgb, _useAOtexture )*_AOpower),_AOexp);
                float gloss = (node_4716*_Gloss);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 diffuseColor = (_MainTex_var.rgb*_Color.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, 0.0, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = (_LightWrap*_ColorSSSbylight.rgb)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * (_Transmision*_ColorSSSbylight.rgb);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                NdotLWrap = max(float3(0,0,0), NdotLWrap);
                float3 directDiffuse = ((forwardLight+backLight) + ((1 +(fd90 - 1)*pow((1.00001-NdotLWrap), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL))*(0.5-max(w.r,max(w.g,w.b))*0.5) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.4191176,0.402795,0.2711937,1));
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _alphaclip;
            uniform float _vertexoffset;
            uniform sampler2D _windmask; uniform float4 _windmask_ST;
            uniform float _windturbulent;
            uniform float _windspeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float3 normalDir : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_5361 = _Time + _TimeEditor;
                float2 node_3635 = ((float2(mul(unity_ObjectToWorld, v.vertex).r,mul(unity_ObjectToWorld, v.vertex).b)*_windturbulent)+(node_5361.r*_windspeed)*float2(1,1));
                float4 _windmask_var = tex2Dlod(_windmask,float4(TRANSFORM_TEX(node_3635, _windmask),0.0,0));
                v.vertex.xyz += ((_windmask_var.rgb*_vertexoffset)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip((_MainTex_var.a*_alphaclip) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Gloss;
            uniform float _AOpower;
            uniform samplerCUBE _SSScubemap;
            uniform float _ssscubemapblur;
            uniform float _AOexp;
            uniform float4 _cubemapssscolor;
            uniform sampler2D _AOtexture; uniform float4 _AOtexture_ST;
            uniform fixed _useAOtexture;
            uniform float _vertexoffset;
            uniform sampler2D _windmask; uniform float4 _windmask_ST;
            uniform float _windturbulent;
            uniform float _windspeed;
            uniform float _SSSLightExponent;
            uniform float4 _ColorSSSbylight;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_5361 = _Time + _TimeEditor;
                float2 node_3635 = ((float2(mul(unity_ObjectToWorld, v.vertex).r,mul(unity_ObjectToWorld, v.vertex).b)*_windturbulent)+(node_5361.r*_windspeed)*float2(1,1));
                float4 _windmask_var = tex2Dlod(_windmask,float4(TRANSFORM_TEX(node_3635, _windmask),0.0,0));
                v.vertex.xyz += ((_windmask_var.rgb*_vertexoffset)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _AOtexture_var = tex2D(_AOtexture,TRANSFORM_TEX(i.uv0, _AOtexture));
                float3 node_4716 = pow((lerp( i.vertexColor.a, _AOtexture_var.rgb, _useAOtexture )*_AOpower),_AOexp);
                o.Emission = saturate(((_ColorSSSbylight.rgb*pow(saturate(abs(dot(lightDirection,i.normalDir))),_SSSLightExponent)*node_4716)+((_cubemapssscolor.rgb+_cubemapssscolor.rgb)*texCUBElod(_SSScubemap,float4(viewReflectDirection,_ssscubemapblur)).rgb*node_4716)));
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffColor = (_MainTex_var.rgb*_Color.rgb);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float roughness = 1.0 - (node_4716*_Gloss);
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
