using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Copyright 2013-2022 Step Function I/O, LLC
 *
 * Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
 * LLC (https://stepfunc.io) under one or more contributor license agreements.
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
 * this file to you under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may obtain
 * a copy of the License at:
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
/*
 * Copyright 2013-2022 Step Function I/O, LLC
 *
 * Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
 * LLC (https://stepfunc.io) under one or more contributor license agreements.
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
 * this file to you under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may obtain
 * a copy of the License at:
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class APDUParser : private StaticOnly
public class APDUParser : StaticOnly
{
	public static ParseResult Parse(in ser4cpp.RSeq buffer, IAPDUHandler handler, Logger logger, ParserSettings settings = ParserSettings.Default())
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Parse(buffer, handler, &logger, settings);
		return Parse(buffer, handler, logger, new opendnp3.ParserSettings(settings));
	}

	public static ParseResult Parse(in ser4cpp.RSeq buffer, IAPDUHandler handler, Logger pLogger, ParserSettings settings = ParserSettings.Default())
	{
		// do two state parsing process with logging and white-listing first but no handling on the first pass
		var result = ParseSinglePass(buffer, pLogger, null, handler, settings);
		// if the first pass was successful, do a 2nd pass with the handler but no logging or white-list
		return (result == ParseResult.OK) ? ParseSinglePass(buffer, null, handler, null, settings) : result;
	}

	public static ParseResult ParseAndLogAll(in ser4cpp.RSeq buffer, Logger pLogger, ParserSettings settings = ParserSettings.Default())
	{
		return ParseSinglePass(buffer, pLogger, null, null, settings);
	}

	public static ParseResult ParseSinglePass(in ser4cpp.RSeq buffer, Logger pLogger, IAPDUHandler pHandler, IWhiteList pWhiteList, in ParserSettings settings)
	{
		uint count = 0;
		ser4cpp.RSeq copy = new ser4cpp.RSeq(buffer);
		while (copy.length() > 0)
		{
			var result = ParseHeader(copy, pLogger, new uint(count), settings, pHandler, pWhiteList);
			++count;
			if (result != ParseResult.OK)
			{
				return result;
			}
		}
		return ParseResult.OK;
	}

	private static bool AllowAll(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		return true;
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static ParseResult ParseHeaders(in ser4cpp::RSeq buffer, Logger pLogger, in ParserSettings settings, IAPDUHandler pHandler);

	private static ParseResult ParseHeader(ser4cpp.RSeq buffer, Logger pLogger, uint count, in ParserSettings settings, IAPDUHandler pHandler, IWhiteList pWhiteList)
	{
		ObjectHeader header = new ObjectHeader();
		var result = ObjectHeaderParser.ParseObjectHeader(header, buffer, pLogger);
		if (result != ParseResult.OK)
		{
			return result;
		}

		var GV = GroupVariationRecord.GetRecord(new byte(header.group), new byte(header.variation));

		if (GV.enumeration == GroupVariation.UNKNOWN)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unknown object %i / %i",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return ParseResult.UNKNOWN_OBJECT;
		}

		// if a white-list is defined and it doesn't validate, exit early
		if (pWhiteList != null && !pWhiteList.IsAllowed(new uint(count), GV.enumeration, QualifierCodeSpec.from_type(new byte(header.qualifier))))
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Header (%i) w/ Object (%i,%i) and qualifier (%i) failed whitelist",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};

			return ParseResult.NOT_ON_WHITELIST;
		}

		return APDUParser.ParseQualifier(buffer, pLogger, new HeaderRecord(GV, header.qualifier, count), settings, pHandler);
	}

	private static ParseResult ParseQualifier(ser4cpp.RSeq buffer, Logger pLogger, in HeaderRecord record, in ParserSettings settings, IAPDUHandler pHandler)
	{
		switch (record.GetQualifierCode())
		{
		case (QualifierCode.ALL_OBJECTS):
			return HandleAllObjectsHeader(pLogger, record, settings, pHandler);

		case (QualifierCode.UINT8_CNT):
			return CountParser.ParseHeader(buffer, NumParser.OneByte(), settings, record, pLogger, pHandler);

		case (QualifierCode.UINT16_CNT):
			return CountParser.ParseHeader(buffer, NumParser.TwoByte(), settings, record, pLogger, pHandler);

		case (QualifierCode.UINT8_START_STOP):
			return RangeParser.ParseHeader(buffer, NumParser.OneByte(), settings, record, pLogger, pHandler);

		case (QualifierCode.UINT16_START_STOP):
			return RangeParser.ParseHeader(buffer, NumParser.TwoByte(), settings, record, pLogger, pHandler);

		case (QualifierCode.UINT8_CNT_UINT8_INDEX):
			return CountIndexParser.ParseHeader(buffer, NumParser.OneByte(), settings, record, pLogger, pHandler);

		case (QualifierCode.UINT16_CNT_UINT16_INDEX):
			return CountIndexParser.ParseHeader(buffer, NumParser.TwoByte(), settings, record, pLogger, pHandler);

		default:
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unknown qualifier %x",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return ParseResult.UNKNOWN_QUALIFIER;
		}
	}

	private static ParseResult HandleAllObjectsHeader(Logger pLogger, in HeaderRecord record, in ParserSettings settings, IAPDUHandler pHandler)
	{
		if (pLogger != null && pLogger.is_enabled(settings.LoggingLevel()))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "%03u,%03u - %s - %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			pLogger.log(settings.LoggingLevel(), "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};

		if (pHandler != null)
		{
			pHandler.OnHeader(new AllObjectsHeader(record));
		}

		return ParseResult.OK;
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static ParseResult ParseCountOfIndices(ser4cpp::RSeq buffer, in HeaderRecord record, in NumParser numparser, ushort count, Logger pLogger, IAPDUHandler pHandler);
}

} // namespace opendnp3


//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define STRINGIFY(x) #x
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define TOSTRING(x) STRINGIFY(x)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOCATION __FILE__ "(" TOSTRING(__LINE__) ")"
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, length_, format, ...) _snprintf_s(dest, length_, _TRUNCATE, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, size, format, ...) snprintf(dest, size, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOG_FORMAT(logger, levels, format, ...) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOG_BLOCK(logger, levels, message) if (logger.is_enabled(levels)) { logger.log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOGGER_BLOCK(pLogger, levels, message) if (pLogger && pLogger->is_enabled(levels)) { pLogger->log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOG_BLOCK(logger, levels, format, ...) if (logger.is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOGGER_BLOCK(pLogger, levels, format, ...) if (pLogger && pLogger->is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); pLogger->log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_HEX_BLOCK(logger, levels, buffer, firstSize, otherSize) if (logger.is_enabled(levels)) { opendnp3::HexLogging::log(logger, levels, buffer, ' ', firstSize, otherSize); }

