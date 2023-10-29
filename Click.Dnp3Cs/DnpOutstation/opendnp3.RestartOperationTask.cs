namespace opendnp3
{

	public class RestartOperationTask
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader header, in ser4cpp.RSeq objects)
		{
			if (!(ValidateSingleResponse(header) && ValidateInternalIndications(header)))
			{
				return ResponseResult.ERROR_BAD_RESPONSE;
			}
        
			if (objects.is_empty())
			{
				return ResponseResult.ERROR_BAD_RESPONSE;
			}
        
			var result = APDUParser.Parse(objects, this, logger);
        
			return (result == ParseResult.OK) ? ResponseResult.OK_FINAL : ResponseResult.ERROR_BAD_RESPONSE;
		}
	}
}
