﻿namespace opendnp3
{

	public class Group51Var1
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool Read(rseq_t buffer, Group51Var1 output)
		{
		  return LittleEndian.read(buffer, output.time);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool Write(in Group51Var1 arg, ser4cpp.wseq_t buffer)
		{
		  return LittleEndian.write(buffer, arg.time);
		}
	}
}