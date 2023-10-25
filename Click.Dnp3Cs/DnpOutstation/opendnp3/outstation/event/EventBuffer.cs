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
    The sequence of events list is a doubly linked-list implemented
    in a finite array.  The list is desired for O(1) remove operations from
    arbitrary parts of the list depending on what the user asks for in terms
    of event type or Class1/2/3.

    At worst, selection is O(n) but it has some type/class tracking to avoid looping
    over the SOE list when there are no more events to be written.
*/

public sealed class EventBuffer : IEventReceiver, IEventSelector, IResponseLoader
{

	public EventBuffer(in EventBufferConfig config)
	{
		this.storage = new opendnp3.EventStorage(config);
	}

	// ------- IEventReceiver ------

	public override void Update(in Event<BinarySpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<DoubleBitBinarySpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<AnalogSpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<CounterSpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<FrozenCounterSpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<BinaryOutputStatusSpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<AnalogOutputStatusSpec> evt)
	{
		this.UpdateAny(evt);
	}

	public override void Update(in Event<OctetStringSpec> evt)
	{
		this.UpdateAny(evt);
	}

	// ------- IEventSelector ------

	public virtual void Unselect()
	{
		this.storage.Unselect();
	}

	public IINField SelectAll(GroupVariation gv)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return SelectMaxCount(gv, std::numeric_limits<uint>::max());
		return new opendnp3.IINField(SelectMaxCount(gv, uint.MaxValue));
	}

	public IINField SelectCount(GroupVariation gv, ushort count)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return SelectMaxCount(gv, count);
		return new opendnp3.IINField(SelectMaxCount(gv, new ushort(count)));
	}

	// ------- IResponseLoader -------

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool HasAnySelection() const override
	public bool HasAnySelection()
	{
		// are there any selected, but unwritten, events
		return storage.NumSelected() > 0;
	}

	public bool Load(HeaderWriter writer)
	{
		ASDUEventWriteHandler handler = new ASDUEventWriteHandler(writer);
		this.storage.Write(handler);
		// all selected events were written?
		return this.storage.NumSelected() == 0;
	}

	// ------- Misc -------

	public void ClearWritten()
	{
		this.storage.ClearWritten();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ClassField UnwrittenClassField() const
	public ClassField UnwrittenClassField()
	{
		return new ClassField(false, storage.NumUnwritten(EventClass.EC1) > 0, storage.NumUnwritten(EventClass.EC2) > 0, storage.NumUnwritten(EventClass.EC3) > 0);
	}

	public bool IsOverflown()
	{
		if (overflow && !this.storage.IsAnyTypeFull())
		{
			overflow = false;
		}

		return overflow;
	}

	public void SelectAllByClass(in ClassField clazz)
	{
		this.storage.SelectByClass(clazz);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint NumEvents(EventClass ec) const
	public uint NumEvents(EventClass ec)
	{
		return new uint(this.storage.NumUnwritten(ec));
	}


	private bool overflow = false;
	private EventStorage storage = new EventStorage();

	private IINField SelectMaxCount(GroupVariation gv, uint maximum)
	{
		switch (gv)
		{
		case (GroupVariation.Group2Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::Binary);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.Binary));
		case (GroupVariation.Group2Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventBinaryVariation::Group2Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventBinaryVariation.Group2Var1));
		case (GroupVariation.Group2Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventBinaryVariation::Group2Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventBinaryVariation.Group2Var2));
		case (GroupVariation.Group2Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventBinaryVariation::Group2Var3);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventBinaryVariation.Group2Var3));

		case (GroupVariation.Group4Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::DoubleBitBinary);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.DoubleBitBinary));
		case (GroupVariation.Group4Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventDoubleBinaryVariation::Group4Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventDoubleBinaryVariation.Group4Var1));
		case (GroupVariation.Group4Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventDoubleBinaryVariation::Group4Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventDoubleBinaryVariation.Group4Var2));
		case (GroupVariation.Group4Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventDoubleBinaryVariation::Group4Var3);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventDoubleBinaryVariation.Group4Var3));

		case (GroupVariation.Group11Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::BinaryOutputStatus);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.BinaryOutputStatus));
		case (GroupVariation.Group11Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventBinaryOutputStatusVariation::Group11Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventBinaryOutputStatusVariation.Group11Var1));
		case (GroupVariation.Group11Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventBinaryOutputStatusVariation::Group11Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventBinaryOutputStatusVariation.Group11Var2));

		case (GroupVariation.Group22Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::Counter);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.Counter));
		case (GroupVariation.Group22Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventCounterVariation::Group22Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventCounterVariation.Group22Var1));
		case (GroupVariation.Group22Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventCounterVariation::Group22Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventCounterVariation.Group22Var2));
		case (GroupVariation.Group22Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventCounterVariation::Group22Var5);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventCounterVariation.Group22Var5));
		case (GroupVariation.Group22Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventCounterVariation::Group22Var6);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventCounterVariation.Group22Var6));

		case (GroupVariation.Group23Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::FrozenCounter);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.FrozenCounter));
		case (GroupVariation.Group23Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventFrozenCounterVariation::Group23Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventFrozenCounterVariation.Group23Var1));
		case (GroupVariation.Group23Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventFrozenCounterVariation::Group23Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventFrozenCounterVariation.Group23Var2));
		case (GroupVariation.Group23Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventFrozenCounterVariation::Group23Var5);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventFrozenCounterVariation.Group23Var5));
		case (GroupVariation.Group23Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventFrozenCounterVariation::Group23Var6);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventFrozenCounterVariation.Group23Var6));

		case (GroupVariation.Group32Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::Analog);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.Analog));
		case (GroupVariation.Group32Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var1));
		case (GroupVariation.Group32Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var2));
		case (GroupVariation.Group32Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var3);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var3));
		case (GroupVariation.Group32Var4):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var4);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var4));
		case (GroupVariation.Group32Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var5);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var5));
		case (GroupVariation.Group32Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var6);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var6));
		case (GroupVariation.Group32Var7):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var7);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var7));
		case (GroupVariation.Group32Var8):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogVariation::Group32Var8);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogVariation.Group32Var8));

		case (GroupVariation.Group42Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventType::AnalogOutputStatus);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventType.AnalogOutputStatus));
		case (GroupVariation.Group42Var1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var1);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var1));
		case (GroupVariation.Group42Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var2);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var2));
		case (GroupVariation.Group42Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var3);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var3));
		case (GroupVariation.Group42Var4):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var4);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var4));
		case (GroupVariation.Group42Var5):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var5);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var5));
		case (GroupVariation.Group42Var6):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var6);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var6));
		case (GroupVariation.Group42Var7):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var7);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var7));
		case (GroupVariation.Group42Var8):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventAnalogOutputStatusVariation::Group42Var8);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventAnalogOutputStatusVariation.Group42Var8));

		case (GroupVariation.Group60Var2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByClass(maximum, EventClass::EC1);
			return new opendnp3.IINField(this.SelectByClass(new uint(maximum), EventClass.EC1));
		case (GroupVariation.Group60Var3):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByClass(maximum, EventClass::EC2);
			return new opendnp3.IINField(this.SelectByClass(new uint(maximum), EventClass.EC2));
		case (GroupVariation.Group60Var4):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByClass(maximum, EventClass::EC3);
			return new opendnp3.IINField(this.SelectByClass(new uint(maximum), EventClass.EC3));

		case (GroupVariation.Group111Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->SelectByType(maximum, EventOctetStringVariation::Group111Var0);
			return new opendnp3.IINField(this.SelectByType(new uint(maximum), EventOctetStringVariation.Group111Var0));

		default:
			return IINBit.FUNC_NOT_SUPPORTED;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField SelectByType<T>(uint max, T type)
	{
		this.storage.SelectByType(type, ser4cpp.Globals.max);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private void UpdateAny<T>(in Event<T> evt)
	{
		if (this.storage.Update(evt))
		{
			this.overflow = true;
		}
	}

	private IINField SelectByClass(uint max, EventClass clazz)
	{
		this.storage.SelectByClass(clazz, ser4cpp.Globals.max);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}
}

} // namespace opendnp3




