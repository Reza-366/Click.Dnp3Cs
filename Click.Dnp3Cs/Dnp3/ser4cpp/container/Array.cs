using System.Diagnostics;

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

/**
 * Template type for a dynamically allocated array
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class W>
public class Array <T, W> : HasLength<W>, System.IDisposable
{

	public Array(W size)
	{
		this.HasLength<W> = size;
		this.buffer = Arrays.InitializeWithDefaultInstances<T>(size);
	}

	public Array()
	{
		this.HasLength<W> = 0;
		this.buffer = null;
	}

	public Array(in Array copy)
	{
		this.HasLength<W> = copy.length();
		this.buffer = Arrays.InitializeWithDefaultInstances<T>(copy.length());
		for (W i = 0; i < copy.length(); ++i)
		{
			buffer[i] = copy.buffer[i];
		}
	}

	public virtual void Dispose()
	{
		Arrays.DeleteArray(buffer);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ArrayView<T, W> to_view() const
	public ArrayView<T, W> to_view()
	{
		return ArrayView<T, W>(buffer, this.m_length);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool contains(W index) const
	public bool contains(W index)
	{
		return index < this.m_length;
	}

	public T this[W index]
	{
		get
		{
			Debug.Assert(index < this.m_length);
			return buffer[index];
		}
		set
		{
			buffer[index] = value;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const T& operator [](W index) const
	public T this[W index]
	{
		get
		{
			Debug.Assert(index < this.m_length);
			return buffer[index];
		}
		set
		{
			buffer[index] = value;
		}
	}

	protected T[] buffer;

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	Array& operator =(const Array&) = delete;
}

} // namespace ser4cpp

