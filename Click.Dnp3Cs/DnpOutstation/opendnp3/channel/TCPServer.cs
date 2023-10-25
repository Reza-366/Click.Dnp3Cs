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

//#include "../../exe4cpp/asio/StrandExecutor.h"



namespace opendnp3
{

/**
 * Binds and listens on an IPv4 TCP port
 *
 * Meant to be used exclusively as a shared_ptr
 */
public abstract class TCPServer //: public std::enable_shared_from_this<TCPServer>, public IListener, private Uncopyable
{

	public TCPServer(in Logger logger, in IPEndpoint endpoint, std::error_code ec)
		 // executor(executor),
		 // endpoint(asio::ip::tcp::v4(), endpoint.port), //REZA
		 // acceptor(*executor->get_context()),
		//  socket(*executor->get_context())
	{
		this.logger = new opendnp3.Logger(logger);
	   // this->Configure(endpoint.address, ec); //REZA
	}

	/// Implement IListener
	public void Shutdown()
	{
		//REZA
	//    if (this->isShutdown)
	//        return;
	//
	//    this->isShutdown = true;
	//
	//    std::error_code ec;
	//    this->acceptor.close(ec);
	//
	//    if (ec)
	//    {
	//        SIMPLE_LOG_BLOCK(logger, flags::ERR, ec.message().c_str());
	//    }
	}

	/// Inherited classes must define these functions

	protected abstract void OnShutdown();

	protected abstract void AcceptConnection(ulong sessionid);

	/// Start asynchronously accepting connections on the strand
	protected void StartAccept()
	{
		//REZA
	//    // this ensures that the TCPListener is never deleted during an active callback
	//    auto callback = [self = shared_from_this()](std::error_code ec) {
	//        if (ec)
	//        {
	//            SIMPLE_LOG_BLOCK(self->logger, flags::INFO, ec.message().c_str());
	//            self->OnShutdown();
	//        }
	//        else
	//        {
	//            // With epoll, even if the acceptor was closed, if a socket was accepted
	//            // and put in ASIO handler queue, it will survive up to here.
	//            // So we need to make sure we are still alive before really accepting the connection.
	//            if (self->isShutdown)
	//            {
	//                return;
	//            }
	//
	//            // For an unknown reason, the socket may not be properly opened when accepted.
	//            // We simply ignore it.
	//            if (!self->socket.is_open())
	//            {
	//                self->StartAccept();
	//                return;
	//            }
	//
	//            const auto ID = self->session_id;
	//            ++self->session_id;
	//
	//            FORMAT_LOG_BLOCK(self->logger, flags::INFO, "Accepted connection from: %s",
	//                             self->remote_endpoint.address().to_string().c_str());
	//
	//            // method responsible for closing
	//            self->AcceptConnection(ID, self->executor, std::move(self->socket));
	//            self->StartAccept();
	//        }
	//    };
	//
	//    this->acceptor.async_accept(socket, remote_endpoint, this->executor->wrap(callback));
	}

	protected Logger logger = new Logger();
	//std::shared_ptr<exe4cpp::StrandExecutor> executor;


	private void Configure(in string adapter, std::error_code ec)
	{
		//REZA
	//    auto address = asio::ip::address::from_string(adapter, ec);
	//
	//    if (ec)
	//    {
	//        return;
	//    }
	//
	//    endpoint.address(address);
	//    acceptor.open(this->endpoint.protocol(), ec);
	//
	//    if (ec)
	//    {
	//        return;
	//    }
	//
	//    acceptor.set_option(asio::ip::tcp::acceptor::reuse_address(true), ec);
	//
	//    if (ec)
	//    {
	//        return;
	//    }
	//
	//    acceptor.bind(this->endpoint, ec);
	//
	//    if (ec)
	//    {
	//        return;
	//    }
	//
	//    acceptor.listen(asio::socket_base::max_connections, ec);
	//
	//    if (!ec)
	//    {
	//        std::ostringstream oss;
	//        oss << this->endpoint;
	//        FORMAT_LOG_BLOCK(this->logger, flags::INFO, "Listening on: %s", oss.str().c_str());
	//    }
	}

	//REZA
//    asio::ip::tcp::endpoint endpoint;
//    asio::ip::tcp::acceptor acceptor;
//    asio::ip::tcp::socket socket;
//    asio::ip::tcp::endpoint remote_endpoint;
	private bool isShutdown = false;
	private ulong session_id = 0;
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
//#include "../../exe4cpp/asio/StrandExecutor.h"


