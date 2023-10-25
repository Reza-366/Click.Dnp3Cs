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

// Synchronizes the time on the outstation
public class SerialTimeSyncTask : IMasterTask
{

	public SerialTimeSyncTask(TaskContext context, IMasterApplication app, in Logger logger) : base(context, app, TaskBehavior.ReactsToIINOnly(), logger, TaskConfig.Default())
	{
		this.delay = -1;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const override final
	public override sealed string Name()
	{
		return "serial time sync";
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const override final
	public override sealed int Priority()
	{
		return opendnp3.priority.Globals.TIME_SYNC;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const override final
	public override sealed bool BlocksLowerPriority()
	{
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const override final
	public override sealed bool IsRecurring()
	{
		return true;
	}

	public override bool BuildRequest(APDURequest request, byte seq)
	{
		if (delay < 0)
		{
			start = this.application.Now();
			build.MeasureDelay(request, seq);
		}
		else
		{
			var now = this.application.Now();
			Group50Var1 time = new Group50Var1();
			time.time = new DNPTime(now.msSinceEpoch + delay);
			request.SetFunction(FunctionCode.WRITE);
			request.SetControl(AppControlField.Request(new byte(seq)));
			var writer = request.GetWriter();
			writer.WriteSingleValue<ser4cpp.UInt8, Group50Var1>(QualifierCode.UINT8_CNT, time);
		}

		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const override final
	private override sealed MasterTaskType GetTaskType()
	{
		return MasterTaskType.NON_LAN_TIME_SYNC;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const override final
	private override sealed bool IsEnabled()
	{
		return true;
	}

	private override IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader response, in ser4cpp.rseq_t objects)
	{
		return (delay < 0) ? OnResponseDelayMeas(response, objects) : OnResponseWriteTime(response, objects);
	}

	private IMasterTask.ResponseResult OnResponseDelayMeas(in APDUResponseHeader response, in ser4cpp.rseq_t objects)
	{
		if (ValidateSingleResponse(response))
		{
			TimeSyncHandler handler = new TimeSyncHandler();
			var result = APDUParser.Parse(objects, handler, logger);
			if (result == ParseResult.OK)
			{
				ushort rtuTurnAroundTime = new ushort();
				if (handler.GetTimeDelay(ref rtuTurnAroundTime))
				{
					var now = this.application.Now();
					var sendReceiveTime = now.msSinceEpoch - start.msSinceEpoch;

					// The later shouldn't happen, but could cause a negative delay which would result in a weird time
					// setting
					delay = (sendReceiveTime >= rtuTurnAroundTime) ? (sendReceiveTime - rtuTurnAroundTime) / 2 : 0;

					return ResponseResult.OK_REPEAT;
				}

				return ResponseResult.ERROR_BAD_RESPONSE;
			}
			else
			{
				return ResponseResult.ERROR_BAD_RESPONSE;
			}
		}
		else
		{
			return ResponseResult.ERROR_BAD_RESPONSE;
		}
	}

	private IMasterTask.ResponseResult OnResponseWriteTime(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
	{
		return ValidateNullResponse(header, objects) ? ResponseResult.OK_FINAL : ResponseResult.ERROR_BAD_RESPONSE;
	}

	private override void Initialize()
	{
		delay = -1;
	}

	// < 0 implies the delay measure hasn't happened yet
	private long delay = new long();

	// what time we sent the delay meas
	private UTCTimestamp start = new UTCTimestamp();
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

