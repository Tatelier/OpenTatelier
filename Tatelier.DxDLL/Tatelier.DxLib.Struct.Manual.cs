using System.Runtime.InteropServices;
namespace DxLibDLL
{
	public static partial class DX
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct IPDATA_IPv6
		{
			[FieldOffset(0)] public byte Byte00;
			[FieldOffset(1)] public byte Byte01;
			[FieldOffset(2)] public byte Byte02;
			[FieldOffset(3)] public byte Byte03;
			[FieldOffset(4)] public byte Byte04;
			[FieldOffset(5)] public byte Byte05;
			[FieldOffset(6)] public byte Byte06;
			[FieldOffset(7)] public byte Byte07;
			[FieldOffset(8)] public byte Byte08;
			[FieldOffset(9)] public byte Byte09;
			[FieldOffset(10)] public byte Byte10;
			[FieldOffset(11)] public byte Byte11;
			[FieldOffset(12)] public byte Byte12;
			[FieldOffset(13)] public byte Byte13;
			[FieldOffset(14)] public byte Byte14;
			[FieldOffset(15)] public byte Byte15;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct RECT
		{
			[FieldOffset(0)] public int left;
			[FieldOffset(4)] public int top;
			[FieldOffset(8)] public int right;
			[FieldOffset(12)] public int bottom;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MATRIX
		{
			[FieldOffset(0)] public float m00;
			[FieldOffset(4)] public float m01;
			[FieldOffset(8)] public float m02;
			[FieldOffset(12)] public float m03;
			[FieldOffset(16)] public float m10;
			[FieldOffset(20)] public float m11;
			[FieldOffset(24)] public float m12;
			[FieldOffset(28)] public float m13;
			[FieldOffset(32)] public float m20;
			[FieldOffset(36)] public float m21;
			[FieldOffset(40)] public float m22;
			[FieldOffset(44)] public float m23;
			[FieldOffset(48)] public float m30;
			[FieldOffset(52)] public float m31;
			[FieldOffset(56)] public float m32;
			[FieldOffset(60)] public float m33;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MATRIX_D
		{
			[FieldOffset(0)] public double m00;
			[FieldOffset(8)] public double m01;
			[FieldOffset(16)] public double m02;
			[FieldOffset(24)] public double m03;
			[FieldOffset(32)] public double m10;
			[FieldOffset(40)] public double m11;
			[FieldOffset(48)] public double m12;
			[FieldOffset(56)] public double m13;
			[FieldOffset(64)] public double m20;
			[FieldOffset(72)] public double m21;
			[FieldOffset(80)] public double m22;
			[FieldOffset(88)] public double m23;
			[FieldOffset(96)] public double m30;
			[FieldOffset(104)] public double m31;
			[FieldOffset(112)] public double m32;
			[FieldOffset(120)] public double m33;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct COLORDATA
		{
			[FieldOffset(0)] public byte Format ;
			[FieldOffset(1)] public byte ChannelNum ;
			[FieldOffset(2)] public byte ChannelBitDepth ;
			[FieldOffset(3)] public byte FloatTypeFlag ;
			[FieldOffset(4)] public byte PixelByte;
			[FieldOffset(5)] public byte ColorBitDepth;
			[FieldOffset(6)] public byte NoneLoc ;
			[FieldOffset(7)] public byte NoneWidth ;
			[FieldOffset(8)] public byte RedWidth ;
			[FieldOffset(9)] public byte GreenWidth ;
			[FieldOffset(10)] public byte BlueWidth ;
			[FieldOffset(11)] public byte AlphaWidth ;
			[FieldOffset(12)] public byte RedLoc ;
			[FieldOffset(13)] public byte GreenLoc ;
			[FieldOffset(14)] public byte BlueLoc ;
			[FieldOffset(15)] public byte AlphaLoc ;
			[FieldOffset(16)] public uint RedMask ;
			[FieldOffset(20)] public uint GreenMask ;
			[FieldOffset(24)] public uint BlueMask ;
			[FieldOffset(28)] public uint AlphaMask ;
			[FieldOffset(32)] public uint NoneMask ;
			[FieldOffset(36)] public int MaxPaletteNo ;
			[FieldOffset(40)] public COLORPALETTEDATA Palette0 ;
			[FieldOffset(1060)] public COLORPALETTEDATA Palette255 ;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MV1_COLL_RESULT_POLY
		{
			[FieldOffset(0)] public int HitFlag;
			[FieldOffset(4)] public VECTOR HitPosition;
			[FieldOffset(16)] public int FrameIndex;
			[FieldOffset(20)] public int PolyIndex;
			[FieldOffset(24)] public int MaterialIndex;
			[FieldOffset(28)] public VECTOR Position0;
			[FieldOffset(40)] public VECTOR Position1;
			[FieldOffset(52)] public VECTOR Position2;
			[FieldOffset(64)] public VECTOR Normal;
			[FieldOffset(76)] public float PositionWeight0;
			[FieldOffset(80)] public float PositionWeight1;
			[FieldOffset(84)] public float PositionWeight2;
			[FieldOffset(88)] public int PosMaxWeightFrameIndex0;
			[FieldOffset(92)] public int PosMaxWeightFrameIndex1;
			[FieldOffset(96)] public int PosMaxWeightFrameIndex2;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MV1_REF_POLYGON
		{
			[FieldOffset(0)] public ushort FrameIndex;
			[FieldOffset(2)] public ushort MeshIndex;
			[FieldOffset(4)] public ushort MaterialIndex;
			[FieldOffset(6)] public ushort VIndexTarget;
			[FieldOffset(8)] public int VIndex0;
			[FieldOffset(12)] public int VIndex1;
			[FieldOffset(16)] public int VIndex2;
			[FieldOffset(20)] public VECTOR MinPosition;
			[FieldOffset(32)] public VECTOR MaxPosition;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct MV1_REF_VERTEX
		{
			[FieldOffset(0)] public VECTOR Position;
			[FieldOffset(12)] public VECTOR Normal;
			[FieldOffset(24)] public FLOAT2 TexCoord0;
			[FieldOffset(32)] public FLOAT2 TexCoord1;
			[FieldOffset(40)] public COLOR_U8 DiffuseColor;
			[FieldOffset(44)] public COLOR_U8 SpecularColor;
			[FieldOffset(48)] public int MaxWeightFrameIndex;
		};
		
		[StructLayout(LayoutKind.Sequential)]
		public struct MV1_REF_POLYGONLIST_NT
		{
			public int PolygonNum;
			public int VertexNum;
			public VECTOR MinPosition;
			public VECTOR MaxPosition;
			public System.IntPtr Polygons;
			public System.IntPtr Vertexs;
		};
		
		public struct MV1_REF_POLYGONLIST
		{
			public int PolygonNum;
			public int VertexNum;
			public VECTOR MinPosition;
			public VECTOR MaxPosition;
			public MV1_REF_POLYGON[] Polygons;
			public MV1_REF_VERTEX[] Vertexs;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct DINPUT_JOYSTATE
		{
			[FieldOffset(0)] public int X;
			[FieldOffset(4)] public int Y;
			[FieldOffset(8)] public int Z;
			[FieldOffset(12)] public int Rx;
			[FieldOffset(16)] public int Ry;
			[FieldOffset(20)] public int Rz;
			[FieldOffset(24)] public int Slider0;
			[FieldOffset(28)] public int Slider1;
			[FieldOffset(32)] public uint POV0;
			[FieldOffset(36)] public uint POV1;
			[FieldOffset(40)] public uint POV2;
			[FieldOffset(44)] public uint POV3;
			[FieldOffset(48)] public byte Buttons0;
			[FieldOffset(49)] public byte Buttons1;
			[FieldOffset(50)] public byte Buttons2;
			[FieldOffset(51)] public byte Buttons3;
			[FieldOffset(52)] public byte Buttons4;
			[FieldOffset(53)] public byte Buttons5;
			[FieldOffset(54)] public byte Buttons6;
			[FieldOffset(55)] public byte Buttons7;
			[FieldOffset(56)] public byte Buttons8;
			[FieldOffset(57)] public byte Buttons9;
			[FieldOffset(58)] public byte Buttons10;
			[FieldOffset(59)] public byte Buttons11;
			[FieldOffset(60)] public byte Buttons12;
			[FieldOffset(61)] public byte Buttons13;
			[FieldOffset(62)] public byte Buttons14;
			[FieldOffset(63)] public byte Buttons15;
			[FieldOffset(64)] public byte Buttons16;
			[FieldOffset(65)] public byte Buttons17;
			[FieldOffset(66)] public byte Buttons18;
			[FieldOffset(67)] public byte Buttons19;
			[FieldOffset(68)] public byte Buttons20;
			[FieldOffset(69)] public byte Buttons21;
			[FieldOffset(70)] public byte Buttons22;
			[FieldOffset(71)] public byte Buttons23;
			[FieldOffset(72)] public byte Buttons24;
			[FieldOffset(73)] public byte Buttons25;
			[FieldOffset(74)] public byte Buttons26;
			[FieldOffset(75)] public byte Buttons27;
			[FieldOffset(76)] public byte Buttons28;
			[FieldOffset(77)] public byte Buttons29;
			[FieldOffset(78)] public byte Buttons30;
			[FieldOffset(79)] public byte Buttons31;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct XINPUT_STATE
		{
			[FieldOffset(0)] public byte Buttons0;
			[FieldOffset(1)] public byte Buttons1;
			[FieldOffset(2)] public byte Buttons2;
			[FieldOffset(3)] public byte Buttons3;
			[FieldOffset(4)] public byte Buttons4;
			[FieldOffset(5)] public byte Buttons5;
			[FieldOffset(6)] public byte Buttons6;
			[FieldOffset(7)] public byte Buttons7;
			[FieldOffset(8)] public byte Buttons8;
			[FieldOffset(9)] public byte Buttons9;
			[FieldOffset(10)] public byte Buttons10;
			[FieldOffset(11)] public byte Buttons11;
			[FieldOffset(12)] public byte Buttons12;
			[FieldOffset(13)] public byte Buttons13;
			[FieldOffset(14)] public byte Buttons14;
			[FieldOffset(15)] public byte Buttons15;
			[FieldOffset(16)] public byte LeftTrigger;
			[FieldOffset(17)] public byte RightTrigger;
			[FieldOffset(18)] public short ThumbLX;
			[FieldOffset(20)] public short ThumbLY;
			[FieldOffset(22)] public short ThumbRX;
			[FieldOffset(24)] public short ThumbRY;
		};
		
		[StructLayout(LayoutKind.Explicit)]
		public struct TOUCHINPUTDATA
		{
			[FieldOffset(0)] public int Time;
			[FieldOffset(4)] public int PointNum;
			[FieldOffset(8)] public TOUCHINPUTPOINT Point0;
			[FieldOffset(24)] public TOUCHINPUTPOINT Point1;
			[FieldOffset(40)] public TOUCHINPUTPOINT Point2;
			[FieldOffset(56)] public TOUCHINPUTPOINT Point3;
			[FieldOffset(72)] public TOUCHINPUTPOINT Point4;
			[FieldOffset(88)] public TOUCHINPUTPOINT Point5;
			[FieldOffset(104)] public TOUCHINPUTPOINT Point6;
			[FieldOffset(120)] public TOUCHINPUTPOINT Point7;
			[FieldOffset(136)] public TOUCHINPUTPOINT Point8;
			[FieldOffset(152)] public TOUCHINPUTPOINT Point9;
			[FieldOffset(168)] public TOUCHINPUTPOINT Point10;
			[FieldOffset(184)] public TOUCHINPUTPOINT Point11;
			[FieldOffset(200)] public TOUCHINPUTPOINT Point12;
			[FieldOffset(216)] public TOUCHINPUTPOINT Point13;
			[FieldOffset(232)] public TOUCHINPUTPOINT Point14;
			[FieldOffset(248)] public TOUCHINPUTPOINT Point15;
		};
	}
}