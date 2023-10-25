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

	public DatabaseConfig(UInt16 all_types)
	{
		opendnp3.Globals.initialize(this.binary_input, new UInt16(all_types));
		opendnp3.Globals.initialize(this.double_binary, new UInt16(all_types));
		opendnp3.Globals.initialize(this.analog_input, new UInt16(all_types));
		opendnp3.Globals.initialize(this.counter, new UInt16(all_types));
		opendnp3.Globals.initialize(this.frozen_counter, new UInt16(all_types));
		opendnp3.Globals.initialize(this.binary_output_status, new UInt16(all_types));
		opendnp3.Globals.initialize(this.analog_output_status, new UInt16(all_types));
		opendnp3.Globals.initialize(this.time_and_interval, new UInt16(all_types));
		opendnp3.Globals.initialize(this.octet_string, new UInt16(all_types));
	}

	public SortedDictionary<UInt16, BinaryConfig> binary_input = new SortedDictionary<UInt16, BinaryConfig>();
	public SortedDictionary<UInt16, DoubleBitBinaryConfig> double_binary = new SortedDictionary<UInt16, DoubleBitBinaryConfig>();
	public SortedDictionary<UInt16, AnalogConfig> analog_input = new SortedDictionary<UInt16, AnalogConfig>();
	public SortedDictionary<UInt16, CounterConfig> counter = new SortedDictionary<UInt16, CounterConfig>();
	public SortedDictionary<UInt16, FrozenCounterConfig> frozen_counter = new SortedDictionary<UInt16, FrozenCounterConfig>();
	public SortedDictionary<UInt16, BOStatusConfig> binary_output_status = new SortedDictionary<UInt16, BOStatusConfig>();
	public SortedDictionary<UInt16, AOStatusConfig> analog_output_status = new SortedDictionary<UInt16, AOStatusConfig>();
	public SortedDictionary<UInt16, TimeAndIntervalConfig> time_and_interval = new SortedDictionary<UInt16, TimeAndIntervalConfig>();
	public SortedDictionary<UInt16, OctetStringConfig> octet_string = new SortedDictionary<UInt16, OctetStringConfig>();
}

} // namespace opendnp3



