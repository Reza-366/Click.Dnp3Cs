using System;
using System.Collections;
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
#if false
public class UInt8 
{
    BitArray _array = new BitArray(8);
	public static bool read_from(BitArray input, ref byte @out)
	{
		if (input.Length < size)
		{
			return false;
		}

		@out = read(new RSeq(input));
		input.advance(size);
		return true;
	}

	public static bool write_to(WSeq dest, byte value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new WSeq(dest), new byte(value));
		dest.advance(size);
		return true;
	}

	public const /*size_t*/int size = 1;
	public const byte min_value = 0;
	public const byte max_value = 255;


	private static byte read(byte start)
	{
		return start;
	}

	private static void write(byte start, byte value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: *(start) = value;
		start=value;
	}
}

	//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
	//ORIGINAL LINE: template <class T, byte B0, byte B1>
	//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
	//ORIGINAL LINE: template <class T, typename B0, typename B1> requires(byte<B0> && byte<B1>)
	public class Bit16 <T, B0, B1>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(T) == 2, "bad size");
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < sizeof(T))&& (B1 < sizeof(T))&& (B0 != B1), "bad config");

	public static bool write_to(WSeq dest, T value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new WSeq(dest), value);
		dest.advance(size);
		return true;
	}

	public static bool read_from(RSeq input, ref T @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new RSeq(input));
		input.advance(size);
		return true;
	}


	public static /*size_t*/int size = sizeof(T);
	public const T max_value = default(T);
	public const T min_value = default(T);

	private static T read(byte[] data)
	{
		return ((T)data[B0] << 0) | ((T)data[B1] << 8);
	}

	private static void write(byte[] data, T value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<byte>(value & 0xFF);
		data[B0].CopyFrom((byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((byte)((value >> 8) & 0xFF));
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, byte B0, byte B1>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1> requires(byte<B0> && byte<B1>)
public class Bit32 <T, B0, B1, B2, B3>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(T) == 4, "bad size");
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < sizeof(T))&& (B1 < sizeof(T))&& (B2 < sizeof(T))&& (B3 < sizeof(T)), "bad config");

	public static bool write_to(WSeq dest, T value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new WSeq(dest), value);
		dest.advance(size);
		return true;
	}

	public static bool read_from(RSeq input, ref T @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new RSeq(input));
		input.advance(size);
		return true;
	}


	public static /*size_t*/int size = sizeof(T);
	public const T max_value = default(T);
	public const T min_value = default(T);

	private static T read(byte[] data)
	{
		return ((T)data[B0] << 0) | ((T)data[B1] << 8) | ((T)data[B2] << 16) | ((T)data[B3] << 24);
	}

	private static void write(byte[] data, T value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<byte>(value & 0xFF);
		data[B0].CopyFrom((byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((byte)((value >> 8) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B2] = static_cast<byte>((value >> 16) & 0xFF);
		data[B2].CopyFrom((byte)((value >> 16) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B3] = static_cast<byte>((value >> 24) & 0xFF);
		data[B3].CopyFrom((byte)((value >> 24) & 0xFF));
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, byte B0, byte B1, byte B2, byte B3>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3>)
public class Bit64 <T, B0, B1, B2, B3, B4, B5, B6, B7>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(T) == 8, "bad size");
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < sizeof(T))&& (B1 < sizeof(T))&& (B2 < sizeof(T))&& (B3 < sizeof(T))&& (B4 < sizeof(T))&& (B5 < sizeof(T))&& (B6 < sizeof(T))&& (B7 < sizeof(T)), "bad config");

	public static bool write_to(WSeq dest, T value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new WSeq(dest), value);
		dest.advance(size);
		return true;
	}

	public static bool read_from(RSeq input, ref T @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new RSeq(input));
		input.advance(size);
		return true;
	}


	public static /*size_t*/int size = sizeof(T);
	public const T max_value = default(T);
	public const T min_value = default(T);

	private static T read(byte[] data)
	{
		return ((T)data[B0] << 0) | ((T)data[B1] << 8) | ((T)data[B2] << 16) | ((T)data[B3] << 24) | ((T)data[B4] << 32) | ((T)data[B5] << 40) | ((T)data[B6] << 48) | ((T)data[B7] << 56);
	}

	private static void write(byte[] data, T value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<byte>(value & 0xFF);
		data[B0].CopyFrom((byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((byte)((value >> 8) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B2] = static_cast<byte>((value >> 16) & 0xFF);
		data[B2].CopyFrom((byte)((value >> 16) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B3] = static_cast<byte>((value >> 24) & 0xFF);
		data[B3].CopyFrom((byte)((value >> 24) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B4] = static_cast<byte>((value >> 32) & 0xFF);
		data[B4].CopyFrom((byte)((value >> 32) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B5] = static_cast<byte>((value >> 40) & 0xFF);
		data[B5].CopyFrom((byte)((value >> 40) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B6] = static_cast<byte>((value >> 48) & 0xFF);
		data[B6].CopyFrom((byte)((value >> 48) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B7] = static_cast<byte>((value >> 56) & 0xFF);
		data[B7].CopyFrom((byte)((value >> 56) & 0xFF));
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, byte B0, byte B1, byte B2, byte B3, byte B4, byte B5, byte B6, byte B7>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1, ty
//pename B2, typename B3, typename B4, typename B5, typename B6, typename B7> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3> && byte<B4> && byte<B5> && byte<B6> && byte<B7>)
public class UBit48 <B0, B1, B2, B3, B4, B5>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < 6)&& (B1 < 6)&& (B2 < 6)&& (B3 < 6)&& (B4 < 6)&& (B5 < 6), "bad config");

	public static bool read_from(RSeq input, ref UInt48Type @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new RSeq(input));
		input.advance(size);
		return true;
	}

	public static bool write_to(WSeq dest, UInt48Type value)
	{
		if (dest.length() < size)
		{
			return false;
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: write(dest, value);
		write(new WSeq(dest), new ser4cpp.UInt48Type(value));
		dest.advance(size);
		return true;
	}

	public const /*size_t*/int size = 6;
	public const ulong min_value = 0;
	public const ulong max_value = 281474976710655UL; // 2^48 -1

	public static UInt48Type read(byte[] data)
	{
		return new UInt48Type(((ulong)data[B0] << 0) | ((ulong)data[B1] << 8) | ((ulong)data[B2] << 16) | ((ulong)data[B3] << 24) | ((ulong)data[B4] << 32) | ((ulong)data[B5] << 40));
	}

	public static void write(byte[] data, UInt48Type value)
	{
		if (value > max_value)
		{
			value = new UInt48Type(max_value);
		}

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<byte>(value & 0xFF);
		data[B0].CopyFrom((byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((byte)((value >> 8) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B2] = static_cast<byte>((value >> 16) & 0xFF);
		data[B2].CopyFrom((byte)((value >> 16) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B3] = static_cast<byte>((value >> 24) & 0xFF);
		data[B3].CopyFrom((byte)((value >> 24) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B4] = static_cast<byte>((value >> 32) & 0xFF);
		data[B4].CopyFrom((byte)((value >> 32) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B5] = static_cast<byte>((value >> 40) & 0xFF);
		data[B5].CopyFrom((byte)((value >> 40) & 0xFF));
	}
}
#endif
}

