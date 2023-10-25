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

public class TransportHeader
{

	private const System.Byte FIN_MASK = 0x80;
	private const System.Byte FIR_MASK = 0x40;
	private const System.Byte SEQ_MASK = 0x3F;

	public static System.Byte ToByte(bool fir, bool fin, System.Byte seq)
	{
		System.Byte hdr = 0;

		if (fir)
		{
			hdr |= FIR_MASK;
		}

		if (fin)
		{
			hdr |= FIN_MASK;
		}

		// Only the lower 6 bits of the sequence number
		hdr |= (SEQ_MASK & seq);

		return new System.Byte(hdr);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	TransportHeader() = delete;
	public TransportHeader(System.Byte @byte)
	{
		this.fir = (@byte & FIR_MASK) != 0;
		this.fin = (@byte & FIN_MASK) != 0;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.seq = (byte & SEQ_MASK);
		this.seq.CopyFrom((@byte & SEQ_MASK));
	}

	public readonly bool fir;
	public readonly bool fin;
	public readonly System.Byte seq = new System.Byte();
}

} // namespace opendnp3



