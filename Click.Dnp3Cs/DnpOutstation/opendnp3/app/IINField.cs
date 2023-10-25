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

public enum IINBit
{
	BROADCAST = 0,
	CLASS1_EVENTS,
	CLASS2_EVENTS,
	CLASS3_EVENTS,
	NEED_TIME,
	LOCAL_CONTROL,
	DEVICE_TROUBLE,
	DEVICE_RESTART,
	FUNC_NOT_SUPPORTED,
	OBJECT_UNKNOWN,
	PARAM_ERROR,
	EVENT_BUFFER_OVERFLOW,
	ALREADY_EXECUTING,
	CONFIG_CORRUPT,
	RESERVED1,
	RESERVED2 = 15
}

/** DNP3 two-byte IIN field.
 */
public class IINField
{

	private enum LSBMask : byte
	{
		BROADCAST = 0x01,
		CLASS1_EVENTS = 0x02,
		CLASS2_EVENTS = 0x04,
		CLASS3_EVENTS = 0x08,
		NEED_TIME = 0x10,
		LOCAL_CONTROL = 0x20,
		DEVICE_TROUBLE = 0x40,
		DEVICE_RESTART = 0x80
	}

	private enum MSBMask : byte
	{
		FUNC_NOT_SUPPORTED = 0x01,
		OBJECT_UNKNOWN = 0x02,
		PARAM_ERROR = 0x04,
		EVENT_BUFFER_OVERFLOW = 0x08,
		ALREADY_EXECUTING = 0x10,
		CONFIG_CORRUPT = 0x20,
		RESERVED1 = 0x40,
		RESERVED2 = 0x80,

		// special mask that indicates if there was any error processing a request
		REQUEST_ERROR_MASK = FUNC_NOT_SUPPORTED | OBJECT_UNKNOWN | PARAM_ERROR
	}

	public static IINField Empty()
	{
		return new IINField(0, 0);
	}

	public IINField(IINBit bit)
	{
		this.LSB = 0;
		this.MSB = 0;
		this.SetBit(bit);
	}

	public IINField(byte aLSB, byte aMSB)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.LSB = aLSB;
		this.LSB.CopyFrom(aLSB);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.MSB = aMSB;
		this.MSB.CopyFrom(aMSB);
	}

	public IINField()
	{
		this.LSB = 0;
		this.MSB = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsSet(IINBit bit) const
	public bool IsSet(IINBit bit)
	{
		switch (bit)
		{
		case (IINBit.BROADCAST):
			return Get(LSBMask.BROADCAST);
		case (IINBit.CLASS1_EVENTS):
			return Get(LSBMask.CLASS1_EVENTS);
		case (IINBit.CLASS2_EVENTS):
			return Get(LSBMask.CLASS2_EVENTS);
		case (IINBit.CLASS3_EVENTS):
			return Get(LSBMask.CLASS3_EVENTS);
		case (IINBit.NEED_TIME):
			return Get(LSBMask.NEED_TIME);
		case (IINBit.LOCAL_CONTROL):
			return Get(LSBMask.LOCAL_CONTROL);
		case (IINBit.DEVICE_TROUBLE):
			return Get(LSBMask.DEVICE_TROUBLE);
		case (IINBit.DEVICE_RESTART):
			return Get(LSBMask.DEVICE_RESTART);
		case (IINBit.FUNC_NOT_SUPPORTED):
			return Get(MSBMask.FUNC_NOT_SUPPORTED);
		case (IINBit.OBJECT_UNKNOWN):
			return Get(MSBMask.OBJECT_UNKNOWN);
		case (IINBit.PARAM_ERROR):
			return Get(MSBMask.PARAM_ERROR);
		case (IINBit.EVENT_BUFFER_OVERFLOW):
			return Get(MSBMask.EVENT_BUFFER_OVERFLOW);
		case (IINBit.ALREADY_EXECUTING):
			return Get(MSBMask.ALREADY_EXECUTING);
		case (IINBit.CONFIG_CORRUPT):
			return Get(MSBMask.CONFIG_CORRUPT);
		case (IINBit.RESERVED1):
			return Get(MSBMask.RESERVED1);
		case (IINBit.RESERVED2):
			return Get(MSBMask.RESERVED2);
		default:
			return false;
		};
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsClear(IINBit bit) const
	public bool IsClear(IINBit bit)
	{
		return !IsSet(bit);
	}

	public void SetBit(IINBit bit)
	{
		switch (bit)
		{
		case (IINBit.BROADCAST):
			Set(LSBMask.BROADCAST);
			break;
		case (IINBit.CLASS1_EVENTS):
			Set(LSBMask.CLASS1_EVENTS);
			break;
		case (IINBit.CLASS2_EVENTS):
			Set(LSBMask.CLASS2_EVENTS);
			break;
		case (IINBit.CLASS3_EVENTS):
			Set(LSBMask.CLASS3_EVENTS);
			break;
		case (IINBit.NEED_TIME):
			Set(LSBMask.NEED_TIME);
			break;
		case (IINBit.LOCAL_CONTROL):
			Set(LSBMask.LOCAL_CONTROL);
			break;
		case (IINBit.DEVICE_TROUBLE):
			Set(LSBMask.DEVICE_TROUBLE);
			break;
		case (IINBit.DEVICE_RESTART):
			Set(LSBMask.DEVICE_RESTART);
			break;
		case (IINBit.FUNC_NOT_SUPPORTED):
			Set(MSBMask.FUNC_NOT_SUPPORTED);
			break;
		case (IINBit.OBJECT_UNKNOWN):
			Set(MSBMask.OBJECT_UNKNOWN);
			break;
		case (IINBit.PARAM_ERROR):
			Set(MSBMask.PARAM_ERROR);
			break;
		case (IINBit.EVENT_BUFFER_OVERFLOW):
			Set(MSBMask.EVENT_BUFFER_OVERFLOW);
			break;
		case (IINBit.ALREADY_EXECUTING):
			Set(MSBMask.ALREADY_EXECUTING);
			break;
		case (IINBit.CONFIG_CORRUPT):
			Set(MSBMask.CONFIG_CORRUPT);
			break;
		case (IINBit.RESERVED1):
			Set(MSBMask.RESERVED1);
			break;
		case (IINBit.RESERVED2):
			Set(MSBMask.RESERVED2);
			break;
		default:
			break;
		};
	}

	public void ClearBit(IINBit bit)
	{
		switch (bit)
		{
		case (IINBit.BROADCAST):
			Clear(LSBMask.BROADCAST);
			break;
		case (IINBit.CLASS1_EVENTS):
			Clear(LSBMask.CLASS1_EVENTS);
			break;
		case (IINBit.CLASS2_EVENTS):
			Clear(LSBMask.CLASS2_EVENTS);
			break;
		case (IINBit.CLASS3_EVENTS):
			Clear(LSBMask.CLASS3_EVENTS);
			break;
		case (IINBit.NEED_TIME):
			Clear(LSBMask.NEED_TIME);
			break;
		case (IINBit.LOCAL_CONTROL):
			Clear(LSBMask.LOCAL_CONTROL);
			break;
		case (IINBit.DEVICE_TROUBLE):
			Clear(LSBMask.DEVICE_TROUBLE);
			break;
		case (IINBit.DEVICE_RESTART):
			Clear(LSBMask.DEVICE_RESTART);
			break;
		case (IINBit.FUNC_NOT_SUPPORTED):
			Clear(MSBMask.FUNC_NOT_SUPPORTED);
			break;
		case (IINBit.OBJECT_UNKNOWN):
			Clear(MSBMask.OBJECT_UNKNOWN);
			break;
		case (IINBit.PARAM_ERROR):
			Clear(MSBMask.PARAM_ERROR);
			break;
		case (IINBit.EVENT_BUFFER_OVERFLOW):
			Clear(MSBMask.EVENT_BUFFER_OVERFLOW);
			break;
		case (IINBit.ALREADY_EXECUTING):
			Clear(MSBMask.ALREADY_EXECUTING);
			break;
		case (IINBit.CONFIG_CORRUPT):
			Clear(MSBMask.CONFIG_CORRUPT);
			break;
		case (IINBit.RESERVED1):
			Clear(MSBMask.RESERVED1);
			break;
		case (IINBit.RESERVED2):
			Clear(MSBMask.RESERVED2);
			break;
		default:
			break;
		};
	}

	public void SetBitToValue(IINBit bit, bool value)
	{
		if (value)
		{
			SetBit(bit);
		}
		else
		{
			ClearBit(bit);
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const IINField& aRHS) const
	public static bool operator == (IINField ImpliedObject, in IINField aRHS)
	{
		return (ImpliedObject.LSB == aRHS.LSB) && (ImpliedObject.MSB == aRHS.MSB);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Any() const
	public bool Any()
	{
		return (LSB | MSB) != 0;
	}

	public void Clear()
	{
		LSB = MSB = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasRequestError() const
	public bool HasRequestError()
	{
		return Get(MSBMask.REQUEST_ERROR_MASK);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: IINField operator |(const IINField& aIIN) const
	public static IINField operator | (IINField ImpliedObject, in IINField aIIN)
	{
		return new IINField(ImpliedObject.LSB | aIIN.LSB, ImpliedObject.MSB | aIIN.MSB);
	}

//C++ TO C# CONVERTER TASK: The |= operator cannot be overloaded in C#:
	public static IINField operator |= (in IINField aIIN)
	{
		MSB |= aIIN.MSB;
		LSB |= aIIN.LSB;
		return this;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: IINField operator &(const IINField& aIIN) const
	public static IINField operator & (IINField ImpliedObject, in IINField aIIN)
	{
		return new IINField(ImpliedObject.LSB & aIIN.LSB, ImpliedObject.MSB & aIIN.MSB);
	}

//C++ TO C# CONVERTER TASK: The &= operator cannot be overloaded in C#:
	public static IINField operator &= (in IINField aIIN)
	{
		MSB &= aIIN.MSB;
		LSB &= aIIN.LSB;
		return this;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: IINField operator ~() const
	public static IINField operator ~(IINField ImpliedObject)
	{
		return new IINField(~ImpliedObject.LSB, ~ImpliedObject.MSB);
	}

	public byte LSB = new byte();
	public byte MSB = new byte();

	private const byte REQUEST_ERROR_MASK = new byte();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool Get(LSBMask bit) const
	private bool Get(LSBMask bit)
	{
		return (LSB & (byte)bit) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool Get(MSBMask bit) const
	private bool Get(MSBMask bit)
	{
		return (MSB & (byte)bit) != 0;
	}

	private void Set(LSBMask bit)
	{
		LSB |= (byte)bit;
	}
	private void Set(MSBMask bit)
	{
		MSB |= (byte)bit;
	}

	private void Clear(LSBMask bit)
	{
		LSB &= ~(byte)bit;
	}
	private void Clear(MSBMask bit)
	{
		MSB &= ~(byte)bit;
	}
}

} // namespace opendnp3



