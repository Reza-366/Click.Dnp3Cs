using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

//#include "../../exe4cpp/IExecutor.h"

namespace opendnp3
{

/**
    Implements the DNP3 transport layer
*/
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class TransportLayer : IUpperLayer, ILowerLayer
{

	public TransportLayer(in Logger logger, uint maxRxFragSize)
	{
		this.logger = new opendnp3.Logger(logger);
		this.receiver = new opendnp3.TransportRx(logger, maxRxFragSize);
		this.transmitter = new opendnp3.TransportTx(logger);
	}

	// ------ ILowerLayer ------


	///////////////////////////////////////
	// Actions
	///////////////////////////////////////

	public override bool BeginTransmit(in Message message)
	{
		if (!isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer offline");
			};
			return false;
		}

		if (message.payload.is_empty())
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "APDU cannot be empty");
			};
			return false;
		}

		if (isSending)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Invalid BeginTransmit call, already transmitting");
			};
			return false;
		}

		if (lower == null)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Can't send without an attached link layer");
			};
			return false;
		}

		isSending = true;
		transmitter.Configure(message);
		lower.Send(transmitter);

		return true;
	}

	// ------ IUpperLayer ------


	///////////////////////////////////////
	// IUpperLayer
	///////////////////////////////////////

	public override bool OnReceive(in Message message)
	{
		if (isOnline)
		{
			var asdu = receiver.ProcessReceive(message);
			if (upper != null && asdu.payload.is_not_empty())
			{
				upper.OnReceive(asdu);
			}
			return true;
		}

		if (logger.is_enabled(opendnp3.flags.Globals.ERR))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer offline");
		};
		return false;
	}

	public override bool OnLowerLayerUp()
	{
		if (isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer already online");
			};
			return false;
		}

		isOnline = true;
		if (upper != null)
		{
			upper.OnLowerLayerUp();
		}
		return true;
	}

	public override bool OnLowerLayerDown()
	{
		if (!isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer already offline");
			};
			return false;
		}

		isOnline = false;
		isSending = false;
		receiver.Reset();

		if (upper != null)
		{
			upper.OnLowerLayerDown();
		}

		return true;
	}

	public override bool OnTxReady()
	{
		if (!isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer offline");
			};
			return false;
		}

		if (!isSending)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Invalid send callback");
			};
			return false;
		}

		isSending = false;

		if (upper != null)
		{
			upper.OnTxReady();
		}

		return true;
	}

	public void SetAppLayer(IUpperLayer upperLayer)
	{
		Debug.Assert(!upper);
		upper = upperLayer;
	}

	public void SetLinkLayer(ILinkLayer linkLayer)
	{
		Debug.Assert(!lower);
		lower = linkLayer;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: StackStatistics::Transport GetStatistics() const
	public StackStatistics.Transport GetStatistics()
	{
		return new StackStatistics.Transport(this.receiver.Statistics(), this.transmitter.Statistics());
	}

	private Logger logger = new Logger();

	private IUpperLayer upper = null;
	private ILinkLayer lower = null;

	// ---- state ----
	private bool isOnline = false;
	private bool isSending = false;

	// ----- Transmitter and Receiver Classes ------
	private TransportRx receiver = new TransportRx();
	private TransportTx transmitter = new TransportTx();
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

