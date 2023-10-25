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

public sealed class WriteHandler : IAPDUHandler
{
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	WriteHandler(IOutstationApplication application, TimeSyncState timeSyncState, AppSeqNum seq, Timestamp now, IINField pWriteIIN);

	public override bool IsAllowed(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		return true;
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<IINValue>> values)
	{
		Indexed<IINValue> pair = new Indexed<IINValue>();

		if (!values.ReadOnlyValue(ref pair))
		{
			return IINBit.PARAM_ERROR;
		}

		if (wroteIIN)
		{
			return IINBit.PARAM_ERROR;
		}

		if (pair.index != (ushort)IINBit.DEVICE_RESTART)
		{
			return IINBit.PARAM_ERROR;
		}

		if (pair.value.value)
		{
			return IINBit.PARAM_ERROR;
		}

		wroteIIN = true;
		writeIIN.ClearBit(IINBit.DEVICE_RESTART);
		return new IINField();
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group50Var1> values)
	{
		if (this.wroteTime)
		{
			return IINBit.PARAM_ERROR;
		}

		if (!application.SupportsWriteAbsoluteTime())
		{
			return IINBit.FUNC_NOT_SUPPORTED;
		}

		Group50Var1 value = new Group50Var1();
		if (!values.ReadOnlyValue(ref value))
		{
			return IINBit.PARAM_ERROR;
		}

		this.wroteTime = true;
		return application.WriteAbsoluteTime(new UTCTimestamp(value.time.value)) ? IINField.Empty() : IINBit.PARAM_ERROR;
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group50Var3> values)
	{
		if (this.wroteTime)
		{
			return IINBit.PARAM_ERROR;
		}

		if (!application.SupportsWriteAbsoluteTime())
		{
			return IINBit.FUNC_NOT_SUPPORTED;
		}

		Group50Var3 value = new Group50Var3();
		if (!values.ReadOnlyValue(ref value))
		{
			return IINBit.PARAM_ERROR;
		}

		if (!this.timeSyncState.CalcTimeDifference(this.seq, this.now))
		{
			return IINBit.PARAM_ERROR;
		}

		UTCTimestamp time = new UTCTimestamp(value.time.value + std::chrono.duration_cast<std::chrono.milliseconds>(this.timeSyncState.GetDifference().value).count());

		this.wroteTime = true;
		return application.WriteAbsoluteTime(time) ? IINField.Empty() : IINBit.PARAM_ERROR;
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
		if (!application.SupportsWriteTimeAndInterval())
		{
			return IINBit.FUNC_NOT_SUPPORTED;
		}

		return application.WriteTimeAndInterval(values) ? IINField.Empty() : IINBit.PARAM_ERROR;
	}

	private IOutstationApplication application;
	private TimeSyncState timeSyncState;
	private AppSeqNum seq = new AppSeqNum();
	private Timestamp now = new Timestamp();
	private IINField writeIIN;

	private bool wroteTime = false;
	private bool wroteIIN = false;
}

} // namespace opendnp3




namespace opendnp3
{


} // namespace opendnp3
