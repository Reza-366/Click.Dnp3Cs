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

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define STRINGIFY(x) #x
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define TOSTRING(x) STRINGIFY(x)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOCATION __FILE__ "(" TOSTRING(__LINE__) ")"

namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class HexLogging : private ser4cpp::StaticOnly
public class HexLogging : ser4cpp.StaticOnly
{
	private static uint max_hex_per_line = max_log_entry_size / 3;

	public static void log(Logger logger, LogLevel level, in RSeq</*size_t*/int> source, char separator = ' ', uint first_row_size = max_hex_per_line, uint other_row_size = max_hex_per_line)
	{
		RSeq</*size_t*/int> copy = new RSeq</*size_t*/int>(source);
		uint row = 0;

		var max_first_size = ser4cpp.Globals.bounded<uint>(new uint(first_row_size), 1, new uint(max_hex_per_line));
		var max_other_size = ser4cpp.Globals.bounded<uint>(new uint(other_row_size), 1, new uint(max_hex_per_line));

		while (copy.is_not_empty())
		{
			var row_size = (row == 0) ? max_first_size : max_other_size;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: copy = log_line(logger, level, copy, separator, row_size);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
			copy.CopyFrom(log_line(logger, new opendnp3.LogLevel(level), copy, separator, row_size));
			++row;
		}
	}

	private static RSeq</*size_t*/int> log_line(Logger logger, LogLevel level, in RSeq</*size_t*/int> data, char separator, uint max_row_size)
	{
		string buffer = new string(new char[opendnp3.Globals.max_log_entry_size]);

		uint count = 0;

		while ((count < max_row_size) && (count < data.length()))
		{
			var pos = count * 3;
			buffer = StringFunctions.ChangeCharacter(buffer, pos, ser4cpp.HexConversions.to_hex_char((data[count] & 0xF0) >> 4));
			buffer = StringFunctions.ChangeCharacter(buffer, pos + 1, ser4cpp.HexConversions.to_hex_char(data[count] & 0x0F));
			buffer = StringFunctions.ChangeCharacter(buffer, pos + 2, separator);
			++count;
		}

		buffer = StringFunctions.ChangeCharacter(buffer, (3 * count) - 1, '\0');

//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
		logger.log(level, "__FILE__ ( __LINE__ )", buffer);

		return data.skip(count);
	}
}

} // namespace opendnp3

