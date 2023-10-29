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

public class CountParser
{
	private delegate void HandleFun(in HeaderRecord record, ushort count, in ser4cpp.RSeq buffer, IAPDUHandler handler);

	public static ParseResult ParseHeader(ser4cpp.RSeq buffer, in NumParser numParser, in ParserSettings settings, in HeaderRecord record, Logger pLogger, IAPDUHandler pHandler)
	{
		ushort count = new ushort();
		var result = numParser.ParseCount(buffer, count, pLogger);
		if (result == ParseResult.OK)
		{
			if (pLogger != null && pLogger.is_enabled(settings.LoggingLevel()))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "%03u,%03u %s, %s [%u]",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(settings.LoggingLevel(), "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};

			if (settings.ExpectsContents())
			{
				return ParseCountOfObjects(buffer, record, new ushort(count), pLogger, pHandler);
			}

			if (pHandler != null)
			{
				pHandler.OnHeader(new CountHeader(record, count));
			}

			return ParseResult.OK;
		}
		else
		{
			return result;
		}
	}

	// Process the count handler against the buffer
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ParseResult Process(const HeaderRecord& record, ser4cpp::RSeq& buffer, IAPDUHandler* pHandler, Logger* pLogger) const
	private ParseResult Process(in HeaderRecord record, ser4cpp.RSeq buffer, IAPDUHandler pHandler, Logger pLogger)
	{
		if (buffer.length() < required_size)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Not enough data for specified objects");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_OBJECTS;
		}

		if (pHandler != null)
		{
			handler(record, count, buffer, pHandler);
		}
		buffer.advance(required_size);
		return ParseResult.OK;
	}

	// Create a count handler from a fixed size descriptor
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Descriptor>
	private static CountParser From<Descriptor>(ushort count)
	{
		var size = (/*size_t*/int)count * Descriptor.Size();
		return new CountParser(count, size, InvokeCountOf<Descriptor>);
	}

	private static ParseResult ParseCountOfObjects(ser4cpp.RSeq buffer, in HeaderRecord record, ushort count, Logger pLogger, IAPDUHandler pHandler)
	{
		switch (record.enumeration)
		{
		case (GroupVariation.Group50Var1):
			return CountParser.From<Group50Var1>(count).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group50Var3):
			return CountParser.From<Group50Var3>(count).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group51Var1):
			return CountParser.From<Group51Var1>(count).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group51Var2):
			return CountParser.From<Group51Var2>(count).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group52Var1):
			return CountParser.From<Group52Var1>(count).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group52Var2):
			return CountParser.From<Group52Var2>(count).Process(record, buffer, pHandler, pLogger);

		default:
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unsupported qualifier/object - %s - %i / %i",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};

			return ParseResult.INVALID_OBJECT_QUALIFIER;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Descriptor>
	private static void InvokeCountOf<Descriptor>(in HeaderRecord record, ushort count, in ser4cpp.RSeq buffer, IAPDUHandler handler)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var read = (ser4cpp.RSeq buffer, uint UnnamedParameter) =>
		{
			T value = new T();
			T.Read(buffer, value);
			return new T(value);
		};

		var collection = opendnp3.Globals.CreateBufferedCollection<T>(buffer, new ushort(count), read);
		handler.OnHeader(new CountHeader(record, count), collection);
	}

	private CountParser(ushort count, /*size_t*/int required_size, HandleFun handler)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count;
		this.count.CopyFrom(count);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.required_size = required_size;
		this.required_size.CopyFrom(required_size);
		this.handler = handler;
	}

	private ushort count = new ushort();
	private /*size_t*/int required_size = new /*size_t*/int();
	private HandleFun handler;

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	CountParser() = delete;
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

