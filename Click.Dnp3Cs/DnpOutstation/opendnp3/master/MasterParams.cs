﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
Configuration information for the dnp3 master
*/
public class MasterParams
{
	/// Default constructor
	public MasterParams()
	{
	}

	/// Application layer response timeout
	public TimeDuration responseTimeout = TimeDuration.Seconds(5);

	/// If true, the master will do time syncs when it sees the time IIN bit from the outstation
	public TimeSyncMode timeSyncMode = TimeSyncMode.None;

	/// If true, the master will disable unsol on startup for all 3 classes
	public bool disableUnsolOnStartup = true;

	/// If true, the master will not clear the restart IIN bit in response to detecting it set
	public bool ignoreRestartIIN = false;

	/// Bitwise mask used determine which classes are enabled for unsol, if 0 unsol is not enabled
	public ClassField unsolClassMask = ClassField.AllEventClasses();

	/// Which classes should be requested in a startup integrity scan, defaults to 3/2/1/0
	/// A mask equal to 0 means no startup integrity scan will be performed
	public ClassField startupIntegrityClassMask = ClassField.AllClasses();

	/// Defines whether an integrity scan will be performed when the EventBufferOverflow IIN is detected
	public bool integrityOnEventOverflowIIN = true;

	/// Which classes should be requested in an event scan when detecting corresponding events available IIN
	public ClassField eventScanOnEventsAvailableClassMask = ClassField.None();

	/// Time delay before retrying a failed task
	public TimeDuration taskRetryPeriod = TimeDuration.Seconds(5);

	/// Maximum time delay before retrying a failed task. Backs off exponentially from taskRetryPeriod
	public TimeDuration maxTaskRetryPeriod = TimeDuration.Minutes(1);

	/// Time delay before failing a non-recurring task (e.g. commands) that cannot start
	public TimeDuration taskStartTimeout = TimeDuration.Seconds(10);

	/// maximum APDU tx size in bytes
	public uint maxTxFragSize = DEFAULT_MAX_APDU_SIZE;

	/// maximum APDU rx size in bytes
	public uint maxRxFragSize = DEFAULT_MAX_APDU_SIZE;

	/// Control how the master chooses what qualifier to send when making requests
	/// The default behavior is to always use two bytes, but the one byte optimization
	/// can be enabled
	public IndexQualifierMode controlQualifierMode = IndexQualifierMode.always_two_bytes;
}

} // namespace opendnp3

