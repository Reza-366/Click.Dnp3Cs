namespace opendnp3
{

	public class DNP3Manager
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public DNP3Manager(System.UInt32 concurrencyHint, ILogHandler handler, Action<System.UInt32> onThreadStart, Action<System.UInt32> onThreadExit)
		{
			this.impl = std::make_unique<DNP3ManagerImpl>(concurrencyHint, handler, onThreadStart, onThreadExit);
		}
	}
}
