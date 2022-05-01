using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common.Except
{
	/// <summary>
	/// 譜面空例外
	/// </summary>
	[System.Serializable]
	public class ScoreEmptyException : Exception
	{
		public ScoreEmptyException() : base()
		{ }
		public ScoreEmptyException(string scoreFolder) : base($"\"{scoreFolder}\" フォルダに譜面がありません。") { }
		public ScoreEmptyException(string message, Exception inner) : base(message, inner) { }
		protected ScoreEmptyException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
