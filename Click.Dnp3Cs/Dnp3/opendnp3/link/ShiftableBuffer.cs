using System.Diagnostics;

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

/** @section DESCRIPTION
        Implements a buffer that can shift its contents as it is read */
public class ShiftableBuffer
{
	/**
	 * Construct the facade over the specified underlying buffer
	 */
	public ShiftableBuffer(System.Byte pBuffer_, size_t size)
	{
		this.pBuffer = pBuffer_;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.M_SIZE = size;
		this.M_SIZE.CopyFrom(size);
		this.writePos = 0;
		this.readPos = 0;
	}

	// ------- Functions related to reading -----------

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t NumBytesRead() const
	public size_t NumBytesRead()
	{
		return writePos - readPos;
	}

	/// @return Pointer to the next byte to be read in the buffer
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: RSeq<size_t> ReadBuffer() const
	public RSeq<size_t> ReadBuffer()
	{
		return RSeq<size_t>(pBuffer + readPos, NumBytesRead());
	}

	/// Signal that some bytes don't have to be stored any longer. They'll be recovered during the next shift operation.
	public void AdvanceRead(size_t numBytes)
	{
		Debug.Assert(numBytes <= this.NumBytesRead());
		readPos += numBytes;
	}

	// ------- Functions related to writing -----------

	/// Shift the buffer back to front, writing over bytes that have already been read. The objective
	/// being to free space for further writing.
	public void Shift()
	{
		var numRead = this.NumBytesRead();

		// copy all unread data to the front of the buffer
//C++ TO C# CONVERTER TASK: The memory management function 'memmove' has no equivalent in C#:
		memmove(pBuffer, pBuffer + readPos, numRead);

		readPos = 0;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: writePos = numRead;
		writePos.CopyFrom(numRead);
	}

	/// Reset the buffer to its initial state, empty
	public void Reset()
	{
		writePos = 0;
		readPos = 0;
	}

	/// @return Bytes of available for writing
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t NumWriteBytes() const
	public size_t NumWriteBytes()
	{
		return M_SIZE - writePos;
	}

	/// @return Pointer to the position in the buffer available for writing
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: System.Byte* WriteBuff() const
	public System.Byte WriteBuff()
	{
		return pBuffer + writePos;
	}

	/// Signal to the buffer bytes were written to the current write position
	public void AdvanceWrite(size_t aNumBytes)
	{
		Debug.Assert(aNumBytes <= this.NumWriteBytes());
		writePos += aNumBytes;
	}

	////////////////////////////////////////////
	// Other functions
	////////////////////////////////////////////

	/// Searches the read subsequence for 0x0564 sync bytes
	/// @return true if both sync bytes were found in the buffer.
	public bool Sync(size_t skipCount)
	{
		while (this.NumBytesRead() > 1) // at least 2 bytes
		{
			if (this.ReadBuffer [0] == 0x05 && this.ReadBuffer()[1] == 0x64)
			{
				return true;
			}

			this.AdvanceRead(1); // skip the first byte
			++skipCount;
		}

		return false;
	}

	private System.Byte pBuffer;
	private readonly size_t M_SIZE = new size_t();
	private size_t writePos = new size_t();
	private size_t readPos = new size_t();
}

} // namespace opendnp3




