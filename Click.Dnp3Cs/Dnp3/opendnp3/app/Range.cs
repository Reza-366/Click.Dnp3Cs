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

public class Range
{
	public static Range From(UInt16 start, UInt16 stop)
	{
		return new Range(start, stop);
	}

	public static Range Invalid()
	{
		return new Range(1, 0);
	}

	public Range()
	{
		this.start = 1;
		this.stop = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t Count() const
	public size_t Count()
	{
		return IsValid() ? ((size_t)stop - (size_t)start + 1) : 0;
	}

	public bool Advance()
	{
		if (this.IsValid())
		{
			if (start < stop)
			{
				++start;
			}
			else
			{
				// make the range invalid
				start = 1;
				stop = 0;
			}

			return true;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Contains(UInt16 index) const
	public bool Contains(UInt16 index)
	{
		return (index >= start) && (index <= stop);
	}

	/// @return A new range with only values found in both ranges
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Range Intersection(const Range& other) const
	public Range Intersection(in Range other)
	{
		return new Range(ser4cpp.Globals.max<UInt16>(new UInt16(start), new UInt16(other.start)), ser4cpp.Globals.min<UInt16>(new UInt16(stop), new UInt16(other.stop)));
	}

	/// @return A new range with min start and the max stop of both ranges
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Range Union(const Range& other) const
	public Range Union(in Range other)
	{
		if (!this.IsValid())
		{
			return other;
		}

		return new Range(ser4cpp.Globals.min<UInt16>(new UInt16(start), new UInt16(other.start)), ser4cpp.Globals.max<UInt16>(new UInt16(stop), new UInt16(other.stop)));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Equals(const Range& other) const
	public bool Equals(in Range other)
	{
		return (other.start == start) && (other.stop == stop);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsValid() const
	public bool IsValid()
	{
		return start <= stop;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsOneByte() const
	public bool IsOneByte()
	{
		return IsValid() && (start <= 255) && (stop <= 255);
	}

	public UInt16 start = new UInt16();
	public UInt16 stop = new UInt16();

	private Range(UInt16 index_)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.start = index_;
		this.start.CopyFrom(index_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.stop = index_;
		this.stop.CopyFrom(index_);
	}

	private Range(UInt16 start_, UInt16 stop_)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.start = start_;
		this.start.CopyFrom(start_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.stop = stop_;
		this.stop.CopyFrom(stop_);
	}
}

} // namespace opendnp3

