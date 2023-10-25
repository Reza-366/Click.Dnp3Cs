using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

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
 * Callback interface for receiving information about a running channel
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class PrintingChannelListener final : public IChannelListener, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class PrintingChannelListener : IChannelListener, Uncopyable
{
	public override void OnStateChange(ChannelState state)
	{
		Console.Write("channel state change: ");
		Console.Write(ChannelStateSpec.to_human_string(state));
		Console.WriteLine();
	}

	public static IChannelListener Create()
	{
		return new PrintingChannelListener();
	}

	public PrintingChannelListener()
	{
	}
}

} // namespace opendnp3

