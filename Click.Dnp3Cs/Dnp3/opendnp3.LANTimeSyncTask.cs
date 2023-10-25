namespace opendnp3
{

	public class LANTimeSyncTask
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader response, in RSeq<size_t> objects)
		{
			return (state == State.RECORD_CURRENT_TIME) ? OnResponseRecordCurrentTime(response, objects) : OnResponseWriteTime(response, objects);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IMasterTask.ResponseResult OnResponseRecordCurrentTime(in APDUResponseHeader response, in RSeq<size_t> objects)
		{
			if (!ValidateNullResponse(response, objects))
			{
				return ResponseResult.ERROR_BAD_RESPONSE;
			}
        
			this.state = State.WRITE_TIME;
        
			return ResponseResult.OK_REPEAT;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IMasterTask.ResponseResult OnResponseWriteTime(in APDUResponseHeader header, in RSeq<size_t> objects)
		{
			return ValidateNullResponse(header, objects) ? ResponseResult.OK_FINAL : ResponseResult.ERROR_BAD_RESPONSE;
		}
	}
}
