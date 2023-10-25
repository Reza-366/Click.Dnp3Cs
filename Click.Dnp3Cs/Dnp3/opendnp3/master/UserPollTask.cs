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

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class ISOEHandler;

/**
 * A generic interface for defining master request/response style tasks
 */

public sealed class UserPollTask : PollTaskBase
{

	public UserPollTask(TaskContext context, HeaderBuilderT builder, in TaskBehavior behavior, bool recurring, IMasterApplication app, ISOEHandler soeHandler, in Logger logger, TaskConfig config) : base(context, app, std::move(soeHandler), behavior, logger, config)
	{
		this.builder = std::move(builder);
		this.recurring = recurring;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const override
	public override int Priority()
	{
		return (int)opendnp3.priority.Globals.USER_POLL;
	}

	public override bool BuildRequest(APDURequest request, System.Byte seq)
	{
		this.rxCount = 0;
		request.SetFunction(FunctionCode.READ);
		request.SetControl(AppControlField.Request(new System.Byte(seq)));
		var writer = request.GetWriter();
		return builder(writer);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const override
	public override bool BlocksLowerPriority()
	{
		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const override
	public override bool IsRecurring()
	{
		return recurring;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const override
	public override bool IsEnabled()
	{
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const override
	private override MasterTaskType GetTaskType()
	{
		return MasterTaskType.USER_TASK;
	}

	private HeaderBuilderT builder;
	private readonly bool recurring;
}

} // namespace opendnp3




