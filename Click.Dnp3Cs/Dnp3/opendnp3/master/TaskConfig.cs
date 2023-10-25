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
 *	Object containing multiple fields for configuring tasks
 */
public class TaskConfig
{
	public TaskConfig(TaskId taskId, ITaskCallback pCallback)
	{
		this.taskId = new opendnp3.TaskId(taskId);
		this.pCallback = pCallback;
	}

	public static TaskConfig Default()
	{
		return new TaskConfig(TaskId.Undefined(), null);
	}

	///  --- syntax sugar for building configs -----

	public static TaskConfig With(ITaskCallback callback)
	{
		return new TaskConfig(TaskId.Undefined(), callback);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	TaskConfig() = delete;

	public TaskId taskId = new TaskId();
	public ITaskCallback pCallback;
}

} // namespace opendnp3

