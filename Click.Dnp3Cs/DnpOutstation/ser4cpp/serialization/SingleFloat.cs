using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

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
//ORIGINAL LINE: class SingleFloat : private StaticOnly
public class SingleFloat : StaticOnly
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(sizeof(float) == 4, "Unexpected length of single float");

	public static bool read_from(rseq_t input, ref float @out)
	{
		uint value = new uint();
		if (uint.read_from(input, value))
		{
			@out = to_float32(new uint(value));
			return true;
		}

		return false;
	}

	public static bool write_to(wseq_t dest, float value)
	{
		if (dest.length() < size)
		{
			return false;
		}

		var uint32_value = to_uint32(value);
		return uint.write_to(dest, uint32_value);
	}

	public static float to_float32(in uint value)
	{
		// Extract the required values
		bool sign = (value & 0x80000000) != 0;
		byte exponent = (byte)((value >> 23) & 0xFF);
		uint mantissa = value & 0x7FFFFF;

		// Check special cases
		if (exponent == 0xFF)
		{
			if (mantissa != 0)
			{
				return numeric_limits<float>.quiet_NaN();
			}
			else
			{
				if (!sign)
				{
					return float.PositiveInfinity;
				}
				else
				{
					return -float.PositiveInfinity;
				}

			}
		}
		if (exponent == 0 && mantissa == 0)
		{
			return 0.0f;
		}

		// Build the actual value
		var weighted_mantissa = (float)mantissa / (uint({1}) << 23);
		float result;
		if (exponent == 0)
		{
			result = std::ldexp(weighted_mantissa, 2 - (ushort({1}) << 8));
		}
		else
		{
			result = std::ldexp(1.0f + weighted_mantissa, exponent - 127);
		}

		// Adjust the sign
		if (sign)
		{
			result = -result;
		}

		return result;
	}

	public static uint to_uint32(in float value)
	{
		uint encoded_value = new uint();

		if (Math.IsNaN(value))
		{
			// NaN has all exponent bit set to 1, and mantissa with a least a 1. Sign bit is ignored.
			// Here, I use x86 qNaN (because libiec61850 simply cast the value into a double)
			encoded_value = 0x7F800001;
		}
		else if (Math.IsInfinity(value))
		{
			// Infinite has all exponent bit set to 1, and mantissa filled with zeroes. Sign bit determines
			// which infinite it represents
			encoded_value = 0x7F800000;
		}
		else if (value != 0.0f)
		{
			int integral_part;
			float fraction_part = std::frexp(Math.Abs(value), integral_part);

			ushort exponent = integral_part + 126;
			encoded_value |= ((uint)exponent & 0xFF) << 23;
			encoded_value |= (uint)(fraction_part * (uint({1}) << 24)) & 0x007FFFFF;
		}

		if (std::signbit(value))
		{
			encoded_value |= uint({1}) << 31;
		}

		return new uint(encoded_value);
	}

	public static uint size = sizeof(float);
	public static float max_value = float.MaxValue;
	public static float min_value = -float.MaxValue;
}

}

