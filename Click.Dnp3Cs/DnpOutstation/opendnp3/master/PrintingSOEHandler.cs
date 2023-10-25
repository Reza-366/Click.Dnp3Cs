using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

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
 *	ISOEHandler singleton that prints to the console.
 */
public sealed class PrintingSOEHandler : ISOEHandler
{

	public PrintingSOEHandler()
	{
	}

	public static ISOEHandler Create()
	{
		return new PrintingSOEHandler();
	}

	public override void BeginFragment(in ResponseInfo info)
	{
		Console.Write("begin response: ");
		Console.Write(info);
		Console.WriteLine();
	}

	public override void EndFragment(in ResponseInfo info)
	{
		Console.Write("end response: ");
		Console.Write(info);
		Console.WriteLine();
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<Binary>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<DoubleBitBinary>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<Analog>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<Counter>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<FrozenCounter>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
		return PrintAll(info, values);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var print = (in Indexed<OctetString> pair) =>
		{
			Console.Write("OctetString ");
			Console.Write(" [");
			Console.Write(pair.index);
			Console.Write("] : Size : ");
			Console.Write(Convert.ToString(pair.value.Size()));
			Console.WriteLine();
		};

		values.ForeachItem(print);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<TimeAndInterval>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var print = (in Indexed<TimeAndInterval> pair) =>
		{
			Console.Write("TimeAndInterval: ");
			Console.Write("[");
			Console.Write(pair.index);
			Console.Write("] : ");
			Console.Write(pair.value.time.value);
			Console.Write(" : ");
			Console.Write(pair.value.interval);
			Console.Write(" : ");
			Console.Write(IntervalUnitsSpec.to_human_string(pair.value.GetUnitsEnum()));
			Console.WriteLine();
		};

		values.ForeachItem(print);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<BinaryCommandEvent>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var print = (in Indexed<BinaryCommandEvent> pair) =>
		{
			Console.Write("BinaryCommandEvent: ");
			Console.Write("[");
			Console.Write(pair.index);
			Console.Write("] : ");
			Console.Write(pair.value.time.value);
			Console.Write(" : ");
			Console.Write(pair.value.value);
			Console.Write(" : ");
			Console.Write(CommandStatusSpec.to_human_string(pair.value.status));
			Console.WriteLine();
		};

		values.ForeachItem(print);
	}

	public override void Process(in HeaderInfo info, in ICollection<Indexed<AnalogCommandEvent>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var print = (in Indexed<AnalogCommandEvent> pair) =>
		{
			Console.Write("AnalogCommandEvent: ");
			Console.Write("[");
			Console.Write(pair.index);
			Console.Write("] : ");
			Console.Write(pair.value.time.value);
			Console.Write(" : ");
			Console.Write(pair.value.value);
			Console.Write(" : ");
			Console.Write(CommandStatusSpec.to_human_string(pair.value.status));
			Console.WriteLine();
		};

		values.ForeachItem(print);
	}

	public override void Process(in HeaderInfo info, in ICollection<DNPTime> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var print = (in DNPTime value) =>
		{
			Console.Write("DNPTime: ");
			Console.Write(value.value);
			Console.WriteLine();
		};

		values.ForeachItem(print);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private static void PrintAll<T>(in HeaderInfo info, in ICollection<Indexed<T>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var print = (in Indexed<T> pair) =>
		{
			Print<T>(info, pair.value, pair.index);
		};
		values.ForeachItem(print);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private static void Print<T>(in HeaderInfo info, in T value, ushort index)
	{
		Console.Write("[");
		Console.Write(index);
		Console.Write("] : ");
		Console.Write(ValueToString(value));
		Console.Write(" : ");
		Console.Write((int)value.flags.value);
		Console.Write(" : ");
		Console.Write(value.time.value);
		Console.WriteLine();
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private static string ValueToString<T>(in T meas)
	{
		std::ostringstream oss = new std::ostringstream();
		oss << meas.value;
		return oss.str();
	}

	private static string GetTimeString(TimestampQuality tsquality)
	{
		std::ostringstream oss = new std::ostringstream();
		switch (tsquality)
		{
		case (TimestampQuality.SYNCHRONIZED):
			return "synchronized";
			break;
		case (TimestampQuality.UNSYNCHRONIZED):
			oss << "unsynchronized";
			break;
		default:
			oss << "no timestamp";
			break;
		}

		return oss.str();
	}

	private static string ValueToString(in DoubleBitBinary meas)
	{
		return DoubleBitSpec.to_human_string(meas.value);
	}
}

} // namespace opendnp3



