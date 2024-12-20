﻿using System;
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


namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class PrefixFields : private StaticOnly
public class PrefixFields : StaticOnly
{
#if false
		//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
		//ORIGINAL LINE: template<typename... Args>
		public static bool Read(ser4cpp.RSeq input, Args ... fields)
	{
		if (input.length() < (sizeof...(Args) * ser4cpp.Globals.Bit16<ushort, 0, 1>.size))
		{
			// not enough in the buffer to even read the length prefixes
			return false;
		}

		ushort[] lengths = Arrays.InitializeWithDefaultInstances<ushort>(sizeof...(Args));

		for (/*size_t*/int i = 0; i < sizeof...(Args); ++i)
		{
			ser4cpp.Globals.Bit16<ushort, 0, 1>.read_from(input, lengths[i]);
		}

		/*size_t*/int sum = 0;

		for (/*size_t*/int i = 0; i < sizeof...(Args); ++i)
		{
			sum += lengths[i];
		}

		if (input.length() < sum)
		{
			// not enough for the defined fields
			return false;
		}

		ReadFields(input, lengths, fields...);

		return true;
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
	public static bool Write(ser4cpp.wseq_t dest, in Args ... fields)
	{
		var total_size = (sizeof...(Args) * ser4cpp.Globals.Bit16<ushort, 0, 1>.size) + SumSizes(fields...);

		if (dest.length() < total_size)
		{
			return false;
		}

		WriteLengths(dest, fields...);
		WriteFields(dest, fields...);

		return true;
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
	public static bool LengthFitsInUInt16(in ser4cpp.RSeq arg1, Args ... fields)
	{
		return (arg1.length() <= ushort.MaxValue) && LengthFitsInUInt16(fields...);
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
	private static /*size_t*/int SumSizes(in ser4cpp.RSeq arg1, Args ... fields)
	{
		return arg1.length() + SumSizes(fields...);
	}

	private static bool LengthFitsInUInt16()
	{
		return true;
	}

	private static /*size_t*/int SumSizes()
	{
		return 0;
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
//C++ TO C# CONVERTER TASK: Pointer arithmetic is detected on the parameter 'pLength', so pointers on this parameter are left unchanged:
	private static void ReadFields(ser4cpp.RSeq input, ushort * pLength, ref ser4cpp.RSeq output, Args ... fields)
	{
		output = input.take(*pLength);
		input.advance(*pLength);
		ReadFields(input, ++pLength, fields...);
	}

	private static void ReadFields(ser4cpp.RSeq input, ushort pLength)
	{
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
	private static void WriteLengths(ser4cpp.wseq_t dest, in ser4cpp.RSeq arg1, Args ... fields)
	{
		ser4cpp.Globals.Bit16<ushort, 0, 1>.write_to(dest, (ushort)arg1.length());
		WriteLengths(dest, fields...);
	}

	private static void WriteLengths(ser4cpp.wseq_t dest)
	{
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
	private static void WriteFields(ser4cpp.wseq_t dest, in ser4cpp.RSeq arg1, Args ... fields)
	{
		dest.copy_from(arg1);
		WriteFields(dest, fields...);
	}

	private static void WriteFields(ser4cpp.wseq_t dest)
	{
	}
#endif
}

} // namespace opendnp3

