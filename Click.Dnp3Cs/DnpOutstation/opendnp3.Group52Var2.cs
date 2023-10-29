namespace opendnp3
{

	public class Group52Var2
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool Read(RSeq buffer, Group52Var2 output)
		{
		  return LittleEndian.read(buffer, output.time);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool Write(in Group52Var2 arg, ser4cpp.wseq_t buffer)
		{
		  return LittleEndian.write(buffer, arg.time);
		}
	}
}
