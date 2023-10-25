namespace opendnp3
{

	public class CRC
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ushort CalcCrc(in ser4cpp.rseq_t view)
		{
			return CalcCrc(view, view.length());
		}
	}
}
