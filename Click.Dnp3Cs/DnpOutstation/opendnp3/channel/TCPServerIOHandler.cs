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


//#include "../../exe4cpp/Timer.h"

namespace opendnp3
{

public class TCPServerIOHandler //final : public IOHandler
{
	private class Server //final : public TCPServer
	{
//    public:
//        typedef std::function<void(const std::shared_ptr<exe4cpp::StrandExecutor>& executor, asio::ip::tcp::socket)>
//            callback_t;
//
//        Server(const Logger& logger,
//               const std::shared_ptr<exe4cpp::StrandExecutor>& executor,
//               const IPEndpoint& endpoint,
//               /*std::error_code*/ int& ec)
//            : TCPServer(logger, executor, endpoint, ec)
//        {
//        }
//        void StartAcceptingConnection(const callback_t& callback)
//        {
//            this->callback = callback;
//            this->StartAccept();
//        }

//        callback_t callback;

		private void OnShutdown()
		{
		} //final {}

//        void AcceptConnection(ulong sessionid,
//                              const std::shared_ptr<exe4cpp::StrandExecutor>& executor,
//                              asio::ip::tcp::socket) final;
	}

	public static TCPServerIOHandler Create(in Logger logger, ServerAcceptMode accept_mode, IChannelListener listener, in IPEndpoint endpoint, /*std::error_code*/ int ec)
	{
		return new TCPServerIOHandler(logger, accept_mode, listener, endpoint, ec);
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	TCPServerIOHandler(in Logger logger, ServerAcceptMode accept_mode, IChannelListener listener, IPEndpoint endpoint, /*std::error_code*/ int ec);


	//void TCPServerIOHandler::Server::AcceptConnection(ulong sessionid,
	//                                                  const std::shared_ptr<exe4cpp::StrandExecutor>& executor,
	//                                                  asio::ip::tcp::socket socket)
	//{
	//    this->callback(executor, std::move(socket));
	//}

	//TCPServerIOHandler::TCPServerIOHandler(const Logger& logger,
	//                                       ServerAcceptMode mode,
	//                                       const std::shared_ptr<IChannelListener>& listener,
	//                                       std::shared_ptr<exe4cpp::StrandExecutor> executor,
	//                                       IPEndpoint endpoint,
	//                                       /*std::error_code*/ int& ec)
	//    : IOHandler(logger, mode == ServerAcceptMode::CloseExisting, listener),
	//      executor(std::move(executor)),
	//      endpoint(std::move(endpoint)),
	//      server(std::make_shared<Server>(this->logger, this->executor, this->endpoint, ec))
	//{
	//}

	protected void ShutdownImpl()
	{
	//    if (this->server)
	//    {
	//        this->server->Shutdown();
	//        this->server.reset();
	//    }
	}

	protected void BeginChannelAccept()
	{
	//    auto callback = [self = shared_from_this(), this](const std::shared_ptr<exe4cpp::StrandExecutor>& executor,
	//                                                      asio::ip::tcp::socket socket) {
	//        this->OnNewChannel(TCPSocketChannel::Create(executor, std::move(socket)));
	//    };
	//
	//    if (this->server)
	//    {
	//        this->server->StartAcceptingConnection(callback);
	//    }
	//    else
	//    {
	//        /*std::error_code*/ int ec;
	//        this->server = std::make_shared<Server>(this->logger, this->executor, this->endpoint, ec);
	//
	//        if (ec)
	//        {
	//            SIMPLE_LOG_BLOCK(this->logger, flags::WARN, ec.message().c_str());
	//
	//            // TODO - should we retry?
	//        }
	//        else
	//        {
	//            this->server->StartAcceptingConnection(callback);
	//        }
	//    }
	}

	protected void SuspendChannelAccept()
	{
	//    if (this->server)
	//    {
	//        this->server->Shutdown();
	//        this->server.reset();
	//    }
	}

//    void OnChannelShutdown() final {} // do nothing, always accepting new connections

	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private readonly IPEndpoint endpoint = new IPEndpoint();
	private Server server;
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

