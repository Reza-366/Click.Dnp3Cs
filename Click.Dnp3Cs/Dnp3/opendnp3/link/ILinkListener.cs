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
 * Various optional callbacks that can be received for the link layer
 */
public class ILinkListener
{
	/// Called when a the reset/unreset status of the link layer changes
	public virtual void OnStateChange(LinkStatus value)
	{
	}

	/// Called when a link-layer frame is received from an unknown destination address
	public virtual void OnUnknownDestinationAddress(UInt16 destination)
	{
	}

	/// Called when a link-layer frame is received from an unknown source address
	public virtual void OnUnknownSourceAddress(UInt16 source)
	{
	}

	/// Called when the keep alive timer elapses. This doesn't denote a keep-alive failure, it's just a notification
	public virtual void OnKeepAliveInitiated()
	{
	}

	/// Called when a keep alive message (request link status) receives no response
	public virtual void OnKeepAliveFailure()
	{
	}

	/// Called when a keep alive message receives a valid response
	public virtual void OnKeepAliveSuccess()
	{
	}
}

} // namespace opendnp3

