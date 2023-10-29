namespace opendnp3
{

	public class APDUHeaderParser
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public APDUHeaderParser.Result<APDUHeader> ParseRequest(in ser4cpp.RSeq apdu, Logger logger)
		{
			if (apdu.length() < APDUHeader.REQUEST_SIZE)
			{
				if (logger != null && logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Request fragment  with insufficient size of %zu bytes",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return Result<APDUHeader>.Error();
			}
        
			return Result<APDUHeader>.Ok(new APDUHeader(new AppControlField(apdu[0]), FunctionCodeSpec.from_type(apdu[1])), apdu.skip(APDUHeader.REQUEST_SIZE));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public APDUHeaderParser.Result<APDUResponseHeader> ParseResponse(in ser4cpp.RSeq apdu, Logger logger)
		{
			if (apdu.length() < APDUHeader.RESPONSE_SIZE)
			{
				if (logger != null && logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Response fragment  with insufficient size of %zu bytes",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return Result<APDUResponseHeader>.Error();
			}
        
			return Result<APDUResponseHeader>.Ok(new APDUResponseHeader(new AppControlField(apdu[0]), FunctionCodeSpec.from_type(apdu[1]), new IINField(apdu[2], apdu[3])), apdu.skip(APDUHeader.RESPONSE_SIZE));
		}
	}
}
