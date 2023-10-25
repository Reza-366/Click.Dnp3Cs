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


//#include "../../../exe4cpp/asio/ThreadPool.h"

namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class DNP3ManagerImpl : private Uncopyable
public class DNP3ManagerImpl : Uncopyable
{

	public DNP3ManagerImpl(uint concurrencyHint, ILogHandler handler, Action<uint> onThreadStart, Action<uint> onThreadExit)
	{
		this.logger = new opendnp3.Logger(std::move(handler), new ModuleId(), "manager", opendnp3.levels.Globals.ALL);
		this.io = new asio.io_context();
		this.resources = ResourceManager.Create();
	}

	public new void Dispose()
	{
		this.Shutdown();
		base.Dispose();
	}

	public void Shutdown()
	{
		if (resources != null)
		{
			resources.Shutdown();
			resources.reset();
		}
	}

	public IChannel AddTCPClient(in string id, in LogLevels levels, in ChannelRetry retry, in List<IPEndpoint> hosts, in string local, IChannelListener listener)
	{
		var create = () =>
		{
			var clogger = this.logger.detach(id, new opendnp3.LogLevels(levels));
			var iohandler = TCPClientIOHandler.Create(clogger, listener, retry, new IPEndpointsList(hosts), local);
			return new opendnp3.DNP3Channel(DNP3Channel.Create(clogger, iohandler, this.resources));
		};

		var channel = this.resources.Bind<IChannel>(create);

		if (channel == null)
		{
		   // throw DNP3Error(Error::SHUTTING_DOWN);
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return channel;
		return new opendnp3.IChannel(channel);
	}

	public IChannel AddTCPServer(in string id, in LogLevels levels, ServerAcceptMode mode, in IPEndpoint endpoint, IChannelListener listener)
	{
	//    auto create = [&]() -> std::shared_ptr<IChannel> {
	//        std::error_code ec;
	//        auto clogger = this->logger.detach(id, levels);
	//        auto executor = exe4cpp::StrandExecutor::create(this->io);
	//        auto iohandler = TCPServerIOHandler::Create(clogger, mode, listener, executor, endpoint, ec);
	//        if (ec)
	//        {
	//            throw DNP3Error(Error::UNABLE_TO_BIND_SERVER, ec);
	//        }
	//        return DNP3Channel::Create(clogger, executor, iohandler, this->resources);
	//    };

	  //  auto channel = this->resources->Bind<IChannel>(create);

	//    if (!channel)
	//    {
	//        throw DNP3Error(Error::SHUTTING_DOWN);
	//    }

		//return channel;
		IChannel rrr;
		return rrr;
	}

	public IChannel AddUDPChannel(in string id, in LogLevels levels, in ChannelRetry retry, in IPEndpoint localEndpoint, in IPEndpoint remoteEndpoint, IChannelListener listener)
	{
	//    auto create = [&]() -> std::shared_ptr<IChannel> {
	//        auto clogger = this->logger.detach(id, levels);
	//        auto executor = exe4cpp::StrandExecutor::create(this->io);
	//        auto iohandler = UDPClientIOHandler::Create(clogger, listener, executor, retry, localEndpoint, remoteEndpoint);
	//        return DNP3Channel::Create(clogger, executor, iohandler, this->resources);
	//    };
	//
	//    auto channel = this->resources->Bind<IChannel>(create);
	//
	//    if (!channel)
	//    {
	//        throw DNP3Error(Error::SHUTTING_DOWN);
	//    }
	//
	//    return channel;
		IChannel rrr;
		return rrr;
	}

	public IChannel AddSerial(in string id, in LogLevels levels, in ChannelRetry retry, SerialSettings settings, IChannelListener listener)
	{
		var create = () =>
		{
			var clogger = this.logger.detach(id, new opendnp3.LogLevels(levels));
			var iohandler = SerialIOHandler.Create(clogger, listener, retry, settings);
			return new opendnp3.DNP3Channel(DNP3Channel.Create(clogger, iohandler, this.resources));
		};

		//auto channel = this->resources->Bind<IChannel>(create);
		//if (!channel)
		//{
			//throw DNP3Error(Error::SHUTTING_DOWN);
		//}
		return create();
	//	std::shared_ptr<IChannel> rrr;
	//	return rrr;
	}

	public IChannel AddTLSClient(in string id, in LogLevels levels, in ChannelRetry retry, in List<IPEndpoint> hosts, in string local, in TLSConfig config, IChannelListener listener)
	{

	//#ifdef OPENDNP3_USE_TLS
	//    auto create = [&]() -> std::shared_ptr<IChannel> {
	//        auto clogger = this->logger.detach(id, levels);
	//        auto executor = exe4cpp::StrandExecutor::create(this->io);
	//        auto iohandler = TLSClientIOHandler::Create(clogger, listener, executor, config, retry, hosts, local);
	//        return DNP3Channel::Create(clogger, executor, iohandler, this->resources);
	//    };
	//
	//    auto channel = this->resources->Bind<IChannel>(create);
	//
	//    if (!channel)
	//    {
	//        throw DNP3Error(Error::SHUTTING_DOWN);
	//    }
	//
	//    return channel;
	//#else
	//  //  throw DNP3Error(Error::NO_TLS_SUPPORT);
	//#endif
		IChannel rrr;
		return rrr;
	}

	public IChannel AddTLSServer(in string id, in LogLevels levels, ServerAcceptMode mode, in IPEndpoint endpoint, in TLSConfig config, IChannelListener listener)
	{

	//#ifdef OPENDNP3_USE_TLS
	//    auto create = [&]() -> std::shared_ptr<IChannel> {
	//        std::error_code ec;
	//        auto clogger = this->logger.detach(id, levels);
	//        auto executor = exe4cpp::StrandExecutor::create(this->io);
	//        auto iohandler = TLSServerIOHandler::Create(clogger, mode, listener, executor, endpoint, config, ec);
	//        if (ec)
	//        {
	//            throw DNP3Error(Error::UNABLE_TO_BIND_SERVER, ec);
	//        }
	//        return DNP3Channel::Create(clogger, executor, iohandler, this->resources);
	//    };
	//
	//    auto channel = this->resources->Bind<IChannel>(create);
	//
	//    if (!channel)
	//    {
	//        throw DNP3Error(Error::SHUTTING_DOWN);
	//    }
	//
	//    return channel;
	//
	//#else
	//    throw DNP3Error(Error::NO_TLS_SUPPORT);
	//#endif
		IChannel rrr;
		return rrr;
	}

	public IListener CreateListener(string loggerid, in LogLevels levels, in IPEndpoint endpoint, IListenCallbacks callbacks)
	{
	//    auto create = [&]() -> std::shared_ptr<IListener> {
	//        std::error_code ec;
	//        auto server
	//            = MasterTCPServer::Create(this->logger.detach(loggerid, levels),
	//            							exe4cpp::StrandExecutor::create(this->io),
	//                                      endpoint,
	//									  callbacks, this->resources, ec);
	//        if (ec)
	//        {
	//            throw DNP3Error(Error::UNABLE_TO_BIND_SERVER, ec);
	//        }
	//        return server;
	//    };
	//
	//    auto listener = this->resources->Bind<IListener>(create);
	//
	//    if (!listener)
	//    {
	//        throw DNP3Error(Error::SHUTTING_DOWN);
	//    }
	//
	//    return listener;
		IListener rrr;
		return rrr;
	}

	public IListener CreateListener(string loggerid, in LogLevels levels, in IPEndpoint endpoint, in TLSConfig config, IListenCallbacks callbacks)
	{
	//
	//#ifdef OPENDNP3_USE_TLS
	//
	//    auto create = [&]() -> std::shared_ptr<IListener> {
	//        std::error_code ec;
	//        auto server
	//            = MasterTLSServer::Create(this->logger.detach(loggerid, levels), exe4cpp::StrandExecutor::create(this->io),
	//                                      endpoint, config, callbacks, this->resources, ec);
	//        if (ec)
	//        {
	//            throw DNP3Error(Error::UNABLE_TO_BIND_SERVER, ec);
	//        }
	//        return server;
	//    };
	//
	//    auto listener = this->resources->Bind<IListener>(create);
	//
	//    if (!listener)
	//    {
	//        throw DNP3Error(Error::SHUTTING_DOWN);
	//    }
	//
	//    return listener;
	//
	//#else
	//   // throw DNP3Error(Error::NO_TLS_SUPPORT);
	//#endif
		IListener rrr;
		return rrr;
	}

	private Logger logger = new Logger();
	private readonly asio.io_context io;
//    exe4cpp::ThreadPool threadpool;
	private ResourceManager resources;
}

} // namespace opendnp3



#if OPENDNP3_USE_TLS
//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include "channel/tls/MasterTLSServer.h"
//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include "channel/tls/TLSClientIOHandler.h"
//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include "channel/tls/TLSServerIOHandler.h"
#endif

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


