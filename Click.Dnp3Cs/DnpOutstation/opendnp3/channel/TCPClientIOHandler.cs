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

namespace opendnp3
{

public sealed class TCPClientIOHandler : IOHandler
{

	public static TCPClientIOHandler Create(in Logger logger, IChannelListener listener, in ChannelRetry retry, in IPEndpointsList remotes, in string adapter)
	{
		return new TCPClientIOHandler(logger, listener, retry, remotes, adapter);
	}

	public TCPClientIOHandler(in Logger logger, IChannelListener listener, in ChannelRetry retry, in IPEndpointsList remotes, string adapter) : base(logger, false, listener)
	{
		this.retry = new opendnp3.ChannelRetry(retry);
		this.remotes = new opendnp3.IPEndpointsList(remotes);
		this.adapter = std::move(adapter);
	}

	protected override void ShutdownImpl()
	{
		this.ResetState();
	}

	protected override void BeginChannelAccept()
	{
		this.client = TCPClient.Create(logger, adapter);
		this.StartConnect(this.retry.minOpenRetry);
	}

	protected override void SuspendChannelAccept()
	{
		this.ResetState();
	}

	protected override void OnChannelShutdown()
	{
		//if (!client)
		//    return;

		//this->retrytimer = this->executor->start(this->retry.reconnectDelay.value, [this, self = shared_from_this()]() {
		//    if (!client)
		//        return;
		//    this->BeginChannelAccept();
		//});
	}

	private bool StartConnect(in TimeDuration delay)
	{
		if (client == null)
		{
			return false;
		}

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto cb = [=, self = this](asio::ip::tcp::socket socket, const /*std::error_code*/ int& ec)->void
		var cb = (asio.ip.tcp.socket socket, in /*std::error_code*/ int ec) =>
		{
			if (ec != null)
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Error Connecting: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};

				++this.statistics.numOpenFail;

				var newDelay = this.retry.NextDelay(delay);

				if (client != null)
				{
					var retry_cb = () =>
					{
						this.remotes.Next();
						this.StartConnect(newDelay);
					};

					//this->retrytimer = this->executor->start(delay.value, retry_cb);
				}
			}
			else
			{
				//FORMAT_LOG_BLOCK(this->logger, flags::INFO, "Connected to: %s, port %u",
				//                 this->remotes.GetCurrentEndpoint().address.c_str(),
				//                 this->remotes.GetCurrentEndpoint().port);

				//if (client)
				//{
				//    this->OnNewChannel(TCPSocketChannel::Create(executor, std::move(socket)));
				//}
			}
		};

		if (this.logger.is_enabled(opendnp3.flags.Globals.INFO))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Connecting to: %s, port %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			this.logger.log(opendnp3.flags.Globals.INFO, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};

	//    this->client->BeginConnect(this->remotes.GetCurrentEndpoint(), cb);

		return true;
	}

	private void ResetState()
	{
		if (this.client != null)
		{
			this.client.Cancel();
			this.client.reset();
		}

		this.remotes.Reset();

		retrytimer.cancel();
	}

	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private readonly ChannelRetry retry = new ChannelRetry();
	private IPEndpointsList remotes = new IPEndpointsList();
	private readonly string adapter = "";

	// current value of the client
	private TCPClient client;

	// connection retry timer
	private exe4cpp.Timer retrytimer = new exe4cpp.Timer();
}

} // namespace opendnp3




