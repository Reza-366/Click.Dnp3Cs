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
    Configuration for the dnp3 link layer
*/
public class LinkConfig
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	LinkConfig() = delete;

	public LinkConfig(bool isMaster, UInt16 localAddr, UInt16 remoteAddr, TimeDuration timeout, TimeDuration keepAliveTimeout)
	{
		this.IsMaster = isMaster;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.LocalAddr = localAddr;
		this.LocalAddr.CopyFrom(localAddr);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.RemoteAddr = remoteAddr;
		this.RemoteAddr.CopyFrom(remoteAddr);
		this.Timeout = new opendnp3.TimeDuration(timeout);
		this.KeepAliveTimeout = new opendnp3.TimeDuration(keepAliveTimeout);
	}

	[System.Obsolete("Use LinkConfig(bool) instead.")]
	public LinkConfig(bool isMaster, bool useConfirms)
	{
		this.IsMaster = isMaster;
		this.LocalAddr = isMaster ? 1 : 1024;
		this.RemoteAddr = isMaster ? 1024 : 1;
		this.Timeout = new opendnp3.TimeDuration(TimeDuration.Seconds(1));
		this.KeepAliveTimeout = new opendnp3.TimeDuration(TimeDuration.Minutes(1));
	}

	public LinkConfig(bool isMaster)
	{
		this.IsMaster = isMaster;
		this.LocalAddr = isMaster ? 1 : 1024;
		this.RemoteAddr = isMaster ? 1024 : 1;
		this.Timeout = new opendnp3.TimeDuration(TimeDuration.Seconds(1));
		this.KeepAliveTimeout = new opendnp3.TimeDuration(TimeDuration.Minutes(1));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline Addresses GetAddresses() const
	public Addresses GetAddresses()
	{
		return new Addresses(this.LocalAddr, this.RemoteAddr);
	}

	/// The master/outstation bit set on all messages
	public bool IsMaster;

	/// dnp3 address of the local device
	public UInt16 LocalAddr = new UInt16();

	/// dnp3 address of the remote device
	public UInt16 RemoteAddr = new UInt16();

	/// the response timeout in milliseconds for confirmed requests
	public TimeDuration Timeout = new TimeDuration();

	/// the interval for keep-alive messages (link status requests)
	/// if set to TimeDuration::Max(), the keep-alive is disabled
	public TimeDuration KeepAliveTimeout = new TimeDuration();
}

} // namespace opendnp3

