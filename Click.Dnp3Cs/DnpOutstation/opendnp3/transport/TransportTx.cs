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


namespace opendnp3
{

/**
State/validation for the DNP3 transport layer's send channel.
*/
public sealed class TransportTx : ITransportSegment
{

	public TransportTx(in Logger logger)
	{
		this.logger = new opendnp3.Logger(logger);
	}

	public void Configure(in Message message)
	{
		Debug.Assert(message.payload.is_not_empty());
		txSegment.clear();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->message = message;
		this.message.CopyFrom(message);
		this.tpduCount = 0;
	}

	// -------  IBufferSegment ------------

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual const Addresses& GetAddresses() const override
	public override Addresses GetAddresses()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->message.addresses;
		return new opendnp3.Addresses(this.message.addresses);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool HasValue() const override
	public override bool HasValue()
	{
		return this.message.payload.length() > 0;
	}

	public override ser4cpp.RSeq GetSegment()
	{
		if (txSegment.is_set())
		{
			return new ser4cpp.RSeq(txSegment.get());
		}

		/*size_t*/int numToSend = (this.message.payload.length() < opendnp3.Globals.MAX_TPDU_PAYLOAD) ? this.message.payload.length() : opendnp3.Globals.MAX_TPDU_PAYLOAD;

		var dest = tpduBuffer.as_wseq().skip(1);
		dest.copy_from(this.message.payload.take(numToSend));

		bool fir = (tpduCount == 0);
		bool fin = (numToSend == this.message.payload.length());
		var destHeader = tpduBuffer.as_wseq();
		ser4cpp.UInt8.write_to(destHeader, TransportHeader.ToByte(fir, fin, new TransportSeqNum(sequence)));

		if (logger.is_enabled(opendnp3.flags.Globals.TRANSPORT_TX))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "FIR: %d FIN: %d SEQ: %u LEN: %zu",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			logger.log(opendnp3.flags.Globals.TRANSPORT_TX, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};

		++statistics.numTransportTx;

		var segment = tpduBuffer.as_seq(numToSend + 1);
		txSegment.set(segment);
		return new RSeq(segment);
	}

	public override bool Advance()
	{
		txSegment.clear();
		/*size_t*/int numToSend = this.message.payload.length() < opendnp3.Globals.MAX_TPDU_PAYLOAD ? this.message.payload.length() : opendnp3.Globals.MAX_TPDU_PAYLOAD;
		this.message.payload.advance(numToSend);
		++tpduCount;
		sequence.Increment();
		return this.message.payload.is_not_empty();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const StackStatistics::Transport::Tx& Statistics() const
	public StackStatistics.Transport.Tx Statistics()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return statistics;
		return new opendnp3.StackStatistics.Transport.Tx(statistics);
	}

	private Message message = new Message();

	private ser4cpp.Settable<ser4cpp.RSeq> txSegment = new ser4cpp.Settable<ser4cpp.RSeq>();

	// Static buffer where we store tpdus that are being transmitted
	private ser4cpp.StaticBuffer<MAX_TPDU_LENGTH> tpduBuffer = new ser4cpp.StaticBuffer<MAX_TPDU_LENGTH>();

	private Logger logger = new Logger();
	private StackStatistics.Transport.Tx statistics = new StackStatistics.Transport.Tx();
	private TransportSeqNum sequence = new TransportSeqNum();
	private uint tpduCount = 0;
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

