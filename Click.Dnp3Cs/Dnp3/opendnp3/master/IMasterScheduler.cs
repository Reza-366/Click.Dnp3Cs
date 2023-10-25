using System.Collections.Generic;

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
 * Interface used by master sessions to schedule tasks
 */
public abstract class IMasterScheduler : System.IDisposable
{

	public virtual void Dispose()
	{
	}

	public abstract void Shutdown();

	/**
	 * Add a single task to the scheduler. The tasks will be started asynchronously,
	 * i.e. not by the call to this method
	 */
	public abstract void Add(IMasterTask task, IMasterTaskRunner runner);

	/**
	 * Remove all tasks associated with this context, including the running one
	 */
	public abstract void SetRunnerOffline(in IMasterTaskRunner runner);

	/**
	 *
	 */
	public abstract bool CompleteCurrentFor(in IMasterTaskRunner runner);

	/**
	 *  Called if task changes in such a way that it might be runnable sooner than scheduled
	 */
	public abstract void Evaluate();

	/**
	 * Run a task as soon as possible
	 */
	public abstract void Demand(IMasterTask task);

	/**
	 * Add multiple tasks in one call
	 */
	public void Add(List<IMasterTask> tasks, IMasterTaskRunner runner)
	{
		foreach (var task in tasks)
		{
			this.Add(task, runner);
		}
	}
}

} // namespace opendnp3

