﻿/*
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
//ORIGINAL LINE: class Buffer : public HasLength<size_t>, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public class Buffer : HasLength<size_t>, Uncopyable
{
	public Buffer() : base(0)
	{
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	~Buffer() = default;

	public Buffer(size_t length) : base(length)
	{
		this.bytes = std::make_unique<System.Byte[]>(length);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	Buffer(Buffer&&) = default;
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	Buffer& operator =(Buffer&&) = default;

	// initialize with the exact length and contents
	public Buffer(in rseq_t input) : this(input.length())
	{
		this.as_wslice().copy_from(input);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline rseq_t as_rslice() const
	public rseq_t as_rslice()
	{
		return rseq_t(this.bytes.get(), this.length());
	}

	public wseq_t as_wslice()
	{
		return wseq_t(this.bytes.get(), this.length());
	}

	private System.Byte[] bytes[0];
}

}
