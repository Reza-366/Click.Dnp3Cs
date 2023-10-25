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
 * Statistics related to both a master or outstation session
 */
public class StackStatistics
{
	public class Link
	{
		/// number of unexpected frames
		public uint64_t numUnexpectedFrame = 0;

		/// frames received w/ wrong master bit
		public uint64_t numBadMasterBit = 0;

		/// frames received for an unknown destination
		public uint64_t numUnknownDestination = 0;

		/// frames received for an unknown source
		public uint64_t numUnknownSource = 0;
	}

	public class Transport
	{
		public class Rx
		{
			/// Number of valid TPDU's received
			public uint64_t numTransportRx = 0;

			/// Number of TPDUs dropped due to malformed contents
			public uint64_t numTransportErrorRx = 0;

			/// Number of times received data was too big for reassembly buffer
			public uint64_t numTransportBufferOverflow = 0;

			/// number of times transport buffer is discard due to new FIR
			public uint64_t numTransportDiscard = 0;

			/// number of segments ignored due to bad FIR/FIN or SEQ
			public uint64_t numTransportIgnore = 0;
		}

		public class Tx
		{
			/// Number of TPDUs transmitted
			public uint64_t numTransportTx = 0;
		}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//		Transport() = default;
		public Transport(in Rx rx, in Tx tx)
		{
			this.rx = new opendnp3.StackStatistics.Transport.Rx(rx);
			this.tx = new opendnp3.StackStatistics.Transport.Tx(tx);
		}

		public Rx rx = new Rx();
		public Tx tx = new Tx();
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	StackStatistics() = default;

	public StackStatistics(in Link link, in Transport transport)
	{
		this.link = new opendnp3.StackStatistics.Link(link);
		this.transport = new opendnp3.StackStatistics.Transport(transport);
	}

	public Link link = new Link();
	public Transport transport = new Transport();
}

} // namespace opendnp3

