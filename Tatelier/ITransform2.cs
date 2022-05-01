namespace Tatelier
{
	public interface ITransform2
	{
		ITransform2 Parent { get; }
		ITransform2 Older { get; }
		ITransform2 Younger { get; }

		float X1 { get; }
		float X2 { get; }

		float Y1 { get; }
		float Y2 { get; }
	}
}
