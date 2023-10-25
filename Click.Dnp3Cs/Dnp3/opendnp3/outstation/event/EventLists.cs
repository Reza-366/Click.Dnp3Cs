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


//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class EventLists : private Uncopyable
public class EventLists : Uncopyable
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	EventLists() = delete;

	public EventLists(in EventBufferConfig config)
	{
		this.events = config.TotalEvents();
		this.binary = config.maxBinaryEvents;
		this.doubleBinary = config.maxDoubleBinaryEvents;
		this.analog = config.maxAnalogEvents;
		this.counter = config.maxCounterEvents;
		this.frozenCounter = config.maxFrozenCounterEvents;
		this.binaryOutputStatus = config.maxBinaryOutputStatusEvents;
		this.analogOutputStatus = config.maxAnalogOutputStatusEvents;
		this.octetString = config.maxOctetStringEvents;
	}

	// master list keeps the aggregate order and generic data
	public List<EventRecord> events = new List<EventRecord>();

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public List<TypedEventRecord<BinarySpec>> GetList<T>()
	{
		return new List<TypedEventRecord<BinarySpec>>(this.binary);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsAnyTypeFull() const
	public bool IsAnyTypeFull()
	{
		return this.binary.IsFullAndCapacityNotZero() || this.doubleBinary.IsFullAndCapacityNotZero() || this.counter.IsFullAndCapacityNotZero() || this.frozenCounter.IsFullAndCapacityNotZero() || this.analog.IsFullAndCapacityNotZero() || this.binaryOutputStatus.IsFullAndCapacityNotZero() || this.analogOutputStatus.IsFullAndCapacityNotZero() || this.octetString.IsFullAndCapacityNotZero();
	}

	public EventClassCounters counters = new EventClassCounters();

	// sub-lists just act as type-specific storage
	private List<TypedEventRecord<BinarySpec>> binary = new List<TypedEventRecord<BinarySpec>>();
	private List<TypedEventRecord<DoubleBitBinarySpec>> doubleBinary = new List<TypedEventRecord<DoubleBitBinarySpec>>();
	private List<TypedEventRecord<AnalogSpec>> analog = new List<TypedEventRecord<AnalogSpec>>();
	private List<TypedEventRecord<CounterSpec>> counter = new List<TypedEventRecord<CounterSpec>>();
	private List<TypedEventRecord<FrozenCounterSpec>> frozenCounter = new List<TypedEventRecord<FrozenCounterSpec>>();
	private List<TypedEventRecord<BinaryOutputStatusSpec>> binaryOutputStatus = new List<TypedEventRecord<BinaryOutputStatusSpec>>();
	private List<TypedEventRecord<AnalogOutputStatusSpec>> analogOutputStatus = new List<TypedEventRecord<AnalogOutputStatusSpec>>();
	private List<TypedEventRecord<OctetStringSpec>> octetString = new List<TypedEventRecord<OctetStringSpec>>();
}

} // namespace opendnp3



namespace opendnp3
{








} // namespace opendnp3
