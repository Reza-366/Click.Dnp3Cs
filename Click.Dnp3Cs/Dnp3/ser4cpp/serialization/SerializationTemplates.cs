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



// On linux (at least Ubuntu 18.10), termios defines B0
// as a bitrate constant, making the templates compilation
// crash. For now, we just undef it.
#if B0
#undef B0
#endif

namespace ser4cpp
{

public class UInt8
{
	public static bool read_from(rseq_t input, ref System.Byte @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new rseq_t(input));
		input.advance(size);
		return true;
	}

	public static bool write_to(wseq_t dest, System.Byte value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new wseq_t(dest), new System.Byte(value));
		dest.advance(size);
		return true;
	}

	public const size_t size = 1;
	public const System.Byte min_value = 0;
	public const System.Byte max_value = 255;


	private static System.Byte read(System.Byte start)
	{
		return (start);
	}

	private static void write(System.Byte start, System.Byte value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: *(start) = value;
		(start).CopyFrom(value);
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, System.Byte B0, System.Byte B1>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1> requires(System.Byte<B0> && System.Byte<B1>)
public class Bit16 <T, B0, B1>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(T) == 2, "bad size");
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < sizeof(T))&& (B1 < sizeof(T))&& (B0 != B1), "bad config");

	public static bool write_to(wseq_t dest, T value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new wseq_t(dest), value);
		dest.advance(size);
		return true;
	}

	public static bool read_from(rseq_t input, ref T @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new rseq_t(input));
		input.advance(size);
		return true;
	}


	public static size_t size = sizeof(T);
	public const T max_value = default(T);
	public const T min_value = default(T);

	private static T read(System.Byte[] data)
	{
		return ((T)data[B0] << 0) | ((T)data[B1] << 8);
	}

	private static void write(System.Byte[] data, T value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<System.Byte>(value & 0xFF);
		data[B0].CopyFrom((System.Byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<System.Byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((System.Byte)((value >> 8) & 0xFF));
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, System.Byte B0, System.Byte B1>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1> requires(System.Byte<B0> && System.Byte<B1>)
public class Bit32 <T, B0, B1, B2, B3>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(T) == 4, "bad size");
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < sizeof(T))&& (B1 < sizeof(T))&& (B2 < sizeof(T))&& (B3 < sizeof(T)), "bad config");

	public static bool write_to(wseq_t dest, T value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new wseq_t(dest), value);
		dest.advance(size);
		return true;
	}

	public static bool read_from(rseq_t input, ref T @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new rseq_t(input));
		input.advance(size);
		return true;
	}


	public static size_t size = sizeof(T);
	public const T max_value = default(T);
	public const T min_value = default(T);

	private static T read(System.Byte[] data)
	{
		return ((T)data[B0] << 0) | ((T)data[B1] << 8) | ((T)data[B2] << 16) | ((T)data[B3] << 24);
	}

	private static void write(System.Byte[] data, T value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<System.Byte>(value & 0xFF);
		data[B0].CopyFrom((System.Byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<System.Byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((System.Byte)((value >> 8) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B2] = static_cast<System.Byte>((value >> 16) & 0xFF);
		data[B2].CopyFrom((System.Byte)((value >> 16) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B3] = static_cast<System.Byte>((value >> 24) & 0xFF);
		data[B3].CopyFrom((System.Byte)((value >> 24) & 0xFF));
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, System.Byte B0, System.Byte B1, System.Byte B2, System.Byte B3>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3> requires(System.Byte<B0> && System.Byte<B1> && System.Byte<B2> && System.Byte<B3>)
public class Bit64 <T, B0, B1, B2, B3, B4, B5, B6, B7>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(T) == 8, "bad size");
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < sizeof(T))&& (B1 < sizeof(T))&& (B2 < sizeof(T))&& (B3 < sizeof(T))&& (B4 < sizeof(T))&& (B5 < sizeof(T))&& (B6 < sizeof(T))&& (B7 < sizeof(T)), "bad config");

	public static bool write_to(wseq_t dest, T value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		write(new wseq_t(dest), value);
		dest.advance(size);
		return true;
	}

	public static bool read_from(rseq_t input, ref T @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new rseq_t(input));
		input.advance(size);
		return true;
	}


	public static size_t size = sizeof(T);
	public const T max_value = default(T);
	public const T min_value = default(T);

	private static T read(System.Byte[] data)
	{
		return ((T)data[B0] << 0) | ((T)data[B1] << 8) | ((T)data[B2] << 16) | ((T)data[B3] << 24) | ((T)data[B4] << 32) | ((T)data[B5] << 40) | ((T)data[B6] << 48) | ((T)data[B7] << 56);
	}

	private static void write(System.Byte[] data, T value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<System.Byte>(value & 0xFF);
		data[B0].CopyFrom((System.Byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<System.Byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((System.Byte)((value >> 8) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B2] = static_cast<System.Byte>((value >> 16) & 0xFF);
		data[B2].CopyFrom((System.Byte)((value >> 16) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B3] = static_cast<System.Byte>((value >> 24) & 0xFF);
		data[B3].CopyFrom((System.Byte)((value >> 24) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B4] = static_cast<System.Byte>((value >> 32) & 0xFF);
		data[B4].CopyFrom((System.Byte)((value >> 32) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B5] = static_cast<System.Byte>((value >> 40) & 0xFF);
		data[B5].CopyFrom((System.Byte)((value >> 40) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B6] = static_cast<System.Byte>((value >> 48) & 0xFF);
		data[B6].CopyFrom((System.Byte)((value >> 48) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B7] = static_cast<System.Byte>((value >> 56) & 0xFF);
		data[B7].CopyFrom((System.Byte)((value >> 56) & 0xFF));
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <class T, System.Byte B0, System.Byte B1, System.Byte B2, System.Byte B3, System.Byte B4, System.Byte B5, System.Byte B6, System.Byte B7>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3, typename B4, typename B5, typename B6, typename B7> requires(System.Byte<B0> && System.Byte<B1> && System.Byte<B2> && System.Byte<B3> && System.Byte<B4> && System.Byte<B5> && System.Byte<B6> && System.Byte<B7>)
public class UBit48 <B0, B1, B2, B3, B4, B5>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert((B0 < 6)&& (B1 < 6)&& (B2 < 6)&& (B3 < 6)&& (B4 < 6)&& (B5 < 6), "bad config");

	public static bool read_from(rseq_t input, ref UInt48Type @out)
	{
		if (input.length() < size)
		{
			return false;
		}

		@out = read(new rseq_t(input));
		input.advance(size);
		return true;
	}

	public static bool write_to(wseq_t dest, UInt48Type value)
	{
		if (dest.length() < size)
		{
			return false;
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: write(dest, value);
		write(new wseq_t(dest), new ser4cpp.UInt48Type(value));
		dest.advance(size);
		return true;
	}

	public const size_t size = 6;
	public const uint64_t min_value = 0;
	public const uint64_t max_value = 281474976710655UL; // 2^48 -1

	public static UInt48Type read(System.Byte[] data)
	{
		return new UInt48Type(((uint64_t)data[B0] << 0) | ((uint64_t)data[B1] << 8) | ((uint64_t)data[B2] << 16) | ((uint64_t)data[B3] << 24) | ((uint64_t)data[B4] << 32) | ((uint64_t)data[B5] << 40));
	}

	public static void write(System.Byte[] data, UInt48Type value)
	{
		if (value > max_value)
		{
			value = new UInt48Type(max_value);
		}

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B0] = static_cast<System.Byte>(value & 0xFF);
		data[B0].CopyFrom((System.Byte)(value & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B1] = static_cast<System.Byte>((value >> 8) & 0xFF);
		data[B1].CopyFrom((System.Byte)((value >> 8) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B2] = static_cast<System.Byte>((value >> 16) & 0xFF);
		data[B2].CopyFrom((System.Byte)((value >> 16) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B3] = static_cast<System.Byte>((value >> 24) & 0xFF);
		data[B3].CopyFrom((System.Byte)((value >> 24) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B4] = static_cast<System.Byte>((value >> 32) & 0xFF);
		data[B4].CopyFrom((System.Byte)((value >> 32) & 0xFF));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: data[B5] = static_cast<System.Byte>((value >> 40) & 0xFF);
		data[B5].CopyFrom((System.Byte)((value >> 40) & 0xFF));
	}
}

}

