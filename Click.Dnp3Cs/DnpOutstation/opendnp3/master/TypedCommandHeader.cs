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


namespace opendnp3
{

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public sealed class TypedCommandHeader <T> : ICommandHeader, ICommandCollection<T>
{
	private class Record : CommandState
	{
		public Record(in Indexed<T> pair) : base(pair.index)
		{
			this.command = pair.value;
		}

		public T command = default(T);
	}

	public TypedCommandHeader(in DNP3Serializer<T> serializer)
	{
		this.serializer = new opendnp3.DNP3Serializer<T>(serializer);
	}

	// --- Implement ICommandCollection ---

	public override ICommandCollection<T> Add(in T command, ushort index)
	{
		if (index > byte.MaxValue)
		{
			this.use_single_byte_index = false;
		}

		this.records.Add(opendnp3.Globals.WithIndex(command, new ushort(index)));
		return this;
	}

	// --- Implement ICommandHeader ----

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool AreAllSelected() const override
	public override bool AreAllSelected()
	{
		return std::all_of(this.records.GetEnumerator(), this.records.end(), (in Record rec) =>
		{
			return rec.state == CommandPointState.SELECT_SUCCESS;
		});
	}

	public override bool Write(HeaderWriter writer, IndexQualifierMode mode)
	{
		if (this.records.Count == 0)
		{
			return false;
		}

		// allow single byte indices if they're all <= 255 and the optimization is allowed
		this.use_single_byte_index &= (mode == IndexQualifierMode.allow_one_byte);

		if (this.use_single_byte_index)
		{
			var iter = writer.IterateOverCountWithPrefix<ser4cpp.UInt8, T>(QualifierCode.UINT8_CNT_UINT8_INDEX, this.serializer);

			foreach (var rec in this.records)
			{
				if (!iter.Write(rec.command, (byte)rec.index))
				{
					return false;
				}
			}

			return iter.IsValid();
		}
		else
		{
			var iter = writer.IterateOverCountWithPrefix<ser4cpp.Globals.Bit16<ushort, 0, 1>, T>(QualifierCode.UINT16_CNT_UINT16_INDEX, this.serializer);

			foreach (var rec in this.records)
			{
				if (!iter.Write(rec.command, new ushort(rec.index)))
				{
					return false;
				}
			}

			return iter.IsValid();
		}
	}

	public override void ApplySelectResponse(QualifierCode code, in ICollection<Indexed<T>> commands)
	{
		if (code != this.ExpectedQualfier())
		{
			return;
		}

		if (commands.Count() > this.records.Count)
		{
			return;
		}

		uint index = 0;

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var visit = (in Indexed<T> item) =>
		{
			auto rec = this.records[index];
			++index;

			if (item.index != rec.index)
			{
				return;
			}

			if (!item.value.ValuesEqual(rec.command))
			{
				rec.state = CommandPointState.SELECT_MISMATCH;
				return;
			}

			if (item.value.status != CommandStatus.SUCCESS)
			{
				rec.state = CommandPointState.SELECT_FAIL;
				rec.status = item.value.status;
				return;
			}

			if (rec.state == CommandPointState.INIT)
			{
				rec.state = CommandPointState.SELECT_SUCCESS;
			}
		};

		commands.ForeachItem(visit);
	}

	public override void ApplyOperateResponse(QualifierCode code, in ICollection<Indexed<T>> commands)
	{
		if (code != this.ExpectedQualfier())
		{
			return;
		}

		if (commands.Count() > this.records.Count)
		{
			return;
		}

		uint index = 0;

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var visit = (in Indexed<T> item) =>
		{
			auto rec = this.records[index];
			++index;

			if (item.index != rec.index)
			{
				return;
			}

			if (!item.value.ValuesEqual(rec.command))
			{
				rec.state = CommandPointState.OPERATE_FAIL;
				return;
			}

			rec.state = CommandPointState.SUCCESS;
			rec.status = item.value.status;
		};

		commands.ForeachItem(visit);
	}

	// --- Implement ICollection<Indexed<CommandResponse>> ----

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual /*size_t*/int Count() const override
	public override /*size_t*/int Count()
	{
		return this.records.Count;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void Foreach(IVisitor<CommandState>& visitor) const override
	public override void Foreach(IVisitor<CommandState> visitor)
	{
		foreach (var rec in this.records)
		{
			visitor.OnValue(rec);
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: QualifierCode ExpectedQualfier() const
	private QualifierCode ExpectedQualfier()
	{
		return this.use_single_byte_index ? QualifierCode.UINT8_CNT_UINT8_INDEX : QualifierCode.UINT16_CNT_UINT16_INDEX;
	}

	private bool use_single_byte_index = true;
	private readonly DNP3Serializer<T> serializer = new DNP3Serializer<T>();
	private List<Record> records = new List<Record>();
}

} // namespace opendnp3

