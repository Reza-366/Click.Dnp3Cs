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

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class OContext;

/**
 * Base class for the outstation states
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class OutstationState : private Uncopyable
public abstract class OutstationState : Uncopyable
{
	public virtual bool IsIdle()
	{
		return false;
	}

	public abstract string Name();

	public abstract OutstationState OnConfirm(OContext UnnamedParameter, in ParsedRequest request);

	public abstract OutstationState OnConfirmTimeout(OContext UnnamedParameter);

	public abstract OutstationState OnNewReadRequest(OContext UnnamedParameter, in ParsedRequest request);

	public abstract OutstationState OnNewNonReadRequest(OContext UnnamedParameter, in ParsedRequest request);

	public abstract OutstationState OnRepeatNonReadRequest(OContext UnnamedParameter, in ParsedRequest request);

	public abstract OutstationState OnRepeatReadRequest(OContext UnnamedParameter, in ParsedRequest request);

	public abstract OutstationState OnBroadcastMessage(OContext UnnamedParameter, in ParsedRequest request);
}

public sealed class StateIdle : OutstationState
{

	public new sealed bool IsIdle()
	{
		return true;
	}

	public override sealed string Name()
	{
		return "Idle";
	}

	public static OutstationState Inst()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.StateIdle(instance);
	}

	public override OutstationState OnConfirm(OContext ctx, in ParsedRequest request)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "unexpected confirm while IDLE with sequence: %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};
		return StateIdle.Inst();
	}

	public override OutstationState OnConfirmTimeout(OContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "unexpected confirm timeout");
		};
		return StateIdle.Inst();
	}

	public override OutstationState OnNewReadRequest(OContext ctx, in ParsedRequest request)
	{
		return ctx.RespondToReadRequest(request);
	}

	public override OutstationState OnNewNonReadRequest(OContext ctx, in ParsedRequest request)
	{
		return ctx.RespondToNonReadRequest(request);
	}

	public override OutstationState OnRepeatNonReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.BeginRetransmitLastResponse(request.addresses.source);
		return this;
	}

	public override OutstationState OnRepeatReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.BeginRetransmitLastResponse(request.addresses.source);
		return this;
	}

	public override OutstationState OnBroadcastMessage(OContext ctx, in ParsedRequest request)
	{
		ctx.ProcessBroadcastRequest(request);
		return this;
	}

	private static StateIdle instance = new StateIdle();

	private StateIdle()
	{
	}
}

/*
 * waiting for a confirm to a solicited read response
 */
public sealed class StateSolicitedConfirmWait : OutstationState
{

	public static OutstationState Inst()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.StateSolicitedConfirmWait(instance);
	}

	public override sealed string Name()
	{
		return "SolicitedConfirmWait";
	}

	public override OutstationState OnConfirm(OContext ctx, in ParsedRequest request)
	{
		if (request.header.control.UNS)
		{
			if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "received unsolicited confirm while waiting for solicited confirm (seq: %u)",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return this;
		}

		if (!ctx.sol.seq.confirmNum.Equals(request.header.control.SEQ))
		{
			if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "solicited confirm with wrong seq: %u, expected: %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return this;
		}

		ctx.history.Reset(); // any time we get a confirm we can treat any request as a new request
		//ctx.confirmTimer.cancel(); //REZA
		ctx.eventBuffer.ClearWritten();
		ctx.lastBroadcastMessageReceived.clear();

		// information the application about the confirm
		ctx.application.OnConfirmProcessed(false, ctx.eventBuffer.NumEvents(EventClass.EC1), ctx.eventBuffer.NumEvents(EventClass.EC2), ctx.eventBuffer.NumEvents(EventClass.EC3));

		if (ctx.rspContext.HasSelection())
		{
			return ctx.ContinueMultiFragResponse(request.addresses, AppSeqNum(request.header.control.SEQ).Next());
		}

		return StateIdle.Inst();
	}

	public override OutstationState OnConfirmTimeout(OContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "solicited confirm timeout");
		};
		return StateIdle.Inst();
	}

	public override OutstationState OnNewReadRequest(OContext ctx, in ParsedRequest request)
	{
		//ctx.confirmTimer.cancel();
		return ctx.RespondToReadRequest(request);
	}

	public override OutstationState OnNewNonReadRequest(OContext ctx, in ParsedRequest request)
	{
		//ctx.confirmTimer.cancel();
		return ctx.RespondToNonReadRequest(request);
	}

	public override OutstationState OnRepeatNonReadRequest(OContext ctx, in ParsedRequest request)
	{
		//ctx.confirmTimer.cancel();
		ctx.BeginRetransmitLastResponse(request.addresses.source);
		return this;
	}

	public override OutstationState OnRepeatReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.RestartSolConfirmTimer();
		ctx.BeginRetransmitLastResponse(request.addresses.source);
		return this;
	}

	public override OutstationState OnBroadcastMessage(OContext ctx, in ParsedRequest request)
	{
		ctx.ProcessBroadcastRequest(request);
		return StateIdle.Inst();
	}

	private static StateSolicitedConfirmWait instance = new StateSolicitedConfirmWait();

	private StateSolicitedConfirmWait()
	{
	}
}

/*
 * waiting for a confirm to an unsolicited read response
 */
public class StateUnsolicitedConfirmWait : OutstationState
{

	public static OutstationState Inst()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.StateUnsolicitedConfirmWait(instance);
	}

	public override string Name()
	{
		return "UnsolicitedConfirmWait";
	}

	public override OutstationState OnConfirm(OContext ctx, in ParsedRequest request)
	{
		if (!request.header.control.UNS)
		{
			if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "received solicited confirm while waiting for unsolicited confirm (seq: %u)",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return this;
		}

		if (!ctx.unsol.seq.confirmNum.Equals(request.header.control.SEQ))
		{
			if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "unsolicited confirm with wrong seq: %u, expected: %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return this;
		}

		ctx.history.Reset(); // any time we get a confirm we can treat any request as a new request
		//ctx.confirmTimer.cancel();
		ctx.lastBroadcastMessageReceived.clear();

		// information the application about the confirm
		ctx.application.OnConfirmProcessed(true, ctx.eventBuffer.NumEvents(EventClass.EC1), ctx.eventBuffer.NumEvents(EventClass.EC2), ctx.eventBuffer.NumEvents(EventClass.EC3));

		if (ctx.unsol.completedNull != 0)
		{
			ctx.eventBuffer.ClearWritten();
		}
		else
		{
			ctx.unsol.completedNull = true;
		}

		ctx.shouldCheckForUnsolicited = true;

		return StateIdle.Inst();
	}

	public override OutstationState OnConfirmTimeout(OContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "unsolicited confirm timeout");
		};

		if (ctx.unsol.completedNull != 0)
		{
			var shouldRetry = ctx.unsolRetries.Retry();
			if (shouldRetry && !ctx.deferred.IsSet())
			{
				ctx.RestartUnsolConfirmTimer();
				ctx.BeginRetransmitLastUnsolicitedResponse();
				return this;
			}
			else
			{
				ctx.eventBuffer.Unselect();
			}
		}

		return StateIdle.Inst();
	}

	public override OutstationState OnNewReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.deferred.Set(request);
		return this;
	}

	public override OutstationState OnNewNonReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.deferred.Reset();
		ctx.RespondToNonReadRequest(request);
		return this;
	}

	public override OutstationState OnRepeatNonReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.BeginRetransmitLastResponse(request.addresses.source);
		return this;
	}

	public override OutstationState OnRepeatReadRequest(OContext ctx, in ParsedRequest request)
	{
		ctx.deferred.Set(request);
		return this;
	}

	public override OutstationState OnBroadcastMessage(OContext ctx, in ParsedRequest request)
	{
		ctx.ProcessBroadcastRequest(request);
		return StateIdle.Inst();
	}

	protected static StateUnsolicitedConfirmWait instance = new StateUnsolicitedConfirmWait();

	protected StateUnsolicitedConfirmWait()
	{
	}
}

/*
 * waiting for a confirm for an unsolicited NULL response (only used in the workaround)
 */
public sealed class StateNullUnsolicitedConfirmWait : StateUnsolicitedConfirmWait
{

	public new static OutstationState Inst()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.StateNullUnsolicitedConfirmWait(instance);
	}

	public new sealed string Name()
	{
		return "NullUnsolicitedConfirmWait";
	}

	public new OutstationState OnNewReadRequest(OContext ctx, in ParsedRequest request)
	{
		//ctx.confirmTimer.cancel();
		return ctx.RespondToReadRequest(request);
	}

	private static StateNullUnsolicitedConfirmWait instance = new StateNullUnsolicitedConfirmWait();

	private StateNullUnsolicitedConfirmWait()
	{
	}
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

namespace opendnp3
{

// ------------- StateIdle ----------------


// ------------- StateSolicitedConfirmWait ----------------


// ------------- StateUnsolicitedConfirmWait ----------------


// ------------- StateUnsolicitedConfirmWait ----------------


} // namespace opendnp3
