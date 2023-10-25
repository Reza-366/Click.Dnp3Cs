namespace opendnp3
{

	public class MContext
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void OnParsedHeader(in ser4cpp.rseq_t UnnamedParameter, in APDUResponseHeader header, in ser4cpp.rseq_t objects)
		{
			// Note: this looks silly, but OnParsedHeader() is virtual and can be overriden to do SA
			this.ProcessAPDU(header, objects);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void ProcessAPDU(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
		{
			switch (header.function)
			{
			case (FunctionCode.UNSOLICITED_RESPONSE):
				this.ProcessUnsolicitedResponse(header, objects);
				break;
			case (FunctionCode.RESPONSE):
				this.ProcessResponse(header, objects);
				break;
			default:
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Ignoring unsupported function code: %s",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				break;
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void ProcessUnsolicitedResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
		{
			if (!header.control.UNS)
			{
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Ignoring unsolicited response without UNS bit set");
				};
				return;
			}
        
			var result = MeasurementHandler.ProcessMeasurements(header.as_response_info(), objects, logger, SOEHandler.get());
        
			if ((result == ParseResult.OK) && header.control.CON)
			{
				this.QueueConfirm(APDUHeader.UnsolicitedConfirm(header.control.SEQ));
			}
        
			this.ProcessIIN(header.IIN);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void ProcessResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
		{
			this.tstate = this.OnResponseEvent(header, objects);
			this.ProcessIIN(header.IIN); // TODO - should we process IIN bits for unexpected responses?
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void Transmit(in ser4cpp.rseq_t data)
		{
			logging.ParseAndLogRequestTx(this.logger, data);
			Debug.Assert(!this.isSending);
			this.isSending = true;
			this.lower.BeginTransmit(new Message(this.addresses, data));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public MContext.TaskState OnResponseEvent(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
		{
			switch (tstate)
			{
			case (TaskState.WAIT_FOR_RESPONSE):
				return OnResponse_WaitForResponse(header, objects);
			default:
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Not expecting a response, sequence: %u",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return tstate;
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public MContext.TaskState OnResponse_WaitForResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
		{
			if (header.control.SEQ != this.solSeq)
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Response with bad sequence: %u",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return TaskState.WAIT_FOR_RESPONSE;
			}
        
			this.responseTimer.cancel();
        
			this.solSeq.Increment();
        
			var now = new Timestamp();
        
			var result = this.activeTask.OnResponse(header, objects, now);
        
			if (header.control.CON)
			{
				this.QueueConfirm(APDUHeader.SolicitedConfirm(header.control.SEQ));
			}
        
			switch (result)
			{
			case (IMasterTask.ResponseResult.OK_CONTINUE):
				this.StartResponseTimer();
				return TaskState.WAIT_FOR_RESPONSE;
			case (IMasterTask.ResponseResult.OK_REPEAT):
				return StartTask_TaskReady();
			default:
				// task completed or failed, either way go back to idle
				this.CompleteActiveTask();
				return TaskState.IDLE;
			}
		}
	}
}
