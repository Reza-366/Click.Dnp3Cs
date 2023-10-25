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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class ASDUEventWriteHandler final : public IEventWriteHandler, private Uncopyable
public sealed class ASDUEventWriteHandler : Uncopyable, IEventWriteHandler
{

	public ASDUEventWriteHandler(in HeaderWriter writer)
	{
		this.writer = new opendnp3.HeaderWriter(writer);
	}

	public ushort Write(EventBinaryVariation variation, in Binary first, IEventCollection<Binary> items)
	{
		switch (variation)
		{
		case (EventBinaryVariation.Group2Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group2Var1.Inst()));
		case (EventBinaryVariation.Group2Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group2Var2.Inst()));
		case (EventBinaryVariation.Group2Var3):
			return new ushort(EventWriters.WriteWithCTO(first.time, this.writer, items, Group2Var3.Inst()));
		default:
			return new ushort(EventWriters.Write(this.writer, items, Group2Var1.Inst()));
		}
	}

	public ushort Write(EventDoubleBinaryVariation variation, in DoubleBitBinary first, IEventCollection<DoubleBitBinary> items)
	{
		switch (variation)
		{
		case (EventDoubleBinaryVariation.Group4Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group4Var1.Inst()));
		case (EventDoubleBinaryVariation.Group4Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group4Var2.Inst()));
		case (EventDoubleBinaryVariation.Group4Var3):
			return new ushort(EventWriters.WriteWithCTO(first.time, this.writer, items, Group4Var3.Inst()));
		default:
			return new ushort(EventWriters.Write(this.writer, items, Group4Var1.Inst()));
		}
	}

	public ushort Write(EventCounterVariation variation, in Counter first, IEventCollection<Counter> items)
	{
		switch (variation)
		{
		case (EventCounterVariation.Group22Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group22Var1.Inst()));
		case (EventCounterVariation.Group22Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group22Var2.Inst()));
		case (EventCounterVariation.Group22Var5):
			return new ushort(EventWriters.Write(this.writer, items, Group22Var5.Inst()));
		case (EventCounterVariation.Group22Var6):
			return new ushort(EventWriters.Write(this.writer, items, Group22Var6.Inst()));
		default:
			return new ushort(EventWriters.Write(this.writer, items, Group22Var1.Inst()));
		}
	}

	public ushort Write(EventFrozenCounterVariation variation, in FrozenCounter first, IEventCollection<FrozenCounter> items)
	{
		switch (variation)
		{
		case (EventFrozenCounterVariation.Group23Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group23Var1.Inst()));
		case (EventFrozenCounterVariation.Group23Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group23Var2.Inst()));
		case (EventFrozenCounterVariation.Group23Var5):
			return new ushort(EventWriters.Write(this.writer, items, Group23Var5.Inst()));
		case (EventFrozenCounterVariation.Group23Var6):
			return new ushort(EventWriters.Write(this.writer, items, Group23Var6.Inst()));
		default:
			return 0;
		}
	}

	public ushort Write(EventAnalogVariation variation, in Analog first, IEventCollection<Analog> items)
	{
		switch (variation)
		{
		case (EventAnalogVariation.Group32Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var1.Inst()));
		case (EventAnalogVariation.Group32Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var2.Inst()));
		case (EventAnalogVariation.Group32Var3):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var3.Inst()));
		case (EventAnalogVariation.Group32Var4):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var4.Inst()));
		case (EventAnalogVariation.Group32Var5):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var5.Inst()));
		case (EventAnalogVariation.Group32Var6):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var6.Inst()));
		case (EventAnalogVariation.Group32Var7):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var7.Inst()));
		case (EventAnalogVariation.Group32Var8):
			return new ushort(EventWriters.Write(this.writer, items, Group32Var8.Inst()));
		default:
			return new ushort(EventWriters.Write(this.writer, items, Group32Var1.Inst()));
		}
	}

	public ushort Write(EventBinaryOutputStatusVariation variation, in BinaryOutputStatus first, IEventCollection<BinaryOutputStatus> items)
	{
		switch (variation)
		{
		case (EventBinaryOutputStatusVariation.Group11Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group11Var1.Inst()));
		case (EventBinaryOutputStatusVariation.Group11Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group11Var2.Inst()));
		default:
			return new ushort(EventWriters.Write(this.writer, items, Group11Var1.Inst()));
		}
	}

	public ushort Write(EventAnalogOutputStatusVariation variation, in AnalogOutputStatus first, IEventCollection<AnalogOutputStatus> items)
	{
		switch (variation)
		{
		case (EventAnalogOutputStatusVariation.Group42Var1):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var1.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var2):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var2.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var3):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var3.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var4):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var4.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var5):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var5.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var6):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var6.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var7):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var7.Inst()));
		case (EventAnalogOutputStatusVariation.Group42Var8):
			return new ushort(EventWriters.Write(this.writer, items, Group42Var8.Inst()));
		default:
			return new ushort(EventWriters.Write(this.writer, items, Group42Var1.Inst()));
		}
	}

	public ushort Write(EventOctetStringVariation variation, in OctetString first, IEventCollection<OctetString> items)
	{
		return new ushort(EventWriters.Write(first.Size(), this.writer, items));
	}

	private HeaderWriter writer = new HeaderWriter();
}

} // namespace opendnp3




