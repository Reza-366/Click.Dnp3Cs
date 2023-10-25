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

public sealed class DefaultMasterApplication : IMasterApplication
{
	public DefaultMasterApplication()
	{
	}

	public static IMasterApplication Create()
	{
		return new DefaultMasterApplication();
	}

	public sealed override void OnReceiveIIN(in IINField iin)
	{
	}

	public sealed override void OnTaskStart(MasterTaskType type, TaskId id)
	{
	}

	public sealed override void OnTaskComplete(in TaskInfo info)
	{
	}

	public sealed override bool AssignClassDuringStartup()
	{
		return false;
	}

	public sealed override void ConfigureAssignClassRequest(in WriteHeaderFunT fun)
	{
	}

	public virtual UTCTimestamp Now()
	{
		ulong time = std::chrono.duration_cast<std::chrono.milliseconds>(std::chrono.system_clock.now().time_since_epoch()).count();
		return new UTCTimestamp(time);
	}

	public sealed override void OnStateChange(LinkStatus value)
	{
	}
}

} // namespace opendnp3




