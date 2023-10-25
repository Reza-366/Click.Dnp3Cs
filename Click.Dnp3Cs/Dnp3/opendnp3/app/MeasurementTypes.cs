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
    The Binary data type is for describing on-off (boolean) type values. Good examples of
    binaries are alarms, mode settings, enabled/disabled flags etc. Think of it as a status
    LED on a piece of equipment.
*/
public class Binary : TypedMeasurement<bool>
{

	// ------------ Binary ---------------

	public Binary() : base(false, flags.RESTART)
	{
	}

	public Binary(bool value) : base(value, flags.GetBinaryFlags(flags.ONLINE, value))
	{
	}

	public Binary(Flags flags) : base(flags.GetBinaryValue(flags), flags)
	{
	}

	public Binary(Flags flags, DNPTime time) : base(flags.GetBinaryValue(flags), flags, time)
	{
	}

	public Binary(bool value, Flags flags) : base(value, flags.GetBinaryFlags(flags, value))
	{
	}

	public Binary(bool value, Flags flags, DNPTime time) : base(value, flags.GetBinaryFlags(flags, value), time)
	{
	}
}

/**
The Double-bit Binary data type has two stable states, on and off, and an in transit state. Motor operated switches
or binary valves are good examples.
*/
public class DoubleBitBinary : TypedMeasurement<DoubleBit>
{

	// ------------ Double Bit Binary ---------------

	public DoubleBitBinary() : base(DoubleBit.INDETERMINATE, flags.RESTART)
	{
	}

	public DoubleBitBinary(DoubleBit value) : base(value, GetFlags(flags.ONLINE, value))
	{
	}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: base(GetValue(flags), flags);
	public DoubleBitBinary(Flags flags) : base(GetValue(new opendnp3.Flags(flags)), flags)
	{
	}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: base(GetValue(flags), flags, time);
	public DoubleBitBinary(Flags flags, DNPTime time) : base(GetValue(new opendnp3.Flags(flags)), flags, time)
	{
	}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: base(value, GetFlags(flags, value));
	public DoubleBitBinary(DoubleBit value, Flags flags) : base(value, GetFlags(new opendnp3.Flags(flags), value))
	{
	}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: base(value, GetFlags(flags, value), time);
	public DoubleBitBinary(DoubleBit value, Flags flags, DNPTime time) : base(value, GetFlags(new opendnp3.Flags(flags), value), time)
	{
	}

	private const System.Byte ValueMask = 0xC0;
	private const System.Byte QualityMask = 0x3F;

	private static DoubleBit GetValue(Flags flags)
	{
		// the value is the top 2 bits, so down-shift 6
		System.Byte value = flags.value >> 6;
		return DoubleBitSpec.from_type(new System.Byte(value));
	}

	private static Flags GetFlags(Flags flags, DoubleBit state)
	{
		System.Byte value = DoubleBitSpec.to_type(state) << 6;
		return new Flags((QualityMask & flags.value) | value);
	}
}

/**
    BinaryOutputStatus is used for describing the current state of a control. It is very infrequently
    used and many masters don't provide any mechanisms for reading these values so their use is
    strongly discouraged, a Binary should be used instead.
*/
public class BinaryOutputStatus : TypedMeasurement<bool>
{

	// ------------ Binary Output Status ---------------

	public BinaryOutputStatus() : base(false, flags.RESTART)
	{
	}

	public BinaryOutputStatus(bool value) : base(value, flags.GetBinaryFlags(flags.ONLINE, value))
	{
	}

	public BinaryOutputStatus(Flags flags) : base(flags.GetBinaryValue(flags), flags)
	{
	}

	public BinaryOutputStatus(Flags flags, DNPTime time) : base(flags.GetBinaryValue(flags), flags, time)
	{
	}

	public BinaryOutputStatus(bool value, Flags flags) : base(value, flags.GetBinaryFlags(flags, value))
	{
	}

	public BinaryOutputStatus(bool value, Flags flags, DNPTime time) : base(value, flags.GetBinaryFlags(flags, value), time)
	{
	}
}

/**
    Analogs are used for variable data points that usually reflect a real world value.
    Good examples are current, voltage, sensor readouts, etc. Think of a speedometer guage.
*/

public class Analog : TypedMeasurement<double>
{

	// ------------ Analog ---------------

	public Analog() : base(flags.RESTART)
	{
	}

	public Analog(double value) : base(value, flags.ONLINE)
	{
	}

	public Analog(double value, Flags flags) : base(value, flags)
	{
	}

	public Analog(double value, Flags flags, DNPTime time)
	{
		this.TypedMeasurement<double> = new <type missing>(value, flags, time);
	}
}

/**
    Counters are used for describing generally increasing values (non-negative!). Good examples are
    total power consumed, max voltage. Think odometer on a car.
*/
public class Counter : TypedMeasurement<System.UInt32>
{

	// ------------ Counter ---------------

	public Counter() : base(0, flags.RESTART)
	{
	}

	public Counter(System.UInt32 value)
	{
		this.TypedMeasurement<System.UInt32> = new <type missing>(value, flags.ONLINE);
	}

	public Counter(System.UInt32 value, Flags flags)
	{
		this.TypedMeasurement<System.UInt32> = new <type missing>(value, flags);
	}

	public Counter(System.UInt32 value, Flags flags, DNPTime time)
	{
		this.TypedMeasurement<System.UInt32> = new <type missing>(value, flags, time);
	}
}

/**
    Frozen counters are used to report the value of a counter point captured at the instant when the count is frozen.
*/
public class FrozenCounter : TypedMeasurement<System.UInt32>
{

	// ------------ Frozen Counter ---------------

	public FrozenCounter() : base(0, flags.RESTART)
	{
	}

	public FrozenCounter(System.UInt32 value)
	{
		this.TypedMeasurement<System.UInt32> = new <type missing>(value, flags.ONLINE);
	}

	public FrozenCounter(System.UInt32 value, Flags flags)
	{
		this.TypedMeasurement<System.UInt32> = new <type missing>(value, flags);
	}

	public FrozenCounter(System.UInt32 value, Flags flags, DNPTime time)
	{
		this.TypedMeasurement<System.UInt32> = new <type missing>(value, flags, time);
	}
}

/**
    Describes the last set value of the set-point. Like the BinaryOutputStatus data type it is not
    well supported and its generally better practice to use an explicit analog.
*/
public class AnalogOutputStatus : TypedMeasurement<double>
{

	// ------------ Analog Output Status ---------------

	public AnalogOutputStatus()
	{
		this.TypedMeasurement<double> = flags.RESTART;
	}

	public AnalogOutputStatus(double value)
	{
		this.TypedMeasurement<double> = new <type missing>(value, flags.ONLINE);
	}

	public AnalogOutputStatus(double value, Flags flags)
	{
		this.TypedMeasurement<double> = new <type missing>(value, flags);
	}

	public AnalogOutputStatus(double value, Flags flags, DNPTime time)
	{
		this.TypedMeasurement<double> = new <type missing>(value, flags, time);
	}
}

/**
    Maps to Group50Var4
    This class is a bit of an outlier as an indexed type and is really only used in the DNP3 PV profile
*/
public class TimeAndInterval
{

	// ------------ TimeAndInterval ---------------

	public TimeAndInterval()
	{
		this.time = new opendnp3.DNPTime(0);
		this.interval = 0;
		this.units = 0;
	}

	public TimeAndInterval(DNPTime time_, System.UInt32 interval_, System.Byte units_)
	{
		this.time = new opendnp3.DNPTime(time_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.interval = interval_;
		this.interval.CopyFrom(interval_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.units = units_;
		this.units.CopyFrom(units_);
	}

	public TimeAndInterval(DNPTime time_, System.UInt32 interval_, IntervalUnits units_)
	{
		this.time = new opendnp3.DNPTime(time_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.interval = interval_;
		this.interval.CopyFrom(interval_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.units = static_cast<System.Byte>(units_);
		this.units.CopyFrom((System.Byte)units_);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: IntervalUnits GetUnitsEnum() const
	public IntervalUnits GetUnitsEnum()
	{
		return IntervalUnitsSpec.from_type(new System.Byte(units));
	}

	public DNPTime time = new DNPTime();
	public System.UInt32 interval = new System.UInt32();
	public System.Byte units = new System.Byte();
}

} // namespace opendnp3



