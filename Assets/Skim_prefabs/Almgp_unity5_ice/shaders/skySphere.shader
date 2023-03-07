// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:34674,y:31486,varname:node_4795,prsc:2|emission-7883-OUT,alpha-303-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32153,y:32646,varname:_MainTex,prsc:2,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False|UVIN-4170-OUT,TEX-6637-TEX;n:type:ShaderForge.SFN_Multiply,id:2393,x:34346,y:31592,varname:node_2393,prsc:2|A-1000-OUT,B-4931-OUT;n:type:ShaderForge.SFN_Color,id:797,x:33673,y:32191,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:6637,x:31478,y:32772,ptovrint:False,ptlb:cloud texture,ptin:_cloudtexture,varname:_cloudtexture,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7441,x:32105,y:32469,varname:_node_7441,prsc:2,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False|UVIN-8801-OUT,TEX-6637-TEX;n:type:ShaderForge.SFN_Blend,id:7645,x:32352,y:32185,varname:node_7645,prsc:2,blmd:19,clmp:True|SRC-3116-OUT,DST-9697-OUT;n:type:ShaderForge.SFN_TexCoord,id:2234,x:31478,y:32368,varname:node_2234,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:4340,x:31389,y:32069,varname:node_4340,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1071,x:31804,y:32106,varname:node_1071,prsc:2|A-4340-TSL,B-4013-OUT,C-4172-OUT;n:type:ShaderForge.SFN_Add,id:8801,x:31912,y:32373,varname:node_8801,prsc:2|A-1071-OUT,B-2234-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:1803,x:32076,y:32114,varname:node_1803,prsc:2|IN-1071-OUT;n:type:ShaderForge.SFN_Add,id:4170,x:31953,y:32587,varname:node_4170,prsc:2|A-1803-OUT,B-6841-OUT,C-8803-OUT;n:type:ShaderForge.SFN_Vector1,id:8803,x:31733,y:32855,varname:node_8803,prsc:2,v1:0.5;n:type:ShaderForge.SFN_TexCoord,id:111,x:31478,y:32530,varname:node_111,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:6841,x:31696,y:32510,varname:node_6841,prsc:2|A-111-UVOUT,B-6118-OUT;n:type:ShaderForge.SFN_Vector1,id:6118,x:31598,y:32647,varname:node_6118,prsc:2,v1:0.83;n:type:ShaderForge.SFN_Slider,id:4013,x:31400,y:32229,ptovrint:False,ptlb:speed,ptin:_speed,varname:_speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:1,max:1;n:type:ShaderForge.SFN_ComponentMask,id:2272,x:32829,y:32537,varname:node_2272,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6780-OUT;n:type:ShaderForge.SFN_Blend,id:1886,x:32442,y:32429,varname:node_1886,prsc:2,blmd:3,clmp:True|SRC-3116-OUT,DST-9697-OUT;n:type:ShaderForge.SFN_Blend,id:648,x:32501,y:32158,varname:node_648,prsc:2,blmd:6,clmp:True|SRC-7645-OUT,DST-1886-OUT;n:type:ShaderForge.SFN_Slider,id:4172,x:31389,y:31893,ptovrint:False,ptlb:time factor,ptin:_timefactor,varname:_timefactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:6780,x:32709,y:32158,varname:node_6780,prsc:2|A-648-OUT,B-7645-OUT,T-5106-OUT;n:type:ShaderForge.SFN_Vector1,id:5106,x:32681,y:32297,varname:node_5106,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:7261,x:32860,y:32729,varname:node_7261,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:7422,x:33082,y:32063,varname:node_7422,prsc:2|A-7261-OUT,B-200-OUT;n:type:ShaderForge.SFN_Tex2d,id:6789,x:32887,y:32124,ptovrint:False,ptlb:cloud gradient,ptin:_cloudgradient,varname:_cloudgradient,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d61840569a2b46f45999072222eebdfc,ntxv:0,isnm:False|UVIN-7422-OUT;n:type:ShaderForge.SFN_Clamp01,id:303,x:34170,y:32039,varname:node_303,prsc:2|IN-2600-OUT;n:type:ShaderForge.SFN_Multiply,id:2600,x:33782,y:32500,varname:node_2600,prsc:2|A-2272-OUT,B-8708-OUT;n:type:ShaderForge.SFN_Slider,id:8708,x:33221,y:32759,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:_opacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Power,id:3116,x:32162,y:32262,varname:node_3116,prsc:2|VAL-7441-RGB,EXP-2943-OUT;n:type:ShaderForge.SFN_Slider,id:2943,x:31852,y:32262,ptovrint:False,ptlb:exp,ptin:_exp,varname:_exp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.967409,max:8;n:type:ShaderForge.SFN_Power,id:9697,x:32292,y:32481,varname:node_9697,prsc:2|VAL-6074-RGB,EXP-2943-OUT;n:type:ShaderForge.SFN_Multiply,id:1627,x:33759,y:31850,varname:node_1627,prsc:2|A-6014-OUT,B-9336-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1251,x:33146,y:31937,ptovrint:False,ptlb:final power,ptin:_finalpower,varname:_finalpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Power,id:200,x:32887,y:31931,varname:node_200,prsc:2|VAL-2272-OUT,EXP-5477-OUT;n:type:ShaderForge.SFN_Slider,id:5477,x:32565,y:31966,ptovrint:False,ptlb:exponen gradient,ptin:_exponengradient,varname:_exponengradient,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.5,cur:0.5,max:8;n:type:ShaderForge.SFN_Color,id:9116,x:33031,y:31646,ptovrint:False,ptlb:bottom color,ptin:_bottomcolor,varname:_bottomcolor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:3354,x:33246,y:31771,varname:node_3354,prsc:2|A-200-OUT,B-9116-RGB;n:type:ShaderForge.SFN_Add,id:9336,x:33475,y:31758,varname:node_9336,prsc:2|A-3354-OUT,B-6789-RGB;n:type:ShaderForge.SFN_Multiply,id:6014,x:33493,y:31900,varname:node_6014,prsc:2|A-1251-OUT,B-6623-OUT;n:type:ShaderForge.SFN_OneMinus,id:5983,x:33143,y:32255,varname:node_5983,prsc:2|IN-2272-OUT;n:type:ShaderForge.SFN_Multiply,id:6623,x:33302,y:32173,varname:node_6623,prsc:2|A-5983-OUT,B-5983-OUT;n:type:ShaderForge.SFN_Dot,id:6911,x:33341,y:31177,varname:node_6911,prsc:2,dt:3|A-7898-OUT,B-647-OUT;n:type:ShaderForge.SFN_NormalVector,id:647,x:32806,y:31134,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:8679,x:33561,y:31105,varname:node_8679,prsc:2|VAL-6911-OUT,EXP-1436-OUT;n:type:ShaderForge.SFN_Slider,id:1436,x:33088,y:30900,ptovrint:False,ptlb:sun exp,ptin:_sunexp,varname:_sunexp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:4.974973,max:75;n:type:ShaderForge.SFN_Clamp01,id:9799,x:33926,y:31339,varname:node_9799,prsc:2|IN-8679-OUT;n:type:ShaderForge.SFN_Color,id:3879,x:33795,y:31003,ptovrint:False,ptlb:sun color,ptin:_suncolor,varname:_suncolor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7943,x:34105,y:31249,varname:node_7943,prsc:2|A-3879-RGB,B-9799-OUT,C-7395-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7395,x:33379,y:31608,ptovrint:False,ptlb:sun power,ptin:_sunpower,varname:_sunpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:1000,x:33890,y:31543,varname:node_1000,prsc:2|A-7943-OUT,B-1627-OUT;n:type:ShaderForge.SFN_Color,id:1211,x:32736,y:31510,ptovrint:False,ptlb:sun direction,ptin:_sundirection,varname:_sundirection,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.5,c3:0,c4:0;n:type:ShaderForge.SFN_RemapRange,id:8002,x:33048,y:31465,varname:node_8002,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-1211-RGB;n:type:ShaderForge.SFN_OneMinus,id:4257,x:33561,y:31227,varname:node_4257,prsc:2|IN-6911-OUT;n:type:ShaderForge.SFN_Add,id:7818,x:33722,y:31239,varname:node_7818,prsc:2|A-4257-OUT,B-4257-OUT,C-4257-OUT;n:type:ShaderForge.SFN_LightVector,id:5385,x:32806,y:31304,varname:node_5385,prsc:2;n:type:ShaderForge.SFN_Add,id:7898,x:33139,y:31258,varname:node_7898,prsc:2|A-5385-OUT,B-8002-OUT;n:type:ShaderForge.SFN_Add,id:4931,x:34075,y:31862,varname:node_4931,prsc:2|A-797-RGB,B-797-RGB;n:type:ShaderForge.SFN_Desaturate,id:7883,x:34469,y:31452,varname:node_7883,prsc:2|COL-2393-OUT,DES-9838-OUT;n:type:ShaderForge.SFN_Slider,id:9838,x:34055,y:31405,ptovrint:False,ptlb:dessaturate,ptin:_dessaturate,varname:_dessaturate,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:1,max:1;proporder:797-6637-4013-4172-6789-8708-2943-1251-5477-9116-1436-3879-7395-1211-9838;pass:END;sub:END;*/

Shader "Almgp/skySphere" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _cloudtexture ("cloud texture", 2D) = "white" {}
        _speed ("speed", Range(-1, 1)) = 1
        _timefactor ("time factor", Range(0, 1)) = 1
        _cloudgradient ("cloud gradient", 2D) = "white" {}
        _opacity ("opacity", Range(0, 5)) = 1
        _exp ("exp", Range(0.1, 8)) = 1.967409
        _finalpower ("final power", Float ) = 5
        _exponengradient ("exponen gradient", Range(0.5, 8)) = 0.5
        _bottomcolor ("bottom color", Color) = (0.5,0.5,0.5,1)
        _sunexp ("sun exp", Range(0.1, 75)) = 4.974973
        _suncolor ("sun color", Color) = (0.5,0.5,0.5,1)
        _sunpower ("sun power", Float ) = 1
        _sundirection ("sun direction", Color) = (0,0.5,0,0)
        _dessaturate ("dessaturate", Range(-1, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform sampler2D _cloudtexture; uniform float4 _cloudtexture_ST;
            uniform float _speed;
            uniform float _timefactor;
            uniform sampler2D _cloudgradient; uniform float4 _cloudgradient_ST;
            uniform float _opacity;
            uniform float _exp;
            uniform float _finalpower;
            uniform float _exponengradient;
            uniform float4 _bottomcolor;
            uniform float _sunexp;
            uniform float4 _suncolor;
            uniform float _sunpower;
            uniform float4 _sundirection;
            uniform float _dessaturate;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float node_6911 = abs(dot((lightDirection+(_sundirection.rgb*2.0+-1.0)),i.normalDir));
                float4 node_4340 = _Time + _TimeEditor;
                float node_1071 = (node_4340.r*_speed*_timefactor);
                float2 node_8801 = (node_1071+i.uv0);
                float4 _node_7441 = tex2D(_cloudtexture,TRANSFORM_TEX(node_8801, _cloudtexture));
                float3 node_3116 = pow(_node_7441.rgb,_exp);
                float2 node_4170 = ((1.0 - node_1071)+(i.uv0*0.83)+0.5);
                float4 _MainTex = tex2D(_cloudtexture,TRANSFORM_TEX(node_4170, _cloudtexture));
                float3 node_9697 = pow(_MainTex.rgb,_exp);
                float3 node_7645 = saturate((node_9697-node_3116));
                float node_2272 = lerp(saturate((1.0-(1.0-node_7645)*(1.0-saturate((node_3116+node_9697-1.0))))),node_7645,0.5).r;
                float node_5983 = (1.0 - node_2272);
                float node_200 = pow(node_2272,_exponengradient);
                float2 node_7422 = float2(1.0,node_200);
                float4 _cloudgradient_var = tex2D(_cloudgradient,TRANSFORM_TEX(node_7422, _cloudgradient));
                float3 emissive = lerp((((_suncolor.rgb*saturate(pow(node_6911,_sunexp))*_sunpower)+((_finalpower*(node_5983*node_5983))*((node_200*_bottomcolor.rgb)+_cloudgradient_var.rgb)))*(_TintColor.rgb+_TintColor.rgb)),dot((((_suncolor.rgb*saturate(pow(node_6911,_sunexp))*_sunpower)+((_finalpower*(node_5983*node_5983))*((node_200*_bottomcolor.rgb)+_cloudgradient_var.rgb)))*(_TintColor.rgb+_TintColor.rgb)),float3(0.3,0.59,0.11)),_dessaturate);
                float3 finalColor = emissive;
                return fixed4(finalColor,saturate((node_2272*_opacity)));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
