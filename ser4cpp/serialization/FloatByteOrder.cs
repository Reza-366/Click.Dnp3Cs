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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct FloatByteOrder : private StaticOnly
public class FloatByteOrder : StaticOnly
{
	public enum Value : byte
	{
		normal,
		reverse,
		unsupported
	}

//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
	private static Value order_order = get_byte_order();

	public static Value order()
	{
//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//		static Value order = get_byte_order();
		return order_order;
	}

//C++ TO C# CONVERTER TASK: Unions are not supported in C#:
//	union FloatUnion
//	{
//		byte bytes[4];
//		float f;
//	};

	private static Value get_byte_order()
	{
		if (is_normal_byte_order())
		{
			return FloatByteOrder.Value.normal;
		}
		else if (is_reverse_byte_order())
		{
			return FloatByteOrder.Value.reverse;
		}
		else
		{
			return FloatByteOrder.Value.unsupported;
		}
	}

	private static bool is_normal_byte_order()
	{
//C++ TO C# CONVERTER TASK: The following line could not be converted:
		FloatUnion value =
		{
			{0x00, 0x00, 0xA0, 0xC1}
		};
		return (value.f == -20.0f);
	}

	private static bool is_reverse_byte_order()
	{
//C++ TO C# CONVERTER TASK: The following line could not be converted:
		FloatUnion value =
		{
			{0xC1, 0xA0, 0x00, 0x00}
		};
		return (value.f == -20.0f);
	}
}

}

