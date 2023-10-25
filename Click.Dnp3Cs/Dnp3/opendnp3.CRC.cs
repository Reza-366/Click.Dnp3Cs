using System;

namespace opendnp3
{

	public class CRC
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public UInt16 CalcCrc(in ser4cpp.rseq_t view)
		{
			return CalcCrc(view, view.length());
		}
	}
}
