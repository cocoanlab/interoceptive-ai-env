// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:34834,y:32169,varname:node_2865,prsc:2|diff-8257-OUT,spec-225-OUT,gloss-6595-OUT,normal-1213-OUT,emission-9430-OUT,difocc-5497-R,spcocc-5497-R;n:type:ShaderForge.SFN_Multiply,id:6343,x:32313,y:32655,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31914,y:32777,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31914,y:32527,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32742,y:33059,varname:_BumpMap,prsc:2,ntxv:3,isnm:True|TEX-8287-TEX;n:type:ShaderForge.SFN_Tex2d,id:6695,x:32402,y:32462,ptovrint:False,ptlb:Detail_normal,ptin:_Detail_normal,varname:_Detail_normal,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_NormalBlend,id:7076,x:33378,y:32583,varname:node_7076,prsc:2|BSE-5964-RGB,DTL-6695-RGB;n:type:ShaderForge.SFN_Tex2d,id:3533,x:31905,y:32244,ptovrint:False,ptlb:detail diffuse,ptin:_detaildiffuse,varname:_detaildiffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:309,x:32204,y:32273,varname:node_309,prsc:2,blmd:10,clmp:True|SRC-6343-OUT,DST-3533-RGB;n:type:ShaderForge.SFN_Lerp,id:928,x:32959,y:32235,varname:node_928,prsc:2|A-309-OUT,B-6343-OUT,T-4263-OUT;n:type:ShaderForge.SFN_Slider,id:4263,x:32061,y:32474,ptovrint:False,ptlb:detail factor,ptin:_detailfactor,varname:_detailfactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:5497,x:32253,y:33108,ptovrint:False,ptlb:Ambient occlusion,ptin:_Ambientocclusion,varname:_Ambientocclusion,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:091f993aa47b1464293a6ef31003ac13,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3127,x:33477,y:31454,ptovrint:False,ptlb:heights,ptin:_heights,varname:_heights,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:625c2958269b5384ab11f31bfd360bd4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4691,x:32099,y:31740,ptovrint:False,ptlb:moss_albedo,ptin:_moss_albedo,varname:_moss_albedo,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:951aab9a19f551f4385d0ceafdaf19b4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4728,x:32382,y:31941,ptovrint:False,ptlb:moss_normal,ptin:_moss_normal,varname:_moss_normal,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:be053ea3235ccb64a889bf0b15c2764b,ntxv:3,isnm:True;n:type:ShaderForge.SFN_NormalVector,id:4542,x:32934,y:31302,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:3883,x:33158,y:31383,varname:node_3883,prsc:2,dt:0|A-4542-OUT,B-6324-RGB;n:type:ShaderForge.SFN_FragmentPosition,id:219,x:32565,y:31562,varname:node_219,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6534,x:32834,y:31839,varname:node_6534,prsc:2|A-219-Y,B-9585-OUT;n:type:ShaderForge.SFN_Vector1,id:9585,x:32782,y:32020,varname:node_9585,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:7933,x:33185,y:31701,varname:node_7933,prsc:2|IN-3883-OUT;n:type:ShaderForge.SFN_Add,id:6018,x:33377,y:31683,varname:node_6018,prsc:2|A-7933-OUT,B-7933-OUT;n:type:ShaderForge.SFN_Power,id:8834,x:33734,y:31683,varname:node_8834,prsc:2|VAL-6018-OUT,EXP-8657-OUT;n:type:ShaderForge.SFN_Slider,id:8657,x:32863,y:31853,ptovrint:False,ptlb:exponent,ptin:_exponent,varname:_exponent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.25,cur:0.9230769,max:9;n:type:ShaderForge.SFN_Subtract,id:9179,x:33865,y:31795,varname:node_9179,prsc:2|A-8834-OUT,B-3059-OUT;n:type:ShaderForge.SFN_Multiply,id:3059,x:33354,y:31985,varname:node_3059,prsc:2|A-3127-R,B-992-OUT;n:type:ShaderForge.SFN_Slider,id:992,x:33449,y:31317,ptovrint:False,ptlb:mask substract,ptin:_masksubstract,varname:_masksubstract,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.239319,max:5;n:type:ShaderForge.SFN_Clamp01,id:7534,x:33096,y:32083,varname:node_7534,prsc:2|IN-9179-OUT;n:type:ShaderForge.SFN_Lerp,id:8257,x:33865,y:32024,varname:node_8257,prsc:2|A-928-OUT,B-5745-OUT,T-7534-OUT;n:type:ShaderForge.SFN_Lerp,id:9036,x:33815,y:32392,varname:node_9036,prsc:2|A-7076-OUT,B-9381-OUT,T-7534-OUT;n:type:ShaderForge.SFN_LightColor,id:2024,x:34323,y:31463,varname:node_2024,prsc:2;n:type:ShaderForge.SFN_LightVector,id:8766,x:34031,y:31128,varname:node_8766,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:146,x:34031,y:31262,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:249,x:34266,y:31262,varname:node_249,prsc:2,dt:1|A-8766-OUT,B-146-OUT;n:type:ShaderForge.SFN_Clamp01,id:2626,x:34427,y:31211,varname:node_2626,prsc:2|IN-249-OUT;n:type:ShaderForge.SFN_Multiply,id:3820,x:34877,y:31276,varname:node_3820,prsc:2|A-8591-OUT,B-9114-OUT;n:type:ShaderForge.SFN_Power,id:8591,x:34721,y:31212,varname:node_8591,prsc:2|VAL-5648-OUT,EXP-5128-OUT;n:type:ShaderForge.SFN_Slider,id:5128,x:34655,y:31042,ptovrint:False,ptlb:SSS_factor,ptin:_SSS_factor,varname:_SSS_factor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:3.164421,max:9;n:type:ShaderForge.SFN_Color,id:9926,x:34585,y:31492,ptovrint:False,ptlb:SSS_color,ptin:_SSS_color,varname:_SSS_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9114,x:34707,y:31377,varname:node_9114,prsc:2|A-2024-RGB,B-9926-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:767,x:34263,y:31917,ptovrint:False,ptlb:Use SSS1,ptin:_UseSSS1,varname:_UseSSS1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-8146-OUT,B-3820-OUT;n:type:ShaderForge.SFN_Vector1,id:8146,x:34879,y:31478,varname:node_8146,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:9430,x:34464,y:31974,varname:node_9430,prsc:2|A-1748-OUT,B-767-OUT,T-7534-OUT;n:type:ShaderForge.SFN_Vector1,id:1748,x:34419,y:31914,varname:node_1748,prsc:2,v1:0;n:type:ShaderForge.SFN_Fresnel,id:5953,x:34450,y:31046,varname:node_5953,prsc:2|NRM-146-OUT,EXP-5993-OUT;n:type:ShaderForge.SFN_Slider,id:5993,x:34068,y:31028,ptovrint:False,ptlb:Freshnel exp,ptin:_Freshnelexp,varname:_Freshnelexp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.115951,max:2;n:type:ShaderForge.SFN_Multiply,id:5648,x:34544,y:31155,varname:node_5648,prsc:2|A-5953-OUT,B-2626-OUT;n:type:ShaderForge.SFN_Color,id:5688,x:32334,y:31433,ptovrint:False,ptlb:detail color add,ptin:_detailcoloradd,varname:_detailcoloradd,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:8241,x:32560,y:31403,varname:node_8241,prsc:2|A-5688-RGB,B-5688-RGB;n:type:ShaderForge.SFN_Multiply,id:5745,x:32369,y:31682,varname:node_5745,prsc:2|A-8241-OUT,B-4691-RGB;n:type:ShaderForge.SFN_NormalBlend,id:9381,x:32817,y:32101,varname:node_9381,prsc:2|BSE-3185-RGB,DTL-4728-RGB;n:type:ShaderForge.SFN_Tex2d,id:3185,x:32742,y:32836,varname:_node_3185,prsc:2,ntxv:0,isnm:False|MIP-7707-OUT,TEX-8287-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8287,x:32487,y:32987,ptovrint:False,ptlb:Base_normal,ptin:_Base_normal,varname:_Base_normal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:7707,x:32330,y:32830,ptovrint:False,ptlb:moss normal blur,ptin:_mossnormalblur,varname:_mossnormalblur,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:7;n:type:ShaderForge.SFN_Color,id:6324,x:32934,y:30990,ptovrint:False,ptlb:Direc,ptin:_Direc,varname:_Direc,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0,c4:0;n:type:ShaderForge.SFN_Vector1,id:225,x:33167,y:32936,varname:node_225,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:9373,x:34352,y:32820,varname:node_9373,prsc:2|A-4847-OUT,B-6505-OUT,T-2380-OUT;n:type:ShaderForge.SFN_Vector3,id:8799,x:33590,y:32554,varname:node_8799,prsc:2,v1:0.5,v2:0.5,v3:1;n:type:ShaderForge.SFN_Slider,id:589,x:32867,y:32720,ptovrint:False,ptlb:normal top power,ptin:_normaltoppower,varname:_normaltoppower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:5531,x:32990,y:32802,ptovrint:False,ptlb:normal down power,ptin:_normaldownpower,varname:_normaldownpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:4847,x:34107,y:32772,varname:node_4847,prsc:2|A-8799-OUT,B-9036-OUT,T-589-OUT;n:type:ShaderForge.SFN_Lerp,id:6505,x:34107,y:32915,varname:node_6505,prsc:2|A-8799-OUT,B-9036-OUT,T-5531-OUT;n:type:ShaderForge.SFN_Clamp,id:8482,x:33875,y:32177,varname:node_8482,prsc:2|IN-3489-OUT,MIN-5156-OUT,MAX-777-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:2380,x:34096,y:32231,varname:node_2380,prsc:2|IN-8482-OUT,IMIN-5156-OUT,IMAX-777-OUT,OMIN-8118-OUT,OMAX-2568-OUT;n:type:ShaderForge.SFN_Vector1,id:8118,x:33440,y:32362,varname:node_8118,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2568,x:33590,y:32322,varname:node_2568,prsc:2,v1:1;n:type:ShaderForge.SFN_SwitchProperty,id:1213,x:34272,y:32498,ptovrint:False,ptlb:use advanced normal setting,ptin:_useadvancednormalsetting,varname:_useadvancednormalsetting,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9036-OUT,B-9373-OUT;n:type:ShaderForge.SFN_Slider,id:5156,x:33096,y:32366,ptovrint:False,ptlb:Norm Min cut,ptin:_NormMincut,varname:_NormMincut,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.89;n:type:ShaderForge.SFN_Slider,id:777,x:33096,y:32512,ptovrint:False,ptlb:Norm Max cut,ptin:_NormMaxcut,varname:_NormMaxcut,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.15,cur:1,max:1;n:type:ShaderForge.SFN_Power,id:3370,x:33569,y:32150,varname:node_3370,prsc:2|VAL-3059-OUT,EXP-9943-OUT;n:type:ShaderForge.SFN_Slider,id:9943,x:33263,y:32177,ptovrint:False,ptlb:mask normal exponent,ptin:_masknormalexponent,varname:_masknormalexponent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8644247,max:5;n:type:ShaderForge.SFN_SwitchProperty,id:3489,x:33644,y:31934,ptovrint:False,ptlb:use normal mask exponent,ptin:_usenormalmaskexponent,varname:_usenormalmaskexponent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-3059-OUT,B-3370-OUT;n:type:ShaderForge.SFN_Lerp,id:1264,x:34412,y:32214,varname:node_1264,prsc:2|A-2659-OUT,B-978-OUT,T-2380-OUT;n:type:ShaderForge.SFN_Slider,id:978,x:34071,y:32138,ptovrint:False,ptlb:gloss curvature,ptin:_glosscurvature,varname:_glosscurvature,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:2659,x:34018,y:32024,ptovrint:False,ptlb:gloss tops,ptin:_glosstops,varname:_glosstops,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_SwitchProperty,id:6595,x:34589,y:32313,ptovrint:False,ptlb:use gloss,ptin:_usegloss,varname:_usegloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2204-OUT,B-1264-OUT;n:type:ShaderForge.SFN_Vector1,id:2204,x:34331,y:32401,varname:node_2204,prsc:2,v1:0;proporder:6665-7736-6695-3533-4263-5497-3127-8657-992-4691-4728-5128-9926-767-5993-5688-8287-7707-6324-589-5531-1213-5156-777-9943-3489-978-2659-6595;pass:END;sub:END;*/

Shader "Almgp/mossyStone/MossyStone_topBottom" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _Detail_normal ("Detail_normal", 2D) = "bump" {}
        _detaildiffuse ("detail diffuse", 2D) = "white" {}
        _detailfactor ("detail factor", Range(0, 1)) = 0
        _Ambientocclusion ("Ambient occlusion", 2D) = "white" {}
        _heights ("heights", 2D) = "white" {}
        _exponent ("exponent", Range(0.25, 9)) = 0.9230769
        _masksubstract ("mask substract", Range(0, 5)) = 1.239319
        _moss_albedo ("moss_albedo", 2D) = "white" {}
        _moss_normal ("moss_normal", 2D) = "bump" {}
        _SSS_factor ("SSS_factor", Range(1, 9)) = 3.164421
        _SSS_color ("SSS_color", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _UseSSS1 ("Use SSS1", Float ) = 0
        _Freshnelexp ("Freshnel exp", Range(0.1, 2)) = 1.115951
        _detailcoloradd ("detail color add", Color) = (0.5,0.5,0.5,1)
        _Base_normal ("Base_normal", 2D) = "bump" {}
        _mossnormalblur ("moss normal blur", Range(0, 7)) = 0
        _Direc ("Direc", Color) = (0,1,0,0)
        _normaltoppower ("normal top power", Range(0, 1)) = 1
        _normaldownpower ("normal down power", Range(0, 1)) = 1
        [MaterialToggle] _useadvancednormalsetting ("use advanced normal setting", Float ) = 0
        _NormMincut ("Norm Min cut", Range(0, 0.89)) = 0
        _NormMaxcut ("Norm Max cut", Range(0.15, 1)) = 1
        _masknormalexponent ("mask normal exponent", Range(0, 5)) = 0.8644247
        [MaterialToggle] _usenormalmaskexponent ("use normal mask exponent", Float ) = 0
        _glosscurvature ("gloss curvature", Range(0, 1)) = 0
        _glosstops ("gloss tops", Range(0, 1)) = 0
        [MaterialToggle] _usegloss ("use gloss", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
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
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Detail_normal; uniform float4 _Detail_normal_ST;
            uniform sampler2D _detaildiffuse; uniform float4 _detaildiffuse_ST;
            uniform float _detailfactor;
            uniform sampler2D _Ambientocclusion; uniform float4 _Ambientocclusion_ST;
            uniform sampler2D _heights; uniform float4 _heights_ST;
            uniform sampler2D _moss_albedo; uniform float4 _moss_albedo_ST;
            uniform sampler2D _moss_normal; uniform float4 _moss_normal_ST;
            uniform float _exponent;
            uniform float _masksubstract;
            uniform float _SSS_factor;
            uniform float4 _SSS_color;
            uniform fixed _UseSSS1;
            uniform float _Freshnelexp;
            uniform float4 _detailcoloradd;
            uniform sampler2D _Base_normal; uniform float4 _Base_normal_ST;
            uniform float _mossnormalblur;
            uniform float4 _Direc;
            uniform float _normaltoppower;
            uniform float _normaldownpower;
            uniform fixed _useadvancednormalsetting;
            uniform float _NormMincut;
            uniform float _NormMaxcut;
            uniform float _masknormalexponent;
            uniform fixed _usenormalmaskexponent;
            uniform float _glosscurvature;
            uniform float _glosstops;
            uniform fixed _usegloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
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
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap = UnpackNormal(tex2D(_Base_normal,TRANSFORM_TEX(i.uv0, _Base_normal)));
                float3 _Detail_normal_var = UnpackNormal(tex2D(_Detail_normal,TRANSFORM_TEX(i.uv0, _Detail_normal)));
                float3 node_7076_nrm_base = _BumpMap.rgb + float3(0,0,1);
                float3 node_7076_nrm_detail = _Detail_normal_var.rgb * float3(-1,-1,1);
                float3 node_7076_nrm_combined = node_7076_nrm_base*dot(node_7076_nrm_base, node_7076_nrm_detail)/node_7076_nrm_base.z - node_7076_nrm_detail;
                float3 node_7076 = node_7076_nrm_combined;
                float3 _node_3185 = UnpackNormal(tex2Dlod(_Base_normal,float4(TRANSFORM_TEX(i.uv0, _Base_normal),0.0,_mossnormalblur)));
                float3 _moss_normal_var = UnpackNormal(tex2D(_moss_normal,TRANSFORM_TEX(i.uv0, _moss_normal)));
                float3 node_9381_nrm_base = _node_3185.rgb + float3(0,0,1);
                float3 node_9381_nrm_detail = _moss_normal_var.rgb * float3(-1,-1,1);
                float3 node_9381_nrm_combined = node_9381_nrm_base*dot(node_9381_nrm_base, node_9381_nrm_detail)/node_9381_nrm_base.z - node_9381_nrm_detail;
                float3 node_9381 = node_9381_nrm_combined;
                float node_7933 = saturate(dot(i.normalDir,_Direc.rgb));
                float4 _heights_var = tex2D(_heights,TRANSFORM_TEX(i.uv0, _heights));
                float node_3059 = (_heights_var.r*_masksubstract);
                float node_7534 = saturate((pow((node_7933+node_7933),_exponent)-node_3059));
                float3 node_9036 = lerp(node_7076,node_9381,node_7534);
                float3 node_8799 = float3(0.5,0.5,1);
                float node_8482 = clamp(lerp( node_3059, pow(node_3059,_masknormalexponent), _usenormalmaskexponent ),_NormMincut,_NormMaxcut);
                float node_8118 = 0.0;
                float node_2380 = (node_8118 + ( (node_8482 - _NormMincut) * (1.0 - node_8118) ) / (_NormMaxcut - _NormMincut));
                float3 normalLocal = lerp( node_9036, lerp(lerp(node_8799,node_9036,_normaltoppower),lerp(node_8799,node_9036,_normaldownpower),node_2380), _useadvancednormalsetting );
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = lerp( 0.0, lerp(_glosstops,_glosscurvature,node_2380), _usegloss );
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
                float4 _Ambientocclusion_var = tex2D(_Ambientocclusion,TRANSFORM_TEX(i.uv0, _Ambientocclusion));
                float3 specularAO = _Ambientocclusion_var.r;
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float4 _detaildiffuse_var = tex2D(_detaildiffuse,TRANSFORM_TEX(i.uv0, _detaildiffuse));
                float4 _moss_albedo_var = tex2D(_moss_albedo,TRANSFORM_TEX(i.uv0, _moss_albedo));
                float3 diffuseColor = lerp(lerp(saturate(( _detaildiffuse_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_detaildiffuse_var.rgb-0.5))*(1.0-node_6343)) : (2.0*_detaildiffuse_var.rgb*node_6343) )),node_6343,_detailfactor),((_detailcoloradd.rgb+_detailcoloradd.rgb)*_moss_albedo_var.rgb),node_7534); // Need this for specular when using metallic
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
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= _Ambientocclusion_var.r; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_1748 = 0.0;
                float3 emissive = lerp(float3(node_1748,node_1748,node_1748),lerp( 0.0, (pow((pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Freshnelexp)*saturate(max(0,dot(lightDirection,i.normalDir)))),_SSS_factor)*(_LightColor0.rgb*_SSS_color.rgb)), _UseSSS1 ),node_7534);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
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
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Detail_normal; uniform float4 _Detail_normal_ST;
            uniform sampler2D _detaildiffuse; uniform float4 _detaildiffuse_ST;
            uniform float _detailfactor;
            uniform sampler2D _heights; uniform float4 _heights_ST;
            uniform sampler2D _moss_albedo; uniform float4 _moss_albedo_ST;
            uniform sampler2D _moss_normal; uniform float4 _moss_normal_ST;
            uniform float _exponent;
            uniform float _masksubstract;
            uniform float _SSS_factor;
            uniform float4 _SSS_color;
            uniform fixed _UseSSS1;
            uniform float _Freshnelexp;
            uniform float4 _detailcoloradd;
            uniform sampler2D _Base_normal; uniform float4 _Base_normal_ST;
            uniform float _mossnormalblur;
            uniform float4 _Direc;
            uniform float _normaltoppower;
            uniform float _normaldownpower;
            uniform fixed _useadvancednormalsetting;
            uniform float _NormMincut;
            uniform float _NormMaxcut;
            uniform float _masknormalexponent;
            uniform fixed _usenormalmaskexponent;
            uniform float _glosscurvature;
            uniform float _glosstops;
            uniform fixed _usegloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
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
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap = UnpackNormal(tex2D(_Base_normal,TRANSFORM_TEX(i.uv0, _Base_normal)));
                float3 _Detail_normal_var = UnpackNormal(tex2D(_Detail_normal,TRANSFORM_TEX(i.uv0, _Detail_normal)));
                float3 node_7076_nrm_base = _BumpMap.rgb + float3(0,0,1);
                float3 node_7076_nrm_detail = _Detail_normal_var.rgb * float3(-1,-1,1);
                float3 node_7076_nrm_combined = node_7076_nrm_base*dot(node_7076_nrm_base, node_7076_nrm_detail)/node_7076_nrm_base.z - node_7076_nrm_detail;
                float3 node_7076 = node_7076_nrm_combined;
                float3 _node_3185 = UnpackNormal(tex2Dlod(_Base_normal,float4(TRANSFORM_TEX(i.uv0, _Base_normal),0.0,_mossnormalblur)));
                float3 _moss_normal_var = UnpackNormal(tex2D(_moss_normal,TRANSFORM_TEX(i.uv0, _moss_normal)));
                float3 node_9381_nrm_base = _node_3185.rgb + float3(0,0,1);
                float3 node_9381_nrm_detail = _moss_normal_var.rgb * float3(-1,-1,1);
                float3 node_9381_nrm_combined = node_9381_nrm_base*dot(node_9381_nrm_base, node_9381_nrm_detail)/node_9381_nrm_base.z - node_9381_nrm_detail;
                float3 node_9381 = node_9381_nrm_combined;
                float node_7933 = saturate(dot(i.normalDir,_Direc.rgb));
                float4 _heights_var = tex2D(_heights,TRANSFORM_TEX(i.uv0, _heights));
                float node_3059 = (_heights_var.r*_masksubstract);
                float node_7534 = saturate((pow((node_7933+node_7933),_exponent)-node_3059));
                float3 node_9036 = lerp(node_7076,node_9381,node_7534);
                float3 node_8799 = float3(0.5,0.5,1);
                float node_8482 = clamp(lerp( node_3059, pow(node_3059,_masknormalexponent), _usenormalmaskexponent ),_NormMincut,_NormMaxcut);
                float node_8118 = 0.0;
                float node_2380 = (node_8118 + ( (node_8482 - _NormMincut) * (1.0 - node_8118) ) / (_NormMaxcut - _NormMincut));
                float3 normalLocal = lerp( node_9036, lerp(lerp(node_8799,node_9036,_normaltoppower),lerp(node_8799,node_9036,_normaldownpower),node_2380), _useadvancednormalsetting );
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = lerp( 0.0, lerp(_glosstops,_glosscurvature,node_2380), _usegloss );
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float4 _detaildiffuse_var = tex2D(_detaildiffuse,TRANSFORM_TEX(i.uv0, _detaildiffuse));
                float4 _moss_albedo_var = tex2D(_moss_albedo,TRANSFORM_TEX(i.uv0, _moss_albedo));
                float3 diffuseColor = lerp(lerp(saturate(( _detaildiffuse_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_detaildiffuse_var.rgb-0.5))*(1.0-node_6343)) : (2.0*_detaildiffuse_var.rgb*node_6343) )),node_6343,_detailfactor),((_detailcoloradd.rgb+_detailcoloradd.rgb)*_moss_albedo_var.rgb),node_7534); // Need this for specular when using metallic
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
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _detaildiffuse; uniform float4 _detaildiffuse_ST;
            uniform float _detailfactor;
            uniform sampler2D _heights; uniform float4 _heights_ST;
            uniform sampler2D _moss_albedo; uniform float4 _moss_albedo_ST;
            uniform float _exponent;
            uniform float _masksubstract;
            uniform float _SSS_factor;
            uniform float4 _SSS_color;
            uniform fixed _UseSSS1;
            uniform float _Freshnelexp;
            uniform float4 _detailcoloradd;
            uniform float4 _Direc;
            uniform float _NormMincut;
            uniform float _NormMaxcut;
            uniform float _masknormalexponent;
            uniform fixed _usenormalmaskexponent;
            uniform float _glosscurvature;
            uniform float _glosstops;
            uniform fixed _usegloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_1748 = 0.0;
                float node_7933 = saturate(dot(i.normalDir,_Direc.rgb));
                float4 _heights_var = tex2D(_heights,TRANSFORM_TEX(i.uv0, _heights));
                float node_3059 = (_heights_var.r*_masksubstract);
                float node_7534 = saturate((pow((node_7933+node_7933),_exponent)-node_3059));
                o.Emission = lerp(float3(node_1748,node_1748,node_1748),lerp( 0.0, (pow((pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Freshnelexp)*saturate(max(0,dot(lightDirection,i.normalDir)))),_SSS_factor)*(_LightColor0.rgb*_SSS_color.rgb)), _UseSSS1 ),node_7534);
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float4 _detaildiffuse_var = tex2D(_detaildiffuse,TRANSFORM_TEX(i.uv0, _detaildiffuse));
                float4 _moss_albedo_var = tex2D(_moss_albedo,TRANSFORM_TEX(i.uv0, _moss_albedo));
                float3 diffColor = lerp(lerp(saturate(( _detaildiffuse_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_detaildiffuse_var.rgb-0.5))*(1.0-node_6343)) : (2.0*_detaildiffuse_var.rgb*node_6343) )),node_6343,_detailfactor),((_detailcoloradd.rgb+_detailcoloradd.rgb)*_moss_albedo_var.rgb),node_7534);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float node_8482 = clamp(lerp( node_3059, pow(node_3059,_masknormalexponent), _usenormalmaskexponent ),_NormMincut,_NormMaxcut);
                float node_8118 = 0.0;
                float node_2380 = (node_8118 + ( (node_8482 - _NormMincut) * (1.0 - node_8118) ) / (_NormMaxcut - _NormMincut));
                float roughness = 1.0 - lerp( 0.0, lerp(_glosstops,_glosscurvature,node_2380), _usegloss );
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
