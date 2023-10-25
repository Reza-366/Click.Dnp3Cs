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

//#include "../../exe4cpp/IExecutor.h"


namespace opendnp3
{

/**
 * Provides access to a permanently bound scan
 */
public sealed class MasterScan : IMasterScan
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	MasterScan() = default;

	public MasterScan(IMasterTask task, IMasterScheduler scheduler)
	{
		this.task = std::move(task);
		this.scheduler = std::move(scheduler);
	}

	public static MasterScan Create(IMasterTask task, IMasterScheduler scheduler)
	{
		return new MasterScan(task, scheduler);
	}

	// Request that the scan be performed as soon as possible
	public override void Demand()
	{
		scheduler.Demand(task);
	}

	private readonly IMasterTask task;
	private readonly IMasterScheduler scheduler;
}

} // namespace opendnp3



