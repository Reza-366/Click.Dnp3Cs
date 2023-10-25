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
 * Counters for the channel and the DNP3 link layer
 */
public class LinkStatistics
{
	public class Parser
	{
		/// Number of frames discarded due to header CRC errors
		public size_t numHeaderCrcError = 0;

		/// Number of frames discarded due to body CRC errors
		public size_t numBodyCrcError = 0;

		/// Number of frames received
		public size_t numLinkFrameRx = 0;

		/// number of bad LEN fields received (malformed frame)
		public size_t numBadLength = 0;

		/// number of bad function codes (malformed frame)
		public size_t numBadFunctionCode = 0;

		/// number of FCV / function code mismatches (malformed frame)
		public size_t numBadFCV = 0;

		/// number of frames w/ unexpected FCB bit set (malformed frame)
		public size_t numBadFCB = 0;
	}

	public class Channel
	{
		/// The number of times the channel has successfully opened
		public size_t numOpen = 0;

		/// The number of times the channel has failed to open
		public size_t numOpenFail = 0;

		/// The number of times the channel has closed either due to user intervention or an error
		public size_t numClose = 0;

		/// The number of bytes received
		public size_t numBytesRx = 0;

		/// The number of bytes transmitted
		public size_t numBytesTx = 0;

		/// Number of frames transmitted
		public size_t numLinkFrameTx = 0;
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	LinkStatistics() = default;

	public LinkStatistics(in Channel channel, in Parser parser)
	{
		this.channel = new opendnp3.LinkStatistics.Channel(channel);
		this.parser = new opendnp3.LinkStatistics.Parser(parser);
	}

	/// statistics for the communicaiton channel
	public Channel channel = new Channel();

	/// statistics for the link parser
	public Parser parser = new Parser();
}

} // namespace opendnp3

