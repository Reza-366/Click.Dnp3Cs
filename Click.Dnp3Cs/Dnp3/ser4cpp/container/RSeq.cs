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



/**
* @brief ser4cpp header-only library namespace
*/
namespace ser4cpp
{

/**
*	Represents a readonly sequence of bytes with a parameterized length type (L)
*/
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <class L>
public class RSeq <L> : HasLength<L>
{
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
//	static_assert(std::numeric_limits<L>::is_integer&& !std::numeric_limits<L>::is_signed, "Must be an unsigned integer");

	public static RSeq empty()
	{
		return new RSeq(null, 0);
	}

	public RSeq()
	{
		this.HasLength<L> = 0;
	}

	public RSeq(System.Byte buffer, L length)
	{
		this.HasLength<L> = length;
		this.buffer_ = buffer;
	}

	public void make_empty()
	{
		this.buffer_ = null;
		this.m_length = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: RSeq take(L count) const
	public RSeq take(L count)
	{
		return new RSeq(this.buffer_, (count < this.length()) ? count : this.length());
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: RSeq skip(L count) const
	public RSeq skip(L count)
	{
		var num = ser4cpp.Globals.min(this.length(), count);
		return new RSeq(this.buffer_ + num, this.length() - num);
	}

	public void advance(L count)
	{
		var num = ser4cpp.Globals.min(this.length(), count);
//C++ TO C# CONVERTER TASK: Pointer arithmetic on arrays is not converted:
		this.buffer_ += num;
		this.m_length -= num;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: operator System.Byte const* () const
	public static implicit operator System.Byte (RSeq ImpliedObject)
	{
		return ImpliedObject.buffer_;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool equals(const RSeq& rhs) const
	public bool equals(in RSeq rhs)
	{
		if (this.m_length == rhs.m_length)
		{
//C++ TO C# CONVERTER TASK: The memory management function 'memcmp' has no equivalent in C#:
			return memcmp(this.buffer_, rhs.buffer_, this.m_length) == 0;
		}
		else
		{
			return false;
		}
	}

	protected System.Byte[] buffer_ = null;
}

}

