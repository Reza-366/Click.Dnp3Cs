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

namespace opendnp3
{

/**
 * Dedicated class for processing response data in the master.
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class TimeSyncHandler : public IAPDUHandler, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public class TimeSyncHandler : IAPDUHandler, Uncopyable
{

	public TimeSyncHandler()
	{
		this.m_valid = false;
		this.m_time = 0;
	}

	public bool GetTimeDelay(ref UInt16 time)
	{
		if (this.Errors().Any())
		{
			return false;
		}
		else
		{
			if (m_valid)
			{
				time = m_time;
			}
			return m_valid;
		}
	}

	public override sealed bool IsAllowed(System.UInt32 headerCount, GroupVariation gv, QualifierCode qc)
	{
		return (headerCount == 0) && (gv == GroupVariation.Group52Var2);
	}

	private override sealed IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var2> times)
	{
		Group52Var2 value = new Group52Var2();
		if (times.ReadOnlyValue(ref value))
		{
			m_valid = true;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: m_time = value.time;
			m_time.CopyFrom(value.time);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		}
		else
		{
			return IINBit.PARAM_ERROR;
		}
	}

	private bool m_valid;
	private UInt16 m_time = new UInt16();
}

} // namespace opendnp3

