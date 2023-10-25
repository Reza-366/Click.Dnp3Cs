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

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_SINGLETON_INSTANCE(type) private: static type instance; protected: type(){}; public: static type& Instance() { return instance; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_NAME_SINGLETON_INSTANCE(type) MACRO_SINGLETON_INSTANCE(type) char const* Name() const override { return #type; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_STATE_SINGLETON_INSTANCE(type) MACRO_NAME_SINGLETON_INSTANCE(type)

namespace opendnp3
{

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class LinkContext;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class ITransportSegment;

public abstract class PriStateBase
{
	// Incoming messages for primary station

	////////////////////////////////////////
	// PriStateBase
	////////////////////////////////////////

	public virtual PriStateBase OnAck(LinkContext ctx, bool receiveBuffFull)
	{
		++ctx.statistics.numUnexpectedFrame;
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Frame context not understood");
		};
		return this;
	}

	public virtual PriStateBase OnNack(LinkContext ctx, bool receiveBuffFull)
	{
		++ctx.statistics.numUnexpectedFrame;
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Frame context not understood");
		};
		return this;
	}

	public virtual PriStateBase OnLinkStatus(LinkContext ctx, bool receiveBuffFull)
	{
		++ctx.statistics.numUnexpectedFrame;
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Frame context not understood");
		};
		return this;
	}

	public virtual PriStateBase OnNotSupported(LinkContext ctx, bool receiveBuffFull)
	{
		++ctx.statistics.numUnexpectedFrame;
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Frame context not understood");
		};
		return this;
	}

	public virtual PriStateBase OnTxReady(LinkContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.ERR))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Invalid action for state: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};
		return this;
	}

	public virtual PriStateBase OnTimeout(LinkContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.ERR))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Invalid action for state: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};
		return this;
	}

	// transmission events to handle
	public virtual PriStateBase TrySendUnconfirmed(LinkContext UnnamedParameter, ITransportSegment segments)
	{
		return this;
	}

	public virtual PriStateBase TrySendRequestLinkStatus(LinkContext UnnamedParameter)
	{
		return this;
	}

	// every concrete state implements this for logging purposes
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const = 0;
	public abstract string Name();
}

//	@section desc Entry state for primary station
public sealed class PLLS_Idle : PriStateBase
{
	private static PLLS_Idle instance = new PLLS_Idle();
	protected PLLS_Idle()
	{
	}
	public static PLLS_Idle Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.PLLS_Idle(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "PLLS_Idle";
	}


	////////////////////////////////////////////////////////
	// Class PLLS_SecNotResetIdle
	////////////////////////////////////////////////////////


	public override PriStateBase TrySendUnconfirmed(LinkContext ctx, ITransportSegment segments)
	{
		var first = segments.GetSegment();
		var output = ctx.FormatPrimaryBufferWithUnconfirmed(segments.GetAddresses(), first);
		ctx.QueueTransmit(output, true);
		return PLLS_SendUnconfirmedTransmitWait.Instance();
	}

	public override PriStateBase TrySendRequestLinkStatus(LinkContext ctx)
	{
		ctx.keepAliveTimeout = false;
		ctx.QueueRequestLinkStatus(new ushort(ctx.config.RemoteAddr));
		ctx.listener.OnKeepAliveInitiated();
		ctx.StartResponseTimer();
		return PLLS_RequestLinkStatusWait.Instance();
	}
}

/////////////////////////////////////////////////////////////////////////////
// Wait state for send unconfirmed data
/////////////////////////////////////////////////////////////////////////////

public sealed class PLLS_SendUnconfirmedTransmitWait : PriStateBase
{
	private static PLLS_SendUnconfirmedTransmitWait instance = new PLLS_SendUnconfirmedTransmitWait();
	protected PLLS_SendUnconfirmedTransmitWait()
	{
	}
	public static PLLS_SendUnconfirmedTransmitWait Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.PLLS_SendUnconfirmedTransmitWait(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "PLLS_SendUnconfirmedTransmitWait";
	}


	////////////////////////////////////////////////////////
	// Class SendUnconfirmedTransmitWait
	////////////////////////////////////////////////////////


	public override PriStateBase OnTxReady(LinkContext ctx)
	{
		if (ctx.pSegments.Advance())
		{
			var output = ctx.FormatPrimaryBufferWithUnconfirmed(ctx.pSegments.GetAddresses(), ctx.pSegments.GetSegment());
			ctx.QueueTransmit(output, true);
			return this;
		}
		// we're done

		ctx.CompleteSendOperation();
		return PLLS_Idle.Instance();
	}
}

/////////////////////////////////////////////////////////////////////////////
// Waiting for a link status response
/////////////////////////////////////////////////////////////////////////////

//	@section desc As soon as we get an ACK, send the delayed pri frame
public sealed class PLLS_RequestLinkStatusWait : PriStateBase
{
	private static PLLS_RequestLinkStatusWait instance = new PLLS_RequestLinkStatusWait();
	protected PLLS_RequestLinkStatusWait()
	{
	}
	public static PLLS_RequestLinkStatusWait Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.PLLS_RequestLinkStatusWait(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "PLLS_RequestLinkStatusWait";
	}


	////////////////////////////////////////////////////////
	// Class PLLS_RequestLinkStatusWait
	////////////////////////////////////////////////////////


	public override PriStateBase OnAck(LinkContext ctx, bool UnnamedParameter)
	{
		ctx.CancelTimer();
		ctx.FailKeepAlive(false);
		return PLLS_Idle.Instance();
	}

	public override PriStateBase OnNack(LinkContext ctx, bool UnnamedParameter)
	{
		ctx.CancelTimer();
		ctx.FailKeepAlive(false);
		return PLLS_Idle.Instance();
	}

	public override PriStateBase OnLinkStatus(LinkContext ctx, bool UnnamedParameter)
	{
		ctx.CancelTimer();
		ctx.CompleteKeepAlive();
		return PLLS_Idle.Instance();
	}

	public override PriStateBase OnNotSupported(LinkContext ctx, bool UnnamedParameter)
	{
		ctx.CancelTimer();
		ctx.FailKeepAlive(false);
		return PLLS_Idle.Instance();
	}

	public override PriStateBase OnTxReady(LinkContext ctx)
	{
		// The request link status was successfully sent
		return this;
	}

	public override PriStateBase OnTimeout(LinkContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Link status request - response timeout");
		};
		ctx.FailKeepAlive(true);
		return PLLS_Idle.Instance();
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


