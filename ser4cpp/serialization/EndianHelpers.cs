using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Copyright (c) 2018, Automatak LLC
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the
 * following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following
 * disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following
 * disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote
 * products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
 * USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */


namespace ser4cpp
{

namespace serializers
{

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename T>

} // namespace serializers

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class EndianHelpers : private StaticOnly
public class EndianHelpers : StaticOnly
{

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template <class T, typename... Args>
	public static bool read<T>(RSeq input, T value, Args ... args)
	{
		return ser4cpp.serializers.Globals.read_one(input, value) && read(input, args...);
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template <class T, typename... Args>
	public static bool write<T>(WSeq dest, in T value, in Args ... args)
	{
		return ser4cpp.serializers.Globals.write_one(dest, value) && write(dest, args...);
	}

	private static bool read(RSeq input)
	{
		return true;
	}

	private static bool write(WSeq dest)
	{
		return true;
	}
}

} // namespace ser4cpp

