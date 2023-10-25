namespace opendnp3
{

	public class CommandSet
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ICommandCollection<AnalogOutputInt16> StartHeader()
		{
			return this.StartHeaderAOInt16();
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ICommandCollection<AnalogOutputInt32> StartHeader()
		{
			return this.StartHeaderAOInt32();
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ICommandCollection<AnalogOutputFloat32> StartHeader()
		{
			return this.StartHeaderAOFloat32();
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ICommandCollection<AnalogOutputDouble64> StartHeader()
		{
			return this.StartHeaderAODouble64();
		}
	}
}
