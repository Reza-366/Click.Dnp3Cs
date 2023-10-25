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

/** Represents the first byte in every APDU
 */
public class AppControlField
{
	public const AppControlField DEFAULT = new AppControlField(true, true, false, false, 0);

	public static AppControlField Request(System.Byte seq)
	{
		return new AppControlField(true, true, false, false, seq);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	AppControlField() = default;

	public AppControlField(System.Byte @byte)
	{
		this.FIR = (@byte & FIR_MASK) != 0;
		this.FIN = (@byte & FIN_MASK) != 0;
		this.CON = (@byte & CON_MASK) != 0;
		this.UNS = (@byte & UNS_MASK) != 0;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.SEQ = byte & SEQ_MASK;
		this.SEQ.CopyFrom(@byte & SEQ_MASK);
	}

	public AppControlField(bool fir, bool fin, bool con, bool uns, System.Byte seq = 0)
	{
		this.FIR = fir;
		this.FIN = fin;
		this.CON = con;
		this.UNS = uns;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.SEQ = seq;
		this.SEQ.CopyFrom(seq);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: System.Byte ToByte() const
	public System.Byte ToByte()
	{
		System.Byte ret = 0;

		if (FIR)
		{
			ret |= FIR_MASK;
		}
		if (FIN)
		{
			ret |= FIN_MASK;
		}
		if (CON)
		{
			ret |= CON_MASK;
		}
		if (UNS)
		{
			ret |= UNS_MASK;
		}

		System.Byte seq = SEQ % 16;

		return ret | seq;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsFirAndFin() const
	public bool IsFirAndFin()
	{
		return FIR && FIN;
	}

	public bool FIR = true;
	public bool FIN = true;
	public bool CON = false;
	public bool UNS = false;
	public System.Byte SEQ = 0;

	private const System.Byte FIR_MASK = 0x80;
	private const System.Byte FIN_MASK = 0x40;
	private const System.Byte CON_MASK = 0x20;
	private const System.Byte UNS_MASK = 0x10;
	private const System.Byte SEQ_MASK = 0x0F;
}

} // namespace opendnp3



