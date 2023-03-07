// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:36123,y:31352,varname:node_4795,prsc:2|diff-4462-OUT,spec-3924-RGB,gloss-7440-OUT,normal-4214-OUT,emission-7597-OUT,alpha-8140-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32283,y:32904,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:35142,y:31825,varname:node_2393,prsc:2|A-6074-RGB,B-7379-OUT;n:type:ShaderForge.SFN_Color,id:797,x:31636,y:32594,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:7379,x:32474,y:32613,varname:node_7379,prsc:2|A-797-RGB,B-797-RGB,C-797-RGB,D-797-RGB;n:type:ShaderForge.SFN_Dot,id:5012,x:32645,y:32295,varname:node_5012,prsc:2,dt:0|A-8214-OUT,B-5487-OUT;n:type:ShaderForge.SFN_LightVector,id:5904,x:32143,y:32190,varname:node_5904,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5487,x:32397,y:32397,prsc:2,pt:False;n:type:ShaderForge.SFN_Clamp01,id:6552,x:32862,y:32305,varname:node_6552,prsc:2|IN-5012-OUT;n:type:ShaderForge.SFN_Power,id:6692,x:33080,y:32601,varname:node_6692,prsc:2|VAL-6552-OUT,EXP-6700-OUT;n:type:ShaderForge.SFN_Slider,id:6700,x:32718,y:32509,ptovrint:False,ptlb:exp,ptin:_exp,varname:_exp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.9444434,max:11;n:type:ShaderForge.SFN_Multiply,id:1693,x:33263,y:32601,varname:node_1693,prsc:2|A-6692-OUT,B-660-OUT;n:type:ShaderForge.SFN_Slider,id:660,x:32784,y:32969,ptovrint:False,ptlb:power,ptin:_power,varname:_power,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:4596,x:35156,y:31283,ptovrint:False,ptlb:normal,ptin:_normal,varname:_normal,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:6843,x:33379,y:32807,varname:node_6843,prsc:2|A-1693-OUT,B-6074-RGB;n:type:ShaderForge.SFN_Lerp,id:1395,x:34509,y:32346,varname:node_1395,prsc:2|A-1693-OUT,B-6843-OUT,T-9354-OUT;n:type:ShaderForge.SFN_Slider,id:9354,x:33618,y:32856,ptovrint:False,ptlb:substract factor,ptin:_substractfactor,varname:_substractfactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_ComponentMask,id:441,x:34933,y:32305,varname:node_441,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-9374-OUT;n:type:ShaderForge.SFN_Slider,id:7440,x:33330,y:32526,ptovrint:False,ptlb:gloss,ptin:_gloss,varname:_gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2905983,max:1;n:type:ShaderForge.SFN_Color,id:3924,x:33304,y:32243,ptovrint:False,ptlb:spec,ptin:_spec,varname:_spec,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4547,x:34438,y:31918,ptovrint:False,ptlb:Atmos gradient,ptin:_Atmosgradient,varname:_Atmosgradient,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c72949342dc36af428d7e0d2d3087665,ntxv:0,isnm:False|UVIN-164-OUT,MIP-1066-OUT;n:type:ShaderForge.SFN_Fresnel,id:6157,x:33599,y:31745,varname:node_6157,prsc:2|NRM-3640-OUT,EXP-4883-OUT;n:type:ShaderForge.SFN_NormalVector,id:3640,x:33377,y:31722,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:4883,x:33284,y:31930,ptovrint:False,ptlb:Planet radius,ptin:_Planetradius,varname:_Planetradius,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.513407,max:8;n:type:ShaderForge.SFN_Append,id:164,x:34023,y:31750,varname:node_164,prsc:2|A-4897-OUT,B-6157-OUT;n:type:ShaderForge.SFN_Vector1,id:4897,x:33717,y:32002,varname:node_4897,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:1066,x:33713,y:31526,ptovrint:False,ptlb:planet atmos blur,ptin:_planetatmosblur,varname:_planetatmosblur,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.929923,max:3;n:type:ShaderForge.SFN_Lerp,id:7186,x:34706,y:31429,varname:node_7186,prsc:2|A-5507-OUT,B-4547-RGB,T-1052-OUT;n:type:ShaderForge.SFN_RemapRange,id:1052,x:34176,y:31501,varname:node_1052,prsc:2,frmn:0,frmx:5,tomn:0,tomx:1|IN-1066-OUT;n:type:ShaderForge.SFN_Blend,id:1719,x:34283,y:31676,varname:node_1719,prsc:2,blmd:10,clmp:True|SRC-4547-RGB,DST-4547-RGB;n:type:ShaderForge.SFN_Multiply,id:7596,x:34341,y:31519,varname:node_7596,prsc:2|A-1719-OUT,B-1719-OUT;n:type:ShaderForge.SFN_Add,id:5507,x:34462,y:31429,varname:node_5507,prsc:2|A-7596-OUT,B-7596-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7517,x:34727,y:31630,ptovrint:False,ptlb:Atmos emmis,ptin:_Atmosemmis,varname:_Atmosemmis,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:1989,x:34706,y:31230,ptovrint:False,ptlb:Atmos add color,ptin:_Atmosaddcolor,varname:_Atmosaddcolor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7597,x:34708,y:31888,varname:node_7597,prsc:2|A-7517-OUT,B-7186-OUT,C-1989-RGB;n:type:ShaderForge.SFN_Subtract,id:9374,x:34989,y:32115,varname:node_9374,prsc:2|A-1395-OUT,B-2656-OUT;n:type:ShaderForge.SFN_Clamp01,id:2656,x:34023,y:31996,varname:node_2656,prsc:2|IN-6009-OUT;n:type:ShaderForge.SFN_Clamp01,id:8140,x:35186,y:32258,varname:node_8140,prsc:2|IN-441-OUT;n:type:ShaderForge.SFN_Add,id:6009,x:33773,y:31841,varname:node_6009,prsc:2|A-6157-OUT,B-6157-OUT;n:type:ShaderForge.SFN_Add,id:4462,x:35104,y:31666,varname:node_4462,prsc:2|A-7379-OUT,B-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6243,x:35036,y:31059,ptovrint:False,ptlb:height,ptin:_height,varname:_height,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6616,x:35607,y:30965,varname:node_6616,prsc:2|A-6142-OUT,B-2866-OUT,T-6243-R;n:type:ShaderForge.SFN_Slider,id:4813,x:34943,y:30872,ptovrint:False,ptlb:normal power 1,ptin:_normalpower1,varname:_normalpower1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:2866,x:35319,y:30918,varname:node_2866,prsc:2|A-4813-OUT,B-6243-R;n:type:ShaderForge.SFN_Multiply,id:6142,x:35317,y:30740,varname:node_6142,prsc:2|A-8651-OUT,B-6243-R;n:type:ShaderForge.SFN_Slider,id:8651,x:34943,y:30747,ptovrint:False,ptlb:normal power 2,ptin:_normalpower2,varname:_normalpower2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Lerp,id:4214,x:35655,y:31160,varname:node_4214,prsc:2|A-1814-OUT,B-4596-RGB,T-6616-OUT;n:type:ShaderForge.SFN_Vector3,id:1814,x:35288,y:31168,varname:node_1814,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Add,id:2794,x:32215,y:31990,varname:node_2794,prsc:2|A-5961-OUT,B-5904-OUT;n:type:ShaderForge.SFN_Color,id:125,x:31800,y:31899,ptovrint:False,ptlb:Fix direct,ptin:_Fixdirect,varname:_Fixdirect,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.859,c2:0.8352813,c3:0.657994,c4:1;n:type:ShaderForge.SFN_RemapRange,id:5961,x:32006,y:31899,varname:node_5961,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-125-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:8214,x:32451,y:32077,ptovrint:False,ptlb:Use custom direct,ptin:_Usecustomdirect,varname:_Usecustomdirect,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5904-OUT,B-2794-OUT;proporder:6074-797-6700-660-4596-9354-7440-3924-4547-4883-1066-7517-1989-6243-4813-8651-125-8214;pass:END;sub:END;*/

Shader "Almgp/planet" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _exp ("exp", Range(0.1, 11)) = 0.9444434
        _power ("power", Range(0, 1)) = 1
        _normal ("normal", 2D) = "bump" {}
        _substractfactor ("substract factor", Range(0, 1)) = 1
        _gloss ("gloss", Range(0, 1)) = 0.2905983
        _spec ("spec", Color) = (0.5,0.5,0.5,1)
        _Atmosgradient ("Atmos gradient", 2D) = "white" {}
        _Planetradius ("Planet radius", Range(0.1, 8)) = 1.513407
        _planetatmosblur ("planet atmos blur", Range(0, 3)) = 1.929923
        _Atmosemmis ("Atmos emmis", Float ) = 1
        _Atmosaddcolor ("Atmos add color", Color) = (1,1,1,1)
        _height ("height", 2D) = "white" {}
        _normalpower1 ("normal power 1", Range(0, 5)) = 0
        _normalpower2 ("normal power 2", Range(0, 5)) = 0
        _Fixdirect ("Fix direct", Color) = (0.859,0.8352813,0.657994,1)
        [MaterialToggle] _Usecustomdirect ("Use custom direct", Float ) = 0
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _exp;
            uniform float _power;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float _substractfactor;
            uniform float _gloss;
            uniform float4 _spec;
            uniform sampler2D _Atmosgradient; uniform float4 _Atmosgradient_ST;
            uniform float _Planetradius;
            uniform float _planetatmosblur;
            uniform float _Atmosemmis;
            uniform float4 _Atmosaddcolor;
            uniform sampler2D _height; uniform float4 _height_ST;
            uniform float _normalpower1;
            uniform float _normalpower2;
            uniform float4 _Fixdirect;
            uniform fixed _Usecustomdirect;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float4 _height_var = tex2D(_height,TRANSFORM_TEX(i.uv0, _height));
                float3 normalLocal = lerp(float3(0,1,0),_normal_var.rgb,lerp((_normalpower2*_height_var.r),(_normalpower1*_height_var.r),_height_var.r));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _spec.rgb;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 node_7379 = (_TintColor.rgb+_TintColor.rgb+_TintColor.rgb+_TintColor.rgb);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (node_7379+(_MainTex_var.rgb*node_7379));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_6157 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Planetradius);
                float2 node_164 = float2(0.0,node_6157);
                float4 _Atmosgradient_var = tex2Dlod(_Atmosgradient,float4(TRANSFORM_TEX(node_164, _Atmosgradient),0.0,_planetatmosblur));
                float3 node_1719 = saturate(( _Atmosgradient_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_Atmosgradient_var.rgb-0.5))*(1.0-_Atmosgradient_var.rgb)) : (2.0*_Atmosgradient_var.rgb*_Atmosgradient_var.rgb) ));
                float3 node_7596 = (node_1719*node_1719);
                float3 emissive = (_Atmosemmis*lerp((node_7596+node_7596),_Atmosgradient_var.rgb,(_planetatmosblur*0.2+0.0))*_Atmosaddcolor.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_1693 = (pow(saturate(dot(lerp( lightDirection, ((_Fixdirect.rgb*2.0+-1.0)+lightDirection), _Usecustomdirect ),i.normalDir)),_exp)*_power);
                return fixed4(finalColor,saturate((lerp(float3(node_1693,node_1693,node_1693),(node_1693*_MainTex_var.rgb),_substractfactor)-saturate((node_6157+node_6157))).r));
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _exp;
            uniform float _power;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float _substractfactor;
            uniform float _gloss;
            uniform float4 _spec;
            uniform sampler2D _Atmosgradient; uniform float4 _Atmosgradient_ST;
            uniform float _Planetradius;
            uniform float _planetatmosblur;
            uniform float _Atmosemmis;
            uniform float4 _Atmosaddcolor;
            uniform sampler2D _height; uniform float4 _height_ST;
            uniform float _normalpower1;
            uniform float _normalpower2;
            uniform float4 _Fixdirect;
            uniform fixed _Usecustomdirect;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float4 _height_var = tex2D(_height,TRANSFORM_TEX(i.uv0, _height));
                float3 normalLocal = lerp(float3(0,1,0),_normal_var.rgb,lerp((_normalpower2*_height_var.r),(_normalpower1*_height_var.r),_height_var.r));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _spec.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 node_7379 = (_TintColor.rgb+_TintColor.rgb+_TintColor.rgb+_TintColor.rgb);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (node_7379+(_MainTex_var.rgb*node_7379));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_1693 = (pow(saturate(dot(lerp( lightDirection, ((_Fixdirect.rgb*2.0+-1.0)+lightDirection), _Usecustomdirect ),i.normalDir)),_exp)*_power);
                float node_6157 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Planetradius);
                return fixed4(finalColor * saturate((lerp(float3(node_1693,node_1693,node_1693),(node_1693*_MainTex_var.rgb),_substractfactor)-saturate((node_6157+node_6157))).r),0);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
