namespace opendnp3
{

	public class PollTaskBase
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader header, in RSeq<size_t> objects)
		{
			if (header.control.FIR)
			{
				if (this.rxCount > 0)
				{
					if (logger.is_enabled(opendnp3.flags.Globals.WARN))
					{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Ignoring unexpected FIR frame");
					};
					return ResponseResult.ERROR_BAD_RESPONSE;
				}
        
				return ProcessMeasurements(header, objects);
			}
			else
			{
				if (this.rxCount > 0)
				{
					return ProcessMeasurements(header, objects);
				}
        
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Ignoring unexpected non-FIR frame");
				};
				return ResponseResult.ERROR_BAD_RESPONSE;
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IMasterTask.ResponseResult ProcessMeasurements(in APDUResponseHeader header, in RSeq<size_t> objects)
		{
			++rxCount;
        
			if (MeasurementHandler.ProcessMeasurements(header.as_response_info(), objects, logger, handler.get()) == ParseResult.OK)
			{
				return header.control.FIN ? ResponseResult.OK_FINAL : ResponseResult.OK_CONTINUE;
			}
        
			return ResponseResult.ERROR_BAD_RESPONSE;
		}
	}
}
