namespace opendnp3
{

	public class LinkSession
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void BeginTransmit(in ser4cpp.rseq_t buffer, ILinkSession UnnamedParameter)
		{
			this.channel.BeginWrite(buffer);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool OnFrame(in LinkHeaderFields header, in ser4cpp.rseq_t userdata)
		{
			if (this.stack)
			{
				this.stack.OnFrame(header, userdata);
			}
			else
			{
				this.first_frame_timer.cancel();
        
				this.callbacks.OnFirstFrame(this.session_id, header, this);
        
				if (this.stack)
				{
					this.stack.OnLowerLayerUp();
        
					// push the frame into the newly created stack
					this.stack.OnFrame(header, userdata);
				}
				else
				{
					if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
					{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "No master created. Closing socket.");
					};
					this.ShutdownImpl();
				}
			}
        
			return true;
		}
	}
}
