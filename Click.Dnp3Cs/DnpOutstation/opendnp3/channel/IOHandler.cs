using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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

/**

Manages I/O for a number of link contexts

*/
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class IOHandler : private IFrameSink, public IChannelCallbacks, public std::enable_shared_from_this<IOHandler>
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public abstract class IOHandler : IFrameSink, IChannelCallbacks
{

	public IOHandler(in Logger logger, bool close_existing, IChannelListener listener)
	{
		this.close_existing = close_existing;
		this.logger = new opendnp3.Logger(logger);
		this.listener = std::move(listener);
		this.parser = new opendnp3.LinkLayerParser(logger);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	virtual ~IOHandler() = default;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LinkStatistics Statistics() const
	public LinkStatistics Statistics()
	{
		return new LinkStatistics(this.statistics, this.parser.Statistics());
	}

	public void Shutdown()
	{
		if (!isShutdown)
		{
			this.isShutdown = true;

			this.Reset();

			this.ShutdownImpl();

			this.UpdateListener(ChannelState.SHUTDOWN);
		}
	}

	/// --- implement ILinkTx ---

	public void BeginTransmit(ILinkSession session, in RSeq/*<size_t>*/ data)
	{
		if (this.channel != 0)
		{
			this.txQueue.emplace_back(data, session);
			this.CheckForSend();
		}
		else
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Router received transmit request while offline");
			};
		}
	}

	// Bind a link layer session to the handler
	public bool AddContext(ILinkSession session, in Addresses addresses)
	{
		if (this.IsRouteInUse(addresses))
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Route already in use: %u -> %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return false;
		}

		if (this.IsSessionInUse(session))
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Context cannot be bound 2x");
			};
			return false;
		}

		sessions.emplace_back(session, addresses); // record is always disabled by default

		return true;
	}

	// Begin sending messages to the context
	public bool Enable(ILinkSession session)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var matches = (in Session rec) =>
		{
			return rec.Matches(session);
		};

		var iter = std::find_if(sessions.GetEnumerator(), sessions.end(), matches);

		if (iter == sessions.end())
		{
			return false;
		}

		if (iter.enabled)
		{
			return true; // already enabled
		}

		iter.enabled = true;

		if (this.channel != 0)
		{
			iter.LowerLayerUp();
		}
		else
		{
			this.UpdateListener(ChannelState.OPENING);

			this.BeginChannelAccept();
		}

		return true;
	}

	// Stop sending messages to this session
	public bool Disable(ILinkSession session)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var matches = (in Session rec) =>
		{
			return rec.Matches(session);
		};

		var iter = std::find_if(sessions.GetEnumerator(), sessions.end(), matches);

		if (iter == sessions.end())
		{
			return false;
		}

		if (!iter.enabled)
		{
			return true; // already disabled
		}

		iter.enabled = false;

		if (channel != null)
		{
			iter.LowerLayerDown();
		}

		if (!this.IsAnySessionEnabled())
		{
			this.Reset();
			this.SuspendChannelAccept();
		}

		return true;
	}

	// Remove this session entirely
	public bool Remove(ILinkSession session)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var matches = (in Session rec) =>
		{
			return rec.Matches(session);
		};

		var iter = std::find_if(sessions.GetEnumerator(), sessions.end(), matches);

		if (iter == sessions.end())
		{
			return false;
		}

		if (channel != null)
		{
			iter.LowerLayerDown();
		}

//C++ TO C# CONVERTER TASK: There is no direct equivalent to the STL vector 'erase' method in C#:
		sessions.erase(iter);

		if (!this.IsAnySessionEnabled())
		{
			this.SuspendChannelAccept();
		}

		return true;
	}

	// Query to see if a route is in use
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsRouteInUse(const Addresses& addresses) const
	public bool IsRouteInUse(in Addresses addresses)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto matches = [addresses](const Session& record)
		var matches = (in Session record) =>
		{
			return record.Matches(addresses);
		};

		return sessions.Exists(matches);
	}

	// ------ Implement IChannelCallbacks -----

	protected override void OnReadComplete(in std::error_code ec, /*size_t*/int num)
	{
		if (ec != null)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "read error: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};

			this.Reset();

			this.UpdateListener(ChannelState.OPENING);
			this.OnChannelShutdown();
		}
		else
		{
			this.statistics.numBytesRx += num;

			this.parser.OnRead(new /*size_t*/int(num), this);
			this.BeginRead();
		}
	}

	protected override void OnWriteComplete(in std::error_code ec, /*size_t*/int num)
	{

		if (ec != null)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "write error: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			this.Reset();

			this.UpdateListener(ChannelState.OPENING);
			this.OnChannelShutdown();
		}
		else
		{
			this.statistics.numBytesTx += num;

			if (this.txQueue.Count > 0)
			{
				var session = this.txQueue.First.Value.session;
				this.txQueue.RemoveFirst();
				session.OnTxReady();
			}

			this.CheckForSend();
		}
	}

	// ------ Super classes will implement these -----

	// start getting a new channel
	protected abstract void BeginChannelAccept();

	// stop getting new channels
	protected abstract void SuspendChannelAccept();

	// shutdown any additional state
	protected abstract void ShutdownImpl();

	// the current channel has closed, start getting a new one
	protected abstract void OnChannelShutdown();

	// Called by the super class when a new channel is available
	protected void OnNewChannel(IAsyncChannel channel)
	{
		// if we have an active channel, and we're configured to close new channels
		// close the new channel instead
		if (this.channel != 0 && !this.close_existing)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Existing channel, closing new connection");
			};
			channel.Shutdown();
			return;
		}

		++this.statistics.numOpen;

		this.Reset();

		this.channel = channel;

		this.channel.SetCallbacks(this);

		this.UpdateListener(ChannelState.OPEN);

		this.BeginRead();

		foreach (var session in this.sessions)
		{
			if (session.enabled)
			{
				session.LowerLayerUp();
			}
		}
	}

	protected readonly bool close_existing;
	protected Logger logger = new Logger();
	protected readonly IChannelListener listener;
	protected LinkStatistics.Channel statistics = new LinkStatistics.Channel();

	private bool isShutdown = false;

	private void UpdateListener(ChannelState state)
	{
		if (listener != null)
		{
			listener.OnStateChange(state);
		}
	}

	// called by the parser when a complete frame is read
	private override bool OnFrame(in LinkHeaderFields header, in RSeq/*<size_t>*/ userdata)
	{
		if (this.SendToSession(header.addresses, header, userdata))
		{
			return true;
		}

		if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Frame w/ unknown route, source: %i, dest %i",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};
		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsSessionInUse(const ILinkSession*& session) const
	private bool IsSessionInUse(ILinkSession session)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var matches = (in Session record) =>
		{
			return record.Matches(session);
		};

		return sessions.Exists(matches);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsAnySessionEnabled() const
	private bool IsAnySessionEnabled()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var matches = (in Session record) =>
		{
			return record.enabled;
		};

		return sessions.Exists(matches);
	}

	private void Reset()
	{
		if (this.channel != 0)
		{
			// shutdown the existing channel and drop the reference to it
			this.channel.Shutdown();
			this.channel.reset();

			++this.statistics.numClose;

			this.UpdateListener(ChannelState.CLOSED);

			// notify any sessions that are online that this layer is offline
			foreach (var item in this.sessions)
			{
				item.LowerLayerDown();
			}
		}

		// reset the state of the parser
		this.parser.Reset();

		// clear any pending tranmissions
		this.txQueue.Clear();
	}

	private void BeginRead()
	{
		this.channel.BeginRead(this.parser.WriteBuff());
	}

	private void CheckForSend()
	{
		if (this.txQueue.Count == 0 || this.channel == 0 || !this.channel.CanWrite())
		{
			return;
		}

		++statistics.numLinkFrameTx;
		this.channel.BeginWrite(this.txQueue.First.Value.txdata);
	}

	private bool SendToSession(in Addresses addresses, in LinkHeaderFields header, in RSeq/*<size_t>*/ userdata)
	{
		bool accepted = false;

		foreach (var session in sessions)
		{
			if (session.enabled)
			{
				accepted |= session.OnFrame(header, userdata);
			}
		}

		return accepted;
	}

	private class Session
	{

		public Session(ILinkSession session, in Addresses addresses)
		{
			this.addresses = new opendnp3.Addresses(addresses);
			this.session = session;
		}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//		Session() = default;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool Matches(const ILinkSession*& session) const
		public bool Matches(ILinkSession session)
		{
			return this.session == session;
		}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool Matches(const Addresses& addresses) const
		public bool Matches(in Addresses addresses)
		{
			return this.addresses == addresses;
		}

		public bool OnFrame(in LinkHeaderFields header, in RSeq/*<size_t>*/ userdata)
		{
			return this.session.OnFrame(header, userdata);
		}

		public bool LowerLayerUp()
		{
			if (!online)
			{
				online = true;
				return this.session.OnLowerLayerUp();
			}
			else
			{
				return false;
			}
		}

		public bool LowerLayerDown()
		{
			if (online)
			{
				online = false;
				return this.session.OnLowerLayerDown();
			}
			else
			{
				return false;
			}
		}

		public bool enabled = false;

		private Addresses addresses = new Addresses();
		private bool online = false;
		private ILinkSession session;
	}

	private class Transmission
	{
		public Transmission(in RSeq/*<size_t>*/ txdata, ILinkSession session)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.txdata = txdata;
			this.txdata.CopyFrom(txdata);
			this.session = session;
		}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//		Transmission() = default;

		public RSeq/*<size_t>*/ txdata = new RSeq/*<size_t>*/();
		public ILinkSession session;
	}

	private List<Session> sessions = new List<Session>();
	private LinkedList<Transmission> txQueue = new LinkedList<Transmission>();

	private LinkLayerParser parser = new LinkLayerParser();

	// current value of the channel, may be empty
	private IAsyncChannel channel;
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

