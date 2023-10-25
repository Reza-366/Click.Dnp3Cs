namespace opendnp3
{

	public class EventLists
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<DoubleBitBinarySpec>> GetList()
		{
			return this.doubleBinary;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<CounterSpec>> GetList()
		{
			return this.counter;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<FrozenCounterSpec>> GetList()
		{
			return this.frozenCounter;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<AnalogSpec>> GetList()
		{
			return this.analog;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<BinaryOutputStatusSpec>> GetList()
		{
			return this.binaryOutputStatus;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<AnalogOutputStatusSpec>> GetList()
		{
			return this.analogOutputStatus;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public List<TypedEventRecord<OctetStringSpec>> GetList()
		{
			return this.octetString;
		}
	}
}
