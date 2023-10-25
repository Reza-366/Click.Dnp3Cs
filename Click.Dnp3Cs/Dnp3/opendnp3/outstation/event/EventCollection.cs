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
//ORIGINAL LINE: template<class T>
public sealed class EventCollection <T> : IEventCollection<typename T.meas_t>
{
	private List<EventRecord>.Iterator iterator;
	private EventClassCounters counters;
	private T.event_variation_t variation = new T.event_variation_t();

	public EventCollection(List<EventRecord>.Iterator iterator, EventClassCounters counters, T.event_variation_t variation)
	{
		this.iterator = iterator;
		this.counters = new opendnp3.EventClassCounters(counters);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.variation = variation;
		this.variation.CopyFrom(variation);
	}

	public override UInt16 WriteSome(IEventWriter<typename T.meas_t> writer)
	{
		UInt16 num_written = 0;
		while (WriteOne(writer))
		{
			++num_written;
		}
		return new UInt16(num_written);
	}

	private bool WriteOne(IEventWriter<typename T.meas_t> writer)
	{
		// don't bother searching
		if (this.counters.selected == 0)
		{
			return false;
		}

		// find the next event with the same type and variation
		EventRecord record = EventWriting.FindNextSelected(this.iterator, T.EventTypeEnum);

		// nothing left to write
		if (record == null)
		{
			return false;
		}

		var data = TypedStorage<T>.Retrieve(record);

		// wrong variation
		if (data.value.selectedVariation != this.variation)
		{
			return false;
		}

		// unable to write
		if (!writer.Write(data.value.value, new UInt16(record.index)))
		{
			return false;
		}

		// success!
		this.counters.OnWrite(record.clazz);
		record.state = EventState.written;
		this.iterator.Next();
		return true;
	}
}

} // namespace opendnp3

