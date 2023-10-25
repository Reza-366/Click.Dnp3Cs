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



namespace opendnp3
{

public class RestartOperationResult
{
	public RestartOperationResult()
	{
		this.summary = new opendnp3.TaskCompletion.FAILURE_NO_COMMS;
	}

	public RestartOperationResult(TaskCompletion summary_, TimeDuration restartTime_)
	{
		this.summary = new opendnp3.TaskCompletion(summary_);
		this.restartTime = new opendnp3.TimeDuration(restartTime_);
	}

	/// The result of the task as a whole.
	public TaskCompletion summary;

	/// Time delay until restart
	public TimeDuration restartTime = new TimeDuration();
}

public delegate void RestartOperationCallbackT(in RestartOperationResult UnnamedParameter);

} // namespace opendnp3
