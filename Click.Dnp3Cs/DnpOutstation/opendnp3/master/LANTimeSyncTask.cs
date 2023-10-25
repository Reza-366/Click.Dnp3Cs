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

// Synchronizes the time on the outstation
public class LANTimeSyncTask : IMasterTask
{

	private enum State
	{
		RECORD_CURRENT_TIME,
		WRITE_TIME
	}

	public LANTimeSyncTask(TaskContext context, IMasterApplication app, in Logger logger) : base(context, app, TaskBehavior.ReactsToIINOnly(), logger, TaskConfig.Default())
	{
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const override final
	public override sealed string Name()
	{
		return "LAN time sync";
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const override final
	public override sealed int Priority()
	{
		return opendnp3.priority.Globals.TIME_SYNC;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const override final
	public override sealed bool BlocksLowerPriority()
	{
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const override final
	public override sealed bool IsRecurring()
	{
		return true;
	}

	public override bool BuildRequest(APDURequest request, byte seq)
	{
		if (state == State.RECORD_CURRENT_TIME)
		{
			this.start = this.application.Now();
			build.RecordCurrentTime(request, seq);
			return true;
		}

		Group50Var3 time = new Group50Var3();
		time.time = new DNPTime(this.start.msSinceEpoch);
		request.SetFunction(FunctionCode.WRITE);
		request.SetControl(AppControlField.Request(new byte(seq)));
		var writer = request.GetWriter();
		return writer.WriteSingleValue<ser4cpp.UInt8, Group50Var3>(QualifierCode.UINT8_CNT, time);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const override final
	private override sealed MasterTaskType GetTaskType()
	{
		return MasterTaskType.LAN_TIME_SYNC;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const override final
	private override sealed bool IsEnabled()
	{
		return true;
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	override sealed ResponseResult ProcessResponse(in APDUResponseHeader response, in ser4cpp::rseq_t objects);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	ResponseResult OnResponseRecordCurrentTime(in APDUResponseHeader response, in ser4cpp::rseq_t objects);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	ResponseResult OnResponseWriteTime(in APDUResponseHeader header, in ser4cpp::rseq_t objects);

	private override void Initialize()
	{
		this.state = State.RECORD_CURRENT_TIME;
	}

	private State state = State.RECORD_CURRENT_TIME;

	// what time we sent the delay meas
	private UTCTimestamp start = new UTCTimestamp();
}

} // namespace opendnp3



namespace opendnp3
{




} // namespace opendnp3
