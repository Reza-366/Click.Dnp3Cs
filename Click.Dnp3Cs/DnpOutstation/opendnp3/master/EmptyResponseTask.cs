using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

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

public static class EmptyResponseTask : IMasterTask
{

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	EmptyResponseTask(TaskContext context, IMasterApplication app, string name, FunctionCode func, HeaderBuilderT format, Timestamp startExpiration, in Logger logger, in TaskConfig config);

	public override bool EmptyResponseTask.BuildRequest(APDURequest request, byte seq)
	{
		request.SetControl(new AppControlField(true, true, false, false, seq));
		request.SetFunction(this.func);
		var writer = request.GetWriter();
		return format(writer);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: char const* Name() const override
	public override string Name()
	{
		return name;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsRecurring() const override
	public override bool IsRecurring()
	{
		return false;
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
//ORIGINAL LINE: MasterTaskType GetTaskType() const override
	private override MasterTaskType GetTaskType()
	{
		return MasterTaskType.USER_TASK;
	}

	private readonly string name = "";

	private FunctionCode func;
	private HeaderBuilderT format;


	/*func, priority::USER_REQUEST, format*/

	private override IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
	{
		return ValidateNullResponse(header, objects) ? ResponseResult.OK_FINAL : ResponseResult.ERROR_BAD_RESPONSE;
	}
}

} // namespace opendnp3



namespace opendnp3
{


} // namespace opendnp3
