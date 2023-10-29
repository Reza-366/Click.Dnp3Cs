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


namespace opendnp3
{

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class Serializer <T>
{
	public delegate bool read_func_t(RSeq/*<size_t>*/ buffer, T output);
	public delegate bool write_func_t(in T value, WSeq</*size_t*/int> buffer);

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	Serializer() = default;

	public Serializer(/*size_t*/int size, read_func_t read_func, write_func_t write_func)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.size = size;
		this.size.CopyFrom(size);
		this.read_func = read_func;
		this.write_func = write_func;
	}

	/**
	 * @return The size (in bytes) required for every call to read/write
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: /*size_t*/int get_size() const
	public /*size_t*/int get_size()
	{
		return new /*size_t*/int(size);
	}

	/**
	 * reads the value and advances the read buffer
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool read(RSeq/*<size_t>*/& buffer, T& output) const
	public bool read(RSeq/*<size_t>*/ buffer, T output)
	{
		return read_func(buffer, output);
	}

	/**
	 * writes the value and advances the write buffer
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool write(const T& value, WSeq</*size_t*/int>& buffer) const
	public bool write(in T value, WSeq</*size_t*/int> buffer)
	{
		return write_func(value, buffer);
	}

	private /*size_t*/int size = 0;
	private read_func_t read_func = null;
	private write_func_t write_func = null;
}
} // namespace opendnp3

