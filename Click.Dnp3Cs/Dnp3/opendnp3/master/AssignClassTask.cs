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

public sealed class AssignClassTask : IMasterTask
{

	public AssignClassTask(TaskContext context, IMasterApplication application, in TaskBehavior behavior, in Logger logger) : base(context, application, behavior, logger, TaskConfig.Default())
	{
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const override
	public override string Name()
	{
		return "Assign Class";
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const override
	public override bool IsRecurring()
	{
		return true;
	}

	public override bool BuildRequest(APDURequest request, System.Byte seq)
	{
		request.SetControl(new AppControlField(true, true, false, false, seq));
		request.SetFunction(FunctionCode.ASSIGN_CLASS);
		var writer = request.GetWriter();

		bool success = true;
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var writeFun = (in Header header) =>
		{
			success &= header.WriteTo(writer);
		};

		this.application.ConfigureAssignClassRequest(writeFun);
		return success;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const override
	public override int Priority()
	{
		return opendnp3.priority.Globals.ASSIGN_CLASS;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const override
	public override bool BlocksLowerPriority()
	{
		return true;
	}

	private TimeDuration retryPeriod = new TimeDuration();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const override
	private override MasterTaskType GetTaskType()
	{
		return MasterTaskType.ASSIGN_CLASS;
	}

	private override IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
	{
		return ValidateNullResponse(header, objects) ? ResponseResult.OK_FINAL : ResponseResult.ERROR_BAD_RESPONSE;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const override
	private override bool IsEnabled()
	{
		return this.application.AssignClassDuringStartup();
	}
}

} // namespace opendnp3




