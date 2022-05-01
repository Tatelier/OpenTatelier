using System.Runtime.InteropServices;
namespace DxLibDLL
{
	public static partial class DX
	{
		public static VECTOR MGetTranslateElem( MATRIX InM )
		{
			VECTOR Result ;
			Result.x = InM.m30 ;
			Result.y = InM.m31 ;
			Result.z = InM.m32 ;
			return Result ;
		}
		
		public static VECTOR_D MGetTranslateElemD( MATRIX_D InM )
		{
			VECTOR_D Result ;
			Result.x = InM.m30 ;
			Result.y = InM.m31 ;
			Result.z = InM.m32 ;
			return Result ;
		}
		
		public static VECTOR_D VConvFtoD( VECTOR In )
		{
			VECTOR_D Result ;
			Result.x = In.x ;
			Result.y = In.y ;
			Result.z = In.z ;
			return Result ;
		}
		
		public static VECTOR VConvDtoF( VECTOR_D In )
		{
			VECTOR Result ;
			Result.x = ( float )In.x ;
			Result.y = ( float )In.y ;
			Result.z = ( float )In.z ;
			return Result ;
		}
		
		public static VECTOR VGet( float x, float y, float z )
		{
			VECTOR Result ;
			Result.x = x ;
			Result.y = y ;
			Result.z = z ;
			return Result ;
		}
		
		public static VECTOR_D VGetD( double x, double y, double z )
		{
			VECTOR_D Result ;
			Result.x = x ;
			Result.y = y ;
			Result.z = z ;
			return Result ;
		}
		
		public static FLOAT2 F2Get( float u, float v )
		{
			FLOAT2 Result ;
			Result.u = u ;
			Result.v = v ;
			return Result ;
		}
		
		public static FLOAT4 F4Get( float x, float y, float z, float w )
		{
			FLOAT4 Result ;
			Result.x = x ;
			Result.y = y ;
			Result.z = z ;
			Result.w = w ;
			return Result ;
		}
		
		public static DOUBLE4 D4Get( double x, double y, double z, double w )
		{
			DOUBLE4 Result ;
			Result.x = x ;
			Result.y = y ;
			Result.z = z ;
			Result.w = w ;
			return Result ;
		}
		
		public static VECTOR VAdd( VECTOR In1, VECTOR In2 )
		{
			VECTOR Result ;
			Result.x = In1.x + In2.x ;
			Result.y = In1.y + In2.y ;
			Result.z = In1.z + In2.z ;
			return Result ;
		}
		
		public static VECTOR_D VAddD( VECTOR_D In1, VECTOR_D In2 )
		{
			VECTOR_D Result ;
			Result.x = In1.x + In2.x ;
			Result.y = In1.y + In2.y ;
			Result.z = In1.z + In2.z ;
			return Result ;
		}
		
		public static VECTOR VSub( VECTOR In1, VECTOR In2 )
		{
			VECTOR Result ;
			Result.x = In1.x - In2.x ;
			Result.y = In1.y - In2.y ;
			Result.z = In1.z - In2.z ;
			return Result ;
		}
		
		public static VECTOR_D VSubD( VECTOR_D In1, VECTOR_D In2 )
		{
			VECTOR_D Result ;
			Result.x = In1.x - In2.x ;
			Result.y = In1.y - In2.y ;
			Result.z = In1.z - In2.z ;
			return Result ;
		}
		
		public static FLOAT2 F2Add( FLOAT2 In1, FLOAT2 In2 )
		{
			FLOAT2 Result ;
			Result.u = In1.u + In2.u ;
			Result.v = In1.v + In2.v ;
			return Result ;
		}
		
		public static FLOAT4 F4Add( FLOAT4 In1, FLOAT4 In2 )
		{
			FLOAT4 Result ;
			Result.x = In1.x + In2.x ;
			Result.y = In1.y + In2.y ;
			Result.z = In1.z + In2.z ;
			Result.w = In1.w + In2.w ;
			return Result ;
		}
		
		public static DOUBLE4	D4Add( DOUBLE4 In1, DOUBLE4 In2 )
		{
			DOUBLE4 Result ;
			Result.x = In1.x + In2.x ;
			Result.y = In1.y + In2.y ;
			Result.z = In1.z + In2.z ;
			Result.w = In1.w + In2.w ;
			return Result ;
		}
		
		public static FLOAT2 F2Sub( FLOAT2 In1, FLOAT2 In2 )
		{
			FLOAT2 Result ;
			Result.u = In1.u - In2.u ;
			Result.v = In1.v - In2.v ;
			return Result ;
		}
		
		public static FLOAT4 F4Sub( FLOAT4 In1, FLOAT4 In2 )
		{
			FLOAT4 Result ;
			Result.x = In1.x - In2.x ;
			Result.y = In1.y - In2.y ;
			Result.z = In1.z - In2.z ;
			Result.w = In1.w - In2.w ;
			return Result ;
		}
		
		public static DOUBLE4	D4Sub( DOUBLE4 In1, DOUBLE4 In2 )
		{
			DOUBLE4 Result ;
			Result.x = In1.x - In2.x ;
			Result.y = In1.y - In2.y ;
			Result.z = In1.z - In2.z ;
			Result.w = In1.w - In2.w ;
			return Result ;
		}
		
		public static float VDot( VECTOR In1, VECTOR In2 )
		{
			return In1.x * In2.x + In1.y * In2.y + In1.z * In2.z ;
		}
		
		public static double VDotD( VECTOR_D In1, VECTOR_D In2 )
		{
			return In1.x * In2.x + In1.y * In2.y + In1.z * In2.z ;
		}
		
		public static VECTOR VCross( VECTOR In1, VECTOR In2 )
		{
			VECTOR Result ;
			Result.x = In1.y * In2.z - In1.z * In2.y ;
			Result.y = In1.z * In2.x - In1.x * In2.z ;
			Result.z = In1.x * In2.y - In1.y * In2.x ;
			return Result ;
		}
		
		public static VECTOR_D VCrossD( VECTOR_D In1, VECTOR_D In2 )
		{
			VECTOR_D Result ;
			Result.x = In1.y * In2.z - In1.z * In2.y ;
			Result.y = In1.z * In2.x - In1.x * In2.z ;
			Result.z = In1.x * In2.y - In1.y * In2.x ;
			return Result ;
		}
		
		public static VECTOR VScale( VECTOR In, float Scale )
		{
			VECTOR Result ;
			Result.x = In.x * Scale ;
			Result.y = In.y * Scale ;
			Result.z = In.z * Scale ;
			return Result ;
		}
		
		public static VECTOR_D VScaleD( VECTOR_D In, double Scale )
		{
			VECTOR_D Result ;
			Result.x = In.x * Scale ;
			Result.y = In.y * Scale ;
			Result.z = In.z * Scale ;
			return Result ;
		}
		
		public static FLOAT2 F2Scale( FLOAT2 In, float Scale )
		{
			FLOAT2 Result ;
			Result.u = In.u * Scale ;
			Result.v = In.v * Scale ;
			return Result ;
		}
		
		public static FLOAT4 F4Scale( FLOAT4 In, float Scale )
		{
			FLOAT4 Result ;
			Result.x = In.x * Scale ;
			Result.y = In.y * Scale ;
			Result.z = In.z * Scale ;
			Result.w = In.w * Scale ;
			return Result ;
		}
		
		public static DOUBLE4	D4Scale( DOUBLE4 In, double Scale )
		{
			DOUBLE4 Result ;
			Result.x = In.x * Scale ;
			Result.y = In.y * Scale ;
			Result.z = In.z * Scale ;
			Result.w = In.w * Scale ;
			return Result ;
		}
		
		public static float VSquareSize( VECTOR In )
		{
			return In.x * In.x + In.y * In.y + In.z * In.z ;
		}
		
		public static double VSquareSizeD( VECTOR_D In )
		{
			return In.x * In.x + In.y * In.y + In.z * In.z ;
		}
		
		public static VECTOR VTransform( VECTOR InV, MATRIX InM )
		{
			VECTOR Result ;
			Result.x = InV.x * InM.m00 + InV.y * InM.m10 + InV.z * InM.m20 + InM.m30 ;
			Result.y = InV.x * InM.m01 + InV.y * InM.m11 + InV.z * InM.m21 + InM.m31 ;
			Result.z = InV.x * InM.m02 + InV.y * InM.m12 + InV.z * InM.m22 + InM.m32 ;
			return Result ;
		}
		
		public static VECTOR_D VTransformD( VECTOR_D InV, MATRIX_D InM )
		{
			VECTOR_D Result ;
			Result.x = InV.x * InM.m00 + InV.y * InM.m10 + InV.z * InM.m20 + InM.m30 ;
			Result.y = InV.x * InM.m01 + InV.y * InM.m11 + InV.z * InM.m21 + InM.m31 ;
			Result.z = InV.x * InM.m02 + InV.y * InM.m12 + InV.z * InM.m22 + InM.m32 ;
			return Result ;
		}
		
		public static VECTOR VTransformSR( VECTOR InV, MATRIX InM )
		{
			VECTOR Result ;
			Result.x = InV.x * InM.m00 + InV.y * InM.m10 + InV.z * InM.m20 ;
			Result.y = InV.x * InM.m01 + InV.y * InM.m11 + InV.z * InM.m21 ;
			Result.z = InV.x * InM.m02 + InV.y * InM.m12 + InV.z * InM.m22 ;
			return Result ;
		}
		
		public static VECTOR_D VTransformSRD( VECTOR_D InV, MATRIX_D InM )
		{
			VECTOR_D Result ;
			Result.x = InV.x * InM.m00 + InV.y * InM.m10 + InV.z * InM.m20 ;
			Result.y = InV.x * InM.m01 + InV.y * InM.m11 + InV.z * InM.m21 ;
			Result.z = InV.x * InM.m02 + InV.y * InM.m12 + InV.z * InM.m22 ;
			return Result ;
		}
		
		public static FLOAT4 QTCross( FLOAT4 A, FLOAT4 B )
		{
			FLOAT4 Result ;
			Result.w = A.w * B.w - ( A.x * B.x + A.y * B.y + A.z * B.z ) ;
			Result.x = B.x * A.w + A.x * B.w + ( A.y * B.z - A.z * B.y ) ;
			Result.y = B.y * A.w + A.y * B.w + ( A.z * B.x - A.x * B.z ) ;
			Result.z = B.z * A.w + A.z * B.w + ( A.x * B.y - A.y * B.x ) ;
			return Result ;
		}
		public static DOUBLE4 QTCrossD( DOUBLE4 A, DOUBLE4 B )
		{
			DOUBLE4 Result ;
			Result.w = A.w * B.w - ( A.x * B.x + A.y * B.y + A.z * B.z ) ;
			Result.x = B.x * A.w + A.x * B.w + ( A.y * B.z - A.z * B.y ) ;
			Result.y = B.y * A.w + A.y * B.w + ( A.z * B.x - A.x * B.z ) ;
			Result.z = B.z * A.w + A.z * B.w + ( A.x * B.y - A.y * B.x ) ;
			return Result ;
		}
		public static FLOAT4 QTConj( FLOAT4 A )
		{
			FLOAT4 Result ;
			Result.w =  A.w ;
			Result.x = -A.x ;
			Result.y = -A.y ;
			Result.z = -A.z ;
			return Result ;
		}
		public static DOUBLE4 QTConjD( DOUBLE4 A )
		{
			DOUBLE4 Result ;
			Result.w =  A.w ;
			Result.x = -A.x ;
			Result.y = -A.y ;
			Result.z = -A.z ;
			return Result ;
		}
		
		
		[DllImport(DxLibDLLFileName, EntryPoint = "dx_MV1GetReferenceMesh")]
		extern static MV1_REF_POLYGONLIST_NT dx_MV1GetReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly);
		static MV1_REF_POLYGONLIST MV1GetReferenceMeshBase(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly)
		{
			MV1_REF_POLYGONLIST_NT Native;
			MV1_REF_POLYGONLIST Result;
			Native = dx_MV1GetReferenceMesh( MHandle, FrameIndex, IsTransform, IsPositionOnly );
			Result.PolygonNum  = Native.PolygonNum;
			Result.VertexNum   = Native.VertexNum;
			Result.MinPosition = Native.MinPosition;
			Result.MaxPosition = Native.MaxPosition;
			Result.Polygons    = null;
			Result.Vertexs     = null;
			if( Native.PolygonNum > 0 )
			{
				Result.Polygons = new MV1_REF_POLYGON[ Native.PolygonNum ];
				int MV1_REF_POLYGON_Size = Marshal.SizeOf( Result.Polygons[ 0 ] );
				long Addr = Native.Polygons.ToInt64();
				for( int i = 0; i < Native.PolygonNum; i++, Addr += MV1_REF_POLYGON_Size )
				{
					Result.Polygons[ i ] = ( MV1_REF_POLYGON )Marshal.PtrToStructure( ( System.IntPtr )Addr, typeof( MV1_REF_POLYGON ) );
				}
			}
			if( Native.VertexNum > 0 )
			{
				Result.Vertexs = new MV1_REF_VERTEX[ Native.VertexNum ];
				int MV1_REF_VERTEX_Size = Marshal.SizeOf( Result.Vertexs[ 0 ] );
				long Addr = Native.Vertexs.ToInt64();
				for( int i = 0; i < Native.VertexNum; i++, Addr += MV1_REF_VERTEX_Size )
				{
					Result.Vertexs[ i ] = ( MV1_REF_VERTEX )Marshal.PtrToStructure( ( System.IntPtr )Addr, typeof( MV1_REF_VERTEX ) );
				}
			}
			return Result;
		}
		public static MV1_REF_POLYGONLIST MV1GetReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly = FALSE) => MV1GetReferenceMeshBase( MHandle, FrameIndex, IsTransform, IsPositionOnly );
		
		
		#if DX_USE_UNSAFE
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate int SetActiveStateChangeCallBackFunctionCallback(int ActiveState, void* UserData);
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetActiveStateChangeCallBackFunction")]
		extern unsafe static int dx_SetActiveStateChangeCallBackFunction(SetActiveStateChangeCallBackFunctionCallback Callback, void* UserData);
		public unsafe static int SetActiveStateChangeCallBackFunction(SetActiveStateChangeCallBackFunctionCallback Callback, void* UserData) => dx_SetActiveStateChangeCallBackFunction(Callback, UserData);
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void SetUseASyncChangeWindowModeFunctionCallback( void *Data );
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseASyncChangeWindowModeFunction")]
		extern unsafe static int dx_SetUseASyncChangeWindowModeFunction( int Flag , SetUseASyncChangeWindowModeFunctionCallback CallBackFunction, void *Data );
		public unsafe static int SetUseASyncChangeWindowModeFunction( int Flag , SetUseASyncChangeWindowModeFunctionCallback CallBackFunction, void *Data ) => dx_SetUseASyncChangeWindowModeFunction( Flag , CallBackFunction, Data );
		
		#endif
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SetMenuItemSelectCallBackFunctionCallback( string ItemName, int ItemID );
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemSelectCallBackFunction")]
		extern static int dx_SetMenuItemSelectCallBackFunction( SetMenuItemSelectCallBackFunctionCallback CallBackFunction );
		public static int SetMenuItemSelectCallBackFunction( SetMenuItemSelectCallBackFunctionCallback CallBackFunction ) => dx_SetMenuItemSelectCallBackFunction( CallBackFunction );
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SetWindowMenuCallback( ushort ID );
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowMenu")]
		extern static int dx_SetWindowMenu( int MenuID, SetWindowMenuCallback MenuProc );
		public static int SetWindowMenu( int MenuID, SetWindowMenuCallback MenuProc ) => dx_SetWindowMenu( MenuID, MenuProc );
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SetRestoreShredPointCallback();
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetRestoreShredPoint")]
		extern static int dx_SetRestoreShredPoint( SetRestoreShredPointCallback ShredPoint );
		public static int SetRestoreShredPoint( SetRestoreShredPointCallback ShredPoint ) => dx_SetRestoreShredPoint( ShredPoint );
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SetRestoreGraphCallbackCallback();
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetRestoreGraphCallback")]
		extern static int dx_SetRestoreGraphCallback( SetRestoreGraphCallbackCallback Callback );
		public static int SetRestoreGraphCallback( SetRestoreGraphCallbackCallback Callback ) => dx_SetRestoreGraphCallback( Callback );
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearDrawScreen")]
		extern static int dx_ClearDrawScreen( out RECT  ClearRect);
		public static int  ClearDrawScreen( out RECT  ClearRect) => dx_ClearDrawScreen( out ClearRect );
		public static int  ClearDrawScreen()
		{
			RECT temp;
		
			temp.left = -1;
			temp.top = -1;
			temp.right = -1;
			temp.bottom = -1;
			return dx_ClearDrawScreen( out temp );
		}
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearDrawScreenZBuffer")]
		extern static int dx_ClearDrawScreenZBuffer( out RECT  ClearRect);
		public static int  ClearDrawScreenZBuffer( out RECT  ClearRect) => dx_ClearDrawScreenZBuffer( out ClearRect );
		
		public static int ClearDrawScreenZBuffer()
		{
			RECT temp;
		
			temp.left = -1;
			temp.top = -1;
			temp.right = -1;
			temp.bottom = -1;
		
			return dx_ClearDrawScreenZBuffer( out temp );
		}
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputStringColor")]
		extern static int dx_SetKeyInputStringColor( ulong  NmlStr, ulong  NmlCur, ulong  IMEStr, ulong  IMECur, ulong  IMELine, ulong  IMESelectStr, ulong  IMEModeStr, ulong  NmlStrE, ulong  IMESelectStrE, ulong  IMEModeStrE, ulong  IMESelectWinE, ulong  IMESelectWinF, ulong  SelectStrBackColor, ulong  SelectStrColor, ulong  SelectStrEdgeColor);
		public static int  SetKeyInputStringColor( ulong  NmlStr, ulong  NmlCur, ulong  IMEStr, ulong  IMECur, ulong  IMELine, ulong  IMESelectStr, ulong  IMEModeStr, ulong  NmlStrE = 0, ulong  IMESelectStrE = 0, ulong  IMEModeStrE = 0, ulong  IMESelectWinE = 0xffffffffffffffff, ulong  IMESelectWinF = 0xffffffffffffffff, ulong  SelectStrBackColor = 0xffffffffffffffff, ulong  SelectStrColor = 0xffffffffffffffff, ulong  SelectStrEdgeColor = 0xffffffffffffffff)
			=> dx_SetKeyInputStringColor( NmlStr , NmlCur , IMEStr , IMECur , IMELine , IMESelectStr , IMEModeStr , NmlStrE , IMESelectStrE , IMEModeStrE , IMESelectWinE , IMESelectWinF , SelectStrBackColor , SelectStrColor , SelectStrEdgeColor );
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Paint")]
		extern static int dx_Paint( int  x, int  y, uint  FillColor, ulong  BoundaryColor);
		public static int  Paint( int  x, int  y, uint  FillColor, ulong  BoundaryColor = 0xffffffffffffffffUL) => dx_Paint( x , y , FillColor , BoundaryColor );
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialTypeParamAllS")]
		extern static int dx_MV1SetMaterialTypeParamAllS( int MHandle, float Param0, float Param1, float Param2, float Param3, float Param4, float Param5);
		public static int  MV1SetMaterialTypeParamAll( int MHandle, float Param0 = 0.0f, float Param1 = 0.0f, float Param2 = 0.0f, float Param3 = 0.0f, float Param4 = 0.0f, float Param5 = 0.0f)
			=> dx_MV1SetMaterialTypeParamAllS( MHandle, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialTypeParamS")]
		extern static int dx_MV1SetMaterialTypeParamS( int MHandle, int MaterialIndex, float Param0, float Param1, float Param2, float Param3, float Param4, float Param5);
		public static int  MV1SetMaterialTypeParam( int MHandle, int MaterialIndex, float Param0 = 0.0f, float Param1 = 0.0f, float Param2 = 0.0f, float Param3 = 0.0f, float Param4 = 0.0f, float Param5 = 0.0f)
			=> dx_MV1SetMaterialTypeParamS( MHandle, MaterialIndex, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphFilterS")]
		extern static int dx_GraphFilterS( int GrHandle, int FilterType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  GraphFilter( int GrHandle, int FilterType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_GraphFilterS( GrHandle, FilterType, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphFilterBltS")]
		extern static int dx_GraphFilterBltS( int SrcGrHandle, int DestGrHandle, int FilterType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  GraphFilterBlt( int SrcGrHandle, int DestGrHandle, int FilterType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_GraphFilterBltS( SrcGrHandle, DestGrHandle, FilterType, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphFilterRectBltS")]
		extern static int dx_GraphFilterRectBltS( int SrcGrHandle, int DestGrHandle, int SrcX1, int SrcY1, int SrcX2, int SrcY2, int DestX, int DestY, int FilterType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  GraphFilterRectBlt( int SrcGrHandle, int DestGrHandle, int SrcX1, int SrcY1, int SrcX2, int SrcY2, int DestX, int DestY, int FilterType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_GraphFilterRectBltS( SrcGrHandle, DestGrHandle, SrcX1, SrcY1, SrcX2, SrcY2, DestX, DestY, FilterType, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphBlendS")]
		extern static int dx_GraphBlendS( int GrHandle, int BlendGrHandle, int BlendRatio, int BlendType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  GraphBlend( int GrHandle, int BlendGrHandle, int BlendRatio, int BlendType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_GraphBlendS( GrHandle, BlendGrHandle, BlendRatio, BlendType, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphBlendBltS")]
		extern static int dx_GraphBlendBltS( int SrcGrHandle, int BlendGrHandle, int DestGrHandle, int BlendRatio, int BlendType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  GraphBlendBlt( int SrcGrHandle, int BlendGrHandle, int DestGrHandle, int BlendRatio, int BlendType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_GraphBlendBltS( SrcGrHandle, BlendGrHandle, DestGrHandle, BlendRatio, BlendType, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphBlendRectBltS")]
		extern static int dx_GraphBlendRectBltS( int SrcGrHandle, int BlendGrHandle, int DestGrHandle, int SrcX1, int SrcY1, int SrcX2, int SrcY2, int BlendX, int BlendY, int DestX, int DestY, int BlendRatio, int BlendType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  GraphBlendRectBlt( int SrcGrHandle, int BlendGrHandle, int DestGrHandle, int SrcX1, int SrcY1, int SrcX2, int SrcY2, int BlendX, int BlendY, int DestX, int DestY, int BlendRatio, int BlendType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_GraphBlendRectBltS( SrcGrHandle, BlendGrHandle, DestGrHandle, SrcX1, SrcY1, SrcX2, SrcY2, BlendX, BlendY, DestX, DestY, BlendRatio, BlendType, Param0, Param1, Param2, Param3, Param4, Param5);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetBlendGraphParamS")]
		extern static int dx_SetBlendGraphParamS( int BlendGraph, int BlendType, int Param0, int Param1, int Param2, int Param3, int Param4, int Param5);
		public static int  SetBlendGraphParam( int BlendGraph, int BlendType, int Param0 = 0, int Param1 = 0, int Param2 = 0, int Param3 = 0, int Param4 = 0, int Param5 = 0)
			=> dx_SetBlendGraphParamS( BlendGraph, BlendType, Param0, Param1, Param2, Param3, Param4, Param5);
	}
}