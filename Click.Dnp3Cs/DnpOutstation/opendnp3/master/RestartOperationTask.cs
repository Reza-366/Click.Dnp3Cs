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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class RestartOperationTask final : public IMasterTask, private IAPDUHandler
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class RestartOperationTask : IMasterTask, IAPDUHandler
{

	public RestartOperationTask(TaskContext context, IMasterApplication app, in Timestamp startTimeout, RestartType operationType, RestartOperationCallbackT callback, in Logger logger, in TaskConfig config) : base(context, app, TaskBehavior.SingleExecutionNoRetry(startTimeout), logger, config)
	{
		this.function = new opendnp3.FunctionCode((operationType == RestartType.COLD) ? FunctionCode.COLD_RESTART : FunctionCode.WARM_RESTART);
		this.callback = std::move(callback);
	}

	public override bool BuildRequest(APDURequest request, byte seq)
	{
		request.SetControl(new AppControlField(true, true, false, false, seq));
		request.SetFunction(this.function);
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: int Priority() const override
	public override int Priority()
	{
		return opendnp3.priority.Globals.USER_REQUEST;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool BlocksLowerPriority() const override
	public override bool BlocksLowerPriority()
	{
		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsRecurring() const override
	public override bool IsRecurring()
	{
		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return FunctionCodeSpec.to_human_string(this.function);
	}

	public override bool IsAllowed(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		if (headerCount != 0)
		{
			return false;
		}

		switch (gv)
		{
		case (GroupVariation.Group52Var1):
		case (GroupVariation.Group52Var2):
			return true;
		default:
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: MasterTaskType GetTaskType() const override
	private override MasterTaskType GetTaskType()
	{
		return MasterTaskType.USER_TASK;
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var1> values)
	{
		Group52Var1 value = new Group52Var1();
		if (values.ReadOnlyValue(ref value))
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->duration = TimeDuration::Milliseconds(value.time);
			this.duration.CopyFrom(TimeDuration.Milliseconds(new ushort(value.time)));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		}

		return IINBit.PARAM_ERROR;
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var2> values)
	{
		Group52Var2 value = new Group52Var2();
		if (values.ReadOnlyValue(ref value))
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->duration = TimeDuration::Milliseconds(value.time);
			this.duration.CopyFrom(TimeDuration.Milliseconds(new ushort(value.time)));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		}

		return IINBit.PARAM_ERROR;
	}

	private static FunctionCode ToFunctionCode(RestartType op)
	{
		return (op == RestartType.COLD) ? FunctionCode.COLD_RESTART : FunctionCode.WARM_RESTART;
	}

	private readonly FunctionCode function;
	private RestartOperationCallbackT callback;
	private TimeDuration duration = new TimeDuration();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	override IMasterTask::ResponseResult ProcessResponse(in APDUResponseHeader header, in RSeq</*size_t*/int> objects);

	private override void OnTaskComplete(TaskCompletion result, Timestamp now)
	{
		if (this.Errors().Any())
		{
			this.callback(new RestartOperationResult(TaskCompletion.FAILURE_BAD_RESPONSE, this.duration));
		}
		else
		{
			this.callback(new RestartOperationResult(result, this.duration));
		}
	}
}

} // namespace opendnp3




namespace opendnp3
{


} // namespace opendnp3
