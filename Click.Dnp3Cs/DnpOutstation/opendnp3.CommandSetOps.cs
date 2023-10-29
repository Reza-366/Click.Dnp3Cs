namespace opendnp3
{

	public class CommandSetOps
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public CommandSetOps.SelectResult ProcessSelectResponse(CommandSet set, in ser4cpp.RSeq headers, Logger logger)
		{
			CommandSetOps handler = new CommandSetOps(Mode.Select, set);
			var result = APDUParser.Parse(headers, handler, logger);
			if (result != ParseResult.OK)
			{
				return SelectResult.FAIL_PARSE;
			}
        
		//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
			var selected = (ICommandHeader header) =>
			{
				return header.AreAllSelected();
			};
			return std::all_of(set.m_headers.begin(), set.m_headers.end(), selected) ? SelectResult.OK : SelectResult.FAIL_SELECT;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public CommandSetOps.OperateResult ProcessOperateResponse(CommandSet set, in ser4cpp.RSeq headers, Logger logger)
		{
			CommandSetOps handler = new CommandSetOps(Mode.Operate, set);
			return (APDUParser.Parse(headers, handler, logger) == ParseResult.OK) ? OperateResult.OK : OperateResult.FAIL_PARSE;
		}
	}
}
