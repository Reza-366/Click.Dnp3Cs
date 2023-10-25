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

/**
 * Callback interface invoked when a new connection is accepted
 */
public sealed class DefaultListenCallbacks : IListenCallbacks
{
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	DefaultListenCallbacks();

	public override void Dispose()
	{
		base.Dispose();
	}

	public override bool AcceptConnection(ulong sessionid, in string ipaddress)
	{
		return true;
	}

	public override bool AcceptCertificate(ulong sessionid, in X509Info info)
	{
		return true;
	}

	public override TimeDuration GetFirstFrameTimeout()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return TimeDuration::Seconds(30);
		return new opendnp3.TimeDuration(TimeDuration.Seconds(30));
	}

	public override void OnFirstFrame(ulong sessionid, in LinkHeaderFields header, ISessionAcceptor acceptor)
	{
		MasterStackConfig config = new MasterStackConfig();

		// full implementations will look up config information for the SRC address

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: config.link.LocalAddr = header.addresses.destination;
		config.link.LocalAddr.CopyFrom(header.addresses.destination);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: config.link.RemoteAddr = header.addresses.source;
		config.link.RemoteAddr.CopyFrom(header.addresses.source);

		var soe = new PrintingSOEHandler();
		var app = new DefaultMasterApplication();

		// full implementations will keep a std::shared_ptr<IGPRSMaster> somewhere
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: auto master = acceptor.AcceptSession(SessionIdToString(sessionid), soe, app, config);
		var master = acceptor.AcceptSession(SessionIdToString(new ulong(sessionid)), new opendnp3.PrintingSOEHandler(soe), new opendnp3.DefaultMasterApplication(app), config);
	}

	public override void OnConnectionClose(ulong sessionid, IMasterSession session)
	{
		// full implementations would drop any references they're holding to this session
		// shared_ptr can be used with == operator also
	}

	public override void OnCertificateError(ulong sessionid, in X509Info info, int error)
	{
	}

	private string SessionIdToString(ulong id)
	{
		std::ostringstream oss = new std::ostringstream();
		oss << "session-" << id;
		return oss.str();
	}
}

} // namespace opendnp3




namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//DefaultListenCallbacks::DefaultListenCallbacks() = default;

} // namespace opendnp3
