using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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

public class DatabaseConfig
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	DatabaseConfig() = default;

	public DatabaseConfig(ushort all_types)
	{
		opendnp3.Globals.initialize(this.binary_input, new ushort(all_types));
		opendnp3.Globals.initialize(this.double_binary, new ushort(all_types));
		opendnp3.Globals.initialize(this.analog_input, new ushort(all_types));
		opendnp3.Globals.initialize(this.counter, new ushort(all_types));
		opendnp3.Globals.initialize(this.frozen_counter, new ushort(all_types));
		opendnp3.Globals.initialize(this.binary_output_status, new ushort(all_types));
		opendnp3.Globals.initialize(this.analog_output_status, new ushort(all_types));
		opendnp3.Globals.initialize(this.time_and_interval, new ushort(all_types));
		opendnp3.Globals.initialize(this.octet_string, new ushort(all_types));
	}

	public SortedDictionary<ushort, BinaryConfig> binary_input = new SortedDictionary<ushort, BinaryConfig>();
	public SortedDictionary<ushort, DoubleBitBinaryConfig> double_binary = new SortedDictionary<ushort, DoubleBitBinaryConfig>();
	public SortedDictionary<ushort, AnalogConfig> analog_input = new SortedDictionary<ushort, AnalogConfig>();
	public SortedDictionary<ushort, CounterConfig> counter = new SortedDictionary<ushort, CounterConfig>();
	public SortedDictionary<ushort, FrozenCounterConfig> frozen_counter = new SortedDictionary<ushort, FrozenCounterConfig>();
	public SortedDictionary<ushort, BOStatusConfig> binary_output_status = new SortedDictionary<ushort, BOStatusConfig>();
	public SortedDictionary<ushort, AOStatusConfig> analog_output_status = new SortedDictionary<ushort, AOStatusConfig>();
	public SortedDictionary<ushort, TimeAndIntervalConfig> time_and_interval = new SortedDictionary<ushort, TimeAndIntervalConfig>();
	public SortedDictionary<ushort, OctetStringConfig> octet_string = new SortedDictionary<ushort, OctetStringConfig>();
}

} // namespace opendnp3



