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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class LinkFrame : private StaticOnly
public class LinkFrame : StaticOnly
{

	////////////////////////////////////////////////
	//	Functions for formatting outgoing Sec to Pri frames
	////////////////////////////////////////////////

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatAck(WSeq</*size_t*/int> buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatNack(WSeq</*size_t*/int> buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatLinkStatus(WSeq</*size_t*/int> buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatNotSupported(WSeq</*size_t*/int> buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger);

	////////////////////////////////////////////////
	//	Functions for formatting outgoing Pri to Sec frames
	////////////////////////////////////////////////

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatTestLinkStatus(WSeq</*size_t*/int> buffer, bool aIsMaster, bool aFcb, ushort aDest, ushort aSrc, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatResetLinkStates(WSeq</*size_t*/int> buffer, bool aIsMaster, ushort aDest, ushort aSrc, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatRequestLinkStatus(WSeq</*size_t*/int> buffer, bool aIsMaster, ushort aDest, ushort aSrc, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatConfirmedUserData(WSeq</*size_t*/int> buffer, bool aIsMaster, bool aFcb, ushort aDest, ushort aSrc, RSeq</*size_t*/int> user_data, Logger pLogger);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatUnconfirmedUserData(WSeq</*size_t*/int> buffer, bool aIsMaster, ushort aDest, ushort aSrc, RSeq</*size_t*/int> user_data, Logger pLogger);

	////////////////////////////////////////////////
	//	Reusable static formatting functions to any buffer
	////////////////////////////////////////////////

	/** Reads data from src to dest removing 2 byte CRC checks every 16 data bytes
	@param apSrc Source buffer with crc checks. Must begin at data, not header
	@param apDest Destination buffer to which the data is extracted
	@param aLength Length of user data to read to the dest buffer. The source buffer must be larger b/c of crc bytes.
	*/
	public static void ReadUserData(byte pSrc, byte pDest, /*size_t*/int len)
	{
		/*size_t*/int length = new /*size_t*/int(len);
//C++ TO C# CONVERTER TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		byte * pRead = new byte(pSrc);
//C++ TO C# CONVERTER TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		byte * pWrite = new byte(pDest);

		while (length > 0)
		{
			/*size_t*/int max = opendnp3.Globals.LPDU_DATA_BLOCK_SIZE;
			/*size_t*/int num = (length <= ser4cpp.Globals.max) ? length : ser4cpp.Globals.max;
			/*size_t*/int num_with_crc = num + 2;
//C++ TO C# CONVERTER TASK: The memory management function 'memmove' has no equivalent in C#:
			memmove(pWrite, pRead, num);
			pRead += num_with_crc;
			pWrite += num;
			length -= num;
		}
	}

	/** Validates FT3 user data integriry
	@param apBody Beginning of the FT3 user data
	@param aLength Number of user bytes to verify, not user + crc.
	@return True if the body CRC is correct */
//C++ TO C# CONVERTER TASK: Pointer arithmetic is detected on the parameter 'pBody', so pointers on this parameter are left unchanged:
	public static bool ValidateBodyCRC(in byte * pBody, /*size_t*/int length)
	{
		while (length > 0)
		{
			/*size_t*/int max = opendnp3.Globals.LPDU_DATA_BLOCK_SIZE;
			/*size_t*/int num = (length <= ser4cpp.Globals.max) ? length : ser4cpp.Globals.max;

			if (CRC.IsCorrectCRC(new byte(pBody), new /*size_t*/int(num)))
			{
				pBody += (num + 2);
				length -= num;
			}
			else
			{
				return false;
			}
		}
		return true;
	}

	// @return Total frame size based on user data length
	public static /*size_t*/int CalcFrameSize(/*size_t*/int dataLength)
	{
		return opendnp3.Globals.LPDU_HEADER_SIZE + CalcUserDataSize(new /*size_t*/int(dataLength));
	}

	private static /*size_t*/int CalcUserDataSize(/*size_t*/int dataLength)
	{
		if (dataLength > 0)
		{
			/*size_t*/int mod16 = dataLength % opendnp3.Globals.LPDU_DATA_BLOCK_SIZE;
			/*size_t*/int size = (dataLength / opendnp3.Globals.LPDU_DATA_BLOCK_SIZE) * opendnp3.Globals.LPDU_DATA_PLUS_CRC_SIZE; // complete blocks
			return (mod16 > 0) ? (size + mod16 + opendnp3.Globals.LPDU_CRC_SIZE) : size; // possible partial block
		}

		return 0;
	}

	/** Writes data from src to dest interlacing 2 byte CRC checks every 16 data bytes
	    @param apSrc Source buffer full of user data
	    @param apDest Destination buffer where the data + CRC is written
	    @param length Number of user data bytes
	*/
//C++ TO C# CONVERTER TASK: Pointer arithmetic is detected on the parameter 'pSrc', so pointers on this parameter are left unchanged:
//C++ TO C# CONVERTER TASK: Pointer arithmetic is detected on the parameter 'pDest', so pointers on this parameter are left unchanged:
	private static void WriteUserData(in byte * pSrc, byte * pDest, /*size_t*/int length)
	{
		while (length > 0)
		{
			byte max = opendnp3.Globals.LPDU_DATA_BLOCK_SIZE;
			/*size_t*/int num = length > ser4cpp.Globals.max ? ser4cpp.Globals.max : length;
//C++ TO C# CONVERTER TASK: The memory management function 'memcpy' has no equivalent in C#:
			memcpy(pDest, pSrc, num);
			CRC.AddCrc(new byte(pDest), new /*size_t*/int(num));
			pSrc += num;
			pDest += (num + 2);
			length -= num;
		}
	}

	/** Write 10 header bytes to to buffer including 0x0564, all fields, and CRC */
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static RSeq</*size_t*/int> FormatHeader(WSeq</*size_t*/int> buffer, byte aDataLength, bool aIsMaster, bool aFcb, bool aFcvDfc, LinkFunction aFuncCode, ushort aDest, ushort aSrc, Logger pLogger);
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

namespace opendnp3
{

////////////////////////////////////////////////
//
//	Outgoing frame formatting functions for Sec to Pri transactions
//
////////////////////////////////////////////////





////////////////////////////////////////////////
//
//	Outgoing frame formatting functions for Pri to Sec transactions
//
////////////////////////////////////////////////







} // namespace opendnp3
