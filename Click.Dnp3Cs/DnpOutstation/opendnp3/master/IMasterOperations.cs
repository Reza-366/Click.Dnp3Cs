using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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
 * All the operations that the user can perform on a running master
 */
public abstract class IMasterOperations : ICommandProcessor, System.IDisposable
{
	public virtual void Dispose()
	{
	}

	/**
	 *  @param filters Adjust the filters to this value
	 */
	public abstract void SetLogFilters(in opendnp3.LogLevels filters);

	/**
	 * Add a recurring user-defined scan from a vector of headers
	 * @ return A proxy class used to manipulate the scan
	 */
	public abstract IMasterScan AddScan(TimeDuration period, in List<Header> headers, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Add a scan that requests all objects using qualifier code 0x06
	 * @ return A proxy class used to manipulate the scan
	 */
	public abstract IMasterScan AddAllObjectsScan(GroupVariationID gvId, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Add a class-based scan to the master
	 * @return A proxy class used to manipulate the scan
	 */
	public abstract IMasterScan AddClassScan(in ClassField field, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Add a start/stop (range) scan to the master
	 * @return A proxy class used to manipulate the scan
	 */
	public abstract IMasterScan AddRangeScan(GroupVariationID gvId, ushort start, ushort stop, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Initiate a single user defined scan via a vector of headers
	 */
	public abstract void Scan(in List<Header> headers, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Initiate a single scan that requests all objects (0x06 qualifier code) for a certain group and variation
	 */
	public abstract void ScanAllObjects(GroupVariationID gvId, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Initiate a single class-based scan
	 */
	public abstract void ScanClasses(in ClassField field, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Initiate a single start/stop (range) scan
	 */
	public abstract void ScanRange(GroupVariationID gvId, ushort start, ushort stop, ISOEHandler soe_handler, in TaskConfig config = TaskConfig.Default());

	/**
	 * Write a time and interval object to a specific index
	 */
	public abstract void Write(in TimeAndInterval value, ushort index, in TaskConfig config = TaskConfig.Default());

	/**
	 * Perform a cold or warm restart and get back the time-to-complete value
	 */
	public abstract void Restart(RestartType op, in RestartOperationCallbackT callback, TaskConfig config = TaskConfig.Default());

	/**
	 * Perform any operation that requires just a function code
	 */
	public abstract void PerformFunction(in string name, FunctionCode func, in List<Header> headers, in TaskConfig config = TaskConfig.Default());
}

} // namespace opendnp3

