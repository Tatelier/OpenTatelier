using System.Runtime.InteropServices;
namespace DxLibDLL
{
	public static partial class DX
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct IMEINPUTCLAUSEDATA
		{
			[FieldOffset(0)] public int Position;
			[FieldOffset(4)] public int Length;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct IMEINPUTDATA
		{
			[FieldOffset(0)] public string InputString;
			[FieldOffset(4)] public int CursorPosition;
			[FieldOffset(8)] public uint ClauseData;
			[FieldOffset(12)] public int ClauseNum;
			[FieldOffset(16)] public int SelectClause;
			[FieldOffset(20)] public int CandidateNum;
			[FieldOffset(24)] public uint CandidateList;
			[FieldOffset(28)] public int SelectCandidate;
			[FieldOffset(32)] public int ConvertFlag;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct DISPLAYMODEDATA
		{
			[FieldOffset(0)] public int Width;
			[FieldOffset(4)] public int Height;
			[FieldOffset(8)] public int ColorBitDepth;
			[FieldOffset(12)] public int RefreshRate;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct DATEDATA
		{
			[FieldOffset(0)] public int Year;
			[FieldOffset(4)] public int Mon;
			[FieldOffset(8)] public int Day;
			[FieldOffset(12)] public int Hour;
			[FieldOffset(16)] public int Min;
			[FieldOffset(20)] public int Sec;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VECTOR
		{
			[FieldOffset(0)] public float x;
			[FieldOffset(4)] public float y;
			[FieldOffset(8)] public float z;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VECTOR_D
		{
			[FieldOffset(0)] public double x;
			[FieldOffset(8)] public double y;
			[FieldOffset(16)] public double z;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct FLOAT2
		{
			[FieldOffset(0)] public float u;
			[FieldOffset(4)] public float v;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct COLOR_F
		{
			[FieldOffset(0)] public float r;
			[FieldOffset(4)] public float g;
			[FieldOffset(8)] public float b;
			[FieldOffset(12)] public float a;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct COLOR_U8
		{
			[FieldOffset(0)] public byte b;
			[FieldOffset(1)] public byte g;
			[FieldOffset(2)] public byte r;
			[FieldOffset(3)] public byte a;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct FLOAT4
		{
			[FieldOffset(0)] public float x;
			[FieldOffset(4)] public float y;
			[FieldOffset(8)] public float z;
			[FieldOffset(12)] public float w;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct DOUBLE4
		{
			[FieldOffset(0)] public double x;
			[FieldOffset(8)] public double y;
			[FieldOffset(16)] public double z;
			[FieldOffset(24)] public double w;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct INT4
		{
			[FieldOffset(0)] public int x;
			[FieldOffset(4)] public int y;
			[FieldOffset(8)] public int z;
			[FieldOffset(12)] public int w;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VERTEX2D
		{
			[FieldOffset(0)] public VECTOR pos;
			[FieldOffset(12)] public float rhw;
			[FieldOffset(16)] public COLOR_U8 dif;
			[FieldOffset(20)] public float u;
			[FieldOffset(24)] public float v;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VERTEX2DSHADER
		{
			[FieldOffset(0)] public VECTOR pos;
			[FieldOffset(12)] public float rhw;
			[FieldOffset(16)] public COLOR_U8 dif;
			[FieldOffset(20)] public COLOR_U8 spc;
			[FieldOffset(24)] public float u;
			[FieldOffset(28)] public float v;
			[FieldOffset(32)] public float su;
			[FieldOffset(36)] public float sv;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VERTEX
		{
			[FieldOffset(0)] public float x;
			[FieldOffset(4)] public float y;
			[FieldOffset(8)] public float u;
			[FieldOffset(12)] public float v;
			[FieldOffset(16)] public byte b;
			[FieldOffset(17)] public byte g;
			[FieldOffset(18)] public byte r;
			[FieldOffset(19)] public byte a;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VERTEX_3D
		{
			[FieldOffset(0)] public VECTOR pos;
			[FieldOffset(12)] public byte b;
			[FieldOffset(13)] public byte g;
			[FieldOffset(14)] public byte r;
			[FieldOffset(15)] public byte a;
			[FieldOffset(16)] public float u;
			[FieldOffset(20)] public float v;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VERTEX3D
		{
			[FieldOffset(0)] public VECTOR pos;
			[FieldOffset(12)] public VECTOR norm;
			[FieldOffset(24)] public COLOR_U8 dif;
			[FieldOffset(28)] public COLOR_U8 spc;
			[FieldOffset(32)] public float u;
			[FieldOffset(36)] public float v;
			[FieldOffset(40)] public float su;
			[FieldOffset(44)] public float sv;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct VERTEX3DSHADER
		{
			[FieldOffset(0)] public VECTOR pos;
			[FieldOffset(12)] public FLOAT4 spos;
			[FieldOffset(28)] public VECTOR norm;
			[FieldOffset(40)] public VECTOR tan;
			[FieldOffset(52)] public VECTOR binorm;
			[FieldOffset(64)] public COLOR_U8 dif;
			[FieldOffset(68)] public COLOR_U8 spc;
			[FieldOffset(72)] public float u;
			[FieldOffset(76)] public float v;
			[FieldOffset(80)] public float su;
			[FieldOffset(84)] public float sv;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct LIGHTPARAM
		{
			[FieldOffset(0)] public int LightType;
			[FieldOffset(4)] public COLOR_F Diffuse;
			[FieldOffset(20)] public COLOR_F Specular;
			[FieldOffset(36)] public COLOR_F Ambient;
			[FieldOffset(52)] public VECTOR Position;
			[FieldOffset(64)] public VECTOR Direction;
			[FieldOffset(76)] public float Range;
			[FieldOffset(80)] public float Falloff;
			[FieldOffset(84)] public float Attenuation0;
			[FieldOffset(88)] public float Attenuation1;
			[FieldOffset(92)] public float Attenuation2;
			[FieldOffset(96)] public float Theta;
			[FieldOffset(100)] public float Phi;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MATERIALPARAM
		{
			[FieldOffset(0)] public COLOR_F Diffuse;
			[FieldOffset(16)] public COLOR_F Ambient;
			[FieldOffset(32)] public COLOR_F Specular;
			[FieldOffset(48)] public COLOR_F Emissive;
			[FieldOffset(64)] public float Power;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct HITRESULT_LINE
		{
			[FieldOffset(0)] public int HitFlag;
			[FieldOffset(4)] public VECTOR Position;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct HITRESULT_LINE_D
		{
			[FieldOffset(0)] public int HitFlag;
			[FieldOffset(4)] public VECTOR_D Position;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SEGMENT_SEGMENT_RESULT
		{
			[FieldOffset(0)] public float SegA_SegB_MinDist_Square;
			[FieldOffset(4)] public float SegA_MinDist_Pos1_Pos2_t;
			[FieldOffset(8)] public float SegB_MinDist_Pos1_Pos2_t;
			[FieldOffset(12)] public VECTOR SegA_MinDist_Pos;
			[FieldOffset(24)] public VECTOR SegB_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SEGMENT_SEGMENT_RESULT_D
		{
			[FieldOffset(0)] public double SegA_SegB_MinDist_Square;
			[FieldOffset(8)] public double SegA_MinDist_Pos1_Pos2_t;
			[FieldOffset(16)] public double SegB_MinDist_Pos1_Pos2_t;
			[FieldOffset(24)] public VECTOR_D SegA_MinDist_Pos;
			[FieldOffset(48)] public VECTOR_D SegB_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SEGMENT_POINT_RESULT
		{
			[FieldOffset(0)] public float Seg_Point_MinDist_Square;
			[FieldOffset(4)] public float Seg_MinDist_Pos1_Pos2_t;
			[FieldOffset(8)] public VECTOR Seg_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SEGMENT_POINT_RESULT_D
		{
			[FieldOffset(0)] public double Seg_Point_MinDist_Square;
			[FieldOffset(8)] public double Seg_MinDist_Pos1_Pos2_t;
			[FieldOffset(16)] public VECTOR_D Seg_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SEGMENT_TRIANGLE_RESULT
		{
			[FieldOffset(0)] public float Seg_Tri_MinDist_Square;
			[FieldOffset(4)] public float Seg_MinDist_Pos1_Pos2_t;
			[FieldOffset(8)] public VECTOR Seg_MinDist_Pos;
			[FieldOffset(20)] public float Tri_MinDist_Pos1_w;
			[FieldOffset(24)] public float Tri_MinDist_Pos2_w;
			[FieldOffset(28)] public float Tri_MinDist_Pos3_w;
			[FieldOffset(32)] public VECTOR Tri_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SEGMENT_TRIANGLE_RESULT_D
		{
			[FieldOffset(0)] public double Seg_Tri_MinDist_Square;
			[FieldOffset(8)] public double Seg_MinDist_Pos1_Pos2_t;
			[FieldOffset(16)] public VECTOR_D Seg_MinDist_Pos;
			[FieldOffset(40)] public double Tri_MinDist_Pos1_w;
			[FieldOffset(48)] public double Tri_MinDist_Pos2_w;
			[FieldOffset(56)] public double Tri_MinDist_Pos3_w;
			[FieldOffset(64)] public VECTOR_D Tri_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct TRIANGLE_POINT_RESULT
		{
			[FieldOffset(0)] public float Tri_Pnt_MinDist_Square;
			[FieldOffset(4)] public float Tri_MinDist_Pos1_w;
			[FieldOffset(8)] public float Tri_MinDist_Pos2_w;
			[FieldOffset(12)] public float Tri_MinDist_Pos3_w;
			[FieldOffset(16)] public VECTOR Tri_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct TRIANGLE_POINT_RESULT_D
		{
			[FieldOffset(0)] public double Tri_Pnt_MinDist_Square;
			[FieldOffset(8)] public double Tri_MinDist_Pos1_w;
			[FieldOffset(16)] public double Tri_MinDist_Pos2_w;
			[FieldOffset(24)] public double Tri_MinDist_Pos3_w;
			[FieldOffset(32)] public VECTOR_D Tri_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct PLANE_POINT_RESULT
		{
			[FieldOffset(0)] public int Pnt_Plane_Normal_Side;
			[FieldOffset(4)] public float Plane_Pnt_MinDist_Square;
			[FieldOffset(8)] public VECTOR Plane_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct PLANE_POINT_RESULT_D
		{
			[FieldOffset(0)] public int Pnt_Plane_Normal_Side;
			[FieldOffset(4)] public double Plane_Pnt_MinDist_Square;
			[FieldOffset(12)] public VECTOR_D Plane_MinDist_Pos;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MV1_COLL_RESULT_POLY_DIM
		{
			[FieldOffset(0)] public int HitNum;
			[FieldOffset(4)] public uint Dim;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct SOUND3D_REVERB_PARAM
		{
			[FieldOffset(0)] public float WetDryMix;
			[FieldOffset(4)] public uint ReflectionsDelay;
			[FieldOffset(8)] public byte ReverbDelay;
			[FieldOffset(9)] public byte RearDelay;
			[FieldOffset(10)] public byte PositionLeft;
			[FieldOffset(11)] public byte PositionRight;
			[FieldOffset(12)] public byte PositionMatrixLeft;
			[FieldOffset(13)] public byte PositionMatrixRight;
			[FieldOffset(14)] public byte EarlyDiffusion;
			[FieldOffset(15)] public byte LateDiffusion;
			[FieldOffset(16)] public byte LowEQGain;
			[FieldOffset(17)] public byte LowEQCutoff;
			[FieldOffset(18)] public byte HighEQGain;
			[FieldOffset(19)] public byte HighEQCutoff;
			[FieldOffset(20)] public float RoomFilterFreq;
			[FieldOffset(24)] public float RoomFilterMain;
			[FieldOffset(28)] public float RoomFilterHF;
			[FieldOffset(32)] public float ReflectionsGain;
			[FieldOffset(36)] public float ReverbGain;
			[FieldOffset(40)] public float DecayTime;
			[FieldOffset(44)] public float Density;
			[FieldOffset(48)] public float RoomSize;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct COLORPALETTEDATA
		{
			[FieldOffset(0)] public byte Blue;
			[FieldOffset(1)] public byte Green;
			[FieldOffset(2)] public byte Red;
			[FieldOffset(3)] public byte Alpha;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct BASEIMAGE
		{
			[FieldOffset(0)] public COLORDATA ColorData;
			[FieldOffset(1064)] public int Width;
			[FieldOffset(1068)] public int Height;
			[FieldOffset(1072)] public int Pitch;
			[FieldOffset(1076)] public System.IntPtr GraphData;
			[FieldOffset(1080)] public int MipMapCount;
			[FieldOffset(1084)] public int GraphDataCount;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct LINEDATA
		{
			[FieldOffset(0)] public int x1;
			[FieldOffset(4)] public int y1;
			[FieldOffset(8)] public int x2;
			[FieldOffset(12)] public int y2;
			[FieldOffset(16)] public uint color;
			[FieldOffset(20)] public int pal;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct POINTDATA
		{
			[FieldOffset(0)] public int x;
			[FieldOffset(4)] public int y;
			[FieldOffset(8)] public uint color;
			[FieldOffset(12)] public int pal;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct CUBEDATA
		{
			[FieldOffset(0)] public VECTOR Pos1;
			[FieldOffset(12)] public VECTOR Pos2;
			[FieldOffset(24)] public COLOR_U8 DifColor;
			[FieldOffset(28)] public COLOR_U8 SpcColor;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct IMAGEFORMATDESC
		{
			[FieldOffset(0)] public byte TextureFlag;
			[FieldOffset(1)] public byte CubeMapTextureFlag;
			[FieldOffset(2)] public byte AlphaChFlag;
			[FieldOffset(3)] public byte DrawValidFlag;
			[FieldOffset(4)] public byte SystemMemFlag;
			[FieldOffset(5)] public byte UseManagedTextureFlag;
			[FieldOffset(6)] public byte UseLinearMapTextureFlag;
			[FieldOffset(7)] public byte PlatformTextureFormat;
			[FieldOffset(8)] public byte BaseFormat;
			[FieldOffset(9)] public byte MipMapCount;
			[FieldOffset(10)] public byte AlphaTestFlag;
			[FieldOffset(11)] public byte FloatTypeFlag;
			[FieldOffset(12)] public byte ColorBitDepth;
			[FieldOffset(13)] public byte ChannelNum;
			[FieldOffset(14)] public byte ChannelBitDepth;
			[FieldOffset(15)] public byte BlendGraphFlag;
			[FieldOffset(16)] public byte UsePaletteFlag;
			[FieldOffset(17)] public byte MSSamples;
			[FieldOffset(18)] public byte MSQuality;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct TOUCHINPUTPOINT
		{
			[FieldOffset(0)] public uint Device;
			[FieldOffset(4)] public uint ID;
			[FieldOffset(8)] public int PositionX;
			[FieldOffset(12)] public int PositionY;
		}
		
		[StructLayout(LayoutKind.Explicit)]
		public struct IPDATA
		{
			[FieldOffset(0)] public byte d1;
			[FieldOffset(1)] public byte d2;
			[FieldOffset(2)] public byte d3;
			[FieldOffset(3)] public byte d4;
		}
		
	}
}