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

  Configuration of maximum event counts per event type.

  The underlying implementation uses a *preallocated* heap buffer to store events
  until they are transmitted to the master. The size of this buffer is proportional
  to the TotalEvents() method, i.e. the sum of the maximum events for each type.

  Implementations should configure the buffers to store a reasonable number events
  given the polling frequency and memory restrictions of the target platform.

*/
public class EventBufferConfig
{
	/**
	    Construct the class using the same maximum for all types. This is mainly used for demo purposes.
	    You probably don't want to use this method unless your implementation actually reports every type.
	*/
	public static EventBufferConfig AllTypes(UInt16 sizes)
	{
		return new EventBufferConfig(sizes, sizes, sizes, sizes, sizes, sizes, sizes, sizes);
	}

	/**
	    Construct the class specifying the maximum number of events for each type individually.
	*/
	public EventBufferConfig(UInt16 maxBinaryEvents = 0, UInt16 maxDoubleBinaryEvents = 0, UInt16 maxAnalogEvents = 0, UInt16 maxCounterEvents = 0, UInt16 maxFrozenCounterEvents = 0, UInt16 maxBinaryOutputStatusEvents = 0, UInt16 maxAnalogOutputStatusEvents = 0, UInt16 maxOctetStringEvents = 0)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxBinaryEvents = maxBinaryEvents;
		this.maxBinaryEvents.CopyFrom(maxBinaryEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxDoubleBinaryEvents = maxDoubleBinaryEvents;
		this.maxDoubleBinaryEvents.CopyFrom(maxDoubleBinaryEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxAnalogEvents = maxAnalogEvents;
		this.maxAnalogEvents.CopyFrom(maxAnalogEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxCounterEvents = maxCounterEvents;
		this.maxCounterEvents.CopyFrom(maxCounterEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxFrozenCounterEvents = maxFrozenCounterEvents;
		this.maxFrozenCounterEvents.CopyFrom(maxFrozenCounterEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxBinaryOutputStatusEvents = maxBinaryOutputStatusEvents;
		this.maxBinaryOutputStatusEvents.CopyFrom(maxBinaryOutputStatusEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxAnalogOutputStatusEvents = maxAnalogOutputStatusEvents;
		this.maxAnalogOutputStatusEvents.CopyFrom(maxAnalogOutputStatusEvents);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxOctetStringEvents = maxOctetStringEvents;
		this.maxOctetStringEvents.CopyFrom(maxOctetStringEvents);
	}

	// Returns the sum of all event count maximums (number of elements in preallocated buffer)
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: System.UInt32 TotalEvents() const
	public System.UInt32 TotalEvents()
	{
		return maxBinaryEvents + maxDoubleBinaryEvents + maxAnalogEvents + maxCounterEvents + maxFrozenCounterEvents + maxBinaryOutputStatusEvents + maxAnalogOutputStatusEvents + maxOctetStringEvents;
	}

	// The number of binary events the outstation will buffer before overflowing
	public UInt16 maxBinaryEvents = new UInt16();

	// The number of double bit binary events the outstation will buffer before overflowing
	public UInt16 maxDoubleBinaryEvents = new UInt16();

	// The number of analog events the outstation will buffer before overflowing
	public UInt16 maxAnalogEvents = new UInt16();

	// The number of counter events the outstation will buffer before overflowing
	public UInt16 maxCounterEvents = new UInt16();

	// The number of frozen counter events the outstation will buffer before overflowing
	public UInt16 maxFrozenCounterEvents = new UInt16();

	// The number of binary output status events the outstation will buffer before overflowing
	public UInt16 maxBinaryOutputStatusEvents = new UInt16();

	// The number of analog output status events the outstation will buffer before overflowing
	public UInt16 maxAnalogOutputStatusEvents = new UInt16();

	// The number of analog output status events the outstation will buffer before overflowing
	public UInt16 maxOctetStringEvents = new UInt16();
}

} // namespace opendnp3



