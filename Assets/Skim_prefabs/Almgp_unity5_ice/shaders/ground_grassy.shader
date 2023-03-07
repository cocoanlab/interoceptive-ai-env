// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:36378,y:32632,varname:node_2865,prsc:2|diff-4784-OUT,spec-2332-OUT,gloss-652-OUT,normal-8438-OUT,lwrap-2730-OUT,difocc-420-OUT,spcocc-420-OUT;n:type:ShaderForge.SFN_Slider,id:1813,x:31964,y:32672,ptovrint:False,ptlb:Roughness First 1,ptin:_RoughnessFirst1,varname:_RoughnessFirst1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:957,x:31358,y:32705,ptovrint:False,ptlb:Material First albedo,ptin:_MaterialFirstalbedo,varname:_MaterialFirstalbedo,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a711b80042416e4fa0834fbdbcdd62b,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:4007,x:31360,y:33051,ptovrint:False,ptlb:Material first normal,ptin:_Materialfirstnormal,varname:_Materialfirstnormal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2dAsset,id:3383,x:31222,y:31979,ptovrint:False,ptlb:mask (red chanel),ptin:_maskredchanel,varname:_maskredchanel,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4989,x:31492,y:31969,cmnt:mask blend,varname:_node_4989,prsc:2,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False|UVIN-1236-OUT,TEX-3383-TEX;n:type:ShaderForge.SFN_Tex2d,id:430,x:31492,y:32128,varname:_node_430,prsc:2,tex:54c07289331fe1e438dc7409c85ba639,ntxv:0,isnm:False|UVIN-3870-OUT,TEX-3383-TEX;n:type:ShaderForge.SFN_TexCoord,id:6840,x:31160,y:31654,varname:node_6840,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:5523,x:31160,y:31553,ptovrint:False,ptlb:mask tile,ptin:_masktile,varname:_masktile,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Multiply,id:1236,x:31474,y:31527,varname:node_1236,prsc:2|A-5523-OUT,B-9329-OUT,C-6840-UVOUT;n:type:ShaderForge.SFN_Vector1,id:9329,x:31291,y:31527,varname:node_9329,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Blend,id:2380,x:31757,y:32047,varname:node_2380,prsc:2,blmd:10,clmp:True|SRC-4989-R,DST-430-R;n:type:ShaderForge.SFN_Rotator,id:6401,x:31659,y:31527,varname:node_6401,prsc:2|UVIN-1236-OUT,ANG-5995-OUT;n:type:ShaderForge.SFN_Vector1,id:5995,x:31659,y:31468,varname:node_5995,prsc:2,v1:1.618;n:type:ShaderForge.SFN_Multiply,id:3870,x:31825,y:31527,cmnt:mask ccordinates,varname:node_3870,prsc:2|A-7617-OUT,B-6401-UVOUT;n:type:ShaderForge.SFN_Vector1,id:7617,x:31659,y:31414,varname:node_7617,prsc:2,v1:0.61;n:type:ShaderForge.SFN_Tex2d,id:3041,x:31595,y:32486,varname:_node_303421,prsc:2,tex:5a711b80042416e4fa0834fbdbcdd62b,ntxv:0,isnm:False|UVIN-6709-OUT,TEX-957-TEX;n:type:ShaderForge.SFN_Tex2d,id:3344,x:31595,y:32652,varname:_node_33844,prsc:2,tex:5a711b80042416e4fa0834fbdbcdd62b,ntxv:0,isnm:False|UVIN-436-OUT,TEX-957-TEX;n:type:ShaderForge.SFN_TexCoord,id:4505,x:30229,y:32956,varname:node_4505,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:3568,x:30291,y:32610,ptovrint:False,ptlb:First material tile,ptin:_Firstmaterialtile,varname:_Firstmaterialtile,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Multiply,id:6709,x:30605,y:32584,varname:node_67346,prsc:2|A-3568-OUT,B-4035-OUT,C-3483-OUT;n:type:ShaderForge.SFN_Vector1,id:4035,x:30422,y:32584,varname:node_4035,prsc:2,v1:5;n:type:ShaderForge.SFN_Rotator,id:9487,x:30790,y:32584,varname:node_94073,prsc:2|UVIN-6709-OUT,ANG-9877-OUT;n:type:ShaderForge.SFN_Vector1,id:9877,x:30790,y:32525,varname:node_9877,prsc:2,v1:1.618;n:type:ShaderForge.SFN_Multiply,id:436,x:30988,y:32648,cmnt:material first ccordinates,varname:node_43777,prsc:2|A-2736-OUT,B-9487-UVOUT;n:type:ShaderForge.SFN_Vector1,id:2736,x:30790,y:32471,varname:node_2736,prsc:2,v1:0.61;n:type:ShaderForge.SFN_Tex2d,id:6490,x:31611,y:32975,varname:_node_6490,prsc:2,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:0,isnm:False|UVIN-6709-OUT,TEX-4007-TEX;n:type:ShaderForge.SFN_Tex2d,id:6149,x:31614,y:33251,varname:_node_6149,prsc:2,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:0,isnm:False|UVIN-436-OUT,TEX-4007-TEX;n:type:ShaderForge.SFN_NormalBlend,id:364,x:31892,y:32978,varname:node_364,prsc:2|BSE-6149-RGB,DTL-6490-RGB;n:type:ShaderForge.SFN_Blend,id:869,x:31880,y:32466,varname:node_869,prsc:2,blmd:10,clmp:True|SRC-3041-RGB,DST-3344-RGB;n:type:ShaderForge.SFN_Slider,id:4818,x:31964,y:32822,ptovrint:False,ptlb:Roughness second,ptin:_Roughnesssecond,varname:_Roughnesssecond,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Vector1,id:2332,x:33781,y:32974,varname:node_2332,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:500,x:32308,y:33024,cmnt:blended albedo,varname:node_500,prsc:2|A-8290-OUT,B-869-OUT,T-6510-OUT;n:type:ShaderForge.SFN_Lerp,id:9575,x:32135,y:33241,cmnt:blended normal,varname:node_9575,prsc:2|A-9796-OUT,B-364-OUT,T-6510-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:3070,x:31404,y:33856,ptovrint:False,ptlb:Material second albedo,ptin:_Materialsecondalbedo,varname:_Materialsecondalbedo,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6510d8c4f9874c44fab1b357f846fb24,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:2593,x:31387,y:34199,ptovrint:False,ptlb:Material second normal,ptin:_Materialsecondnormal,varname:_Materialsecondnormal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:7553,x:31640,y:33824,varname:_node_98076,prsc:2,tex:6510d8c4f9874c44fab1b357f846fb24,ntxv:0,isnm:False|UVIN-5940-OUT,TEX-3070-TEX;n:type:ShaderForge.SFN_TexCoord,id:5998,x:30125,y:33498,varname:node_5998,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:8294,x:30318,y:33758,ptovrint:False,ptlb:Second material tile,ptin:_Secondmaterialtile,varname:_Secondmaterialtile,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Multiply,id:7710,x:30619,y:33688,varname:node_7710,prsc:2|A-8294-OUT,B-9593-OUT,C-3668-OUT;n:type:ShaderForge.SFN_Vector1,id:9593,x:30449,y:33732,varname:node_9593,prsc:2,v1:5;n:type:ShaderForge.SFN_Rotator,id:5893,x:30817,y:33732,varname:node_5893,prsc:2|UVIN-7710-OUT,ANG-8791-OUT;n:type:ShaderForge.SFN_Vector1,id:8791,x:30817,y:33673,varname:node_8791,prsc:2,v1:1.618;n:type:ShaderForge.SFN_Multiply,id:5940,x:30983,y:33732,cmnt:material second ccordinates,varname:node_5940,prsc:2|A-5372-OUT,B-5893-UVOUT;n:type:ShaderForge.SFN_Vector1,id:5372,x:30817,y:33619,varname:node_5372,prsc:2,v1:0.61;n:type:ShaderForge.SFN_Tex2d,id:726,x:31641,y:34145,varname:_node_69112,prsc:2,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:0,isnm:False|UVIN-7710-OUT,TEX-2593-TEX;n:type:ShaderForge.SFN_Tex2d,id:4434,x:31641,y:34345,varname:_node_61249,prsc:2,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:0,isnm:False|UVIN-5940-OUT,TEX-2593-TEX;n:type:ShaderForge.SFN_NormalBlend,id:9796,x:31890,y:34117,varname:node_0796,prsc:2|BSE-4434-RGB,DTL-726-RGB;n:type:ShaderForge.SFN_Blend,id:8290,x:31885,y:33667,varname:node_8290,prsc:2,blmd:10,clmp:True|SRC-2331-RGB,DST-7553-RGB;n:type:ShaderForge.SFN_Clamp,id:9619,x:32366,y:32050,varname:node_9619,prsc:2|IN-5828-OUT,MIN-7433-OUT,MAX-6301-OUT;n:type:ShaderForge.SFN_Power,id:5828,x:31969,y:32046,varname:node_5828,prsc:2|VAL-2380-OUT,EXP-8047-OUT;n:type:ShaderForge.SFN_Slider,id:8047,x:31890,y:31932,ptovrint:False,ptlb:Mask power,ptin:_Maskpower,varname:_Maskpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1,max:7;n:type:ShaderForge.SFN_Slider,id:7433,x:32030,y:32198,ptovrint:False,ptlb:Mask clamp min,ptin:_Maskclampmin,varname:_Maskclampmin,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.99;n:type:ShaderForge.SFN_Slider,id:6301,x:32050,y:32332,ptovrint:False,ptlb:Mask clamp max,ptin:_Maskclampmax,varname:_Maskclampmax,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.001,cur:1,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:2610,x:32575,y:32049,varname:node_2610,prsc:2|IN-9619-OUT,IMIN-7433-OUT,IMAX-6301-OUT,OMIN-7228-OUT,OMAX-3456-OUT;n:type:ShaderForge.SFN_Vector1,id:7228,x:32452,y:32312,varname:node_7228,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3456,x:32452,y:32415,varname:node_3456,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:6808,x:34375,y:34155,cmnt:Blended Roughness,varname:node_6808,prsc:2|A-4818-OUT,B-1813-OUT,T-6510-OUT;n:type:ShaderForge.SFN_ComponentMask,id:6510,x:32827,y:32049,varname:node_6510,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2610-OUT;n:type:ShaderForge.SFN_Color,id:7653,x:33273,y:32483,ptovrint:False,ptlb:Light wrapm firs,ptin:_Lightwrapmfirs,varname:_Lightwrapmfirs,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:589,x:31418,y:35013,ptovrint:False,ptlb:detail albedo,ptin:_detailalbedo,varname:_detailalbedo,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6510d8c4f9874c44fab1b357f846fb24,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:542,x:31401,y:35356,ptovrint:False,ptlb:detail normal,ptin:_detailnormal,varname:_detailnormal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:5221,x:31636,y:34791,varname:_node_3041,prsc:2,tex:6510d8c4f9874c44fab1b357f846fb24,ntxv:0,isnm:False|TEX-589-TEX;n:type:ShaderForge.SFN_Tex2d,id:9897,x:31636,y:34957,varname:_node_3344,prsc:2,tex:6510d8c4f9874c44fab1b357f846fb24,ntxv:0,isnm:False|TEX-589-TEX;n:type:ShaderForge.SFN_TexCoord,id:4088,x:30332,y:35016,varname:node_4088,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:2048,x:30332,y:34915,ptovrint:False,ptlb:Detail material tile,ptin:_Detailmaterialtile,varname:_Detailmaterialtile,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Multiply,id:2709,x:30646,y:34889,varname:node_2709,prsc:2|A-2048-OUT,B-3854-OUT,C-1096-OUT;n:type:ShaderForge.SFN_Vector1,id:3854,x:30463,y:34889,varname:node_3854,prsc:2,v1:7;n:type:ShaderForge.SFN_Rotator,id:9843,x:30831,y:34889,varname:node_9843,prsc:2|UVIN-2709-OUT,ANG-8120-OUT;n:type:ShaderForge.SFN_Vector1,id:8120,x:30831,y:34830,varname:node_8120,prsc:2,v1:1.618;n:type:ShaderForge.SFN_Multiply,id:2339,x:30997,y:34889,cmnt:detail  ccordinates,varname:node_2339,prsc:2|A-6026-OUT,B-9843-UVOUT;n:type:ShaderForge.SFN_Vector1,id:6026,x:30831,y:34776,varname:node_6026,prsc:2,v1:0.61;n:type:ShaderForge.SFN_Tex2d,id:1114,x:31655,y:35302,varname:_node_7490,prsc:2,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:0,isnm:False|UVIN-2709-OUT,TEX-542-TEX;n:type:ShaderForge.SFN_Tex2d,id:8763,x:31655,y:35502,varname:_node_64749,prsc:2,tex:848b02aa303c3c04ca3ce234e5ef7e04,ntxv:0,isnm:False|UVIN-2339-OUT,TEX-542-TEX;n:type:ShaderForge.SFN_NormalBlend,id:8322,x:31904,y:35274,varname:node_8322,prsc:2|BSE-8763-RGB,DTL-1114-RGB;n:type:ShaderForge.SFN_Blend,id:1765,x:31822,y:34810,varname:node_1765,prsc:2,blmd:10,clmp:True|SRC-5221-RGB,DST-9897-RGB;n:type:ShaderForge.SFN_NormalBlend,id:539,x:32661,y:33300,varname:node_539,prsc:2|BSE-9575-OUT,DTL-8322-OUT;n:type:ShaderForge.SFN_Lerp,id:5647,x:33004,y:32977,varname:node_5647,prsc:2|A-500-OUT,B-4255-OUT,T-2412-OUT;n:type:ShaderForge.SFN_Slider,id:2412,x:32697,y:33741,ptovrint:False,ptlb:detail albedo factor,ptin:_detailalbedofactor,varname:_detailalbedofactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3162398,max:1;n:type:ShaderForge.SFN_Lerp,id:8438,x:32798,y:33187,varname:node_8438,prsc:2|A-9020-OUT,B-539-OUT,T-4799-OUT;n:type:ShaderForge.SFN_Slider,id:4799,x:32677,y:33565,ptovrint:False,ptlb:detail normal factor,ptin:_detailnormalfactor,varname:_detailnormalfactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:2331,x:31624,y:33590,varname:_node_2331,prsc:2,tex:6510d8c4f9874c44fab1b357f846fb24,ntxv:0,isnm:False|UVIN-7710-OUT,TEX-3070-TEX;n:type:ShaderForge.SFN_Color,id:141,x:33273,y:32693,ptovrint:False,ptlb:light wrap second,ptin:_lightwrapsecond,varname:_lightwrapsecond,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:5233,x:33482,y:32516,varname:node_5233,prsc:2|A-7653-RGB,B-7653-RGB;n:type:ShaderForge.SFN_Add,id:5934,x:33509,y:32693,varname:node_5934,prsc:2|A-141-RGB,B-141-RGB;n:type:ShaderForge.SFN_Lerp,id:3186,x:33888,y:32578,varname:node_3186,prsc:2|A-5934-OUT,B-5233-OUT,T-6510-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:2730,x:34180,y:32628,ptovrint:False,ptlb:use light wrap,ptin:_uselightwrap,varname:_uselightwrap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-954-OUT,B-3186-OUT;n:type:ShaderForge.SFN_Vector1,id:954,x:33886,y:32458,varname:node_954,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:3953,x:33394,y:33370,ptovrint:False,ptlb:Colorize firs,ptin:_Colorizefirs,varname:_Colorizefirs,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:5498,x:33394,y:33586,ptovrint:False,ptlb:colorize second,ptin:_colorizesecond,varname:_colorizesecond,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:7753,x:33622,y:33361,varname:node_7753,prsc:2|A-3953-RGB,B-3953-RGB;n:type:ShaderForge.SFN_Add,id:9666,x:33638,y:33632,varname:node_9666,prsc:2|A-5498-RGB,B-5498-RGB;n:type:ShaderForge.SFN_Lerp,id:6480,x:33924,y:33376,varname:node_6480,prsc:2|A-9666-OUT,B-7753-OUT,T-6510-OUT;n:type:ShaderForge.SFN_Multiply,id:448,x:34981,y:32825,varname:node_448,prsc:2|A-5647-OUT,B-6480-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:5354,x:32779,y:34106,ptovrint:False,ptlb:Roughness mask first,ptin:_Roughnessmaskfirst,varname:_Roughnessmaskfirst,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:2215,x:32793,y:34680,ptovrint:False,ptlb:roughness mask second,ptin:_roughnessmasksecond,varname:_roughnessmasksecond,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1709,x:33242,y:34283,varname:_node_1709,prsc:2,ntxv:0,isnm:False|UVIN-436-OUT,TEX-5354-TEX;n:type:ShaderForge.SFN_Tex2d,id:8162,x:33255,y:34634,varname:_node_8162,prsc:2,ntxv:0,isnm:False|UVIN-5940-OUT,TEX-2215-TEX;n:type:ShaderForge.SFN_Tex2d,id:1779,x:33217,y:34077,varname:_node_1779,prsc:2,ntxv:0,isnm:False|UVIN-6709-OUT,TEX-5354-TEX;n:type:ShaderForge.SFN_Tex2d,id:7073,x:33267,y:34821,varname:_node_7073,prsc:2,ntxv:0,isnm:False|UVIN-7710-OUT,TEX-2215-TEX;n:type:ShaderForge.SFN_Blend,id:1949,x:33550,y:34173,varname:node_1949,prsc:2,blmd:10,clmp:True|SRC-1779-R,DST-1709-R;n:type:ShaderForge.SFN_Blend,id:3627,x:33578,y:34688,varname:node_3627,prsc:2,blmd:10,clmp:True|SRC-8162-R,DST-7073-R;n:type:ShaderForge.SFN_Lerp,id:6595,x:33858,y:34338,varname:node_6595,prsc:2|A-3627-OUT,B-1949-OUT,T-6510-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5337,x:34280,y:34340,ptovrint:False,ptlb:Flip Roughness mask,ptin:_FlipRoughnessmask,varname:_FlipRoughnessmask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6595-OUT,B-3203-OUT;n:type:ShaderForge.SFN_Multiply,id:6350,x:34756,y:34086,varname:node_6350,prsc:2|A-5383-OUT,B-6808-OUT;n:type:ShaderForge.SFN_Negate,id:3203,x:34229,y:34561,varname:node_3203,prsc:2|IN-6595-OUT;n:type:ShaderForge.SFN_Slider,id:2859,x:34543,y:34627,ptovrint:False,ptlb:Roughness mask power,ptin:_Roughnessmaskpower,varname:_Roughnessmaskpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:5383,x:34741,y:34327,varname:node_5383,prsc:2|A-9322-OUT,B-2859-OUT;n:type:ShaderForge.SFN_Add,id:9322,x:34556,y:34347,varname:node_9322,prsc:2|A-5337-OUT,B-2859-OUT;n:type:ShaderForge.SFN_Add,id:4654,x:35019,y:34088,varname:node_4654,prsc:2|A-6350-OUT,B-2859-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:652,x:35840,y:33069,ptovrint:False,ptlb:use Roughness,ptin:_useRoughness,varname:_useRoughness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-3189-OUT,B-4654-OUT;n:type:ShaderForge.SFN_Vector1,id:3189,x:34740,y:33846,varname:node_3189,prsc:2,v1:1;n:type:ShaderForge.SFN_Parallax,id:7654,x:30434,y:32858,varname:node_7654,prsc:2|UVIN-4505-UVOUT,HEI-2380-OUT,DEP-4237-OUT,REF-4401-OUT;n:type:ShaderForge.SFN_Parallax,id:7486,x:30412,y:33430,varname:node_7486,prsc:2|UVIN-5998-UVOUT,HEI-2380-OUT,DEP-4237-OUT,REF-4401-OUT;n:type:ShaderForge.SFN_Slider,id:4237,x:29602,y:34300,ptovrint:False,ptlb:Paralax first Dep,ptin:_ParalaxfirstDep,varname:_ParalaxfirstDep,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.005,cur:0,max:0.005;n:type:ShaderForge.SFN_Slider,id:4401,x:29589,y:34432,ptovrint:False,ptlb:Paralax first Ref,ptin:_ParalaxfirstRef,varname:_ParalaxfirstRef,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:4255,x:32720,y:33063,varname:node_4255,prsc:2|A-500-OUT,B-1765-OUT;n:type:ShaderForge.SFN_Lerp,id:420,x:35139,y:33201,varname:node_420,prsc:2|A-165-OUT,B-7836-OUT,T-9828-OUT;n:type:ShaderForge.SFN_Vector1,id:165,x:33141,y:31859,varname:node_165,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:9828,x:33960,y:35701,ptovrint:False,ptlb:AO factor,ptin:_AOfactor,varname:_AOfactor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:3932,x:32918,y:35405,ptovrint:False,ptlb:AO texture first,ptin:_AOtexturefirst,varname:_AOtexturefirst,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:1573,x:32896,y:35888,ptovrint:False,ptlb:AO texture second,ptin:_AOtexturesecond,varname:_AOtexturesecond,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3582,x:33140,y:35270,varname:_node_3582,prsc:2,ntxv:0,isnm:False|UVIN-6709-OUT,TEX-3932-TEX;n:type:ShaderForge.SFN_Tex2d,id:3499,x:33130,y:35478,varname:_node_3499,prsc:2,ntxv:0,isnm:False|UVIN-436-OUT,TEX-3932-TEX;n:type:ShaderForge.SFN_Tex2d,id:5572,x:33162,y:35733,varname:_node_5572,prsc:2,ntxv:0,isnm:False|UVIN-7710-OUT,TEX-1573-TEX;n:type:ShaderForge.SFN_Tex2d,id:327,x:33189,y:35945,varname:_node_327,prsc:2,ntxv:0,isnm:False|UVIN-5940-OUT,TEX-1573-TEX;n:type:ShaderForge.SFN_SwitchProperty,id:3483,x:30530,y:33045,ptovrint:False,ptlb:Use First paralax,ptin:_UseFirstparalax,varname:_UseFirstparalax,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4505-UVOUT,B-7654-UVOUT;n:type:ShaderForge.SFN_SwitchProperty,id:3668,x:30619,y:33444,ptovrint:False,ptlb:Use second paralax,ptin:_Usesecondparalax,varname:_Usesecondparalax,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5998-UVOUT,B-7486-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9238,x:33436,y:35290,varname:node_9238,prsc:2|A-3582-R,B-3499-R;n:type:ShaderForge.SFN_Multiply,id:434,x:33464,y:35789,varname:node_434,prsc:2|A-5572-R,B-327-R;n:type:ShaderForge.SFN_Lerp,id:7836,x:33991,y:35364,varname:node_7836,prsc:2|A-434-OUT,B-9238-OUT,T-6510-OUT;n:type:ShaderForge.SFN_Parallax,id:9146,x:30472,y:34550,varname:node_9146,prsc:2|UVIN-4088-UVOUT,HEI-6510-OUT,DEP-4237-OUT,REF-4401-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:1096,x:30724,y:34607,ptovrint:False,ptlb:USe detail paralax,ptin:_USedetailparalax,varname:_USedetailparalax,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4088-UVOUT,B-9146-UVOUT;n:type:ShaderForge.SFN_Lerp,id:9020,x:32373,y:33224,varname:node_9020,prsc:2|A-7883-OUT,B-9575-OUT,T-1290-OUT;n:type:ShaderForge.SFN_Vector3,id:7883,x:32120,y:33165,varname:node_7883,prsc:2,v1:0.5,v2:0.5,v3:1;n:type:ShaderForge.SFN_Slider,id:1290,x:32198,y:33510,ptovrint:False,ptlb:normal power,ptin:_normalpower,varname:_normalpower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:4784,x:35985,y:32553,varname:node_4784,prsc:2|A-448-OUT,B-3462-OUT,T-6959-OUT;n:type:ShaderForge.SFN_Multiply,id:3462,x:35638,y:32562,varname:node_3462,prsc:2|A-9880-OUT,B-448-OUT;n:type:ShaderForge.SFN_Slider,id:6959,x:35025,y:32530,ptovrint:False,ptlb:Multyply AO to Albedo,ptin:_MultyplyAOtoAlbedo,varname:_MultyplyAOtoAlbedo,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Power,id:128,x:35573,y:32889,varname:node_128,prsc:2|VAL-420-OUT,EXP-2903-OUT;n:type:ShaderForge.SFN_Slider,id:2903,x:35133,y:32877,ptovrint:False,ptlb:AO_Albedo exponent,ptin:_AO_Albedoexponent,varname:_AO_Albedoexponent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.1,max:10;n:type:ShaderForge.SFN_Clamp,id:5961,x:35657,y:32713,varname:node_5961,prsc:2|IN-128-OUT,MIN-7333-OUT,MAX-5658-OUT;n:type:ShaderForge.SFN_Slider,id:5658,x:35198,y:32708,ptovrint:False,ptlb:AO albedo cut,ptin:_AOalbedocut,varname:_AOalbedocut,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.01,cur:0.01,max:1;n:type:ShaderForge.SFN_Vector1,id:7333,x:35453,y:32833,varname:node_7333,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9880,x:35863,y:32706,varname:node_9880,prsc:2|IN-5961-OUT,IMIN-7333-OUT,IMAX-5658-OUT,OMIN-7333-OUT,OMAX-4087-OUT;n:type:ShaderForge.SFN_Vector1,id:4087,x:35770,y:32914,varname:node_4087,prsc:2,v1:1;proporder:1813-3383-5523-4818-8047-7433-6301-957-3568-3070-4007-2593-8294-542-2048-4799-589-2412-7653-141-2730-3953-5498-5354-2215-5337-2859-652-4237-4401-9828-3932-1573-3483-3668-1096-1290-6959-2903-5658;pass:END;sub:END;*/

Shader "Almgp/ground_grassy" {
    Properties {
        _RoughnessFirst1 ("Roughness First 1", Range(0, 1)) = 0.8
        _maskredchanel ("mask (red chanel)", 2D) = "white" {}
        _masktile ("mask tile", Float ) = 5
        _Roughnesssecond ("Roughness second", Range(0, 1)) = 0.8
        _Maskpower ("Mask power", Range(0.1, 7)) = 1
        _Maskclampmin ("Mask clamp min", Range(0, 0.99)) = 0
        _Maskclampmax ("Mask clamp max", Range(0.001, 1)) = 1
        _MaterialFirstalbedo ("Material First albedo", 2D) = "black" {}
        _Firstmaterialtile ("First material tile", Float ) = 5
        _Materialsecondalbedo ("Material second albedo", 2D) = "bump" {}
        _Materialfirstnormal ("Material first normal", 2D) = "bump" {}
        _Materialsecondnormal ("Material second normal", 2D) = "bump" {}
        _Secondmaterialtile ("Second material tile", Float ) = 8
        _detailnormal ("detail normal", 2D) = "bump" {}
        _Detailmaterialtile ("Detail material tile", Float ) = 8
        _detailnormalfactor ("detail normal factor", Range(0, 1)) = 0
        _detailalbedo ("detail albedo", 2D) = "bump" {}
        _detailalbedofactor ("detail albedo factor", Range(0, 1)) = 0.3162398
        _Lightwrapmfirs ("Light wrapm firs", Color) = (0.5,0.5,0.5,1)
        _lightwrapsecond ("light wrap second", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _uselightwrap ("use light wrap", Float ) = 1
        _Colorizefirs ("Colorize firs", Color) = (0.5,0.5,0.5,1)
        _colorizesecond ("colorize second", Color) = (0.5,0.5,0.5,1)
        _Roughnessmaskfirst ("Roughness mask first", 2D) = "white" {}
        _roughnessmasksecond ("roughness mask second", 2D) = "white" {}
        [MaterialToggle] _FlipRoughnessmask ("Flip Roughness mask", Float ) = 0
        _Roughnessmaskpower ("Roughness mask power", Range(0, 1)) = 0
        [MaterialToggle] _useRoughness ("use Roughness", Float ) = 1
        _ParalaxfirstDep ("Paralax first Dep", Range(-0.005, 0.005)) = 0
        _ParalaxfirstRef ("Paralax first Ref", Range(-1, 1)) = 0
        _AOfactor ("AO factor", Range(0, 1)) = 0
        _AOtexturefirst ("AO texture first", 2D) = "white" {}
        _AOtexturesecond ("AO texture second", 2D) = "white" {}
        [MaterialToggle] _UseFirstparalax ("Use First paralax", Float ) = 0
        [MaterialToggle] _Usesecondparalax ("Use second paralax", Float ) = 0
        [MaterialToggle] _USedetailparalax ("USe detail paralax", Float ) = 0
        _normalpower ("normal power", Range(0, 1)) = 0
        _MultyplyAOtoAlbedo ("Multyply AO to Albedo", Range(0, 1)) = 0
        _AO_Albedoexponent ("AO_Albedo exponent", Range(0.1, 10)) = 0.1
        _AOalbedocut ("AO albedo cut", Range(0.01, 1)) = 0.01
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
            uniform float _RoughnessFirst1;
            uniform sampler2D _MaterialFirstalbedo; uniform float4 _MaterialFirstalbedo_ST;
            uniform sampler2D _Materialfirstnormal; uniform float4 _Materialfirstnormal_ST;
            uniform sampler2D _maskredchanel; uniform float4 _maskredchanel_ST;
            uniform float _masktile;
            uniform float _Firstmaterialtile;
            uniform float _Roughnesssecond;
            uniform sampler2D _Materialsecondalbedo; uniform float4 _Materialsecondalbedo_ST;
            uniform sampler2D _Materialsecondnormal; uniform float4 _Materialsecondnormal_ST;
            uniform float _Secondmaterialtile;
            uniform float _Maskpower;
            uniform float _Maskclampmin;
            uniform float _Maskclampmax;
            uniform float4 _Lightwrapmfirs;
            uniform sampler2D _detailalbedo; uniform float4 _detailalbedo_ST;
            uniform sampler2D _detailnormal; uniform float4 _detailnormal_ST;
            uniform float _Detailmaterialtile;
            uniform float _detailalbedofactor;
            uniform float _detailnormalfactor;
            uniform float4 _lightwrapsecond;
            uniform fixed _uselightwrap;
            uniform float4 _Colorizefirs;
            uniform float4 _colorizesecond;
            uniform sampler2D _Roughnessmaskfirst; uniform float4 _Roughnessmaskfirst_ST;
            uniform sampler2D _roughnessmasksecond; uniform float4 _roughnessmasksecond_ST;
            uniform fixed _FlipRoughnessmask;
            uniform float _Roughnessmaskpower;
            uniform fixed _useRoughness;
            uniform float _ParalaxfirstDep;
            uniform float _ParalaxfirstRef;
            uniform float _AOfactor;
            uniform sampler2D _AOtexturefirst; uniform float4 _AOtexturefirst_ST;
            uniform sampler2D _AOtexturesecond; uniform float4 _AOtexturesecond_ST;
            uniform fixed _UseFirstparalax;
            uniform fixed _Usesecondparalax;
            uniform fixed _USedetailparalax;
            uniform float _normalpower;
            uniform float _MultyplyAOtoAlbedo;
            uniform float _AO_Albedoexponent;
            uniform float _AOalbedocut;
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
                float node_5893_ang = 1.618;
                float node_5893_spd = 1.0;
                float node_5893_cos = cos(node_5893_spd*node_5893_ang);
                float node_5893_sin = sin(node_5893_spd*node_5893_ang);
                float2 node_5893_piv = float2(0.5,0.5);
                float2 node_1236 = (_masktile*0.1*i.uv0);
                float4 _node_4989 = tex2D(_maskredchanel,TRANSFORM_TEX(node_1236, _maskredchanel)); // mask blend
                float node_6401_ang = 1.618;
                float node_6401_spd = 1.0;
                float node_6401_cos = cos(node_6401_spd*node_6401_ang);
                float node_6401_sin = sin(node_6401_spd*node_6401_ang);
                float2 node_6401_piv = float2(0.5,0.5);
                float2 node_6401 = (mul(node_1236-node_6401_piv,float2x2( node_6401_cos, -node_6401_sin, node_6401_sin, node_6401_cos))+node_6401_piv);
                float2 node_3870 = (0.61*node_6401); // mask ccordinates
                float4 _node_430 = tex2D(_maskredchanel,TRANSFORM_TEX(node_3870, _maskredchanel));
                float node_2380 = saturate(( _node_430.r > 0.5 ? (1.0-(1.0-2.0*(_node_430.r-0.5))*(1.0-_node_4989.r)) : (2.0*_node_430.r*_node_4989.r) ));
                float2 node_7710 = (_Secondmaterialtile*5.0*lerp( i.uv0, (_ParalaxfirstDep*(node_2380 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _Usesecondparalax ));
                float2 node_5893 = (mul(node_7710-node_5893_piv,float2x2( node_5893_cos, -node_5893_sin, node_5893_sin, node_5893_cos))+node_5893_piv);
                float2 node_5940 = (0.61*node_5893); // material second ccordinates
                float3 _node_61249 = UnpackNormal(tex2D(_Materialsecondnormal,TRANSFORM_TEX(node_5940, _Materialsecondnormal)));
                float3 _node_69112 = UnpackNormal(tex2D(_Materialsecondnormal,TRANSFORM_TEX(node_7710, _Materialsecondnormal)));
                float3 node_0796_nrm_base = _node_61249.rgb + float3(0,0,1);
                float3 node_0796_nrm_detail = _node_69112.rgb * float3(-1,-1,1);
                float3 node_0796_nrm_combined = node_0796_nrm_base*dot(node_0796_nrm_base, node_0796_nrm_detail)/node_0796_nrm_base.z - node_0796_nrm_detail;
                float3 node_0796 = node_0796_nrm_combined;
                float node_94073_ang = 1.618;
                float node_94073_spd = 1.0;
                float node_94073_cos = cos(node_94073_spd*node_94073_ang);
                float node_94073_sin = sin(node_94073_spd*node_94073_ang);
                float2 node_94073_piv = float2(0.5,0.5);
                float2 node_67346 = (_Firstmaterialtile*5.0*lerp( i.uv0, (_ParalaxfirstDep*(node_2380 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _UseFirstparalax ));
                float2 node_94073 = (mul(node_67346-node_94073_piv,float2x2( node_94073_cos, -node_94073_sin, node_94073_sin, node_94073_cos))+node_94073_piv);
                float2 node_43777 = (0.61*node_94073); // material first ccordinates
                float3 _node_6149 = UnpackNormal(tex2D(_Materialfirstnormal,TRANSFORM_TEX(node_43777, _Materialfirstnormal)));
                float3 _node_6490 = UnpackNormal(tex2D(_Materialfirstnormal,TRANSFORM_TEX(node_67346, _Materialfirstnormal)));
                float3 node_364_nrm_base = _node_6149.rgb + float3(0,0,1);
                float3 node_364_nrm_detail = _node_6490.rgb * float3(-1,-1,1);
                float3 node_364_nrm_combined = node_364_nrm_base*dot(node_364_nrm_base, node_364_nrm_detail)/node_364_nrm_base.z - node_364_nrm_detail;
                float3 node_364 = node_364_nrm_combined;
                float node_7228 = 0.0;
                float node_6510 = (node_7228 + ( (clamp(pow(node_2380,_Maskpower),_Maskclampmin,_Maskclampmax) - _Maskclampmin) * (1.0 - node_7228) ) / (_Maskclampmax - _Maskclampmin)).r;
                float3 node_9575 = lerp(node_0796,node_364,node_6510); // blended normal
                float node_9843_ang = 1.618;
                float node_9843_spd = 1.0;
                float node_9843_cos = cos(node_9843_spd*node_9843_ang);
                float node_9843_sin = sin(node_9843_spd*node_9843_ang);
                float2 node_9843_piv = float2(0.5,0.5);
                float2 node_2709 = (_Detailmaterialtile*7.0*lerp( i.uv0, (_ParalaxfirstDep*(node_6510 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _USedetailparalax ));
                float2 node_9843 = (mul(node_2709-node_9843_piv,float2x2( node_9843_cos, -node_9843_sin, node_9843_sin, node_9843_cos))+node_9843_piv);
                float2 node_2339 = (0.61*node_9843); // detail  ccordinates
                float3 _node_64749 = UnpackNormal(tex2D(_detailnormal,TRANSFORM_TEX(node_2339, _detailnormal)));
                float3 _node_7490 = UnpackNormal(tex2D(_detailnormal,TRANSFORM_TEX(node_2709, _detailnormal)));
                float3 node_8322_nrm_base = _node_64749.rgb + float3(0,0,1);
                float3 node_8322_nrm_detail = _node_7490.rgb * float3(-1,-1,1);
                float3 node_8322_nrm_combined = node_8322_nrm_base*dot(node_8322_nrm_base, node_8322_nrm_detail)/node_8322_nrm_base.z - node_8322_nrm_detail;
                float3 node_8322 = node_8322_nrm_combined;
                float3 node_539_nrm_base = node_9575 + float3(0,0,1);
                float3 node_539_nrm_detail = node_8322 * float3(-1,-1,1);
                float3 node_539_nrm_combined = node_539_nrm_base*dot(node_539_nrm_base, node_539_nrm_detail)/node_539_nrm_base.z - node_539_nrm_detail;
                float3 node_539 = node_539_nrm_combined;
                float3 normalLocal = lerp(lerp(float3(0.5,0.5,1),node_9575,_normalpower),node_539,_detailnormalfactor);
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
                float4 _node_8162 = tex2D(_roughnessmasksecond,TRANSFORM_TEX(node_5940, _roughnessmasksecond));
                float4 _node_7073 = tex2D(_roughnessmasksecond,TRANSFORM_TEX(node_7710, _roughnessmasksecond));
                float4 _node_1779 = tex2D(_Roughnessmaskfirst,TRANSFORM_TEX(node_67346, _Roughnessmaskfirst));
                float4 _node_1709 = tex2D(_Roughnessmaskfirst,TRANSFORM_TEX(node_43777, _Roughnessmaskfirst));
                float node_6595 = lerp(saturate(( _node_7073.r > 0.5 ? (1.0-(1.0-2.0*(_node_7073.r-0.5))*(1.0-_node_8162.r)) : (2.0*_node_7073.r*_node_8162.r) )),saturate(( _node_1709.r > 0.5 ? (1.0-(1.0-2.0*(_node_1709.r-0.5))*(1.0-_node_1779.r)) : (2.0*_node_1709.r*_node_1779.r) )),node_6510);
                float gloss = 1.0 - lerp( 1.0, ((((lerp( node_6595, (-1*node_6595), _FlipRoughnessmask )+_Roughnessmaskpower)*_Roughnessmaskpower)*lerp(_Roughnesssecond,_RoughnessFirst1,node_6510))+_Roughnessmaskpower), _useRoughness ); // Convert roughness to gloss
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
                float4 _node_5572 = tex2D(_AOtexturesecond,TRANSFORM_TEX(node_7710, _AOtexturesecond));
                float4 _node_327 = tex2D(_AOtexturesecond,TRANSFORM_TEX(node_5940, _AOtexturesecond));
                float4 _node_3582 = tex2D(_AOtexturefirst,TRANSFORM_TEX(node_67346, _AOtexturefirst));
                float4 _node_3499 = tex2D(_AOtexturefirst,TRANSFORM_TEX(node_43777, _AOtexturefirst));
                float node_420 = lerp(1.0,lerp((_node_5572.r*_node_327.r),(_node_3582.r*_node_3499.r),node_6510),_AOfactor);
                float3 specularAO = node_420;
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _node_2331 = tex2D(_Materialsecondalbedo,TRANSFORM_TEX(node_7710, _Materialsecondalbedo));
                float4 _node_98076 = tex2D(_Materialsecondalbedo,TRANSFORM_TEX(node_5940, _Materialsecondalbedo));
                float4 _node_303421 = tex2D(_MaterialFirstalbedo,TRANSFORM_TEX(node_67346, _MaterialFirstalbedo));
                float4 _node_33844 = tex2D(_MaterialFirstalbedo,TRANSFORM_TEX(node_43777, _MaterialFirstalbedo));
                float3 node_500 = lerp(saturate(( _node_98076.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_98076.rgb-0.5))*(1.0-_node_2331.rgb)) : (2.0*_node_98076.rgb*_node_2331.rgb) )),saturate(( _node_33844.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_33844.rgb-0.5))*(1.0-_node_303421.rgb)) : (2.0*_node_33844.rgb*_node_303421.rgb) )),node_6510); // blended albedo
                float4 _node_3041 = tex2D(_detailalbedo,TRANSFORM_TEX(i.uv0, _detailalbedo));
                float4 _node_3344 = tex2D(_detailalbedo,TRANSFORM_TEX(i.uv0, _detailalbedo));
                float3 node_448 = (lerp(node_500,(node_500+saturate(( _node_3344.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_3344.rgb-0.5))*(1.0-_node_3041.rgb)) : (2.0*_node_3344.rgb*_node_3041.rgb) ))),_detailalbedofactor)*lerp((_colorizesecond.rgb+_colorizesecond.rgb),(_Colorizefirs.rgb+_Colorizefirs.rgb),node_6510));
                float node_7333 = 0.0;
                float3 diffuseColor = lerp(node_448,((node_7333 + ( (clamp(pow(node_420,_AO_Albedoexponent),node_7333,_AOalbedocut) - node_7333) * (1.0 - node_7333) ) / (_AOalbedocut - node_7333))*node_448),_MultyplyAOtoAlbedo); // Need this for specular when using metallic
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
                float3 w = lerp( 0.0, lerp((_lightwrapsecond.rgb+_lightwrapsecond.rgb),(_Lightwrapmfirs.rgb+_Lightwrapmfirs.rgb),node_6510), _uselightwrap )*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                NdotLWrap = max(float3(0,0,0), NdotLWrap);
                float3 directDiffuse = (forwardLight + ((1 +(fd90 - 1)*pow((1.00001-NdotLWrap), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL))*(0.5-max(w.r,max(w.g,w.b))*0.5) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= node_420; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            uniform float _RoughnessFirst1;
            uniform sampler2D _MaterialFirstalbedo; uniform float4 _MaterialFirstalbedo_ST;
            uniform sampler2D _Materialfirstnormal; uniform float4 _Materialfirstnormal_ST;
            uniform sampler2D _maskredchanel; uniform float4 _maskredchanel_ST;
            uniform float _masktile;
            uniform float _Firstmaterialtile;
            uniform float _Roughnesssecond;
            uniform sampler2D _Materialsecondalbedo; uniform float4 _Materialsecondalbedo_ST;
            uniform sampler2D _Materialsecondnormal; uniform float4 _Materialsecondnormal_ST;
            uniform float _Secondmaterialtile;
            uniform float _Maskpower;
            uniform float _Maskclampmin;
            uniform float _Maskclampmax;
            uniform float4 _Lightwrapmfirs;
            uniform sampler2D _detailalbedo; uniform float4 _detailalbedo_ST;
            uniform sampler2D _detailnormal; uniform float4 _detailnormal_ST;
            uniform float _Detailmaterialtile;
            uniform float _detailalbedofactor;
            uniform float _detailnormalfactor;
            uniform float4 _lightwrapsecond;
            uniform fixed _uselightwrap;
            uniform float4 _Colorizefirs;
            uniform float4 _colorizesecond;
            uniform sampler2D _Roughnessmaskfirst; uniform float4 _Roughnessmaskfirst_ST;
            uniform sampler2D _roughnessmasksecond; uniform float4 _roughnessmasksecond_ST;
            uniform fixed _FlipRoughnessmask;
            uniform float _Roughnessmaskpower;
            uniform fixed _useRoughness;
            uniform float _ParalaxfirstDep;
            uniform float _ParalaxfirstRef;
            uniform float _AOfactor;
            uniform sampler2D _AOtexturefirst; uniform float4 _AOtexturefirst_ST;
            uniform sampler2D _AOtexturesecond; uniform float4 _AOtexturesecond_ST;
            uniform fixed _UseFirstparalax;
            uniform fixed _Usesecondparalax;
            uniform fixed _USedetailparalax;
            uniform float _normalpower;
            uniform float _MultyplyAOtoAlbedo;
            uniform float _AO_Albedoexponent;
            uniform float _AOalbedocut;
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
                float node_5893_ang = 1.618;
                float node_5893_spd = 1.0;
                float node_5893_cos = cos(node_5893_spd*node_5893_ang);
                float node_5893_sin = sin(node_5893_spd*node_5893_ang);
                float2 node_5893_piv = float2(0.5,0.5);
                float2 node_1236 = (_masktile*0.1*i.uv0);
                float4 _node_4989 = tex2D(_maskredchanel,TRANSFORM_TEX(node_1236, _maskredchanel)); // mask blend
                float node_6401_ang = 1.618;
                float node_6401_spd = 1.0;
                float node_6401_cos = cos(node_6401_spd*node_6401_ang);
                float node_6401_sin = sin(node_6401_spd*node_6401_ang);
                float2 node_6401_piv = float2(0.5,0.5);
                float2 node_6401 = (mul(node_1236-node_6401_piv,float2x2( node_6401_cos, -node_6401_sin, node_6401_sin, node_6401_cos))+node_6401_piv);
                float2 node_3870 = (0.61*node_6401); // mask ccordinates
                float4 _node_430 = tex2D(_maskredchanel,TRANSFORM_TEX(node_3870, _maskredchanel));
                float node_2380 = saturate(( _node_430.r > 0.5 ? (1.0-(1.0-2.0*(_node_430.r-0.5))*(1.0-_node_4989.r)) : (2.0*_node_430.r*_node_4989.r) ));
                float2 node_7710 = (_Secondmaterialtile*5.0*lerp( i.uv0, (_ParalaxfirstDep*(node_2380 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _Usesecondparalax ));
                float2 node_5893 = (mul(node_7710-node_5893_piv,float2x2( node_5893_cos, -node_5893_sin, node_5893_sin, node_5893_cos))+node_5893_piv);
                float2 node_5940 = (0.61*node_5893); // material second ccordinates
                float3 _node_61249 = UnpackNormal(tex2D(_Materialsecondnormal,TRANSFORM_TEX(node_5940, _Materialsecondnormal)));
                float3 _node_69112 = UnpackNormal(tex2D(_Materialsecondnormal,TRANSFORM_TEX(node_7710, _Materialsecondnormal)));
                float3 node_0796_nrm_base = _node_61249.rgb + float3(0,0,1);
                float3 node_0796_nrm_detail = _node_69112.rgb * float3(-1,-1,1);
                float3 node_0796_nrm_combined = node_0796_nrm_base*dot(node_0796_nrm_base, node_0796_nrm_detail)/node_0796_nrm_base.z - node_0796_nrm_detail;
                float3 node_0796 = node_0796_nrm_combined;
                float node_94073_ang = 1.618;
                float node_94073_spd = 1.0;
                float node_94073_cos = cos(node_94073_spd*node_94073_ang);
                float node_94073_sin = sin(node_94073_spd*node_94073_ang);
                float2 node_94073_piv = float2(0.5,0.5);
                float2 node_67346 = (_Firstmaterialtile*5.0*lerp( i.uv0, (_ParalaxfirstDep*(node_2380 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _UseFirstparalax ));
                float2 node_94073 = (mul(node_67346-node_94073_piv,float2x2( node_94073_cos, -node_94073_sin, node_94073_sin, node_94073_cos))+node_94073_piv);
                float2 node_43777 = (0.61*node_94073); // material first ccordinates
                float3 _node_6149 = UnpackNormal(tex2D(_Materialfirstnormal,TRANSFORM_TEX(node_43777, _Materialfirstnormal)));
                float3 _node_6490 = UnpackNormal(tex2D(_Materialfirstnormal,TRANSFORM_TEX(node_67346, _Materialfirstnormal)));
                float3 node_364_nrm_base = _node_6149.rgb + float3(0,0,1);
                float3 node_364_nrm_detail = _node_6490.rgb * float3(-1,-1,1);
                float3 node_364_nrm_combined = node_364_nrm_base*dot(node_364_nrm_base, node_364_nrm_detail)/node_364_nrm_base.z - node_364_nrm_detail;
                float3 node_364 = node_364_nrm_combined;
                float node_7228 = 0.0;
                float node_6510 = (node_7228 + ( (clamp(pow(node_2380,_Maskpower),_Maskclampmin,_Maskclampmax) - _Maskclampmin) * (1.0 - node_7228) ) / (_Maskclampmax - _Maskclampmin)).r;
                float3 node_9575 = lerp(node_0796,node_364,node_6510); // blended normal
                float node_9843_ang = 1.618;
                float node_9843_spd = 1.0;
                float node_9843_cos = cos(node_9843_spd*node_9843_ang);
                float node_9843_sin = sin(node_9843_spd*node_9843_ang);
                float2 node_9843_piv = float2(0.5,0.5);
                float2 node_2709 = (_Detailmaterialtile*7.0*lerp( i.uv0, (_ParalaxfirstDep*(node_6510 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _USedetailparalax ));
                float2 node_9843 = (mul(node_2709-node_9843_piv,float2x2( node_9843_cos, -node_9843_sin, node_9843_sin, node_9843_cos))+node_9843_piv);
                float2 node_2339 = (0.61*node_9843); // detail  ccordinates
                float3 _node_64749 = UnpackNormal(tex2D(_detailnormal,TRANSFORM_TEX(node_2339, _detailnormal)));
                float3 _node_7490 = UnpackNormal(tex2D(_detailnormal,TRANSFORM_TEX(node_2709, _detailnormal)));
                float3 node_8322_nrm_base = _node_64749.rgb + float3(0,0,1);
                float3 node_8322_nrm_detail = _node_7490.rgb * float3(-1,-1,1);
                float3 node_8322_nrm_combined = node_8322_nrm_base*dot(node_8322_nrm_base, node_8322_nrm_detail)/node_8322_nrm_base.z - node_8322_nrm_detail;
                float3 node_8322 = node_8322_nrm_combined;
                float3 node_539_nrm_base = node_9575 + float3(0,0,1);
                float3 node_539_nrm_detail = node_8322 * float3(-1,-1,1);
                float3 node_539_nrm_combined = node_539_nrm_base*dot(node_539_nrm_base, node_539_nrm_detail)/node_539_nrm_base.z - node_539_nrm_detail;
                float3 node_539 = node_539_nrm_combined;
                float3 normalLocal = lerp(lerp(float3(0.5,0.5,1),node_9575,_normalpower),node_539,_detailnormalfactor);
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
                float4 _node_8162 = tex2D(_roughnessmasksecond,TRANSFORM_TEX(node_5940, _roughnessmasksecond));
                float4 _node_7073 = tex2D(_roughnessmasksecond,TRANSFORM_TEX(node_7710, _roughnessmasksecond));
                float4 _node_1779 = tex2D(_Roughnessmaskfirst,TRANSFORM_TEX(node_67346, _Roughnessmaskfirst));
                float4 _node_1709 = tex2D(_Roughnessmaskfirst,TRANSFORM_TEX(node_43777, _Roughnessmaskfirst));
                float node_6595 = lerp(saturate(( _node_7073.r > 0.5 ? (1.0-(1.0-2.0*(_node_7073.r-0.5))*(1.0-_node_8162.r)) : (2.0*_node_7073.r*_node_8162.r) )),saturate(( _node_1709.r > 0.5 ? (1.0-(1.0-2.0*(_node_1709.r-0.5))*(1.0-_node_1779.r)) : (2.0*_node_1709.r*_node_1779.r) )),node_6510);
                float gloss = 1.0 - lerp( 1.0, ((((lerp( node_6595, (-1*node_6595), _FlipRoughnessmask )+_Roughnessmaskpower)*_Roughnessmaskpower)*lerp(_Roughnesssecond,_RoughnessFirst1,node_6510))+_Roughnessmaskpower), _useRoughness ); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _node_2331 = tex2D(_Materialsecondalbedo,TRANSFORM_TEX(node_7710, _Materialsecondalbedo));
                float4 _node_98076 = tex2D(_Materialsecondalbedo,TRANSFORM_TEX(node_5940, _Materialsecondalbedo));
                float4 _node_303421 = tex2D(_MaterialFirstalbedo,TRANSFORM_TEX(node_67346, _MaterialFirstalbedo));
                float4 _node_33844 = tex2D(_MaterialFirstalbedo,TRANSFORM_TEX(node_43777, _MaterialFirstalbedo));
                float3 node_500 = lerp(saturate(( _node_98076.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_98076.rgb-0.5))*(1.0-_node_2331.rgb)) : (2.0*_node_98076.rgb*_node_2331.rgb) )),saturate(( _node_33844.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_33844.rgb-0.5))*(1.0-_node_303421.rgb)) : (2.0*_node_33844.rgb*_node_303421.rgb) )),node_6510); // blended albedo
                float4 _node_3041 = tex2D(_detailalbedo,TRANSFORM_TEX(i.uv0, _detailalbedo));
                float4 _node_3344 = tex2D(_detailalbedo,TRANSFORM_TEX(i.uv0, _detailalbedo));
                float3 node_448 = (lerp(node_500,(node_500+saturate(( _node_3344.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_3344.rgb-0.5))*(1.0-_node_3041.rgb)) : (2.0*_node_3344.rgb*_node_3041.rgb) ))),_detailalbedofactor)*lerp((_colorizesecond.rgb+_colorizesecond.rgb),(_Colorizefirs.rgb+_Colorizefirs.rgb),node_6510));
                float4 _node_5572 = tex2D(_AOtexturesecond,TRANSFORM_TEX(node_7710, _AOtexturesecond));
                float4 _node_327 = tex2D(_AOtexturesecond,TRANSFORM_TEX(node_5940, _AOtexturesecond));
                float4 _node_3582 = tex2D(_AOtexturefirst,TRANSFORM_TEX(node_67346, _AOtexturefirst));
                float4 _node_3499 = tex2D(_AOtexturefirst,TRANSFORM_TEX(node_43777, _AOtexturefirst));
                float node_420 = lerp(1.0,lerp((_node_5572.r*_node_327.r),(_node_3582.r*_node_3499.r),node_6510),_AOfactor);
                float node_7333 = 0.0;
                float3 diffuseColor = lerp(node_448,((node_7333 + ( (clamp(pow(node_420,_AO_Albedoexponent),node_7333,_AOalbedocut) - node_7333) * (1.0 - node_7333) ) / (_AOalbedocut - node_7333))*node_448),_MultyplyAOtoAlbedo); // Need this for specular when using metallic
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
                float3 w = lerp( 0.0, lerp((_lightwrapsecond.rgb+_lightwrapsecond.rgb),(_Lightwrapmfirs.rgb+_Lightwrapmfirs.rgb),node_6510), _uselightwrap )*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                NdotLWrap = max(float3(0,0,0), NdotLWrap);
                float3 directDiffuse = (forwardLight + ((1 +(fd90 - 1)*pow((1.00001-NdotLWrap), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL))*(0.5-max(w.r,max(w.g,w.b))*0.5) * attenColor;
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
            uniform float _RoughnessFirst1;
            uniform sampler2D _MaterialFirstalbedo; uniform float4 _MaterialFirstalbedo_ST;
            uniform sampler2D _maskredchanel; uniform float4 _maskredchanel_ST;
            uniform float _masktile;
            uniform float _Firstmaterialtile;
            uniform float _Roughnesssecond;
            uniform sampler2D _Materialsecondalbedo; uniform float4 _Materialsecondalbedo_ST;
            uniform float _Secondmaterialtile;
            uniform float _Maskpower;
            uniform float _Maskclampmin;
            uniform float _Maskclampmax;
            uniform sampler2D _detailalbedo; uniform float4 _detailalbedo_ST;
            uniform float _detailalbedofactor;
            uniform float4 _Colorizefirs;
            uniform float4 _colorizesecond;
            uniform sampler2D _Roughnessmaskfirst; uniform float4 _Roughnessmaskfirst_ST;
            uniform sampler2D _roughnessmasksecond; uniform float4 _roughnessmasksecond_ST;
            uniform fixed _FlipRoughnessmask;
            uniform float _Roughnessmaskpower;
            uniform fixed _useRoughness;
            uniform float _ParalaxfirstDep;
            uniform float _ParalaxfirstRef;
            uniform float _AOfactor;
            uniform sampler2D _AOtexturefirst; uniform float4 _AOtexturefirst_ST;
            uniform sampler2D _AOtexturesecond; uniform float4 _AOtexturesecond_ST;
            uniform fixed _UseFirstparalax;
            uniform fixed _Usesecondparalax;
            uniform float _MultyplyAOtoAlbedo;
            uniform float _AO_Albedoexponent;
            uniform float _AOalbedocut;
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
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float2 node_1236 = (_masktile*0.1*i.uv0);
                float4 _node_4989 = tex2D(_maskredchanel,TRANSFORM_TEX(node_1236, _maskredchanel)); // mask blend
                float node_6401_ang = 1.618;
                float node_6401_spd = 1.0;
                float node_6401_cos = cos(node_6401_spd*node_6401_ang);
                float node_6401_sin = sin(node_6401_spd*node_6401_ang);
                float2 node_6401_piv = float2(0.5,0.5);
                float2 node_6401 = (mul(node_1236-node_6401_piv,float2x2( node_6401_cos, -node_6401_sin, node_6401_sin, node_6401_cos))+node_6401_piv);
                float2 node_3870 = (0.61*node_6401); // mask ccordinates
                float4 _node_430 = tex2D(_maskredchanel,TRANSFORM_TEX(node_3870, _maskredchanel));
                float node_2380 = saturate(( _node_430.r > 0.5 ? (1.0-(1.0-2.0*(_node_430.r-0.5))*(1.0-_node_4989.r)) : (2.0*_node_430.r*_node_4989.r) ));
                float2 node_7710 = (_Secondmaterialtile*5.0*lerp( i.uv0, (_ParalaxfirstDep*(node_2380 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _Usesecondparalax ));
                float4 _node_2331 = tex2D(_Materialsecondalbedo,TRANSFORM_TEX(node_7710, _Materialsecondalbedo));
                float node_5893_ang = 1.618;
                float node_5893_spd = 1.0;
                float node_5893_cos = cos(node_5893_spd*node_5893_ang);
                float node_5893_sin = sin(node_5893_spd*node_5893_ang);
                float2 node_5893_piv = float2(0.5,0.5);
                float2 node_5893 = (mul(node_7710-node_5893_piv,float2x2( node_5893_cos, -node_5893_sin, node_5893_sin, node_5893_cos))+node_5893_piv);
                float2 node_5940 = (0.61*node_5893); // material second ccordinates
                float4 _node_98076 = tex2D(_Materialsecondalbedo,TRANSFORM_TEX(node_5940, _Materialsecondalbedo));
                float2 node_67346 = (_Firstmaterialtile*5.0*lerp( i.uv0, (_ParalaxfirstDep*(node_2380 - _ParalaxfirstRef)*mul(tangentTransform, viewDirection).xy + i.uv0).rg, _UseFirstparalax ));
                float4 _node_303421 = tex2D(_MaterialFirstalbedo,TRANSFORM_TEX(node_67346, _MaterialFirstalbedo));
                float node_94073_ang = 1.618;
                float node_94073_spd = 1.0;
                float node_94073_cos = cos(node_94073_spd*node_94073_ang);
                float node_94073_sin = sin(node_94073_spd*node_94073_ang);
                float2 node_94073_piv = float2(0.5,0.5);
                float2 node_94073 = (mul(node_67346-node_94073_piv,float2x2( node_94073_cos, -node_94073_sin, node_94073_sin, node_94073_cos))+node_94073_piv);
                float2 node_43777 = (0.61*node_94073); // material first ccordinates
                float4 _node_33844 = tex2D(_MaterialFirstalbedo,TRANSFORM_TEX(node_43777, _MaterialFirstalbedo));
                float node_7228 = 0.0;
                float node_6510 = (node_7228 + ( (clamp(pow(node_2380,_Maskpower),_Maskclampmin,_Maskclampmax) - _Maskclampmin) * (1.0 - node_7228) ) / (_Maskclampmax - _Maskclampmin)).r;
                float3 node_500 = lerp(saturate(( _node_98076.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_98076.rgb-0.5))*(1.0-_node_2331.rgb)) : (2.0*_node_98076.rgb*_node_2331.rgb) )),saturate(( _node_33844.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_33844.rgb-0.5))*(1.0-_node_303421.rgb)) : (2.0*_node_33844.rgb*_node_303421.rgb) )),node_6510); // blended albedo
                float4 _node_3041 = tex2D(_detailalbedo,TRANSFORM_TEX(i.uv0, _detailalbedo));
                float4 _node_3344 = tex2D(_detailalbedo,TRANSFORM_TEX(i.uv0, _detailalbedo));
                float3 node_448 = (lerp(node_500,(node_500+saturate(( _node_3344.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_3344.rgb-0.5))*(1.0-_node_3041.rgb)) : (2.0*_node_3344.rgb*_node_3041.rgb) ))),_detailalbedofactor)*lerp((_colorizesecond.rgb+_colorizesecond.rgb),(_Colorizefirs.rgb+_Colorizefirs.rgb),node_6510));
                float4 _node_5572 = tex2D(_AOtexturesecond,TRANSFORM_TEX(node_7710, _AOtexturesecond));
                float4 _node_327 = tex2D(_AOtexturesecond,TRANSFORM_TEX(node_5940, _AOtexturesecond));
                float4 _node_3582 = tex2D(_AOtexturefirst,TRANSFORM_TEX(node_67346, _AOtexturefirst));
                float4 _node_3499 = tex2D(_AOtexturefirst,TRANSFORM_TEX(node_43777, _AOtexturefirst));
                float node_420 = lerp(1.0,lerp((_node_5572.r*_node_327.r),(_node_3582.r*_node_3499.r),node_6510),_AOfactor);
                float node_7333 = 0.0;
                float3 diffColor = lerp(node_448,((node_7333 + ( (clamp(pow(node_420,_AO_Albedoexponent),node_7333,_AOalbedocut) - node_7333) * (1.0 - node_7333) ) / (_AOalbedocut - node_7333))*node_448),_MultyplyAOtoAlbedo);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float4 _node_8162 = tex2D(_roughnessmasksecond,TRANSFORM_TEX(node_5940, _roughnessmasksecond));
                float4 _node_7073 = tex2D(_roughnessmasksecond,TRANSFORM_TEX(node_7710, _roughnessmasksecond));
                float4 _node_1779 = tex2D(_Roughnessmaskfirst,TRANSFORM_TEX(node_67346, _Roughnessmaskfirst));
                float4 _node_1709 = tex2D(_Roughnessmaskfirst,TRANSFORM_TEX(node_43777, _Roughnessmaskfirst));
                float node_6595 = lerp(saturate(( _node_7073.r > 0.5 ? (1.0-(1.0-2.0*(_node_7073.r-0.5))*(1.0-_node_8162.r)) : (2.0*_node_7073.r*_node_8162.r) )),saturate(( _node_1709.r > 0.5 ? (1.0-(1.0-2.0*(_node_1709.r-0.5))*(1.0-_node_1779.r)) : (2.0*_node_1709.r*_node_1779.r) )),node_6510);
                float roughness = lerp( 1.0, ((((lerp( node_6595, (-1*node_6595), _FlipRoughnessmask )+_Roughnessmaskpower)*_Roughnessmaskpower)*lerp(_Roughnesssecond,_RoughnessFirst1,node_6510))+_Roughnessmaskpower), _useRoughness );
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
