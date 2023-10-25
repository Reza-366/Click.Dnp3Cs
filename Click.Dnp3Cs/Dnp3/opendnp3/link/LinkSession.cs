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
//ORIGINAL LINE: class LinkSession final : public ILinkTx, public IChannelCallbacks, private IFrameSink, public std::enable_shared_from_this<LinkSession>, public IResource, private ISessionAcceptor, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public static class LinkSession : ILinkTx, IChannelCallbacks, IFrameSink, IResource, ISessionAcceptor, Uncopyable
{
	public static LinkSession Create(in Logger logger, uint64_t sessionid, IResourceManager manager, IListenCallbacks callbacks, IAsyncChannel channel)
	{
		var session = new LinkSession(logger, sessionid, manager, callbacks, channel);

		session.Start();

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return session;
		return new opendnp3.LinkSession(session);
	}

	public LinkSession(in Logger logger, uint64_t sessionid, IResourceManager manager, IListenCallbacks callbacks, IAsyncChannel channel)
	{
		this.logger = new opendnp3.Logger(logger);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.session_id = sessionid;
		this.session_id.CopyFrom(sessionid);
		this.manager = std::move(manager);
		this.callbacks = std::move(callbacks);
		this.channel = channel;
		this.parser = new opendnp3.LinkLayerParser(logger);
	}

	// override IResource
	public void Shutdown()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto shutdown = [self = this]()
		var shutdown = () =>
		{
			self.ShutdownImpl();
		};

	//    this->channel->executor->block_until_and_flush(shutdown);//REZA
	}

	public void SetLogFilters(in LogLevels filters)
	{
		this.logger.set_levels(filters);
	}

	private void ShutdownImpl()
	{
		if (this.is_shutdown)
		{
			return;
		}

		this.is_shutdown = true;

		this.callbacks.OnConnectionClose(new uint64_t(this.session_id), this.stack);

		if (this.stack != null)
		{
			this.stack.OnLowerLayerDown();
			this.stack.BeginShutdown();
		}

		this.first_frame_timer.cancel();

		this.channel.Shutdown();

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto detach = [self = this]()
		var detach = () =>
		{
			self.manager.Detach(self);
		};

		//this->channel->executor->post(detach);
	}

	// IChannelCallbacks
	private override void OnReadComplete(in std::error_code ec, size_t num)
	{
		if (ec != null)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", ec.message().c_str());
			};
			this.ShutdownImpl();
		}
		else
		{
			this.parser.OnRead(new size_t(num), this);
			this.BeginReceive();
		}
	}

	private override void OnWriteComplete(in std::error_code ec, size_t num)
	{
		if (ec != null)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", ec.message().c_str());
			};
			this.ShutdownImpl();
		}
		else
		{
			this.stack.OnTxReady();
		}
	}

	// ILinkTx
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void BeginTransmit(in RSeq<size_t> buffer, ILinkSession session);

	// IFrameSink
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed bool OnFrame(in LinkHeaderFields header, in RSeq<size_t> userdata);

	// ISessionAcceptor
	private IMasterSession AcceptSession(in string loggerid, ISOEHandler SOEHandler, IMasterApplication application, in MasterStackConfig config)
	{
		if (this.stack != null)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", "SocketSession already has a master bound");
			};
			return null;
		}

		// rename the logger id to something meaningful
		this.logger.rename(loggerid);

		this.stack = MasterSessionStack.Create(this.logger, SOEHandler, application, new MasterSchedulerBackend(), this, this, config);

		return stack;
	}

	private void Start()
	{
		this.channel.SetCallbacks(this);

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto timeout = [self = this]()
		var timeout = () =>
		{
			if (self.logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				self.logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", "Timed out before receving a frame. Closing socket.");
			};
			self.channel.Shutdown();
		};

		//this->first_frame_timer = this->channel->executor->start(this->callbacks->GetFirstFrameTimeout().value, timeout);

		this.BeginReceive();
	}

	private void BeginReceive()
	{
		var dest = parser.WriteBuff();
		channel.BeginRead(dest);
	}

	private bool is_shutdown = false;
	private Logger logger = new Logger();
	private readonly uint64_t session_id = new uint64_t();

	private readonly IResourceManager manager;
	private readonly IListenCallbacks callbacks;
	private readonly IAsyncChannel channel;

	private LinkLayerParser parser = new LinkLayerParser();
	private exe4cpp.Timer first_frame_timer = new exe4cpp.Timer();

	private MasterSessionStack stack; // initialized to null
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



} // namespace opendnp3
