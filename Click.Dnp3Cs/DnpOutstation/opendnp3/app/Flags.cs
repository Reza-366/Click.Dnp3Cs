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

/**
  Measurement Flags
*/
public class Flags
{
	public Flags()
	{
		this.value = 0;
	}

	public Flags(byte value)
	{
		this.value =value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(BinaryQuality flag) const
	public bool IsSet(BinaryQuality flag)
	{
		return IsSetAny(flag);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(DoubleBitBinaryQuality flag) const
	public bool IsSet(DoubleBitBinaryQuality flag)
	{
		return IsSetAny(flag);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(AnalogQuality flag) const
	public bool IsSet(AnalogQuality flag)
	{
		return IsSetAny(flag);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(CounterQuality flag) const
	public bool IsSet(CounterQuality flag)
	{
		return IsSetAny(flag);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(FrozenCounterQuality flag) const
	public bool IsSet(FrozenCounterQuality flag)
	{
		return IsSetAny(flag);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(BinaryOutputStatusQuality flag) const
	public bool IsSet(BinaryOutputStatusQuality flag)
	{
		return IsSetAny(flag);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsSet(AnalogOutputStatusQuality flag) const
	public bool IsSet(AnalogOutputStatusQuality flag)
	{
		return IsSetAny(flag);
	}

	public void Set(BinaryQuality flag)
	{
		SetAny(flag);
	}
	public void Set(DoubleBitBinaryQuality flag)
	{
		SetAny(flag);
	}
	public void Set(AnalogQuality flag)
	{
		SetAny(flag);
	}
	public void Set(CounterQuality flag)
	{
		SetAny(flag);
	}
	public void Set(FrozenCounterQuality flag)
	{
		SetAny(flag);
	}
	public void Set(BinaryOutputStatusQuality flag)
	{
		SetAny(flag);
	}
	public void Set(AnalogOutputStatusQuality flag)
	{
		SetAny(flag);
	}

	public byte value = new byte();

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsSetAny(T flag) const
	protected bool IsSetAny<T>(T flag)
	{
		return (value & (byte)flag) != 0;
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	protected void SetAny<T>(T flag)
	{
		value |= (byte)flag;
	}
}

} // namespace opendnp3

