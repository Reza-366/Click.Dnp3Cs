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

public sealed class SerialChannel //: public IAsyncChannel //REZA
{

	public static SerialChannel Create()
	{
		return new SerialChannel();
	}

	public SerialChannel()
	{
		//: IAsyncChannel(), port() //REZA
	}

	public bool Open(in SerialSettings settings, ref std::error_code ec)
	{
		port.open(settings.deviceName, new std::error_code(ec));
		if (ec != null)
		{
			return false;
		}

#if USE_FLOCK
		var r = flock(port.native_handle(), LOCK_EX | LOCK_NB);
		if (r < 0)
		{
			ec = std::make_error_code(std::errc.device_or_resource_busy);
			return false;
		}
#endif

		Configure(settings, port, ec);

		if (ec != null)
		{
			port.close();
			return false;
		}

		return true;
	}

	private void BeginReadImpl(WSeq</*size_t*/int> buffer)
	{
	//    auto callback = [this](const std::error_code& ec, /*size_t*/int num) { this->OnReadCallback(ec, num); };
	//    port.async_read_some(asio::buffer(buffer, buffer.length()), this->executor->wrap(callback)); // REZA
	}

	private void BeginWriteImpl(in RSeq/*<size_t>*/ buffer)
	{
	  //  auto callback = [this](const std::error_code& ec, /*size_t*/int num) { this->OnWriteCallback(ec, num); };
		//async_write(port, asio::buffer(buffer, buffer.length()), this->executor->wrap(callback)); //REZA
	}

	private void ShutdownImpl()
	{
		std::error_code ec = new std::error_code();
#if USE_FLOCK
		/* Explicitly unlock serial device handler before exiting.*/
		flock(port.native_handle(), LOCK_UN);
#endif
		port.close(new std::error_code(ec));
	}

	private asio.serial_port port = new asio.serial_port();
}

} // namespace opendnp3




#if USE_FLOCK
//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include <sys/file.h>

#endif

