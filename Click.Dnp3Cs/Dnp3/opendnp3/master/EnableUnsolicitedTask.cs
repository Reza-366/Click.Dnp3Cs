﻿/*
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
 * Base class for tasks that only require a single response
 */

public sealed class EnableUnsolicitedTask : IMasterTask
{

	public EnableUnsolicitedTask(TaskContext context, IMasterApplication app, in TaskBehavior behavior, ClassField enabledClasses, in Logger logger) : base(context, app, behavior, logger, TaskConfig.Default())
	{
		this.enabledClasses = new opendnp3.ClassField(enabledClasses);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const override
	public override bool IsRecurring()
	{
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const override
	public override string Name()
	{
		return "Enable Unsolicited";
	}

	public override bool BuildRequest(APDURequest request, System.Byte seq)
	{
		build.EnableUnsolicited(request, enabledClasses.OnlyEventClasses(), seq);
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const override
	public override int Priority()
	{
		return opendnp3.priority.Globals.ENABLE_UNSOLICITED;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const override
	public override bool BlocksLowerPriority()
	{
		return true;
	}

	private ClassField enabledClasses = new ClassField();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const override
	private override MasterTaskType GetTaskType()
	{
		return MasterTaskType.ENABLE_UNSOLICITED;
	}

	private override IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
	{
		return ValidateNullResponse(header, objects) ? ResponseResult.OK_FINAL : ResponseResult.ERROR_BAD_RESPONSE;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const override
	private override bool IsEnabled()
	{
		return enabledClasses.HasEventClass();
	}
}

} // namespace opendnp3


//#include "../../exe4cpp/IExecutor.h"
