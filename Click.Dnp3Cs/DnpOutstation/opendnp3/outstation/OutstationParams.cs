using System;
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
 *	Static configuration parameters for an outstation session
 */
public class OutstationParams
{
	/// The maximum number of controls the outstation will attempt to process from a single APDU
	public uint maxControlsPerRequest = 4_294_967_295;

	/// How long the outstation will allow an operate to proceed after a prior select
	public TimeDuration selectTimeout = TimeDuration.Seconds(10);

	/// Timeout for solicited confirms
	public TimeDuration solConfirmTimeout = DEFAULT_APP_TIMEOUT;

	/// Timeout for unsolicited confirms
	public TimeDuration unsolConfirmTimeout = DEFAULT_APP_TIMEOUT;

	/// Number of unsolicited non-regenerated retries
	public NumRetries numUnsolRetries = NumRetries.Infinite();

	/// Workaround for test procedure 8.11.2.1. Will respond immediatly to READ requests
	/// when waiting for unsolicited NULL responses.
	///
	/// @warning This is NOT compliant to IEEE-1815-2012.
	public bool noDefferedReadDuringUnsolicitedNullResponse = false;

	/// The maximum fragment size the outstation will use for fragments it sends
	public uint maxTxFragSize = DEFAULT_MAX_APDU_SIZE;

	/// The maximum fragment size the outstation will be able to receive
	public uint maxRxFragSize = DEFAULT_MAX_APDU_SIZE;

	/// Global enabled / disable for unsolicited messages. If false, the NULL unsolicited message is not even sent
	public bool allowUnsolicited = false;

	/// A bitmask type that specifies the types allowed in a class 0 reponse
	public StaticTypeBitField typesAllowedInClass0 = StaticTypeBitField.AllTypes();

	/// Class mask for unsolicted, default to 0 as unsolicited has to be enabled
	public ClassField unsolClassMask = ClassField.None();

	/// If true, the outstation processes responds to any request/confirmation as if it came from the expected master
	/// address
	public bool respondToAnyMaster = false;
}

} // namespace opendnp3

