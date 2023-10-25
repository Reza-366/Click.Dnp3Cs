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
//ORIGINAL LINE: template<class IndexType>
public class BitfieldRangeWriteIterator <IndexType> : System.IDisposable
{
	public static BitfieldRangeWriteIterator Null()
	{
		var buffer = WSeq<size_t>.empty();
		return new BitfieldRangeWriteIterator(0, buffer);
	}

	public BitfieldRangeWriteIterator(IndexType.type_t start_, WSeq<size_t> position_)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.start = start_;
		this.start.CopyFrom(start_);
		this.count = 0;
		this.maxCount = 0;
		this.isValid = position_.length() >= (2 * IndexType.size);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.range = position_;
		this.range.CopyFrom(position_);
		this.pPosition = position_;
		if (isValid)
		{
			IndexType.write_to(range, start_);
			pPosition.advance(2 * IndexType.size);
			maxCount = pPosition.length() * 8;
		}
	}

	public void Dispose()
	{
		if (isValid && count > 0)
		{
			IndexType.type_t stop = start + count - 1;
			IndexType.write_to(range, stop);

			var num = count / 8;

			if ((count % 8) > 0)
			{
				++num;
			}

			pPosition.advance(num);
		}
	}

	public bool Write(bool value)
	{
		if (isValid && count < maxCount)
		{
			var @byte = count / 8;
			var bit = count % 8;

			if (bit == 0)
			{
				pPosition[@byte] = 0; // initialize byte to 0
			}

			if (value)
			{
				pPosition[@byte] = (pPosition[@byte] | (1 << bit));
			}

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
	private IndexType.type_t count = new IndexType.type_t();

	private size_t maxCount = new size_t();

	private bool isValid;

	private WSeq<size_t> range = new WSeq<size_t>(); // make a copy to record where we write the range
	private WSeq<size_t> pPosition;
}

} // namespace opendnp3

