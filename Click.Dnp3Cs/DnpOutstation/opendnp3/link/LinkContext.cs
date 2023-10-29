using ser4cpp;
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

//#include "../../exe4cpp/IExecutor.h"



namespace opendnp3
{
	//MOVED to LinkTransmitMode.h
	//class PriStateBase;
	//class SecStateBase;

	//enum class LinkTransmitMode : byte
	//{
	//    Idle,
	//    Primary,
	//    Secondary
	//};

//	@section desc Implements the contextual state of DNP3 Data Link Layer
public class LinkContext
{
	private LinkContext(in Logger logger, IUpperLayer upper, ILinkListener listener, ILinkSession session, in LinkLayerConfig config)
	{
		this.logger = new opendnp3.Logger(logger);
		this.config = new opendnp3.LinkLayerConfig(config);
		this.pSegments = null;
		this.txMode = new opendnp3.LinkTransmitMode.Idle;
		this.nextReadFCB = false;
		this.isOnline = false;
		this.keepAliveTimeout = false;
		this.pPriState = PLLS_Idle.Instance();
		this.pSecState = SLLS_NotReset.Instance();
		this.listener = std::move(listener);
		this.upper = std::move(upper);
		this.pSession = session;
	}

	public static LinkContext Create(in Logger logger, IUpperLayer upper, ILinkListener listener, ILinkSession session, in LinkLayerConfig config)
	{
		return new LinkContext(logger, upper, listener, session, config);
	}

	// ---- helpers for dealing with the FCB bits ----

	public void ResetReadFCB()
	{
		nextReadFCB = true;
	}
	public void ToggleReadFCB()
	{
		nextReadFCB = !nextReadFCB;
	}

	// --- helpers for dealing with layer state transitations ---
	public bool OnLowerLayerUp()
	{
		if (this.isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer already online");
			};
			return false;
		}

		this.isOnline = true;

		this.RestartKeepAliveTimer();

		listener.OnStateChange(LinkStatus.UNRESET);
		upper.OnLowerLayerUp();

		return true;
	}

	public bool OnLowerLayerDown()
	{
		if (!isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer is not online");
			};
			return false;
		}

		isOnline = false;
		keepAliveTimeout = false;
		pSegments = null;
		txMode = LinkTransmitMode.Idle;
		pendingPriTx.clear();
		pendingSecTx.clear();

		rspTimeoutTimer.cancel();
		keepAliveTimer.cancel();

		pPriState = PLLS_Idle.Instance();
		pSecState = SLLS_NotReset.Instance();

		listener.OnStateChange(LinkStatus.UNRESET);
		upper.OnLowerLayerDown();

		return true;
	}

	public bool OnTxReady()
	{
		if (this.txMode == LinkTransmitMode.Idle)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Unknown transmission callback");
			};
			return false;
		}

		var isPrimary = (this.txMode == LinkTransmitMode.Primary);
		this.txMode = LinkTransmitMode.Idle;

		// before we dispatch the transmit result, give any pending transmissions access first
		this.TryPendingTx(this.pendingSecTx, false);
		this.TryPendingTx(this.pendingPriTx, true);

		// now dispatch the completion event to the correct state handler
		if (isPrimary)
		{
			this.pPriState = this.pPriState.OnTxReady(this);
		}
		else
		{
			this.pSecState = this.pSecState.OnTxReady(this);
		}

		return true;
	}

	public bool SetTxSegment(ITransportSegment segments)
	{
		if (!this.isOnline)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer is not online");
			};
			return false;
		}

		if (this.pSegments != null)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Already transmitting a segment");
			};
			return false;
		}

		this.pSegments = segments;
		return true;
	}

	// --- helpers for formatting user data messages ---
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	ser4cpp::RSeq FormatPrimaryBufferWithUnconfirmed(in Addresses addr, in ser4cpp::RSeq tpdu);

	// --- Helpers for queueing frames ---
	public void QueueAck(ushort destination)
	{
		var dest = secTxBuffer.as_wseq();
		var buffer = LinkFrame.FormatAck(dest, config.IsMaster, false, new ushort(destination), new ushort(this.config.LocalAddr), logger);
		if (logger.is_enabled(opendnp3.flags.Globals.LINK_TX_HEX))
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::LINK_TX_HEX, buffer, ' ', 10, 18);
			opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.LINK_TX_HEX), buffer, ' ', 10, 18);
		};
		this.QueueTransmit(buffer, false);
	}

	public void QueueLinkStatus(ushort destination)
	{
		var dest = secTxBuffer.as_wseq();
		var buffer = LinkFrame.FormatLinkStatus(dest, config.IsMaster, false, new ushort(destination), new ushort(this.config.LocalAddr), logger);
		if (logger.is_enabled(opendnp3.flags.Globals.LINK_TX_HEX))
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::LINK_TX_HEX, buffer, ' ', 10, 18);
			opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.LINK_TX_HEX), buffer, ' ', 10, 18);
		};
		this.QueueTransmit(buffer, false);
	}

	public void QueueRequestLinkStatus(ushort destination)
	{
		var dest = priTxBuffer.as_wseq();
		var buffer = LinkFrame.FormatRequestLinkStatus(dest, config.IsMaster, new ushort(destination), new ushort(this.config.LocalAddr), logger);
		if (logger.is_enabled(opendnp3.flags.Globals.LINK_TX_HEX))
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::LINK_TX_HEX, buffer, ' ', 10, 18);
			opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.LINK_TX_HEX), buffer, ' ', 10, 18);
		};
		this.QueueTransmit(buffer, true);
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void QueueTransmit(in ser4cpp::RSeq buffer, bool primary);

	// --- public members ----

	public void PushDataUp(in Message message)
	{
		upper.OnReceive(message);
	}

	public void CompleteSendOperation()
	{
		this.pSegments = null;

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto callback = [upper = upper]()
		var callback = () =>
		{
			upper.OnTxReady();
		};

		//this->executor->post(callback);
	}

	public void TryStartTransmission()
	{
		if (this.keepAliveTimeout)
		{
			this.pPriState = pPriState.TrySendRequestLinkStatus(this);
		}

		if (this.pSegments != null)
		{
			this.pPriState = pPriState.TrySendUnconfirmed(this, pSegments);
		}
	}

	public void OnKeepAliveTimeout()
	{
		var now = new Timestamp();
		var elapsed = now - this.lastMessageTimestamp;

		if (elapsed >= this.config.KeepAliveTimeout)
		{
			this.keepAliveTimeout = true;
		}

		this.RestartKeepAliveTimer();

		this.TryStartTransmission();
	}

	public void OnResponseTimeout()
	{
		this.pPriState = (this.pPriState.OnTimeout(this));

		this.TryStartTransmission();
	}

	public void StartResponseTimer()
	{
		//this->rspTimeoutTimer = executor->start(config.Timeout.value, [self = shared_from_this()]() {
		//    if (self->isOnline)
		//    {
		//        self->OnResponseTimeout();
		//    }
		//});
	}

	public void RestartKeepAliveTimer()
	{
		//this->keepAliveTimer.cancel();

		//this->lastMessageTimestamp = Timestamp(this->executor->get_time());
		//const auto expiration = this->lastMessageTimestamp + this->config.KeepAliveTimeout;

		//this->keepAliveTimer = executor->start(expiration.value, [self = shared_from_this()]() {
		//    if (self->isOnline)
		//    {
		//        self->OnKeepAliveTimeout();
		//    }
		//});
	}

	public void CancelTimer()
	{
		rspTimeoutTimer.cancel();
	}

	public void FailKeepAlive(bool timeout)
	{
		if (timeout)
		{
			this.listener.OnKeepAliveFailure();
		}
	}

	public void CompleteKeepAlive()
	{
		this.listener.OnKeepAliveSuccess();
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool OnFrame(in LinkHeaderFields header, in ser4cpp::RSeq userdata);
	public bool TryPendingTx(ser4cpp.Settable<RSeq/*<size_t>*/> pending, bool primary)
	{
		if (this.txMode == LinkTransmitMode.Idle && pending.is_set())
		{
			this.linktx.BeginTransmit(pending.get(), pSession);
			pending.clear();
			this.txMode = primary ? LinkTransmitMode.Primary : LinkTransmitMode.Secondary;
			return true;
		}

		return false;
	}


	// //REZA  Goes to ILinkContextPars
	//// buffers used for primary and secondary requests
	public ser4cpp.StaticBuffer<LPDU_MAX_FRAME_SIZE> priTxBuffer = new ser4cpp.StaticBuffer<LPDU_MAX_FRAME_SIZE>();
	public ser4cpp.StaticBuffer<LPDU_HEADER_SIZE> secTxBuffer = new ser4cpp.StaticBuffer<LPDU_HEADER_SIZE>();

	public ser4cpp.Settable<ser4cpp.RSeq> pendingPriTx = new ser4cpp.Settable<ser4cpp.RSeq>();
	public ser4cpp.Settable<ser4cpp.RSeq> pendingSecTx = new ser4cpp.Settable<ser4cpp.RSeq>();

	public Logger logger = new Logger();
	public readonly LinkLayerConfig config = new LinkLayerConfig();
	public ITransportSegment pSegments;
	public LinkTransmitMode txMode;

	//const std::shared_ptr<exe4cpp::IExecutor> executor;

	public exe4cpp.Timer rspTimeoutTimer = new exe4cpp.Timer();
	public exe4cpp.Timer keepAliveTimer = new exe4cpp.Timer();
	public bool nextReadFCB;
	public bool isOnline;
	public bool keepAliveTimeout;
	public Timestamp lastMessageTimestamp = new Timestamp();
	public StackStatistics.Link statistics = new StackStatistics.Link();

	public ILinkTx linktx = null;

	public PriStateBase pPriState;
	public SecStateBase pSecState;

	public readonly ILinkListener listener;
	public readonly IUpperLayer upper;

	public ILinkSession pSession;
}

} // namespace opendnp3


//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_SINGLETON_INSTANCE(type) private: static type instance; protected: type(){}; public: static type& Instance() { return instance; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_NAME_SINGLETON_INSTANCE(type) MACRO_SINGLETON_INSTANCE(type) char const* Name() const override { return #type; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_STATE_SINGLETON_INSTANCE(type) MACRO_NAME_SINGLETON_INSTANCE(type)
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




} // namespace opendnp3
