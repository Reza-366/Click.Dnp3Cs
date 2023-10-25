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

// A facade for writing APDUs to an external buffer
public class HeaderWriter
{
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class APDUWrapper;

	public bool WriteHeader(GroupVariationID id, QualifierCode qc)
	{
		if (position.length() < 3)
		{
			return false;
		}

		ser4cpp.UInt8.write_to(position, new byte(id.group));
		ser4cpp.UInt8.write_to(position, new byte(id.variation));
		ser4cpp.UInt8.write_to(position, QualifierCodeSpec.to_type(qc));
		return true;
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class IndexType, class WriteType>
	public RangeWriteIterator<IndexType, WriteType> IterateOverRange<IndexType, WriteType>(QualifierCode qc, in DNP3Serializer<WriteType> serializer, IndexType.type_t start)
	{
		var reserve_size = 2 * IndexType.size + serializer.get_size();
		if (this.WriteHeaderWithReserve(serializer.ID(), qc, reserve_size))
		{
			return RangeWriteIterator<IndexType, WriteType>(start, serializer, position);
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return RangeWriteIterator<IndexType, WriteType>::Null();
			return new RangeWriteIterator(RangeWriteIterator<IndexType, WriteType>.Null());
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class IndexType>
	public bool WriteRangeHeader<IndexType>(QualifierCode qc, GroupVariationID gvId, IndexType.type_t start, IndexType.type_t stop)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: if (WriteHeaderWithReserve(gvId, qc, 2 * IndexType::size))
		if (WriteHeaderWithReserve(new opendnp3.GroupVariationID(gvId), qc, 2 * IndexType.size))
		{
			IndexType.write_to(position, start);
			IndexType.write_to(position, stop);
			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class IndexType>
	public bool WriteCountHeader<IndexType>(QualifierCode qc, GroupVariationID gvId, IndexType.type_t count)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: if (WriteHeaderWithReserve(gvId, qc, IndexType::size))
		if (WriteHeaderWithReserve(new opendnp3.GroupVariationID(gvId), qc, IndexType.size))
		{
			IndexType.write_to(position, count);
			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class CountType, class WriteType>
	public CountWriteIterator<CountType, WriteType> IterateOverCount<CountType, WriteType>(QualifierCode qc, in DNP3Serializer<WriteType> serializer)
	{
		var reserve_size = CountType.size + serializer.get_size();
		if (this.WriteHeaderWithReserve(serializer.ID(), qc, reserve_size))
		{
			return CountWriteIterator<CountType, WriteType>(serializer, position);
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return CountWriteIterator<CountType, WriteType>::Null();
			return new CountWriteIterator(CountWriteIterator<CountType, WriteType>.Null());
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class IndexType>
	public BitfieldRangeWriteIterator<IndexType> IterateOverSingleBitfield<IndexType>(GroupVariationID id, QualifierCode qc, IndexType.type_t start)
	{
		var reserve_size = 2 * IndexType.size + 1; // need at least 1 byte
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: if (this->WriteHeaderWithReserve(id, qc, reserve_size))
		if (this.WriteHeaderWithReserve(new opendnp3.GroupVariationID(id), qc, reserve_size))
		{
			return BitfieldRangeWriteIterator<IndexType>(start, position);
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return BitfieldRangeWriteIterator<IndexType>::Null();
			return new BitfieldRangeWriteIterator(BitfieldRangeWriteIterator<IndexType>.Null());
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class CountType, class ValueType>
	public bool WriteSingleValue<CountType, ValueType>(QualifierCode qc, in DNP3Serializer<ValueType> serializer, in ValueType value)
	{
		var reserve_size = CountType.size + serializer.Size();
		if (this.WriteHeaderWithReserve(ValueType.ID, qc, reserve_size))
		{
			CountType.WSlice(position, 1); // write the count
			serializer.Write(value, position);
			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class CountType, class WriteType>
	public bool WriteSingleValue<CountType, WriteType>(QualifierCode qc, in WriteType value)
	{
		var reserve_size = CountType.size + WriteType.Size();
		if (this.WriteHeaderWithReserve(WriteType.ID(), qc, reserve_size))
		{
			CountType.write_to(position, 1); // write the count
			WriteType.Write(value, position);
			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class CountType, class ValueType>
	public bool WriteSingleIndexedValue<CountType, ValueType>(QualifierCode qc, in DNP3Serializer<ValueType> serializer, in ValueType value, CountType.type_t index)
	{
		var reserve_size = 2 * CountType.size + serializer.get_size();
		if (this.WriteHeaderWithReserve(serializer.ID(), qc, reserve_size))
		{
			CountType.write_to(position, 1); // write the count
			CountType.write_to(position, index); // write the index
			serializer.write(value, position);
			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class PrefixType, class WriteType>
	public PrefixedWriteIterator<PrefixType, WriteType> IterateOverCountWithPrefix<PrefixType, WriteType>(QualifierCode qc, in DNP3Serializer<WriteType> serializer)
	{
		var reserve_size = 2 * PrefixType.size + serializer.get_size(); // enough space for the count, 1 prefix + object
		if (this.WriteHeaderWithReserve(serializer.ID(), qc, reserve_size))
		{
			return PrefixedWriteIterator<PrefixType, WriteType>(serializer, position);
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrefixedWriteIterator<PrefixType, WriteType>::Null();
			return new PrefixedWriteIterator(PrefixedWriteIterator<PrefixType, WriteType>.Null());
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class PrefixType, class WriteType, class CTOType>
	public PrefixedWriteIterator<PrefixType, WriteType> IterateOverCountWithPrefixAndCTO<PrefixType, WriteType, CTOType>(QualifierCode qc, in DNP3Serializer<WriteType> serializer, in CTOType cto)
	{
		this.Mark();
		if (this.WriteSingleValue<ser4cpp.UInt8, CTOType>(QualifierCode.UINT8_CNT, cto))
		{
			var iter = IterateOverCountWithPrefix<PrefixType, WriteType>(qc, serializer);
			if (!iter.IsValid())
			{
				// remove the CTO header, if there's no space to write a value
				this.Rollback();
			}
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return iter;
			return new opendnp3.PrefixedWriteIterator<PrefixType>(iter);
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrefixedWriteIterator<PrefixType, WriteType>::Null();
			return new PrefixedWriteIterator(PrefixedWriteIterator<PrefixType, WriteType>.Null());
		}
	}

	// record the current position in case we need to rollback
	public void Mark()
	{
		mark.set(position);
	}

	// roll back to the last mark
	public bool Rollback()
	{
		if (mark.is_set())
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: *position = mark.get();
			position.CopyFrom(mark.get());
			mark.clear();
			return true;
		}

		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: /*size_t*/int Remaining() const
	public /*size_t*/int Remaining()
	{
		return position.length();
	}

	private HeaderWriter(ser4cpp.wseq_t position_)
	{
		this.position = position_;
	}

	private bool WriteHeaderWithReserve(GroupVariationID id, QualifierCode qc, /*size_t*/int reserve)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return (position->length() < (3 + reserve)) ? false : WriteHeader(id, qc);
		return (position.length() < (3 + reserve)) ? false : WriteHeader(new opendnp3.GroupVariationID(id), qc);
	}

	private ser4cpp.wseq_t position;

	private ser4cpp.Settable<ser4cpp.wseq_t> mark = new ser4cpp.Settable<ser4cpp.wseq_t>();
}

} // namespace opendnp3





