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

public enum APDUEquality
{
	FULL_EQUALITY,
	OBJECT_HEADERS_EQUAL,
	NONE
}

// This class is used to write to an underlying buffer
public class APDUWrapper
{
	public APDUWrapper()
	{
		this.valid = false;
	}

	public APDUWrapper(in ser4cpp.wseq_t buffer)
	{
		this.valid = true;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.buffer = buffer;
		this.buffer.CopyFrom(buffer);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.remaining = buffer;
		this.remaining.CopyFrom(buffer);
		Debug.Assert(buffer.length() >= 2); // need a control & function at a minimum
		remaining.advance(2);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsValid() const
	public bool IsValid()
	{
		return valid;
	}

	public void SetFunction(FunctionCode code)
	{
		Debug.Assert(buffer.is_not_empty());
		buffer[1] = FunctionCodeSpec.to_type(code);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: FunctionCode GetFunction() const
	public FunctionCode GetFunction()
	{
		Debug.Assert(buffer.is_not_empty());
		return FunctionCodeSpec.from_type(buffer[1]);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: AppControlField GetControl() const
	public AppControlField GetControl()
	{
		Debug.Assert(buffer.is_not_empty());
		return new AppControlField(buffer[0]);
	}

	public void SetControl(AppControlField control)
	{
		buffer[0] = control.ToByte();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t Size() const
	public size_t Size()
	{
		return buffer.length() - remaining.length();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ser4cpp::rseq_t ToRSeq() const
	public ser4cpp.rseq_t ToRSeq()
	{
		return buffer.@readonly().take(this.Size());
	}

	public HeaderWriter GetWriter()
	{
		return new HeaderWriter(remaining);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t Remaining() const
	public size_t Remaining()
	{
		return remaining.length();
	}

	protected bool valid;
	protected ser4cpp.wseq_t buffer = new ser4cpp.wseq_t();
	protected ser4cpp.wseq_t remaining = new ser4cpp.wseq_t();
}

} // namespace opendnp3




