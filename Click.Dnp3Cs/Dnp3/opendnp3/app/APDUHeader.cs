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

public class APDUHeader
{
	public const System.UInt32 REQUEST_SIZE = 2;
	public const System.UInt32 RESPONSE_SIZE = 4;

	public static APDUHeader SolicitedConfirm( seq)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Confirm(seq, false);
		return new opendnp3.APDUHeader(Confirm(new System.Byte(seq), false));
	}

	public static APDUHeader UnsolicitedConfirm(System.Byte seq)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Confirm(seq, true);
		return new opendnp3.APDUHeader(Confirm(new System.Byte(seq), true));
	}

	public static APDUHeader Confirm(System.Byte seq, bool unsolicited)
	{
		APDUHeader header = new APDUHeader();
		header.function = FunctionCode.CONFIRM;
		header.control = new AppControlField(true, true, false, unsolicited, seq);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return header;
		return new opendnp3.APDUHeader(header);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	APDUHeader() = default;

	public APDUHeader(in AppControlField control, FunctionCode function)
	{
		this.control = new opendnp3.AppControlField(control);
		this.function = new opendnp3.FunctionCode(function);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Equals(const APDUHeader& header) const
	public bool Equals(in APDUHeader header)
	{
		return (header.function == function) && (header.control.ToByte() == control.ToByte());
	}

	public AppControlField control = new AppControlField();
	public FunctionCode function = FunctionCode.UNKNOWN;
}

public class APDUResponseHeader : APDUHeader
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	APDUResponseHeader() = default;

	public APDUResponseHeader(in AppControlField control, FunctionCode function, in IINField IIN) : base(control, function)
	{
		this.IIN = new opendnp3.IINField(IIN);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ResponseInfo as_response_info() const
	public ResponseInfo as_response_info()
	{
		return new ResponseInfo(this.function == FunctionCode.UNSOLICITED_RESPONSE, control.FIR, control.FIN);
	}

	public IINField IIN = new IINField();
}

} // namespace opendnp3



