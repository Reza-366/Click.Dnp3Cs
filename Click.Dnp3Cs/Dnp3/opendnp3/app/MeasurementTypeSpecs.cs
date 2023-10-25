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

public class BinarySpec : BinaryInfo
{

	public static bool IsQualityOnlineOnly(in Binary binary)
	{
		return (binary.flags.value & 0b01111111) == (System.Byte)BinaryQuality.ONLINE;
	}

	public static bool IsEvent(in Binary old_value, in Binary new_value, in BinaryConfig config)
	{
		return old_value.flags.value != new_value.flags.value;
	}
}

public class DoubleBitBinarySpec : DoubleBitBinaryInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in DoubleBitBinary old_value, in DoubleBitBinary new_value, in config_t config)
	{
		return old_value.flags.value != new_value.flags.value;
	}
}

public class BinaryOutputStatusSpec : BinaryOutputStatusInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in BinaryOutputStatus old_value, in BinaryOutputStatus new_value, in config_t config)
	{
		return old_value.flags.value != new_value.flags.value;
	}
}

public class AnalogSpec : AnalogInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in Analog old_value, in Analog new_value, in config_t config)
	{
		return opendnp3.measurements.Globals.IsEvent(new_value, old_value, config.deadband);
	}
}

public class CounterSpec : CounterInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in Counter old_value, in Counter new_value, in config_t config)
	{
		if (old_value.flags.value != new_value.flags.value)
		{
			return true;
		}
		else
		{
			return opendnp3.measurements.Globals.IsEvent<System.UInt32, uint64_t>(old_value.value, new_value.value, config.deadband);
		}
	}
}

public class FrozenCounterSpec : FrozenCounterInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in FrozenCounter old_value, in FrozenCounter new_value, in config_t config)
	{
		if (old_value.flags.value != new_value.flags.value)
		{
			return true;
		}
		else
		{
			return opendnp3.measurements.Globals.IsEvent<System.UInt32, uint64_t>(old_value.value, new_value.value, config.deadband);
		}
	}
}

public class AnalogOutputStatusSpec : AnalogOutputStatusInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in AnalogOutputStatus old_value, in AnalogOutputStatus new_value, in config_t config)
	{
		return opendnp3.measurements.Globals.IsEvent(new_value, old_value, config.deadband);
	}
}

public class OctetStringSpec : OctetStringInfo
{

//C++ TO C# CONVERTER TASK: The typedef 'config_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public static bool IsEvent(in OctetString old_value, in OctetString new_value, in config_t config)
	{
		var old_value_buffer = old_value.ToBuffer();
		RSeq<size_t> old_value_seq = new RSeq<size_t>(old_value_buffer.data, old_value_buffer.length);
		var new_value_buffer = new_value.ToBuffer();
		RSeq<size_t> new_value_seq = new RSeq<size_t>(new_value_buffer.data, new_value_buffer.length);
		return !old_value_seq.equals(new_value_seq);
	}
}

public class TimeAndIntervalSpec : TimeAndIntervalInfo
{
}

} // namespace opendnp3

