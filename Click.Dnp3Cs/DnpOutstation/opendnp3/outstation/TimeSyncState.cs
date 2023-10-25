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

///
/// Represent all of the mutable state for time synchornization
///
public class TimeSyncState
{

	public TimeSyncState()
	{
	}

	public void RecordCurrentTime(in AppSeqNum seq, in Timestamp now)
	{
		valid = true;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: time = now;
		time.CopyFrom(now);
		expectedSeqNum = seq.Next();
	}

	public bool CalcTimeDifference(in AppSeqNum seq, in Timestamp now)
	{
		if (!valid)
		{
			return false;
		}
		if (!expectedSeqNum.Equals(seq))
		{
			return false;
		}
		if (now < time)
		{
			return false;
		}

		this.difference = now - time;
		this.valid = false;

		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: TimeDuration GetDifference() const
	public TimeDuration GetDifference()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->difference;
		return new opendnp3.TimeDuration(this.difference);
	}

	private bool valid = false;
	private Timestamp time = new Timestamp();
	private TimeDuration difference = new TimeDuration();
	private AppSeqNum expectedSeqNum = new AppSeqNum();
}

} // namespace opendnp3

