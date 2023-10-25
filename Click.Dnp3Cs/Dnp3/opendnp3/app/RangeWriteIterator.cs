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
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class IndexType, class WriteType>
public class RangeWriteIterator <IndexType, WriteType> : System.IDisposable
{
	public static RangeWriteIterator Null()
	{
		return new RangeWriteIterator();
	}

	public RangeWriteIterator()
	{
		this.start = 0;
		this.count = 0;
		this.isValid = false;
		this.pPosition = null;
	}

	public RangeWriteIterator(IndexType.type_t start_, in Serializer<WriteType> serializer, WSeq<size_t> position)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.start = start_;
		this.start.CopyFrom(start_);
		this.serializer = new opendnp3.Serializer<WriteType>(serializer);
		this.count = 0;
		this.isValid = position.length() >= 2 * IndexType.size;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.range = position;
		this.range.CopyFrom(position);
		this.pPosition = position;
		if (isValid)
		{
			IndexType.write_to(range, start);
			pPosition.advance(2 * IndexType.size);
		}
	}

	public void Dispose()
	{
		if (isValid && count > 0)
		{
			var stop = start + count - 1;
			IndexType.write_to(range, (typename IndexType.type_t)stop);
		}
	}

	public bool Write(in WriteType value)
	{
		if (isValid && (pPosition.length() >= serializer.get_size()) && (count <= IndexType.max_value))
		{
			serializer.write(value, pPosition);
			++count;
			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsValid() const
	public bool IsValid()
	{
		return isValid;
	}

	private IndexType.type_t start = new IndexType.type_t();
	private Serializer<WriteType> serializer = new Serializer<WriteType>();
	private System.UInt32 count = new System.UInt32();

	private bool isValid;

	private WSeq<size_t> range = new WSeq<size_t>(); // make a copy to record where we write the range
	private WSeq<size_t> pPosition;
}

} // namespace opendnp3

