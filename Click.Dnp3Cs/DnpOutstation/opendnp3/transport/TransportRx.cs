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
State/validation for the DNP3 transport layer's receive channel.
*/
public class TransportRx
{

	public TransportRx(in Logger logger, uint maxRxFragSize)
	{
		this.logger = new opendnp3.Logger(logger);
		this.rxBuffer = new ser4cpp.Buffer(maxRxFragSize);
		this.numBytesRead = 0;
	}

	public Message ProcessReceive(in Message segment)
	{
		++statistics.numTransportRx;

		if (segment.payload.is_empty())
		{
			FORMAT_LOG_BLOCK(logger, opendnp3.flags.Globals.WARN, "Received tpdu with no header");
			++statistics.numTransportErrorRx;
			return new Message();
		}

		TransportHeader header = new TransportHeader(segment.payload[0]);

		var payload = segment.payload.skip(1);

		if (logger.is_enabled(opendnp3.flags.Globals.TRANSPORT_RX))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "FIR: %d FIN: %d SEQ: %u LEN: %zu",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			logger.log(opendnp3.flags.Globals.TRANSPORT_RX, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};

		if (header.fir && this.numBytesRead > 0)
		{
			++statistics.numTransportDiscard;
			if (logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "FIR received mid-fragment, discarding previous bytes");
			};
			this.numBytesRead = 0;
			// continue processing
		}

		// there are special checks we must perform if it isn't the first packet
		if (!header.fir)
		{
			if (this.numBytesRead == 0)
			{
				++statistics.numTransportIgnore;
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "non-FIR packet with 0 prior bytes");
				};
				return new Message(); // drop the data
			}

			if (header.seq != this.expectedSeq)
			{
				++statistics.numTransportIgnore;
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Received segment w/ seq: %u, expected: %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return new Message(); // drop the data
			}

			if (segment.addresses != this.lastAddresses)
			{
				++statistics.numTransportIgnore;
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Bad addressing: last { src: %u, dest: %u } received { src: %u, dest: %u}",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return new Message(); // drop the data
			}
		}

		var available = this.GetAvailable();

		if (payload.length() > available.length())
		{
			// transport buffer overflow
			++statistics.numTransportBufferOverflow;
			if (logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Exceeded the buffer size before a complete fragment was read");
			};
			this.numBytesRead = 0;
			return new Message();
		}

		available.copy_from(payload);

		this.numBytesRead += payload.length();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->lastAddresses = segment.addresses;
		this.lastAddresses.CopyFrom(segment.addresses);
		this.expectedSeq = header.seq;
		this.expectedSeq.Increment();

		if (header.fin)
		{
			var ret = rxBuffer.as_rslice().take(numBytesRead);
			this.numBytesRead = 0;
			return new Message(segment.addresses, ret);
		}

		return new Message();
	}

	public void Reset()
	{
		this.ClearRxBuffer();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const StackStatistics::Transport::Rx& Statistics() const
	public StackStatistics.Transport.Rx Statistics()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return statistics;
		return new opendnp3.StackStatistics.Transport.Rx(statistics);
	}

	private WSeq</*size_t*/int> GetAvailable()
	{
		return rxBuffer.as_wslice().skip(numBytesRead);
	}

	private void ClearRxBuffer()
	{
		numBytesRead = 0;
	}

	private Logger logger = new Logger();
	private StackStatistics.Transport.Rx statistics = new StackStatistics.Transport.Rx();

	private ser4cpp.Buffer rxBuffer = new ser4cpp.Buffer();
	private /*size_t*/int numBytesRead = new /*size_t*/int();
	private Addresses lastAddresses = new Addresses();

	private TransportSeqNum expectedSeq = new TransportSeqNum();
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

