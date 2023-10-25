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


//#include <asio.hpp>


namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class SocketHelpers : private StaticOnly
public class SocketHelpers : StaticOnly
{

	/**
	 * Bind a socket object to a local endpoint given an address. If the address is empty, 0.0.0.0 is used
	 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename proto_t, typename socket_t>
	public static void BindToLocalAddress<proto_t, socket_t>(in string address, ushort port, socket_t socket, std::error_code ec)
	{
//        typename proto_t::endpoint endpoint;
//        auto string = address.empty() ? "0.0.0.0" : address;
//        auto addr = asio::ip::address::from_string(string, ec);
//        if (!ec)
//        {
//            endpoint.address(addr);
//            endpoint.port(port);
//            socket.open(proto_t::v4(), ec);
//            if (!ec)
//            {
//                socket.bind(endpoint, ec);
//            }
//        }
	}
}

} // namespace opendnp3

