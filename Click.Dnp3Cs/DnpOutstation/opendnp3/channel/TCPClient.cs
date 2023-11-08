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


namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class TCPClient final : public std::enable_shared_from_this<TCPClient>, private Uncopyable
public sealed class TCPClient : Uncopyable
{

	public delegate void connect_callback_t(in /*std::error_code*/ int ec);

	public static TCPClient Create(in Logger logger, in string adapter)
	{
		return new TCPClient(logger, adapter);
	}

	public TCPClient(in Logger logger, string adapter)
	{
		this.condition = new opendnp3.LoggingConnectionCondition(logger);
		this.adapter = std::move(adapter);
	}

	public bool Cancel()
	{
		if (this.canceled || !this.connecting)
		{
			return false;
		}

		/*std::error_code*/ int ec = new /*std::error_code*/ int();
	//    socket.cancel(ec);
	//    resolver.cancel();
		this.canceled = true;
		return true;
	}

	public bool BeginConnect(in IPEndpoint remote, in connect_callback_t callback)
	{
	//    if (connecting || canceled)
	//        return false;
	//
	//    this->connecting = true;
	//
	//    /*std::error_code*/ int ec;
	//    SocketHelpers::BindToLocalAddress<asio::ip::tcp>(this->adapter, 0, this->socket, ec);
	//
	//    if (ec)
	//    {
	//        return this->PostConnectError(callback, ec);
	//    }
	//
	//    const auto address = asio::ip::address::from_string(remote.address, ec);
	//    auto self = this->shared_from_this();
	//    if (ec)
	//    {
	//        // Try DNS resolution instead
	//        auto cb = [self, callback](const /*std::error_code*/ int& ec, asio::ip::tcp::resolver::iterator endpoints) {
	//            self->HandleResolveResult(callback, endpoints, ec);
	//        };
	//
	//        std::stringstream portstr;
	//        portstr << remote.port;
	//
	//        resolver.async_resolve(asio::ip::tcp::resolver::query(remote.address, portstr.str()), executor->wrap(cb));
	//
	//        return true;
	//    }
	//
	//    asio::ip::tcp::endpoint remoteEndpoint(address, remote.port);
	//    auto cb = [self, callback](const /*std::error_code*/ int& ec) {
	//        self->connecting = false;
	//        if (!self->canceled)
	//        {
	//            callback(self->executor, std::move(self->socket), ec);
	//        }
	//    };
	//
	//    socket.async_connect(remoteEndpoint, executor->wrap(cb));
	//    return true;
		return true;
	}

	private void HandleResolveResult(in connect_callback_t callback, in /*std::error_code*/ int ec)
	{
	//    if (ec)
	//    {
	//        this->PostConnectError(callback, ec);
	//    }
	//    else
	//    {
	//        // attempt a connection to each endpoint in the iterator until we connect
	//        auto cb = [self = shared_from_this(), callback](const /*std::error_code*/ int& ec,
	//                                                        //asio::ip::tcp::resolver::iterator endpoints //reza
	//														) {
	//            self->connecting = false;
	//            if (!self->canceled)
	//            {
	//                callback(self->executor, std::move(self->socket), ec);
	//            }
	//        };
	//
	//        asio::async_connect(this->socket, endpoints, this->condition, this->executor->wrap(cb));
	//    }
	}

	private bool PostConnectError(in connect_callback_t callback, in /*std::error_code*/ int ec)
	{
	//    auto cb = [self = shared_from_this(), ec, callback]() {
	//        self->connecting = false;
	//        if (!self->canceled)
	//        {
	//            callback(self->executor, std::move(self->socket), ec);
	//        }
	//    };
	//    executor->post(cb);
	//    return true;
		return true;
	}

	private bool connecting = false;
	private bool canceled = false;

	private LoggingConnectionCondition condition = new LoggingConnectionCondition();
	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private readonly string adapter = "";
//  asio::ip::tcp::socket socket;
//  asio::ip::tcp::endpoint localEndpoint;
//  asio::ip::tcp::resolver resolver;
}

} // namespace opendnp3




