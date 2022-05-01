using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class CSSTransform
	{
		public ITransform Parent => null;
		public IReadOnlyList<ITransform> Children => new ITransform[0];

		/// <summary>
		/// 前要素
		/// </summary>
		public ITransform Prev => null;

		public PositionType Position { get; set; } = PositionType.Fixed;
		public float Left { get; set; } = 0F;
		public float Top { get; set; } = 0F;

		public float X { get; set; }
		public float Y { get; set; }

		public float Width { get; set; } = 0F;
		public float Height { get; set; } = 0F;

		public float NextPivotX
		{
			get
			{
				switch (Position)
				{
					default:
						return Left;
				}
			}
		}

		public float NextPivotY
		{
			get
			{
				switch (Position)
				{
					case PositionType.Fixed:
					case PositionType.Absolute:
					default:
						return Prev.Transform.NextPivotY;
					case PositionType.Relative:
						return Prev.Transform.NextPivotY + Height;

				}
			}
		}

		public void Refresh()
		{

		}
		public void RefreshChildren()
		{
			foreach (var item in Children)
			{
				item.Transform.Refresh();
			}
		}
	}
}
