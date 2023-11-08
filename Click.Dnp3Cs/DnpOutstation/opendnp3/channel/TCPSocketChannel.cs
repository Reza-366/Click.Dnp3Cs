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


namespace opendnp3
{

public sealed class TCPSocketChannel : IAsyncChannel
{

	public static IAsyncChannel Create(asio.ip.tcp.socket socket)
	{
	//static std::shared_ptr<IAsyncChannel> Create(std::shared_ptr<exe4cpp::StrandExecutor> executor)
		return new TCPSocketChannel(std::move(socket));
	}

	public TCPSocketChannel(asio.ip.tcp.socket socket)
	{
		this.socket = new asio.ip.tcp.socket(std::move(socket));
	}

	protected override void BeginReadImpl(WSeq</*size_t*/int> dest)
	{
	//    auto callback = [this](const /*std::error_code*/ int& ec, /*size_t*/int num) { this->OnReadCallback(ec, num); };
	//
	//    socket.async_read_some(asio::buffer(dest, dest.length()), this->executor->wrap(callback));
	}

	protected override void BeginWriteImpl(in RSeq/*<size_t>*/ buffer)
	{
	//    auto callback = [this](const /*std::error_code*/ int& ec, /*size_t*/int num) { this->OnWriteCallback(ec, num); };
	//
	//    asio::async_write(socket, asio::buffer(buffer, buffer.length()), this->executor->wrap(callback));
	}

	protected override void ShutdownImpl()
	{
	//    /*std::error_code*/ int ec;
	//    socket.shutdown(asio::socket_base::shutdown_type::shutdown_both, ec);
	//    socket.close(ec);
	}

	private asio.ip.tcp.socket socket = new asio.ip.tcp.socket();
}

} // namespace opendnp3



