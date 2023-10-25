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
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_SINGLETON_INSTANCE(type) private: static type instance; protected: type(){}; public: static type& Instance() { return instance; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_NAME_SINGLETON_INSTANCE(type) MACRO_SINGLETON_INSTANCE(type) char const* Name() const override { return #type; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_STATE_SINGLETON_INSTANCE(type) MACRO_NAME_SINGLETON_INSTANCE(type)

namespace opendnp3
{

public abstract class SecStateBase
{
	// Incoming messages to secondary station

	public abstract SecStateBase OnResetLinkStates(LinkContext UnnamedParameter, UInt16 source);
	public abstract SecStateBase OnRequestLinkStatus(LinkContext UnnamedParameter, UInt16 source);

	public abstract SecStateBase OnTestLinkStatus(LinkContext UnnamedParameter, UInt16 source, bool fcb);
	public abstract SecStateBase OnConfirmedUserData(LinkContext UnnamedParameter, UInt16 source, bool fcb, bool isBroadcast, in Message message);


	////////////////////////////////////////
	// SecStateBase
	////////////////////////////////////////

	public virtual SecStateBase OnTxReady(LinkContext ctx)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.ERR))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Invalid event for state: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
		};
		return this;
	}

	// every concrete state implements this for logging purposes

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const = 0;
	public abstract string Name();
}

////////////////////////////////////////////////////////
//	Class SLLS_TransmitWait
////////////////////////////////////////////////////////
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class NextState>
public abstract class SLLS_TransmitWaitBase <NextState> : SecStateBase
{

	protected SLLS_TransmitWaitBase()
	{
	}

	public override SecStateBase OnTxReady(LinkContext ctx)
	{
		return NextState.Instance();
	}

	public override SecStateBase OnResetLinkStates(LinkContext ctx, UInt16 source)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Ignoring link frame, remote is flooding");
		};
		return this;
	}

	public override SecStateBase OnRequestLinkStatus(LinkContext ctx, UInt16 source)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Ignoring link frame, remote is flooding");
		};
		return this;
	}

	public override SecStateBase OnTestLinkStatus(LinkContext ctx, UInt16 source, bool fcb)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Ignoring link frame, remote is flooding");
		};
		return this;
	}

	public override SecStateBase OnConfirmedUserData(LinkContext ctx, UInt16 source, bool fcb, bool isBroadcast, in Message message)
	{
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Ignoring link frame, remote is flooding");
		};
		return this;
	}
}

////////////////////////////////////////////////////////
//	Class SLLS_UnReset
////////////////////////////////////////////////////////
public sealed class SLLS_NotReset : SecStateBase
{
	private static SLLS_NotReset instance = new SLLS_NotReset();
	protected SLLS_NotReset()
	{
	}
	public static SLLS_NotReset Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.SLLS_NotReset(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "SLLS_NotReset";
	}

	public override SecStateBase OnConfirmedUserData(LinkContext ctx, UInt16 source, bool fcb, bool isBroadcast, in Message message)
	{
		++ctx.statistics.numUnexpectedFrame;
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "ConfirmedUserData ignored: secondary not reset");
		};
		return this;
	}

	public override SecStateBase OnResetLinkStates(LinkContext ctx, UInt16 source)
	{
		ctx.QueueAck(new UInt16(source));
		ctx.ResetReadFCB();
		return SLLS_TransmitWaitReset.Instance();
	}

	public override SecStateBase OnRequestLinkStatus(LinkContext ctx, UInt16 source)
	{
		ctx.QueueLinkStatus(new UInt16(source));
		return SLLS_TransmitWaitNotReset.Instance();
	}


	////////////////////////////////////////////////////////
	//	Class SLLS_NotReset
	////////////////////////////////////////////////////////

	public override SecStateBase OnTestLinkStatus(LinkContext ctx, UInt16 source, bool fcb)
	{
		++ctx.statistics.numUnexpectedFrame;
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "TestLinkStatus ignored");
		};
		return this;
	}
}

////////////////////////////////////////////////////////
//	Class SLLS_Reset
////////////////////////////////////////////////////////
public sealed class SLLS_Reset : SecStateBase
{
	private static SLLS_Reset instance = new SLLS_Reset();
	protected SLLS_Reset()
	{
	}
	public static SLLS_Reset Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.SLLS_Reset(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "SLLS_Reset";
	}

	public override SecStateBase OnConfirmedUserData(LinkContext ctx, UInt16 source, bool fcb, bool isBroadcast, in Message message)
	{
		if (!isBroadcast)
		{
			ctx.QueueAck(new UInt16(source));
		}

		if (ctx.nextReadFCB == fcb)
		{
			ctx.ToggleReadFCB();
			ctx.PushDataUp(message);
		}
		else
		{
			if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "ConfirmedUserData ignored: unexpected frame count bit (FCB)");
			};
		}

		return SLLS_TransmitWaitReset.Instance();
	}

	public override SecStateBase OnResetLinkStates(LinkContext ctx, UInt16 source)
	{
		ctx.QueueAck(new UInt16(source));
		ctx.ResetReadFCB();
		return SLLS_TransmitWaitReset.Instance();
	}

	public override SecStateBase OnRequestLinkStatus(LinkContext ctx, UInt16 source)
	{
		ctx.QueueLinkStatus(new UInt16(source));
		return SLLS_TransmitWaitReset.Instance();
	}


	////////////////////////////////////////////////////////
	//	Class SLLS_Reset
	////////////////////////////////////////////////////////

	public override SecStateBase OnTestLinkStatus(LinkContext ctx, UInt16 source, bool fcb)
	{
		if (ctx.nextReadFCB == fcb)
		{
			ctx.QueueAck(new UInt16(source));
			ctx.ToggleReadFCB();
			return SLLS_TransmitWaitReset.Instance();
		}

		// "Re-transmit most recent response that contained function code 0 (ACK) or 1 (NACK)."
		// This is a PITA implement
		// TODO - see if this function is deprecated or not
		if (ctx.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			ctx.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Received TestLinkStatus with invalid FCB");
		};
		return this;
	}
}

public class SLLS_TransmitWaitReset : SLLS_TransmitWaitBase<SLLS_Reset>
{
	private static SLLS_TransmitWaitReset instance = new SLLS_TransmitWaitReset();
	protected SLLS_TransmitWaitReset()
	{
	}
	public static SLLS_TransmitWaitReset Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.SLLS_TransmitWaitReset(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "SLLS_TransmitWaitReset";
	}
}

public class SLLS_TransmitWaitNotReset : SLLS_TransmitWaitBase<SLLS_NotReset>
{
	private static SLLS_TransmitWaitNotReset instance = new SLLS_TransmitWaitNotReset();
	protected SLLS_TransmitWaitNotReset()
	{
	}
	public static SLLS_TransmitWaitNotReset Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.SLLS_TransmitWaitNotReset(instance);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return "SLLS_TransmitWaitNotReset";
	}
}

} // namespace opendnp3





namespace opendnp3
{

////////////////////////////////////////////////////////
//	Class SLLS_TransmitWaitReset
////////////////////////////////////////////////////////

////////////////////////////////////////////////////////
//	Class SLLS_TransmitWaitNotReset
////////////////////////////////////////////////////////

} // namespace opendnp3
