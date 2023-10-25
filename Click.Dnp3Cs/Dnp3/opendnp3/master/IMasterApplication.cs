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

public delegate void WriteHeaderFunT(in Header UnnamedParameter);

/**
 * Interface for all master application callback info except for measurement values.
 */
public class IMasterApplication : ILinkListener, IUTCTimeSource, System.IDisposable
{
	public virtual void Dispose()
	{
	}

	/// Called when a response or unsolicited response is receive from the outstation
	public virtual void OnReceiveIIN(in IINField iin)
	{
	}

	/// Task start notification
	public virtual void OnTaskStart(MasterTaskType type, TaskId id)
	{
	}

	/// Task completion notification
	public virtual void OnTaskComplete(in TaskInfo info)
	{
	}

	/// Called when the application layer is opened
	public virtual void OnOpen()
	{
	}

	/// Called when the application layer is closed
	public virtual void OnClose()
	{
	}

	/// @return true if the master should do an assign class task during startup handshaking
	public virtual bool AssignClassDuringStartup()
	{
		return false;
	}

	/// Configure the request headers for assign class. Only called if
	/// "AssignClassDuringStartup" returns true
	/// The user only needs to call the function for each header type to be written
	public virtual void ConfigureAssignClassRequest(in WriteHeaderFunT fun)
	{
	}
}

} // namespace opendnp3

