namespace opendnp3
{

	public class MeasurementHandler
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ParseResult ProcessMeasurements(ResponseInfo info, in RSeq</*size_t*/int> objects, Logger logger, ISOEHandler pHandler)
		{
			MeasurementHandler handler = new MeasurementHandler(info, logger, pHandler);
			return APDUParser.Parse(objects, handler, logger);
		}
	}
}
