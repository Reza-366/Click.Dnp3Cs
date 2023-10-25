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

/// Parses FT3 frames
public class LinkLayerParser
{
	private enum State
	{
		FindSync,
		ReadHeader,
		ReadBody,
		Complete
	}

	/// @param logger_ Logger that the receiver is to use.
	/// @param pSink_ Completely parsed frames are sent to this interface
	public LinkLayerParser(in Logger logger)
	{
		this.logger = new opendnp3.Logger(logger);
		this.state = new opendnp3.LinkLayerParser.State.FindSync;
		this.frameSize = 0;
		this.buffer = new opendnp3.ShiftableBuffer(rxBuffer, opendnp3.Globals.LPDU_MAX_FRAME_SIZE);
	}

	/// Called when valid data has been written to the current buffer write position
	/// Parses the new data and calls the specified frame sink
	/// @param numBytes Number of bytes written
	public void OnRead(size_t numBytes, IFrameSink sink)
	{
		buffer.AdvanceWrite(new size_t(numBytes));

		while (ParseUntilComplete() == State.Complete)
		{
			++statistics.numLinkFrameRx;
			this.PushFrame(sink);
			state = State.FindSync;
		}

		buffer.Shift();
	}

	/// @return Buffer that can currently be used for writing
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: WSeq<size_t> WriteBuff() const
	public WSeq<size_t> WriteBuff()
	{
		return WSeq<size_t>(buffer.WriteBuff(), buffer.NumWriteBytes());
	}

	/// Resets the state of parser
	public void Reset()
	{
		state = State.FindSync;
		frameSize = 0;
		buffer.Reset();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const LinkStatistics::Parser& Statistics() const
	public LinkStatistics.Parser Statistics()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->statistics;
		return new opendnp3.LinkStatistics.Parser(this.statistics);
	}

	private LinkLayerParser.State ParseUntilComplete()
	{
		var lastState = this.state;
		// continue as long as we're making progress, i.e. a state change
		while ((this.state = ParseOneStep()) != lastState)
		{
			lastState = state;
		}
		return state;
	}

	private LinkLayerParser.State ParseOneStep()
	{
		switch (state)
		{
		case (State.FindSync):
			return ParseSync();
		case (State.ReadHeader):
			return ParseHeader();
		case (State.ReadBody):
			return ParseBody();
		default:
			return state;
		}
	}

	private LinkLayerParser.State ParseSync()
	{
		if (this.buffer.NumBytesRead() >= 10) // && buffer.Sync())
		{
			size_t skipCount = 0;
			var synced = buffer.Sync(skipCount);
			if (skipCount > 0)
			{
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Skipped %zu bytes seaching for start bytes",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
				};
			}

			return synced ? State.ReadHeader : State.FindSync;
		}

		return State.FindSync;
	}

	private LinkLayerParser.State ParseHeader()
	{
		if (this.buffer.NumBytesRead() >= 10)
		{
			if (this.ReadHeader())
			{
				return State.ReadBody;
			}

			this.FailFrame();
			return State.FindSync;
		}
		else
		{
			return State.ReadHeader;
		}
	}

	private LinkLayerParser.State ParseBody()
	{
		if (buffer.NumBytesRead() < this.frameSize)
		{
			return State.ReadBody;
		}

		if (this.ValidateBody())
		{
			this.TransferUserData();
			return State.Complete;
		}

		this.FailFrame();
		return State.FindSync;
	}

	private void PushFrame(IFrameSink sink)
	{
		LinkHeaderFields fields = new LinkHeaderFields(header.GetFuncEnum(), header.IsFromMaster(), header.IsFcbSet(), header.IsFcvDfcSet(), new Addresses(header.GetSrc(), header.GetDest()));

		sink.OnFrame(fields, userData);

		buffer.AdvanceRead(new size_t(frameSize));
	}

	private bool ReadHeader()
	{
		header.Read(buffer.ReadBuffer());
		if (CRC.IsCorrectCRC(buffer.ReadBuffer(), LinkHeaderIndex.LI_CRC))
		{
			return ValidateHeaderParameters();
		}
		else
		{
			++statistics.numHeaderCrcError;
			if (logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "CRC failure in header");
			};
			return false;
		}
	}

	private bool ValidateBody()
	{
		System.UInt32 len = header.GetLength() - opendnp3.Globals.LPDU_MIN_LENGTH;
		if (LinkFrame.ValidateBodyCRC(buffer.ReadBuffer() + opendnp3.Globals.LPDU_HEADER_SIZE, new System.UInt32(len)))
		{
			if (logger.is_enabled(opendnp3.flags.Globals.LINK_RX))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Function: %s Dest: %u Source: %u Length: %u",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.LINK_RX, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
			};

			if (logger.is_enabled(opendnp3.flags.Globals.LINK_RX_HEX))
			{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::LINK_RX_HEX, buffer.ReadBuffer().take(frameSize), ' ', 10, 18);
				opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.LINK_RX_HEX), buffer.ReadBuffer().take(frameSize), ' ', 10, 18);
			};

			return true;
		}

		++this.statistics.numBodyCrcError;
		if (logger.is_enabled(opendnp3.flags.Globals.ERR))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", "CRC failure in body");
		};
		return false;
	}

	private bool ValidateHeaderParameters()
	{
		if (!header.ValidLength())
		{
			++statistics.numBadLength;
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "LENGTH out of range [5,255]: %i",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
			};
			return false;
		}

		// Now make sure that the function code is known and that the FCV is appropriate
		if (!this.ValidateFunctionCode())
		{
			return false;
		}

		System.Byte user_data_length = header.GetLength() - opendnp3.Globals.LPDU_MIN_LENGTH;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: frameSize = LinkFrame::CalcFrameSize(user_data_length);
		frameSize.CopyFrom(LinkFrame.CalcFrameSize(new System.Byte(user_data_length)));
		LinkFunction func = header.GetFuncEnum();

		bool has_payload = user_data_length > 0;
		bool should_have_payload = (func == LinkFunction.PRI_CONFIRMED_USER_DATA || func == LinkFunction.PRI_UNCONFIRMED_USER_DATA);

		// make sure that the presence/absence of user data matches the function code
		if (should_have_payload && !has_payload)
		{
			++statistics.numBadLength;
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "User data with no payload. FUNCTION: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
			};
			return false;
		}

		if (!should_have_payload && has_payload)
		{
			++statistics.numBadLength;
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unexpected LENGTH in frame: %i with FUNCTION: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
			};
			return false;
		}

		// calculate the total frame size
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: frameSize = LinkFrame::CalcFrameSize(user_data_length);
		frameSize.CopyFrom(LinkFrame.CalcFrameSize(new System.Byte(user_data_length)));

		return true;
	}

	private bool ValidateFunctionCode()
	{
		// Now make sure that the function code is known and that the FCV is appropriate
		if (header.IsPriToSec())
		{
			bool fcv_set = false;

			switch (header.GetFuncEnum())
			{
			case (LinkFunction.PRI_CONFIRMED_USER_DATA):
			case (LinkFunction.PRI_TEST_LINK_STATES):
				fcv_set = true;
				break;
			case (LinkFunction.PRI_REQUEST_LINK_STATUS):
			case (LinkFunction.PRI_RESET_LINK_STATES):
			case (LinkFunction.PRI_UNCONFIRMED_USER_DATA):
				break;
			default:
			{
				++statistics.numBadFunctionCode;
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unknown PriToSec FUNCTION: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
				};
				return false;
			}
			}

			// now check the fcv
			if (fcv_set != header.IsFcvDfcSet())
			{
				++statistics.numBadFCV;
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Bad FCV for FUNCTION: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
				};
				return false;
			}

			// if fcv isn't expected to be set, fcb can be either 1 or 0, doesn't matter
		}
		else // SecToPri - just validate the function codes and that FCB is 0
		{
			switch (header.GetFuncEnum())
			{
			case (LinkFunction.SEC_ACK):
			case (LinkFunction.SEC_NACK):
			case (LinkFunction.SEC_LINK_STATUS):
			case (LinkFunction.SEC_NOT_SUPPORTED):
				break;
			default:
			{
				++statistics.numBadFunctionCode;
				if (logger.is_enabled(opendnp3.flags.Globals.ERR))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unknown SecToPri FUNCTION: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
				};
				return false;
			}
			}

			// now check the fcb, it should always be zero
			if (header.IsFcbSet())
			{
				++statistics.numBadFCB;
				if (logger.is_enabled(opendnp3.flags.Globals.ERR))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "FCB set for SecToPri FUNCTION: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.ERR, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
				};
				return false;
			}
		}

		return true; // valid!
	}

	private void FailFrame()
	{
		// All you have to do is advance the reader by one, when the resync happens the data will disappear
		buffer.AdvanceRead(1);
	}

	private void TransferUserData()
	{
		System.UInt32 len = header.GetLength() - opendnp3.Globals.LPDU_MIN_LENGTH;
		LinkFrame.ReadUserData(buffer.ReadBuffer() + opendnp3.Globals.LPDU_HEADER_SIZE, rxBuffer, new System.UInt32(len));
		userData = RSeq<size_t>(rxBuffer, len);
	}

	private Logger logger = new Logger();
	private LinkStatistics.Parser statistics = new LinkStatistics.Parser();

	private LinkHeader header = new LinkHeader();

	private State state;
	private size_t frameSize = new size_t();
	private RSeq<size_t> userData = new RSeq<size_t>();

	// buffer where received data is written
	private System.Byte[] rxBuffer = Arrays.InitializeWithDefaultInstances<System.Byte>(LPDU_MAX_FRAME_SIZE);

	// facade over the rxBuffer that provides ability to "shift" as data is read
	private ShiftableBuffer buffer = new ShiftableBuffer();
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

