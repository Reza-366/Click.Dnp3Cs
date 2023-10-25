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

public sealed class UDPClientIOHandler : IOHandler
{

	public static UDPClientIOHandler Create(in Logger logger, IChannelListener listener, in ChannelRetry retry, in IPEndpoint localEndpoint, in IPEndpoint remoteEndpoint)
	{
		return new UDPClientIOHandler(logger, listener, retry, localEndpoint, remoteEndpoint);
	}

	public UDPClientIOHandler(in Logger logger, IChannelListener listener, in ChannelRetry retry, in IPEndpoint localEndpoint, in IPEndpoint remoteEndpoint) : base(logger, false, listener)
	{
		this.retry = new opendnp3.ChannelRetry(retry);
		this.localEndpoint = new opendnp3.IPEndpoint(localEndpoint);
		this.remoteEndpoint = new opendnp3.IPEndpoint(remoteEndpoint);
	}

	protected override void ShutdownImpl()
	{
		this.ResetState();
	}

	protected override void BeginChannelAccept()
	{
	//    client = std::make_shared<UDPClient>(logger, executor);
	//    this->TryOpen(this->retry.minOpenRetry);
	}

	protected override void SuspendChannelAccept()
	{
	//    this->ResetState();
	}

	protected override void OnChannelShutdown()
	{
	//    this->retrytimer = this->executor->start(this->retry.reconnectDelay.value, [this, self = shared_from_this()]() {
	//        this->BeginChannelAccept();
	//	}
	//);
	}

	private bool TryOpen(in TimeDuration delay)
	{
	//    if (!client)
	//    {
	//        return false;
	//    }
	//
	//    auto cb = [=, self = shared_from_this()](const std::shared_ptr<exe4cpp::StrandExecutor>& executor,
	//                                             asio::ip::udp::socket socket, const std::error_code& ec) -> void {
	//        if (ec)
	//        {
	//            FORMAT_LOG_BLOCK(this->logger, flags::WARN, "Error opening UDP socket: %s", ec.message().c_str());
	//
	//            ++this->statistics.numOpenFail;
	//
	//            const auto newDelay = this->retry.NextDelay(delay);
	//
	//            if (client)
	//            {
	//                auto retry_cb = [self, newDelay, this]() { this->TryOpen(newDelay); };
	//
	//                this->retrytimer = this->executor->start(delay.value, retry_cb);
	//            }
	//        }
	//        else
	//        {
	//            FORMAT_LOG_BLOCK(this->logger, flags::INFO, "UDP socket binded to: %s, port %u, sending to %s, port %u",
	//                             socket.local_endpoint().address().to_string().c_str(), socket.local_endpoint().port(),
	//                             socket.remote_endpoint().address().to_string().c_str(), socket.remote_endpoint().port());
	//
	//            if (client)
	//            {
	//                this->OnNewChannel(UDPSocketChannel::Create(executor, this->logger, std::move(socket)));
	//            }
	//        }
	//    };
	//
	//    FORMAT_LOG_BLOCK(this->logger, flags::INFO, "Binding UDP socket to: %s, port %u, resolving address: %s, port %u",
	//                     localEndpoint.address.c_str(), localEndpoint.port,
	//                     remoteEndpoint.address.c_str(), remoteEndpoint.port);
	//
	//    this->client->Open(localEndpoint, remoteEndpoint, cb);
	//
	//    return true;
		return true;
	}

	private void ResetState()
	{
	//    if (this->client)
	//    {
	//        this->client->Cancel();
	//        this->client.reset();
	//    }
	//
	//    retrytimer.cancel();
	}

	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private readonly ChannelRetry retry = new ChannelRetry();
	private readonly IPEndpoint localEndpoint = new IPEndpoint();
	private readonly IPEndpoint remoteEndpoint = new IPEndpoint();

	// current value of the client
	private UDPClient client;

	// connection retry timer
	//exe4cpp::Timer retrytimer;
}

} // namespace opendnp3




