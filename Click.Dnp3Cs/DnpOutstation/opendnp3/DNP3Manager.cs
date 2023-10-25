using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
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

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class DNP3ManagerImpl;

/**
 *	Root DNP3 object used to create channels and sessions.
 */
public class DNP3Manager : System.IDisposable
{

	/**
	 *	Construct a manager
	 *
	 *	@param concurrencyHint How many threads to allocate in the thread pool
	 *	@param handler Callback interface for log messages
	 *	@param onThreadStart Action to run when a thread pool thread starts
	 *	@param onThreadExit Action to run just before a thread pool thread exits
	 */
//C++ TO C# CONVERTER TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	DNP3Manager(uint concurrencyHint, opendnp3.ILogHandler * handler = , Action<uint> onThreadStart = null, Action<uint> onThreadExit = null); //  []void(uint) {});

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	public void Dispose();

	/**
	 * Permanently shutdown the manager and all sub-objects that have been created. Stop
	 * the thead pool.
	 */
	public void Shutdown()
	{
		impl.Shutdown();
	}

	/**
	 * Add a persistent TCP client channel. Automatically attempts to reconnect.
	 *
	 * @param id Alias that will be used for logging purposes with this channel
	 * @param levels Bitfield that describes the logging level for this channel and associated sessions
	 * @param retry Retry parameters for failed channels
	 * @param hosts List of host addresses to use to connect to the remote outstation (i.e. 127.0.0.1 or www.google.com)
	 * @param local adapter address on which to attempt the connection (use 0.0.0.0 for all adapters)
	 * @param listener optional callback interface (can be nullptr) for info about the running channel
	 * @return shared_ptr to a channel interface
	 */
	public IChannel AddTCPClient(in string id, in LogLevels levels, in ChannelRetry retry, in List<IPEndpoint> hosts, in string local, IChannelListener listener)
	{
		return this.impl.AddTCPClient(id, levels, retry, hosts, local, std::move(listener));
	}

	/**
	 * Add a persistent TCP server channel. Only accepts a single connection at a time.
	 *
	 * @param id Alias that will be used for logging purposes with this channel
	 * @param levels Bitfield that describes the logging level for this channel and associated sessions
	 * @param mode Describes how new connections are treated when another session already exists
	 * @param endpoint Network adapter to listen on (i.e. 127.0.0.1 or 0.0.0.0) and port
	 * @param listener optional callback interface (can be nullptr) for info about the running channel
	 * @throw DNP3Error if the manager was already shutdown or if the server could not be binded properly
	 * @return shared_ptr to a channel interface
	 */
	public IChannel AddTCPServer(in string id, in LogLevels levels, ServerAcceptMode mode, in IPEndpoint endpoint, IChannelListener listener)
	{
		return this.impl.AddTCPServer(id, levels, mode, endpoint, std::move(listener));
	}

	/**
	 * Add a persistent UDP channel.
	 *
	 * @param id Alias that will be used for logging purposes with this channel
	 * @param levels Bitfield that describes the logging level for this channel and associated sessions
	 * @param retry Retry parameters for failed channels
	 * @param localEndpoint Local endpoint from which datagrams will be received
	 * @param remoteEndpoint Remote endpoint where datagrams will be sent to
	 * @param listener optional callback interface (can be nullptr) for info about the running channel
	 * @throw DNP3Error if the manager was already shutdown
	 * @return shared_ptr to a channel interface
	 */
	public IChannel AddUDPChannel(in string id, in LogLevels levels, in ChannelRetry retry, in IPEndpoint localEndpoint, in IPEndpoint remoteEndpoint, IChannelListener listener)
	{
		return this.impl.AddUDPChannel(id, levels, retry, localEndpoint, remoteEndpoint, std::move(listener));
	}

	/**
	 * Add a persistent serial channel
	 *
	 * @param id Alias that will be used for logging purposes with this channel
	 * @param levels Bitfield that describes the logging level for this channel and associated sessions
	 * @param retry Retry parameters for failed channels
	 * @param settings settings object that fully parameterizes the serial port
	 * @param listener optional callback interface (can be nullptr) for info about the running channel
	 * @throw DNP3Error if the manager was already shutdown
	 * @return shared_ptr to a channel interface
	 */
	public IChannel AddSerial(in string id, in LogLevels levels, in ChannelRetry retry, SerialSettings settings, IChannelListener listener)
	{
		return this.impl.AddSerial(id, levels, retry, std::move(settings), std::move(listener));
	}

	/**
	 * Add a TLS client channel
	 *
	 * @throw std::system_error Throws underlying ASIO exception of TLS configuration is invalid
	 *
	 * @param id Alias that will be used for logging purposes with this channel
	 * @param levels Bitfield that describes the logging level for this channel and associated sessions
	 * @param retry Retry parameters for failed channels
	 * @param hosts IP address of remote outstation (i.e. 127.0.0.1 or www.google.com)
	 * @param local adapter address on which to attempt the connection (use 0.0.0.0 for all adapters)
	 * @param config TLS configuration information
	 * @param listener optional callback interface (can be nullptr) for info about the running channel
	 * @throw DNP3Error if the manager was already shutdown or if the library was compiled without TLS support
	 * @return shared_ptr to a channel interface
	 */
	public IChannel AddTLSClient(in string id, in LogLevels levels, in ChannelRetry retry, in List<IPEndpoint> hosts, in string local, in TLSConfig config, IChannelListener listener)
	{
		return this.impl.AddTLSClient(id, levels, retry, hosts, local, config, std::move(listener));
	}

	/**
	 * Add a TLS server channel
	 *
	 * @throw std::system_error Throws underlying ASIO exception of TLS configuration is invalid
	 *
	 * @param id Alias that will be used for logging purposes with this channel
	 * @param levels Bitfield that describes the logging level for this channel and associated sessions
	 * @param mode Describes how new connections are treated when another session already exists
	 * @param endpoint Network adapter to listen on (i.e. 127.0.0.1 or 0.0.0.0) and port
	 * @param config TLS configuration information
	 * @param listener optional callback interface (can be nullptr) for info about the running channel
	 * @throw DNP3Error if the manager was already shutdown, if the library was compiled without TLS support
	 *                  or if the server could not be binded properly
	 * @return shared_ptr to a channel interface
	 */
	public IChannel AddTLSServer(in string id, in LogLevels levels, ServerAcceptMode mode, in IPEndpoint endpoint, in TLSConfig config, IChannelListener listener)
	{
		return this.impl.AddTLSServer(id, levels, mode, endpoint, config, std::move(listener));
	}

	/**
	 * Create a TCP listener that will be used to accept incoming connections
	 * @throw DNP3Error if the manager was already shutdown or if the server could not be binded properly
	 */
	public IListener CreateListener(string loggerid, in LogLevels loglevel, in IPEndpoint endpoint, IListenCallbacks callbacks)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return impl->CreateListener(std::move(loggerid), loglevel, endpoint, callbacks);
		return new opendnp3.IListener(impl.CreateListener(std::move(loggerid), loglevel, endpoint, callbacks));
	}

	/**
	 * Create a TLS listener that will be used to accept incoming connections
	 * @throw DNP3Error if the manager was already shutdown, if the library was compiled without TLS support
	 *                  or if the server could not be binded properly
	 */
	public IListener CreateListener(string loggerid, in LogLevels loglevel, in IPEndpoint endpoint, in TLSConfig config, IListenCallbacks callbacks)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return impl->CreateListener(std::move(loggerid), loglevel, endpoint, config, callbacks);
		return new opendnp3.IListener(impl.CreateListener(std::move(loggerid), loglevel, endpoint, config, callbacks));
	}

	private DNP3ManagerImpl impl;
}

} // namespace opendnp3




namespace opendnp3
{


//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//DNP3Manager::~DNP3Manager() = default;

} // namespace opendnp3
