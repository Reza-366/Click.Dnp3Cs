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

/**
 * The object to represent a setpoint request from the master. Think of
 * this like turning a dial on the front of a machine to desired setting.
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class AnalogOutput <T>
{
	public AnalogOutput()
	{
		this.value = 0;
		this.status = new opendnp3.CommandStatus.SUCCESS;
	}

	public AnalogOutput(T value_)
	{
		this.value = value_;
		this.status = new opendnp3.CommandStatus.SUCCESS;
	}

	public AnalogOutput(T value_, CommandStatus status_)
	{
		this.value = value_;
		this.status = new opendnp3.CommandStatus(status_);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool ValuesEqual(const AnalogOutput<T>& lhs) const
	public bool ValuesEqual(in AnalogOutput<T> lhs)
	{
		return value == lhs.value;
	}

	public T value = default(T);

	/**
	 * The status value defaults to CS_SUCCESS for requests
	 */
	public CommandStatus status;
}

/**
 *	16-bit signed integer analog output. The underlying serialization is Group41, Variation 2
 */
public class AnalogOutputInt16 : AnalogOutput<int16_t>
{
	public AnalogOutputInt16()
	{
		this.AnalogOutput<int16_t> = 0;
	}

	public AnalogOutputInt16(int16_t aValue)
	{
		this.AnalogOutput<int16_t> = aValue;
	}

	public AnalogOutputInt16(int16_t aValue, CommandStatus aStatus)
	{
		this.AnalogOutput<int16_t> = new <type missing>(aValue, aStatus);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const AnalogOutputInt16& arRHS) const
	public static bool operator == (AnalogOutputInt16 ImpliedObject, in AnalogOutputInt16 arRHS)
	{
		return ImpliedObject.ValuesEqual(arRHS) && ImpliedObject.status == arRHS.status;
	}
}

/**
 *	32-bit signed integer analog output. The underlying serialization is Group41, Variation 1
 */
public class AnalogOutputInt32 : AnalogOutput<int32_t>
{
	public AnalogOutputInt32()
	{
		this.AnalogOutput<int32_t> = 0;
	}

	public AnalogOutputInt32(int32_t aValue)
	{
		this.AnalogOutput<int32_t> = aValue;
	}

	public AnalogOutputInt32(int32_t aValue, CommandStatus aStatus)
	{
		this.AnalogOutput<int32_t> = new <type missing>(aValue, aStatus);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const AnalogOutputInt32& arRHS) const
	public static bool operator == (AnalogOutputInt32 ImpliedObject, in AnalogOutputInt32 arRHS)
	{
		return ImpliedObject.ValuesEqual(arRHS) && ImpliedObject.status == arRHS.status;
	}
}

/**
 *	Single precision analog output. The underlying serialization is Group41, Variation 3
 */
public class AnalogOutputFloat32 : AnalogOutput<float>
{
	public AnalogOutputFloat32()
	{
		this.AnalogOutput<float> = 0;
	}

	public AnalogOutputFloat32(float aValue)
	{
		this.AnalogOutput<float> = aValue;
	}

	public AnalogOutputFloat32(float aValue, CommandStatus aStatus)
	{
		this.AnalogOutput<float> = new <type missing>(aValue, aStatus);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const AnalogOutputFloat32& arRHS) const
	public static bool operator == (AnalogOutputFloat32 ImpliedObject, in AnalogOutputFloat32 arRHS)
	{
		return ImpliedObject.ValuesEqual(arRHS) && ImpliedObject.status == arRHS.status;
	}
}

/**
 *	Double precision analog output. The underlying serialization is Group41, Variation 3
 */
public class AnalogOutputDouble64 : AnalogOutput<double>
{
	public AnalogOutputDouble64()
	{
		this.AnalogOutput<double> = 0;
	}

	public AnalogOutputDouble64(double aValue)
	{
		this.AnalogOutput<double> = aValue;
	}

	public AnalogOutputDouble64(double aValue, CommandStatus aStatus)
	{
		this.AnalogOutput<double> = new <type missing>(aValue, aStatus);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const AnalogOutputDouble64& arRHS) const
	public static bool operator == (AnalogOutputDouble64 ImpliedObject, in AnalogOutputDouble64 arRHS)
	{
		return ImpliedObject.ValuesEqual(arRHS) && ImpliedObject.status == arRHS.status;
	}
}

} // namespace opendnp3



