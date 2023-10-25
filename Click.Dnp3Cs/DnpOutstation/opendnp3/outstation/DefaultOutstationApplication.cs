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
 * A singleton with default setting useful for examples
 */
public class DefaultOutstationApplication : IOutstationApplication
{
	public static IOutstationApplication Create(TimeDuration timeSyncRefreshRate = TimeDuration.Minutes(1))
	{
		return new DefaultOutstationApplication(timeSyncRefreshRate);
	}

	public DefaultOutstationApplication(TimeDuration timeSyncRefreshRate = TimeDuration.Minutes(1))
	{
		this.refresh_rate = new opendnp3.TimeDuration(timeSyncRefreshRate);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	virtual ~DefaultOutstationApplication() = default;

	// IDnpTimeSource
	public override DNPTime Now()
	{
		var result = new DNPTime(last_timestamp.msSinceEpoch + std::chrono.duration_cast<std::chrono.milliseconds>(std::chrono.system_clock.now() - last_update).count());
		result.quality = IsTimeValid() ? TimestampQuality.SYNCHRONIZED : TimestampQuality.UNSYNCHRONIZED;
		return result;
	}

	// IOutstationApplication
	public override bool SupportsWriteAbsoluteTime()
	{
		return true;
	}
	public override bool WriteAbsoluteTime(in UTCTimestamp timestamp)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: last_timestamp = timestamp;
		last_timestamp.CopyFrom(timestamp);
		last_update = std::chrono.system_clock.now();
		return true;
	}

	public override bool SupportsWriteTimeAndInterval()
	{
		return false;
	}
	public override bool WriteTimeAndInterval(in ICollection<Indexed<TimeAndInterval>> values)
	{
		return false;
	}

	public override bool SupportsAssignClass()
	{
		return true;
	}
	public override void RecordClassAssignment(AssignClassType type, PointClass clazz, ushort start, ushort stop)
	{
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ApplicationIIN GetApplicationIIN() const override
	public override ApplicationIIN GetApplicationIIN()
	{
		ApplicationIIN result = new ApplicationIIN();
		result.needTime = NeedsTime();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return result;
		return new opendnp3.ApplicationIIN(result);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual RestartMode ColdRestartSupport() const override
	public override RestartMode ColdRestartSupport()
	{
		return RestartMode.UNSUPPORTED;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual RestartMode WarmRestartSupport() const override
	public override RestartMode WarmRestartSupport()
	{
		return RestartMode.UNSUPPORTED;
	}
	public override ushort ColdRestart()
	{
		return 65535;
	}
	public override ushort WarmRestart()
	{
		return 65535;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsTimeValid() const
	private bool IsTimeValid()
	{
		return std::chrono.system_clock.now() - last_update <= refresh_rate.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool NeedsTime() const
	private bool NeedsTime()
	{
		return std::chrono.system_clock.now() - last_update > refresh_rate.value / 2;
	}

	private TimeDuration refresh_rate = new TimeDuration();
	private UTCTimestamp last_timestamp = new UTCTimestamp();
	private std::chrono.system_clock.time_point last_update = new std::chrono.system_clock.time_point(std::chrono.milliseconds(0));
}

} // namespace opendnp3



