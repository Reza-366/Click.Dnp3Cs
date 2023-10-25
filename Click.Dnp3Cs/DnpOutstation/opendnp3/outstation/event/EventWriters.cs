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

public class EventWriters
{

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public static ushort Write<T>(HeaderWriter writer, IEventCollection<T> items, in DNP3Serializer<T> serializer)
	{
		BasicEventWriter<T> handler = new BasicEventWriter<T>(writer, serializer);
		return new ushort(items.WriteSome(handler));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public static ushort WriteWithCTO<T>(in DNPTime cto, HeaderWriter writer, IEventCollection<T> items, in DNP3Serializer<T> serializer)
	{
		if (cto.quality == TimestampQuality.SYNCHRONIZED)
		{
			Group51Var1 value = new Group51Var1();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: value.time = cto;
			value.time.CopyFrom(cto);
			CTOEventWriter<T, Group51Var1> handler = new CTOEventWriter<T, Group51Var1>(value, writer, serializer);
			return new ushort(items.WriteSome(handler));
		}
		else
		{
			Group51Var2 value = new Group51Var2();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: value.time = cto;
			value.time.CopyFrom(cto);
			CTOEventWriter<T, Group51Var2> handler = new CTOEventWriter<T, Group51Var2>(value, writer, serializer);
			return new ushort(items.WriteSome(handler));
		}
	}

	public static ushort Write(byte firstSize, HeaderWriter writer, IEventCollection<OctetString> items)
	{
		OctetStringEventWriter handler = new OctetStringEventWriter(writer, firstSize);
		return new ushort(items.WriteSome(handler));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private sealed class BasicEventWriter <T> : IEventWriter<T>
	{
		private PrefixedWriteIterator<ser4cpp.UInt16, T> iterator = new PrefixedWriteIterator<ser4cpp.UInt16, T>();

		public BasicEventWriter(HeaderWriter writer, in DNP3Serializer<T> serializer)
		{
			this.iterator = new opendnp3.PrefixedWriteIterator<ser4cpp.UInt16, T>(writer.IterateOverCountWithPrefix<ser4cpp.UInt16, T>(QualifierCode.UINT16_CNT_UINT16_INDEX, serializer));
		}

		public override bool Write(in T meas, ushort index)
		{
			return iterator.IsValid() ? iterator.Write(meas, new ushort(index)) : false;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class U>
	private sealed class CTOEventWriter <T, U> : IEventWriter<T>
	{
		private readonly DNPTime cto = new DNPTime();
		private PrefixedWriteIterator<ser4cpp.UInt16, T> iterator = new PrefixedWriteIterator<ser4cpp.UInt16, T>();

		public CTOEventWriter(in U cto, HeaderWriter writer, in DNP3Serializer<T> serializer)
		{
			this.cto = cto.time;
			this.iterator = new opendnp3.PrefixedWriteIterator<ser4cpp.UInt16, T>(writer.IterateOverCountWithPrefixAndCTO<ser4cpp.UInt16, T, U>(QualifierCode.UINT16_CNT_UINT16_INDEX, serializer, cto));
		}

		public override bool Write(in T meas, ushort index)
		{
			if (!this.iterator.IsValid())
			{
				return false;
			}

			// Check that the quality of the measurement fits with the CTO variation
			if (this.cto.quality == TimestampQuality.SYNCHRONIZED)
			{
				if (meas.time.quality != TimestampQuality.SYNCHRONIZED)
				{
					return false;
				}
			}
			else
			{
				if (meas.time.quality == TimestampQuality.SYNCHRONIZED)
				{
					return false;
				}
			}

			// can't encode timestamps that go backwards
			if (meas.time.value < this.cto.value)
			{
				return false;
			}

			var diff = meas.time.value - this.cto.value;

			// can't encode timestamps where the diff is greater than ushort
			if (diff > ser4cpp.UInt16.max_value)
			{
				return false;
			}

			var copy = meas;
			copy.time = new DNPTime(diff);

			return this.iterator.Write(copy, new ushort(index));
		}
	}
}

} // namespace opendnp3




namespace opendnp3
{

public class OctetStringEventWriter : IEventWriter<OctetString>
{
	private readonly OctetStringSerializer serializer = new OctetStringSerializer();
	private PrefixedWriteIterator<ser4cpp.UInt16, OctetString> iterator = new PrefixedWriteIterator<ser4cpp.UInt16, OctetString>();

	public OctetStringEventWriter(HeaderWriter writer, byte size)
	{
		this.serializer = new opendnp3.OctetStringSerializer(true, size);
		this.iterator = new opendnp3.PrefixedWriteIterator<ser4cpp.UInt16, OctetString>(writer.IterateOverCountWithPrefix<ser4cpp.UInt16>(QualifierCode.UINT16_CNT_UINT16_INDEX, serializer));
	}

	public override bool Write(in OctetString meas, ushort index)
	{
		if (meas.Size() != this.serializer.get_size())
		{
			return false;
		}

		return iterator.Write(meas, new ushort(index));
	}
}

} // namespace opendnp3
