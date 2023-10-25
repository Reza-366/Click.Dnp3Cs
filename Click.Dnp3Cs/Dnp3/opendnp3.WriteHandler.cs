namespace opendnp3
{

	public class WriteHandler
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public WriteHandler(IOutstationApplication application, TimeSyncState timeSyncState, SequenceNum<System.Byte, 16> seq, Timestamp now, IINField writeIIN)
		{
			this.application = new opendnp3.IOutstationApplication(application);
			this.timeSyncState = new opendnp3.TimeSyncState(timeSyncState);
			this.seq = new opendnp3.SequenceNum<System.Byte, 16>(seq);
			this.now = new opendnp3.Timestamp(now);
			this.writeIIN = new opendnp3.IINField(writeIIN);
		}
	}
}
