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

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public delegate bool static_write_func_t<Spec>(StaticDataMap<Spec> map, HeaderWriter writer);

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct StaticWriters : private StaticOnly
public class StaticWriters : StaticOnly
{
	public static static_write_func_t<BinarySpec> get(StaticBinaryVariation variation)
	{
		switch (variation)
		{
		case (StaticBinaryVariation.Group1Var1):
			return &opendnp3.Globals.WriteSingleBitfield<BinarySpec, Group1Var1>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<BinarySpec, Group1Var2>;
		}
	}

	public static static_write_func_t<DoubleBitBinarySpec> get(StaticDoubleBinaryVariation variation)
	{
		switch (variation)
		{
		case (StaticDoubleBinaryVariation.Group3Var2):
			return &opendnp3.Globals.WriteWithSerializer<DoubleBitBinarySpec, Group3Var2>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<DoubleBitBinarySpec, Group3Var2>;
		}
	}

	public static static_write_func_t<CounterSpec> get(StaticCounterVariation variation)
	{
		switch (variation)
		{
		case (StaticCounterVariation.Group20Var1):
			return &opendnp3.Globals.WriteWithSerializer<CounterSpec, Group20Var1>;
		case (StaticCounterVariation.Group20Var2):
			return &opendnp3.Globals.WriteWithSerializer<CounterSpec, Group20Var2>;
		case (StaticCounterVariation.Group20Var5):
			return &opendnp3.Globals.WriteWithSerializer<CounterSpec, Group20Var5>;
		case (StaticCounterVariation.Group20Var6):
			return &opendnp3.Globals.WriteWithSerializer<CounterSpec, Group20Var6>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<CounterSpec, Group20Var1>;
		}
	}

	public static static_write_func_t<FrozenCounterSpec> get(StaticFrozenCounterVariation variation)
	{
		switch (variation)
		{
		case (StaticFrozenCounterVariation.Group21Var1):
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var1>;
		case (StaticFrozenCounterVariation.Group21Var2):
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var2>;
		case (StaticFrozenCounterVariation.Group21Var5):
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var5>;
		case (StaticFrozenCounterVariation.Group21Var6):
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var6>;
		case (StaticFrozenCounterVariation.Group21Var9):
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var9>;
		case (StaticFrozenCounterVariation.Group21Var10):
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var10>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<FrozenCounterSpec, Group21Var1>;
		}
	}

	public static static_write_func_t<AnalogSpec> get(StaticAnalogVariation variation)
	{
		switch (variation)
		{
		case (StaticAnalogVariation.Group30Var1):
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var1>;
		case (StaticAnalogVariation.Group30Var2):
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var2>;
		case (StaticAnalogVariation.Group30Var3):
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var3>;
		case (StaticAnalogVariation.Group30Var4):
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var4>;
		case (StaticAnalogVariation.Group30Var5):
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var5>;
		case (StaticAnalogVariation.Group30Var6):
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var6>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<AnalogSpec, Group30Var1>;
		}
	}

	public static static_write_func_t<AnalogOutputStatusSpec> get(StaticAnalogOutputStatusVariation variation)
	{
		switch (variation)
		{
		case (StaticAnalogOutputStatusVariation.Group40Var1):
			return &opendnp3.Globals.WriteWithSerializer<AnalogOutputStatusSpec, Group40Var1>;
		case (StaticAnalogOutputStatusVariation.Group40Var2):
			return &opendnp3.Globals.WriteWithSerializer<AnalogOutputStatusSpec, Group40Var2>;
		case (StaticAnalogOutputStatusVariation.Group40Var3):
			return &opendnp3.Globals.WriteWithSerializer<AnalogOutputStatusSpec, Group40Var3>;
		case (StaticAnalogOutputStatusVariation.Group40Var4):
			return &opendnp3.Globals.WriteWithSerializer<AnalogOutputStatusSpec, Group40Var4>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<AnalogOutputStatusSpec, Group40Var1>;
		}
	}

	public static static_write_func_t<BinaryOutputStatusSpec> get(StaticBinaryOutputStatusVariation variation)
	{
		switch (variation)
		{
		case (StaticBinaryOutputStatusVariation.Group10Var2):
			return &opendnp3.Globals.WriteWithSerializer<BinaryOutputStatusSpec, Group10Var2>;
		default:
			return &opendnp3.Globals.WriteWithSerializer<BinaryOutputStatusSpec, Group10Var2>;
		}
	}

	public static static_write_func_t<OctetStringSpec> get(StaticOctetStringVariation variation)
	{
		return opendnp3.Globals.write_octet_strings;
	}

	public static static_write_func_t<TimeAndIntervalSpec> get(StaticTimeAndIntervalVariation variation)
	{
		return &opendnp3.Globals.WriteWithSerializer<TimeAndIntervalSpec, Group50Var4>;
	}
}

} // namespace opendnp3




