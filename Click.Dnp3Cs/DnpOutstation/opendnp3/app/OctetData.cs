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
 * A base-class for bitstrings containing up to 255 bytes
 */
public class OctetData
{
	public const byte MAX_SIZE = 255;

	/**
	 * Construct with a default value of [0x00] (length == 1)
	 */
	public OctetData()
	{
		this.size = 1;
	}

	/**
	 * Construct from a c-style string
	 *
	 * strlen() is used internally to determine the length
	 *
	 * If the length is 0, the default value of [0x00] is assigned
	 * If the length is > 255, only the first 255 bytes are copied.
	 *
	 * The null terminator is NOT copied as part of buffer
	 */
	public OctetData(string input) : this(ToSlice(input))
	{
	}

	/**
	 * Construct from read-only buffer slice
	 *
	 *
	 * If the length is 0, the default value of [0x00] is assigned
	 * If the length is > 255, only the first 255 bytes are copied.
	 *
	 * The null terminator is NOT copied as part of buffer
	 */
	public OctetData(in Buffer input)
	{
		this.size = input.length == 0 ? 1 : ser4cpp.Globals.min<byte>(new byte(MAX_SIZE), (byte)input.length);
		RSeq</*size_t*/int> input_slice = new RSeq</*size_t*/int>(input.data, input.length);
		if (input_slice.is_not_empty())
		{
			WSeq</*size_t*/int> dest = new WSeq</*size_t*/int>(buffer.data(), buffer.Count);
			dest.copy_from(input_slice.take(size));
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline byte Size() const
	public byte Size()
	{
		return new byte(size);
	}

	/**
	 * Set the octet data to the input buffer
	 *
	 * If the length is 0, the default value of [0x00] is assigned
	 * If the length is > 255, only the first 255 bytes are copied
	 *
	 * @param input the input data to copy into this object
	 *
	 * @return true if the input meets the length requirements, false otherwise
	 */
	public bool Set(in Buffer input)
	{
		RSeq</*size_t*/int> input_slice = new RSeq</*size_t*/int>(input.data, input.length);
		if (input_slice.is_empty())
		{
			this.size = 0;
			this.buffer[0] = 0x00;
			return false;
		}

		bool is_oversized = input_slice.length() > MAX_SIZE;
		byte usable_size = is_oversized ? MAX_SIZE : (byte)input_slice.length();

		WSeq</*size_t*/int> dest = new WSeq</*size_t*/int>(buffer.data(), buffer.Count);
		dest.copy_from(input_slice.take(usable_size));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->size = usable_size;
		this.size.CopyFrom(usable_size);
		return !is_oversized;
	}

	/**
	 * Set the buffer equal to the supplied c-string
	 *
	 * If the length is 0, the default value of [0x00] is assigned
	 * If the length is > 255, only the first 255 bytes are copied
	 *
	 * @param input c-style string to copy into this object
	 *
	 * @return true if the input meets the length requirements, false otherwise
	 */
	public bool Set(string input)
	{
		/*size_t*/int length = strlen(input);
//C++ TO C# CONVERTER TASK: There is no equivalent to 'reinterpret_cast' in C#:
		return this.Set(new Buffer(reinterpret_cast<const byte>(input), length > MAX_SIZE ? MAX_SIZE : length));
	}

	/**
	 * @return a view of the current data
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const Buffer ToBuffer() const
	public Buffer ToBuffer()
	{
		return new Buffer(buffer.data(), size);
	}

	private static Buffer ToSlice(string input)
	{
		/*size_t*/int length = strlen(input);
		if (length == 0)
		{
			return new Buffer();
		}
//C++ TO C# CONVERTER TASK: There is no equivalent to 'reinterpret_cast' in C#:
		return new Buffer(reinterpret_cast<const byte>(input), length > MAX_SIZE ? MAX_SIZE : length);
	}

	private List<byte> buffer = new List<byte>() {0x00};
	private byte size = new byte();
}

} // namespace opendnp3





