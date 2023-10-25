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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class OutstationSolState : private Uncopyable
public class OutstationSolState : Uncopyable
{
	public OutstationSolState(System.UInt32 maxTxSize)
	{
		this.tx = new opendnp3.TxBuffer(maxTxSize);
	}

	public void Reset()
	{
	}

	public OutstationSeqNum seq = new OutstationSeqNum();
	public TxBuffer tx = new TxBuffer();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class OutstationUnsolState : private Uncopyable
public class OutstationUnsolState : Uncopyable
{
	public OutstationUnsolState(System.UInt32 maxTxSize)
	{
		this.completedNull = false;
		this.tx = new opendnp3.TxBuffer(maxTxSize);
	}

	public void Reset()
	{
		completedNull = false;
	}

	public bool completedNull;
	public OutstationSeqNum seq = new OutstationSeqNum();
	public TxBuffer tx = new TxBuffer();
}

} // namespace opendnp3

