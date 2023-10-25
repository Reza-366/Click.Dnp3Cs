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

/** represents a sequence number
 */
//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template<class T, T Modulus> class SequenceNum
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, typename Modulus> requires T<Modulus>
public class SequenceNum <T, Modulus>
{
	private static T Next(T seq)
	{
		return (seq + 1) % Modulus;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: byte Get() const
	public byte Get()
	{
		return this.seq;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: operator byte() const
	public static implicit operator byte(SequenceNum ImpliedObject)
	{
		return ImpliedObject.seq;
	}

	public SequenceNum()
	{
		this.seq = 0;
	}

	public SequenceNum(T value)
	{
		this.seq = value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Equals(T other) const
	public bool Equals(T other)
	{
		return other == this.seq;
	}

	public void Increment()
	{
		this.seq = Next(this.seq);
	}

	public void Reset()
	{
		this.seq = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: SequenceNum Next() const
	public SequenceNum Next()
	{
		return new SequenceNum(Next(seq));
	}

	protected T seq = default(T);
}

} // namespace opendnp3

