namespace opendnp3
{

	public class DNP3Manager
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public DNP3Manager(uint concurrencyHint, ILogHandler handler, Action<uint> onThreadStart, Action<uint> onThreadExit)
		{
			this.impl = std::make_unique<DNP3ManagerImpl>(concurrencyHint, handler, onThreadStart, onThreadExit);
		}
	}
}
