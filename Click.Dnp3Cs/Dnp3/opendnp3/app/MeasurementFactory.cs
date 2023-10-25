﻿/*
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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct BinaryFactory : private StaticOnly
public class BinaryFactory : StaticOnly
{
	public static Binary From(System.Byte flags)
	{
		return new Binary(new Flags(flags));
	}

	public static Binary From(System.Byte flags, UInt16 time)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return From(flags, DNPTime(time));
		return new opendnp3.Binary(From(new System.Byte(flags), new DNPTime(time)));
	}

	public static Binary From(System.Byte flags, DNPTime time)
	{
		return new Binary(new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct DoubleBitBinaryFactory : private StaticOnly
public class DoubleBitBinaryFactory : StaticOnly
{
	public static DoubleBitBinary From(System.Byte flags)
	{
		return new DoubleBitBinary(new Flags(flags));
	}

	public static DoubleBitBinary From(System.Byte flags, UInt16 time)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return From(flags, DNPTime(time));
		return new opendnp3.DoubleBitBinary(From(new System.Byte(flags), new DNPTime(time)));
	}

	public static DoubleBitBinary From(System.Byte flags, DNPTime time)
	{
		return new DoubleBitBinary(new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct AnalogFactory : private StaticOnly
public class AnalogFactory : StaticOnly
{
	public static Analog From(int32_t count)
	{
		return new Analog(count);
	}
	public static Analog From(System.Byte flags, double value)
	{
		return new Analog(value, new Flags(flags));
	}
	public static Analog From(System.Byte flags, double value, DNPTime time)
	{
		return new Analog(value, new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct CounterFactory : private StaticOnly
public class CounterFactory : StaticOnly
{
	public static Counter From(System.UInt32 count)
	{
		return new Counter(count);
	}
	public static Counter From(System.Byte flags, System.UInt32 count)
	{
		return new Counter(count, new Flags(flags));
	}
	public static Counter From(System.Byte flags, System.UInt32 count, DNPTime time)
	{
		return new Counter(count, new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct FrozenCounterFactory : private StaticOnly
public class FrozenCounterFactory : StaticOnly
{
	public static FrozenCounter From(System.UInt32 count)
	{
		return new FrozenCounter(count);
	}
	public static FrozenCounter From(System.Byte flags, System.UInt32 count)
	{
		return new FrozenCounter(count, new Flags(flags));
	}
	public static FrozenCounter From(System.Byte flags, System.UInt32 count, DNPTime time)
	{
		return new FrozenCounter(count, new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct TimeAndIntervalFactory : private StaticOnly
public class TimeAndIntervalFactory : StaticOnly
{
	public static TimeAndInterval From(DNPTime time, System.UInt32 interval, System.Byte units)
	{
		return new TimeAndInterval(time, interval, units);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ControlRelayOutputBlockFactory : private StaticOnly
public class ControlRelayOutputBlockFactory : StaticOnly
{
	public static ControlRelayOutputBlock From(System.Byte code, System.Byte count, System.UInt32 onTime, System.UInt32 offTime, System.Byte status)
	{
		return new ControlRelayOutputBlock(code, count, onTime, offTime, CommandStatusSpec.from_type(new System.Byte(status)));
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct BinaryOutputStatusFactory : private StaticOnly
public class BinaryOutputStatusFactory : StaticOnly
{
	public static BinaryOutputStatus From(System.Byte flags)
	{
		return new BinaryOutputStatus(new Flags(flags));
	}

	public static BinaryOutputStatus From(System.Byte flags, DNPTime time)
	{
		return new BinaryOutputStatus(new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct BinaryCommandEventFactory : private StaticOnly
public class BinaryCommandEventFactory : StaticOnly
{
	public static BinaryCommandEvent From(System.Byte flags)
	{
		return new BinaryCommandEvent(new Flags(flags));
	}

	public static BinaryCommandEvent From(System.Byte flags, DNPTime time)
	{
		return new BinaryCommandEvent(new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct AnalogOutputStatusFactory : private StaticOnly
public class AnalogOutputStatusFactory : StaticOnly
{
	public static AnalogOutputStatus From(System.Byte flags, double value)
	{
		return new AnalogOutputStatus(value, new Flags(flags));
	}

	public static AnalogOutputStatus From(System.Byte flags, double value, DNPTime time)
	{
		return new AnalogOutputStatus(value, new Flags(flags), time);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct AnalogCommandEventFactory : private StaticOnly
public class AnalogCommandEventFactory : StaticOnly
{
	public static AnalogCommandEvent From(System.Byte status, double value)
	{
		return new AnalogCommandEvent(value, CommandStatusSpec.from_type(new System.Byte(status)));
	}

	public static AnalogCommandEvent From(System.Byte status, double value, DNPTime time)
	{
		return new AnalogCommandEvent(value, CommandStatusSpec.from_type(new System.Byte(status)), time);
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class ValueType>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct AnalogOutputFactory : private StaticOnly
public class AnalogOutputFactory <Target, ValueType> : StaticOnly
{
	public static Target From(ValueType value, System.Byte status)
	{
		return Target(value, CommandStatusSpec.from_type(new System.Byte(status)));
	}
}


} // namespace opendnp3
