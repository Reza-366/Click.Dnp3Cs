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
 * Represents a communication channel upon which masters and outstations can be bound.
 */
public abstract class IChannel : IResource
{
	protected LinkStatistics statics = new LinkStatistics(); //REZA


	public override void Dispose()
	{
		base.Dispose();
	}

	/**
	 * Synchronously read the channel statistics
	 */
	//virtual LinkStatistics GetStatistics() = 0;
	public virtual LinkStatistics GetStatistics()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return statics;
		return new opendnp3.LinkStatistics(statics);
	}

	/**
	 *  @return The current logger settings for this channel
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual opendnp3::LogLevels GetLogFilters() const = 0;
	public abstract opendnp3.LogLevels GetLogFilters();

	/**
	 *  @param filters Adjust the filters to this value
	 */
	public abstract void SetLogFilters(in opendnp3.LogLevels filters);

	/**
	 * Add a master to the channel
	 *
	 * @param id An ID that gets used for logging
	 * @param SOEHandler Callback object for all received measurements
	 * @param application The master application bound to the master session
	 * @param config Configuration object that controls how the master behaves
	 *
	 * @return shared_ptr to the running master
	 */
	public abstract IMaster AddMaster(in string id, ISOEHandler SOEHandler, IMasterApplication application, in MasterStackConfig config);

	/**
	 * Add an outstation to the channel
	 *
	 * @param id An ID that gets used for logging
	 * @param commandHandler Callback object for handling command requests
	 * @param application Callback object for user code
	 * @param config Configuration object that controls how the outstation behaves
	 * @return shared_ptr to the running outstation
	 */
	public abstract IOutstation AddOutstation(in string id, ICommandHandler commandHandler, IOutstationApplication application, in OutstationStackConfig config);
}

} // namespace opendnp3

