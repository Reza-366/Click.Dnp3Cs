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
 * Interface for all outstation application callback info except for control requests
 */
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public class IOutstationApplication : ILinkListener, IDnpTimeSource, System.IDisposable
{
	/// Queries whether the the outstation supports absolute time writes
	/// If this function returns false, WriteAbsoluteTime will never be called
	/// and the outstation will return IIN 2.1 (FUNC_NOT_SUPPORTED)
	public virtual bool SupportsWriteAbsoluteTime()
	{
		return false;
	}

	/// Write the time to outstation, only called if SupportsWriteAbsoluteTime return true
	/// @return boolean value indicating if the time value supplied was accepted. Returning
	/// false will cause the outstation to set IIN 2.3 (PARAM_ERROR) in its response.
	/// The outstation should clear its NEED_TIME field when handling this response
	public virtual bool WriteAbsoluteTime(in UTCTimestamp timestamp)
	{
		return false;
	}

	/// Queries whether the outstation supports the writing of TimeAndInterval
	/// If this function returns false, WriteTimeAndInterval will never be called
	/// and the outstation will return IIN 2.1 (FUNC_NOT_SUPPORTED) when it receives this request
	public virtual bool SupportsWriteTimeAndInterval()
	{
		return false;
	}

	/// Write one or more TimeAndInterval values. Only called if SupportsWriteTimeAndInterval returns true.
	/// The outstation application code is reponsible for updating TimeAndInterval values in the database if this
	/// behavior is desired
	/// @return boolean value indicating if the values supplied were accepted. Returning
	/// false will cause the outstation to set IIN 2.3 (PARAM_ERROR) in its response.
	public virtual bool WriteTimeAndInterval(in ICollection<Indexed<TimeAndInterval>> values)
	{
		return false;
	}

	/// True if the outstation supports the assign class function code
	/// If this function returns false, the assign class callbacks will never be called
	/// and the outstation will return IIN 2.1 (FUNC_NOT_SUPPORTED) when it receives this function code
	public virtual bool SupportsAssignClass()
	{
		return false;
	}

	/// Called if SupportsAssignClass returns true
	/// The type and range are pre-validated against the outstation's database
	/// and class assignments are automatically applied internally.
	/// This callback allows user code to persist the changes to non-volatile memory
	public virtual void RecordClassAssignment(AssignClassType type, PointClass clazz, ushort start, ushort stop)
	{
	}

	/// Returns the application-controlled IIN field
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ApplicationIIN GetApplicationIIN() const
	public virtual ApplicationIIN GetApplicationIIN()
	{
		return new ApplicationIIN();
	}

	/// Query the outstation for the cold restart mode it supports
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual RestartMode ColdRestartSupport() const
	public virtual RestartMode ColdRestartSupport()
	{
		return RestartMode.UNSUPPORTED;
	}

	/// Query the outstation for the warm restart mode it supports
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual RestartMode WarmRestartSupport() const
	public virtual RestartMode WarmRestartSupport()
	{
		return RestartMode.UNSUPPORTED;
	}

	/// The outstation should perform a complete restart.
	/// See the DNP3 specification for a complete descripton of normal behavior
	/// @return number of seconds or milliseconds until restart is complete. The value
	/// is interpreted based on the Restart Mode returned from ColdRestartSupport()
	public virtual ushort ColdRestart()
	{
		return 65535;
	}

	/// The outstation should perform a partial restart of only the DNP3 application.
	/// See the DNP3 specification for a complete descripton of normal behavior
	/// @return number of seconds or milliseconds until restart is complete. The value
	/// is interpreted based on the Restart Mode returned from WarmRestartSupport()
	public virtual ushort WarmRestart()
	{
		return 65535;
	}

	/// This method notifies that application code that an expected CONFIRM has been
	/// received, and events may have cleared from the event buffer. It is informational
	/// only.
	///
	/// @param is_unsolicited true, if the confirm is for an unsolicited response, false for a solicited response
	/// @param num_class1 number of Class 1 events remaining in the event buffer after processing the confirm
	/// @param num_class2 number of Class 2 events remaining in the event buffer after processing the confirm
	/// @param num_class3 number of Class 3 events remaining in the event buffer after processing the confirm
	public virtual void OnConfirmProcessed(bool is_unsolicited, uint num_class1, uint num_class2, uint num_class3)
	{
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	virtual ~IOutstationApplication() = default;
}

} // namespace opendnp3


