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

// A one or two byte unsigned integer parser
public class NumParser
{
	// a function that consumes bytes from a buffer and returns a UInt16 count
	private delegate UInt16 ReadFun(RSeq<size_t> buffer);

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: System.Byte NumBytes() const
	public System.Byte NumBytes()
	{
		return new System.Byte(size);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ParseResult ParseCount(RSeq<size_t>& buffer, UInt16& count, Logger* pLogger) const
	public ParseResult ParseCount(RSeq<size_t> buffer, UInt16 count, Logger pLogger)
	{
		if (this.Read(ref count, buffer))
		{
			if (count == 0)
			{
				if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
				{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "count of 0");
				};
				return ParseResult.COUNT_OF_ZERO;
			}

			return ParseResult.OK;
		}
		else
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Not enough data for count");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_RANGE;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ParseResult ParseRange(RSeq<size_t>& buffer, Range& range, Logger* pLogger) const
	public ParseResult ParseRange(RSeq<size_t> buffer, Range range, Logger pLogger)
	{
		if (buffer.length() < (2 * (size_t)size))
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Not enough data for start / stop");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_RANGE;
		}

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: range.start = this->ReadNum(buffer);
		range.start.CopyFrom(this.ReadNum(buffer));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: range.stop = this->ReadNum(buffer);
		range.stop.CopyFrom(this.ReadNum(buffer));

		if (range.IsValid())
		{
			return ParseResult.OK;
		}

		if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "start (%u) > stop (%u)",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
		};
		return ParseResult.BAD_START_STOP;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: UInt16 ReadNum(RSeq<size_t>& buffer) const
	public UInt16 ReadNum(RSeq<size_t> buffer)
	{
		return pReadFun(buffer);
	}

	public static NumParser OneByte()
	{
		return new NumParser(ReadOneByte, 1);
	}

	public static NumParser TwoByte()
	{
		return new NumParser(ReadTwoBytes, 2);
	}

	// read the number, consuming from the buffer
	// return true if there is enough bytes, false otherwise
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Read(UInt16& num, RSeq<size_t>& buffer) const
	private bool Read(ref UInt16 num, RSeq<size_t> buffer)
	{
		if (buffer.length() < size)
		{
			return false;
		}

		num = pReadFun(buffer);
		return true;
	}

	private static UInt16 ReadOneByte(RSeq<size_t> buffer)
	{
		System.Byte result = 0;
		ser4cpp.UInt8.read_from(buffer, ref result);
		return new System.Byte(result);
	}

	private static UInt16 ReadTwoBytes(RSeq<size_t> buffer)
	{
		UInt16 result = 0;
		ser4cpp.Globals.Bit16<UInt16, 0, 1>.read_from(buffer, result);
		return new UInt16(result);
	}

	private NumParser(ReadFun pReadFun, System.Byte size)
	{
		this.pReadFun = pReadFun;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.size = size;
		this.size.CopyFrom(size);
	}

	private ReadFun pReadFun;
	private System.Byte size = new System.Byte();

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	NumParser() = delete;
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

