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

public sealed class Database : IUpdateHandler, IStaticSelector, IClassAssigner, IResponseLoader
{
	public Database(in DatabaseConfig config, IEventReceiver event_receiver, IDnpTimeSource time_source, StaticTypeBitField allowed_class_zero_types)
	{
		this.event_receiver = new opendnp3.IEventReceiver(event_receiver);
		this.time_source = new opendnp3.IDnpTimeSource(time_source);
		this.allowed_class_zero_types = new opendnp3.StaticTypeBitField(allowed_class_zero_types);
		this.binary_input = new opendnp3.StaticDataMap<BinarySpec>(config.binary_input);
		this.double_binary = new opendnp3.StaticDataMap<DoubleBitBinarySpec>(config.double_binary);
		this.analog_input = new opendnp3.StaticDataMap<AnalogSpec>(config.analog_input);
		this.counter = new opendnp3.StaticDataMap<CounterSpec>(config.counter);
		this.frozen_counter = new opendnp3.StaticDataMap<FrozenCounterSpec>(config.frozen_counter);
		this.binary_output_status = new opendnp3.StaticDataMap<BinaryOutputStatusSpec>(config.binary_output_status);
		this.analog_output_status = new opendnp3.StaticDataMap<AnalogOutputStatusSpec>(config.analog_output_status);
		this.time_and_interval = new opendnp3.StaticDataMap<TimeAndIntervalSpec>(config.time_and_interval);
		this.octet_string = new opendnp3.StaticDataMap<OctetStringSpec>(config.octet_string);
	}

	// ------- IStaticSelector -------------
	public IINField SelectAll(GroupVariation gv)
	{
		if (gv == GroupVariation.Group60Var1)
		{
			this.select_all_class_zero<BinarySpec>(this.binary_input);
			this.select_all_class_zero<DoubleBitBinarySpec>(this.double_binary);
			this.select_all_class_zero<BinaryOutputStatusSpec>(this.binary_output_status);
			this.select_all_class_zero<CounterSpec>(this.counter);
			this.select_all_class_zero<FrozenCounterSpec>(this.frozen_counter);
			this.select_all_class_zero<AnalogSpec>(this.analog_input);
			this.select_all_class_zero<AnalogOutputStatusSpec>(this.analog_output_status);
			this.select_all_class_zero<TimeAndIntervalSpec>(this.time_and_interval);
			this.select_all_class_zero<OctetStringSpec>(this.octet_string);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		}

		switch (gv)
		{
		case (GroupVariation.Group1Var0):
			return select_all<BinarySpec>(this.binary_input);
		case (GroupVariation.Group1Var1):
			return select_all<BinarySpec>(this.binary_input, StaticBinaryVariation.Group1Var1);
		case (GroupVariation.Group1Var2):
			return select_all<BinarySpec>(this.binary_input, StaticBinaryVariation.Group1Var2);

		case (GroupVariation.Group3Var0):
			return select_all<DoubleBitBinarySpec>(this.double_binary);
		case (GroupVariation.Group3Var2):
			return select_all<DoubleBitBinarySpec>(this.double_binary, StaticDoubleBinaryVariation.Group3Var2);

		case (GroupVariation.Group10Var0):
			return select_all<BinaryOutputStatusSpec>(this.binary_output_status);
		case (GroupVariation.Group10Var2):
			return select_all<BinaryOutputStatusSpec>(this.binary_output_status, StaticBinaryOutputStatusVariation.Group10Var2);

		case (GroupVariation.Group20Var0):
			return select_all<CounterSpec>(this.counter);
		case (GroupVariation.Group20Var1):
			return select_all<CounterSpec>(this.counter, StaticCounterVariation.Group20Var1);
		case (GroupVariation.Group20Var2):
			return select_all<CounterSpec>(this.counter, StaticCounterVariation.Group20Var2);
		case (GroupVariation.Group20Var5):
			return select_all<CounterSpec>(this.counter, StaticCounterVariation.Group20Var5);
		case (GroupVariation.Group20Var6):
			return select_all<CounterSpec>(this.counter, StaticCounterVariation.Group20Var6);

		case (GroupVariation.Group21Var0):
			return select_all<FrozenCounterSpec>(this.frozen_counter);
		case (GroupVariation.Group21Var1):
			return select_all<FrozenCounterSpec>(this.frozen_counter, StaticFrozenCounterVariation.Group21Var1);
		case (GroupVariation.Group21Var2):
			return select_all<FrozenCounterSpec>(this.frozen_counter, StaticFrozenCounterVariation.Group21Var2);
		case (GroupVariation.Group21Var5):
			return select_all<FrozenCounterSpec>(this.frozen_counter, StaticFrozenCounterVariation.Group21Var5);
		case (GroupVariation.Group21Var6):
			return select_all<FrozenCounterSpec>(this.frozen_counter, StaticFrozenCounterVariation.Group21Var6);
		case (GroupVariation.Group21Var9):
			return select_all<FrozenCounterSpec>(this.frozen_counter, StaticFrozenCounterVariation.Group21Var9);
		case (GroupVariation.Group21Var10):
			return select_all<FrozenCounterSpec>(this.frozen_counter, StaticFrozenCounterVariation.Group21Var10);

		case (GroupVariation.Group30Var0):
			return select_all<AnalogSpec>(this.analog_input);
		case (GroupVariation.Group30Var1):
			return select_all<AnalogSpec>(this.analog_input, StaticAnalogVariation.Group30Var1);
		case (GroupVariation.Group30Var2):
			return select_all<AnalogSpec>(this.analog_input, StaticAnalogVariation.Group30Var2);
		case (GroupVariation.Group30Var3):
			return select_all<AnalogSpec>(this.analog_input, StaticAnalogVariation.Group30Var3);
		case (GroupVariation.Group30Var4):
			return select_all<AnalogSpec>(this.analog_input, StaticAnalogVariation.Group30Var4);
		case (GroupVariation.Group30Var5):
			return select_all<AnalogSpec>(this.analog_input, StaticAnalogVariation.Group30Var5);
		case (GroupVariation.Group30Var6):
			return select_all<AnalogSpec>(this.analog_input, StaticAnalogVariation.Group30Var6);

		case (GroupVariation.Group40Var0):
			return select_all<AnalogOutputStatusSpec>(this.analog_output_status);
		case (GroupVariation.Group40Var1):
			return select_all<AnalogOutputStatusSpec>(this.analog_output_status, StaticAnalogOutputStatusVariation.Group40Var1);
		case (GroupVariation.Group40Var2):
			return select_all<AnalogOutputStatusSpec>(this.analog_output_status, StaticAnalogOutputStatusVariation.Group40Var2);
		case (GroupVariation.Group40Var3):
			return select_all<AnalogOutputStatusSpec>(this.analog_output_status, StaticAnalogOutputStatusVariation.Group40Var3);
		case (GroupVariation.Group40Var4):
			return select_all<AnalogOutputStatusSpec>(this.analog_output_status, StaticAnalogOutputStatusVariation.Group40Var4);

		case (GroupVariation.Group50Var4):
			return select_all<TimeAndIntervalSpec>(this.time_and_interval, StaticTimeAndIntervalVariation.Group50Var4);

		case (GroupVariation.Group110Var0):
			return select_all<OctetStringSpec>(this.octet_string);

		default:
			return new IINField(IINBit.FUNC_NOT_SUPPORTED);
		}
	}

	public IINField SelectRange(GroupVariation gv, in Range range)
	{
		switch (gv)
		{
		case (GroupVariation.Group1Var0):
			return select_range<BinarySpec>(this.binary_input, range);
		case (GroupVariation.Group1Var1):
			return select_range<BinarySpec>(this.binary_input, range, StaticBinaryVariation.Group1Var1);
		case (GroupVariation.Group1Var2):
			return select_range<BinarySpec>(this.binary_input, range, StaticBinaryVariation.Group1Var2);

		case (GroupVariation.Group3Var0):
			return select_range<DoubleBitBinarySpec>(this.double_binary, range);
		case (GroupVariation.Group3Var2):
			return select_range<DoubleBitBinarySpec>(this.double_binary, range, StaticDoubleBinaryVariation.Group3Var2);

		case (GroupVariation.Group10Var0):
			return select_range<BinaryOutputStatusSpec>(this.binary_output_status, range);
		case (GroupVariation.Group10Var2):
			return select_range<BinaryOutputStatusSpec>(this.binary_output_status, range, StaticBinaryOutputStatusVariation.Group10Var2);

		case (GroupVariation.Group20Var0):
			return select_range<CounterSpec>(this.counter, range);
		case (GroupVariation.Group20Var1):
			return select_range<CounterSpec>(this.counter, range, StaticCounterVariation.Group20Var1);
		case (GroupVariation.Group20Var2):
			return select_range<CounterSpec>(this.counter, range, StaticCounterVariation.Group20Var2);
		case (GroupVariation.Group20Var5):
			return select_range<CounterSpec>(this.counter, range, StaticCounterVariation.Group20Var5);
		case (GroupVariation.Group20Var6):
			return select_range<CounterSpec>(this.counter, range, StaticCounterVariation.Group20Var6);

		case (GroupVariation.Group21Var0):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range);
		case (GroupVariation.Group21Var1):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range, StaticFrozenCounterVariation.Group21Var1);
		case (GroupVariation.Group21Var2):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range, StaticFrozenCounterVariation.Group21Var2);
		case (GroupVariation.Group21Var5):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range, StaticFrozenCounterVariation.Group21Var5);
		case (GroupVariation.Group21Var6):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range, StaticFrozenCounterVariation.Group21Var6);
		case (GroupVariation.Group21Var9):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range, StaticFrozenCounterVariation.Group21Var9);
		case (GroupVariation.Group21Var10):
			return select_range<FrozenCounterSpec>(this.frozen_counter, range, StaticFrozenCounterVariation.Group21Var10);

		case (GroupVariation.Group30Var0):
			return select_range<AnalogSpec>(this.analog_input, range);
		case (GroupVariation.Group30Var1):
			return select_range<AnalogSpec>(this.analog_input, range, StaticAnalogVariation.Group30Var1);
		case (GroupVariation.Group30Var2):
			return select_range<AnalogSpec>(this.analog_input, range, StaticAnalogVariation.Group30Var2);
		case (GroupVariation.Group30Var3):
			return select_range<AnalogSpec>(this.analog_input, range, StaticAnalogVariation.Group30Var3);
		case (GroupVariation.Group30Var4):
			return select_range<AnalogSpec>(this.analog_input, range, StaticAnalogVariation.Group30Var4);
		case (GroupVariation.Group30Var5):
			return select_range<AnalogSpec>(this.analog_input, range, StaticAnalogVariation.Group30Var5);
		case (GroupVariation.Group30Var6):
			return select_range<AnalogSpec>(this.analog_input, range, StaticAnalogVariation.Group30Var6);

		case (GroupVariation.Group40Var0):
			return select_range<AnalogOutputStatusSpec>(this.analog_output_status, range);
		case (GroupVariation.Group40Var1):
			return select_range<AnalogOutputStatusSpec>(this.analog_output_status, range, StaticAnalogOutputStatusVariation.Group40Var1);
		case (GroupVariation.Group40Var2):
			return select_range<AnalogOutputStatusSpec>(this.analog_output_status, range, StaticAnalogOutputStatusVariation.Group40Var2);
		case (GroupVariation.Group40Var3):
			return select_range<AnalogOutputStatusSpec>(this.analog_output_status, range, StaticAnalogOutputStatusVariation.Group40Var3);
		case (GroupVariation.Group40Var4):
			return select_range<AnalogOutputStatusSpec>(this.analog_output_status, range, StaticAnalogOutputStatusVariation.Group40Var4);

		case (GroupVariation.Group50Var4):
			return select_range<TimeAndIntervalSpec>(this.time_and_interval, range, StaticTimeAndIntervalVariation.Group50Var4);

		case (GroupVariation.Group110Var0):
			return select_range<OctetStringSpec>(this.octet_string, range, StaticOctetStringVariation.Group110Var0);

		default:
			return new IINField(IINBit.FUNC_NOT_SUPPORTED);
		}
	}

	public IINField SelectIndices(GroupVariation gv, in ICollection<ushort> indices)
	{
		switch (gv)
		{
		case (GroupVariation.Group1Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->binary_input, indices);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.binary_input, indices));
		case (GroupVariation.Group1Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->binary_input, indices, StaticBinaryVariation::Group1Var1);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.binary_input, indices, StaticBinaryVariation.Group1Var1));
		case (GroupVariation.Group1Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->binary_input, indices, StaticBinaryVariation::Group1Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.binary_input, indices, StaticBinaryVariation.Group1Var2));

		case (GroupVariation.Group3Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->double_binary, indices);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.double_binary, indices));
		case (GroupVariation.Group3Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->double_binary, indices, StaticDoubleBinaryVariation::Group3Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.double_binary, indices, StaticDoubleBinaryVariation.Group3Var2));

		case (GroupVariation.Group10Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->binary_output_status, indices);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.binary_output_status, indices));
		case (GroupVariation.Group10Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->binary_output_status, indices, StaticBinaryOutputStatusVariation::Group10Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.binary_output_status, indices, StaticBinaryOutputStatusVariation.Group10Var2));

		case (GroupVariation.Group20Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->counter, indices);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.counter, indices));
		case (GroupVariation.Group20Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->counter, indices, StaticCounterVariation::Group20Var1);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.counter, indices, StaticCounterVariation.Group20Var1));
		case (GroupVariation.Group20Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->counter, indices, StaticCounterVariation::Group20Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.counter, indices, StaticCounterVariation.Group20Var2));
		case (GroupVariation.Group20Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->counter, indices, StaticCounterVariation::Group20Var5);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.counter, indices, StaticCounterVariation.Group20Var5));
		case (GroupVariation.Group20Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->counter, indices, StaticCounterVariation::Group20Var6);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.counter, indices, StaticCounterVariation.Group20Var6));

		case (GroupVariation.Group21Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices));
		case (GroupVariation.Group21Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices, StaticFrozenCounterVariation::Group21Var1);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices, StaticFrozenCounterVariation.Group21Var1));
		case (GroupVariation.Group21Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices, StaticFrozenCounterVariation::Group21Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices, StaticFrozenCounterVariation.Group21Var2));
		case (GroupVariation.Group21Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices, StaticFrozenCounterVariation::Group21Var5);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices, StaticFrozenCounterVariation.Group21Var5));
		case (GroupVariation.Group21Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices, StaticFrozenCounterVariation::Group21Var6);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices, StaticFrozenCounterVariation.Group21Var6));
		case (GroupVariation.Group21Var9):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices, StaticFrozenCounterVariation::Group21Var9);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices, StaticFrozenCounterVariation.Group21Var9));
		case (GroupVariation.Group21Var10):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->frozen_counter, indices, StaticFrozenCounterVariation::Group21Var10);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.frozen_counter, indices, StaticFrozenCounterVariation.Group21Var10));

		case (GroupVariation.Group30Var0):
			return opendnp3.Globals.select_indices<AnalogSpec>(this.analog_input, indices);
		case (GroupVariation.Group30Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_input, indices, StaticAnalogVariation::Group30Var1);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_input, indices, StaticAnalogVariation.Group30Var1));
		case (GroupVariation.Group30Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_input, indices, StaticAnalogVariation::Group30Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_input, indices, StaticAnalogVariation.Group30Var2));
		case (GroupVariation.Group30Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_input, indices, StaticAnalogVariation::Group30Var3);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_input, indices, StaticAnalogVariation.Group30Var3));
		case (GroupVariation.Group30Var4):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_input, indices, StaticAnalogVariation::Group30Var4);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_input, indices, StaticAnalogVariation.Group30Var4));
		case (GroupVariation.Group30Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_input, indices, StaticAnalogVariation::Group30Var5);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_input, indices, StaticAnalogVariation.Group30Var5));
		case (GroupVariation.Group30Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_input, indices, StaticAnalogVariation::Group30Var6);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_input, indices, StaticAnalogVariation.Group30Var6));

		case (GroupVariation.Group40Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_output_status, indices);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_output_status, indices));
		case (GroupVariation.Group40Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_output_status, indices, StaticAnalogOutputStatusVariation::Group40Var1);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_output_status, indices, StaticAnalogOutputStatusVariation.Group40Var1));
		case (GroupVariation.Group40Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_output_status, indices, StaticAnalogOutputStatusVariation::Group40Var2);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_output_status, indices, StaticAnalogOutputStatusVariation.Group40Var2));
		case (GroupVariation.Group40Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_output_status, indices, StaticAnalogOutputStatusVariation::Group40Var3);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_output_status, indices, StaticAnalogOutputStatusVariation.Group40Var3));
		case (GroupVariation.Group40Var4):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->analog_output_status, indices, StaticAnalogOutputStatusVariation::Group40Var4);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.analog_output_status, indices, StaticAnalogOutputStatusVariation.Group40Var4));

		case (GroupVariation.Group50Var4):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->time_and_interval, indices, StaticTimeAndIntervalVariation::Group50Var4);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.time_and_interval, indices, StaticTimeAndIntervalVariation.Group50Var4));

		case (GroupVariation.Group110Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return select_indices(this->octet_string, indices, StaticOctetStringVariation::Group110Var0);
			return new opendnp3.IINField(opendnp3.Globals.select_indices(this.octet_string, indices, StaticOctetStringVariation.Group110Var0));

		default:
			return new IINField(IINBit.FUNC_NOT_SUPPORTED);
		}
	}

	public void Unselect()
	{
		this.binary_input.clear_selection();
		this.double_binary.clear_selection();
		this.binary_output_status.clear_selection();
		this.counter.clear_selection();
		this.frozen_counter.clear_selection();
		this.analog_input.clear_selection();
		this.analog_output_status.clear_selection();
		this.time_and_interval.clear_selection();
		this.octet_string.clear_selection();
	}

	// ------- IClassAssigner -------------
	public Range AssignClassToAll(AssignClassType type, PointClass clazz)
	{
		switch (type)
		{
		case (AssignClassType.BinaryInput):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->binary_input.assign_class(clazz);
			return new opendnp3.Range(this.binary_input.assign_class(clazz));
		case (AssignClassType.DoubleBinaryInput):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->double_binary.assign_class(clazz);
			return new opendnp3.Range(this.double_binary.assign_class(clazz));
		case (AssignClassType.Counter):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->counter.assign_class(clazz);
			return new opendnp3.Range(this.counter.assign_class(clazz));
		case (AssignClassType.FrozenCounter):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->frozen_counter.assign_class(clazz);
			return new opendnp3.Range(this.frozen_counter.assign_class(clazz));
		case (AssignClassType.AnalogInput):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->analog_input.assign_class(clazz);
			return new opendnp3.Range(this.analog_input.assign_class(clazz));
		case (AssignClassType.BinaryOutputStatus):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->binary_output_status.assign_class(clazz);
			return new opendnp3.Range(this.binary_output_status.assign_class(clazz));
		case (AssignClassType.AnalogOutputStatus):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->analog_output_status.assign_class(clazz);
			return new opendnp3.Range(this.analog_output_status.assign_class(clazz));
		default:
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Range::Invalid();
			return new opendnp3.Range(Range.Invalid());
		}
	}

	public Range AssignClassToRange(AssignClassType type, PointClass clazz, in Range range)
	{
		switch (type)
		{
		case (AssignClassType.BinaryInput):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->binary_input.assign_class(clazz, range);
			return new opendnp3.Range(this.binary_input.assign_class(clazz, range));
		case (AssignClassType.DoubleBinaryInput):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->double_binary.assign_class(clazz, range);
			return new opendnp3.Range(this.double_binary.assign_class(clazz, range));
		case (AssignClassType.Counter):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->counter.assign_class(clazz, range);
			return new opendnp3.Range(this.counter.assign_class(clazz, range));
		case (AssignClassType.FrozenCounter):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->frozen_counter.assign_class(clazz, range);
			return new opendnp3.Range(this.frozen_counter.assign_class(clazz, range));
		case (AssignClassType.AnalogInput):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->analog_input.assign_class(clazz, range);
			return new opendnp3.Range(this.analog_input.assign_class(clazz, range));
		case (AssignClassType.BinaryOutputStatus):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->binary_output_status.assign_class(clazz, range);
			return new opendnp3.Range(this.binary_output_status.assign_class(clazz, range));
		case (AssignClassType.AnalogOutputStatus):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->analog_output_status.assign_class(clazz, range);
			return new opendnp3.Range(this.analog_output_status.assign_class(clazz, range));
		default:
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Range::Invalid();
			return new opendnp3.Range(Range.Invalid());
		}
	}

	// ------- IResponseLoader -------------
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasAnySelection() const override
	public bool HasAnySelection()
	{
		return binary_input.has_any_selection() || double_binary.has_any_selection() || analog_input.has_any_selection() || counter.has_any_selection() || frozen_counter.has_any_selection() || binary_output_status.has_any_selection() || analog_output_status.has_any_selection() || time_and_interval.has_any_selection() || octet_string.has_any_selection();
	}

	public bool Load(HeaderWriter writer)
	{
		return opendnp3.Globals.load_type(this.binary_input, writer) && opendnp3.Globals.load_type(this.double_binary, writer) && opendnp3.Globals.load_type(this.analog_input, writer) && opendnp3.Globals.load_type(this.counter, writer) && opendnp3.Globals.load_type(this.frozen_counter, writer) && opendnp3.Globals.load_type(this.binary_output_status, writer) && opendnp3.Globals.load_type(this.analog_output_status, writer) && opendnp3.Globals.load_type(this.time_and_interval, writer) && opendnp3.Globals.load_type(this.octet_string, writer);
	}

	// ------- IUpdateHandler ---------------
	public override bool Update(in Binary meas, ushort index, EventMode mode)
	{
		return this.binary_input.update(meas, index, mode, event_receiver);
	}

	public override bool Update(in DoubleBitBinary meas, ushort index, EventMode mode)
	{
		return this.double_binary.update(meas, index, mode, event_receiver);
	}

	public override bool Update(in Analog meas, ushort index, EventMode mode)
	{
		return this.analog_input.update(meas, index, mode, event_receiver);
	}

	public override bool Update(in Counter meas, ushort index, EventMode mode)
	{
		return this.counter.update(meas, index, mode, event_receiver);
	}

	public override bool FreezeCounter(ushort index, bool clear, EventMode mode)
	{
		var num_selected = this.counter.select(Range.From(new ushort(index), new ushort(index)));
		this.FreezeSelectedCounters(clear, mode);

		return num_selected > 0;
	}

	public override bool Update(in BinaryOutputStatus meas, ushort index, EventMode mode)
	{
		return this.binary_output_status.update(meas, index, mode, event_receiver);
	}

	public override bool Update(in AnalogOutputStatus meas, ushort index, EventMode mode)
	{
		return this.analog_output_status.update(meas, index, mode, event_receiver);
	}

	public override bool Update(in OctetString meas, ushort index, EventMode mode)
	{
		return this.octet_string.update(meas, index, mode, event_receiver);
	}

	public override bool Update(in TimeAndInterval meas, ushort index)
	{
		return this.time_and_interval.update(meas, index, EventMode.Suppress, event_receiver);
	}

	public override bool Modify(FlagsType type, ushort start, ushort stop, byte flags)
	{
		switch (type)
		{
		case (FlagsType.BinaryInput):
			return this.binary_input.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		case (FlagsType.DoubleBinaryInput):
			return this.double_binary.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		case (FlagsType.AnalogInput):
			return this.analog_input.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		case (FlagsType.Counter):
			return this.counter.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		case (FlagsType.FrozenCounter):
			return this.frozen_counter.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		case (FlagsType.BinaryOutputStatus):
			return this.binary_output_status.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		case (FlagsType.AnalogOutputStatus):
			return this.analog_output_status.modify(new ushort(start), new ushort(stop), new byte(flags), this.event_receiver);
		}

		return false;
	}

	public bool FreezeSelectedCounters(bool clear, EventMode mode = EventMode.Detect)
	{
		foreach (var c in this.counter)
		{
			FrozenCounter new_value = new FrozenCounter(c.second.value.value, c.second.value.flags, time_source.Now());
			this.frozen_counter.update(new_value, c.first, mode, this.event_receiver);

			if (clear)
			{
				c.second.value.value = 0;
				c.second.value.time = time_source.Now();
				this.counter.update(c.second.value, c.first, mode, this.event_receiver);
			}
		}

		this.counter.clear_selection();

		return true;
	}

	private IEventReceiver event_receiver;
	private IDnpTimeSource time_source;
	private StaticTypeBitField allowed_class_zero_types = new StaticTypeBitField();

	private StaticDataMap<BinarySpec> binary_input = new StaticDataMap<BinarySpec>();
	private StaticDataMap<DoubleBitBinarySpec> double_binary = new StaticDataMap<DoubleBitBinarySpec>();
	private StaticDataMap<AnalogSpec> analog_input = new StaticDataMap<AnalogSpec>();
	private StaticDataMap<CounterSpec> counter = new StaticDataMap<CounterSpec>();
	private StaticDataMap<FrozenCounterSpec> frozen_counter = new StaticDataMap<FrozenCounterSpec>();
	private StaticDataMap<BinaryOutputStatusSpec> binary_output_status = new StaticDataMap<BinaryOutputStatusSpec>();
	private StaticDataMap<AnalogOutputStatusSpec> analog_output_status = new StaticDataMap<AnalogOutputStatusSpec>();
	private StaticDataMap<TimeAndIntervalSpec> time_and_interval = new StaticDataMap<TimeAndIntervalSpec>();
	private StaticDataMap<OctetStringSpec> octet_string = new StaticDataMap<OctetStringSpec>();

	// ----- helper methods ------

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
	private void select_all_class_zero<Spec>(StaticDataMap<Spec> map)
	{
		if (this.allowed_class_zero_types.IsSet(Spec.StaticTypeEnum))
		{
			select_all<Spec>(map);
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
	private static IINField select_all<Spec>(StaticDataMap<Spec> map)
	{
		map.select_all();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
	private static IINField select_all<Spec>(StaticDataMap<Spec> map, Spec.static_variation_t variation)
	{
		map.select_all(new Spec.static_variation_t(variation));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
	private static IINField select_range<Spec>(StaticDataMap<Spec> map, in Range range)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: const auto count = map.select(range);
		var count = map.select(new opendnp3.Range(range));
		return (count != range.Count()) ? new IINField(IINBit.PARAM_ERROR) : IINField.Empty();
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
	private static IINField select_range<Spec>(StaticDataMap<Spec> map, in Range range, Spec.static_variation_t variation)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: const auto count = map.select(range, variation);
		var count = map.select(new opendnp3.Range(range), new Spec.static_variation_t(variation));
		return (count != range.Count()) ? new IINField(IINBit.PARAM_ERROR) : IINField.Empty();
	}
}

} // namespace opendnp3



