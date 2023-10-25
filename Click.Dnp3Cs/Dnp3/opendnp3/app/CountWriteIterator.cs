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
//ORIGINAL LINE: template<class CountType, class WriteType>
public class CountWriteIterator <CountType, WriteType> : System.IDisposable
{
	public static CountWriteIterator Null()
	{
		return new CountWriteIterator();
	}

	public CountWriteIterator()
	{
		this.count = 0;
		this.isValid = false;
		this.pPosition = null;
	}

	public CountWriteIterator(in Serializer<WriteType> serializer, WSeq<size_t> position)
	{
		this.count = 0;
		this.serializer = new opendnp3.Serializer<WriteType>(serializer);
		this.isValid = position.length() >= CountType.size;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.countPosition = position;
		this.countPosition.CopyFrom(position);
		this.pPosition = position;
		if (isValid)
		{
			position.advance(CountType.size);
		}
	}

	public void Dispose()
	{
		if (isValid)
		{
			CountType.write_to(countPosition, count);
		}
	}

	public bool Write(in WriteType value)
	{
		if (isValid && (serializer.get_size() <= pPosition.length()) && (count < CountType.max_value))
		{
			serializer.write(value, this.pPosition);
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

	private CountType.type_t count = new CountType.type_t();
	private Serializer<WriteType> serializer = new Serializer<WriteType>();

	private bool isValid;

	private WSeq<size_t> countPosition = new WSeq<size_t>(); // make a copy to record where we write the count
	private WSeq<size_t> pPosition;
}

} // namespace opendnp3

