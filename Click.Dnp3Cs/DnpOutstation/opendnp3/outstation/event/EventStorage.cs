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

/*
    Data-stucture for holding events.

    * Only performs dynamic allocation at initialization
    * Maintains distinct lists for each type of event to optimize memory usage
*/

public class EventStorage
{

	public EventStorage(in EventBufferConfig config)
	{
		this.state = new opendnp3.EventLists(config);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsAnyTypeFull() const
	public bool IsAnyTypeFull()
	{
		return this.state.IsAnyTypeFull();
	}

	// number selected
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint NumSelected() const
	public uint NumSelected()
	{
		return new uint(this.state.counters.selected);
	}

	// unselected/selected but not already written
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint NumUnwritten(EventClass clazz) const
	public uint NumUnwritten(EventClass clazz)
	{
		return this.state.counters.total.Get(clazz) - this.state.counters.written.Get(clazz);
	}

	// write selected events to some handler
	public uint Write(IEventWriteHandler handler)
	{
		return new uint(EventWriting.Write(this.state, handler));
	}

	// all written events go back to unselected state
	public uint ClearWritten()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto written = [this](EventRecord& record)->bool
		var written = (EventRecord record) =>
		{
			if (record.state == EventState.written)
			{
				record.type.RemoveTypeFromStorage(record, this.state);
				this.state.counters.OnRemove(record.clazz, record.state);
				return true;
			}

			return false;
		};

		return this.state.events.RemoveAll(written);
	}

	// all written and selected events are reverted to unselected state
	public void Unselect()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var clear = (EventRecord record) =>
		{
			record.state = EventState.unselected;
		};

		this.state.events.Foreach(clear);

		// keep the total, but clear the selected/written
		this.state.counters.ResetOnFail();
	}

	// ---- these functions return true if an overflow occurs ----

	public bool Update(in Event<BinarySpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<DoubleBitBinarySpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<AnalogSpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<CounterSpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<FrozenCounterSpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<BinaryOutputStatusSpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<AnalogOutputStatusSpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	public bool Update(in Event<OctetStringSpec> evt)
	{
		return EventUpdate.Update(state, evt);
	}

	// ---- function used to select distinct types ----

	public uint SelectByType(EventBinaryVariation variation, uint max)
	{
		return EventSelection.SelectByType<BinarySpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventDoubleBinaryVariation variation, uint max)
	{
		return EventSelection.SelectByType<DoubleBitBinarySpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventAnalogVariation variation, uint max)
	{
		return EventSelection.SelectByType<AnalogSpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventCounterVariation variation, uint max)
	{
		return EventSelection.SelectByType<CounterSpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventFrozenCounterVariation variation, uint max)
	{
		return EventSelection.SelectByType<FrozenCounterSpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventBinaryOutputStatusVariation variation, uint max)
	{
		return EventSelection.SelectByType<BinaryOutputStatusSpec>(this.state, variation, ser4cpp.Globals.max);
		return 0;
	}

	public uint SelectByType(EventAnalogOutputStatusVariation variation, uint max)
	{
		return EventSelection.SelectByType<AnalogOutputStatusSpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventOctetStringVariation variation, uint max)
	{
		return EventSelection.SelectByType<OctetStringSpec>(this.state, variation, ser4cpp.Globals.max);
	}

	public uint SelectByType(EventType type, uint max)
	{
		switch (type)
		{
		case (EventType.Binary):
			return EventSelection.SelectByType<BinarySpec>(this.state, ser4cpp.Globals.max);
		case (EventType.DoubleBitBinary):
			return EventSelection.SelectByType<DoubleBitBinarySpec>(this.state, ser4cpp.Globals.max);
		case (EventType.Counter):
			return EventSelection.SelectByType<CounterSpec>(this.state, ser4cpp.Globals.max);
		case (EventType.FrozenCounter):
			return EventSelection.SelectByType<FrozenCounterSpec>(this.state, ser4cpp.Globals.max);
		case (EventType.Analog):
			return EventSelection.SelectByType<AnalogSpec>(this.state, ser4cpp.Globals.max);
		case (EventType.BinaryOutputStatus):
			return EventSelection.SelectByType<BinaryOutputStatusSpec>(this.state, ser4cpp.Globals.max);
		case (EventType.AnalogOutputStatus):
			return EventSelection.SelectByType<AnalogOutputStatusSpec>(this.state, ser4cpp.Globals.max);
		case (EventType.OctetString):
			return EventSelection.SelectByType<OctetStringSpec>(this.state, ser4cpp.Globals.max);
		default:
			return 0;
		}
	}

	// ---- function used to select by event class ----

	public uint SelectByClass(in EventClass clazz)
	{
		return new uint(EventSelection.SelectByClass(this.state, new ClassField(clazz), uint.MaxValue));
	}

	public uint SelectByClass(in EventClass clazz, uint max)
	{
		return new uint(EventSelection.SelectByClass(this.state, new ClassField(clazz), ser4cpp.Globals.max));
	}

	public uint SelectByClass(in ClassField clazz)
	{
		return new uint(EventSelection.SelectByClass(this.state, clazz, uint.MaxValue));
	}

	public uint SelectByClass(in ClassField clazz, uint max)
	{
		return new uint(EventSelection.SelectByClass(this.state, clazz, ser4cpp.Globals.max));
	}

	private EventLists state = new EventLists();
}

} // namespace opendnp3




