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

public class MasterTasks
{

	public MasterTasks(in MasterParams @params, in Logger logger, IMasterApplication app, ISOEHandler SOEHandler)
	{
		this.context = new TaskContext();
		this.clearRestart = new ClearRestartTask(context, app, logger);
		this.assignClass = new AssignClassTask(context, app, RetryBehavior(@params), logger);
		this.startupIntegrity = new StartupIntegrityPoll(context, app, SOEHandler, @params.startupIntegrityClassMask, RetryBehavior(@params), logger);
		this.eventScan = new EventScanTask(context, app, SOEHandler, @params.eventScanOnEventsAvailableClassMask, logger);
		this.disableUnsol = GetDisableUnsolTask(context, @params, logger, app);
		this.enableUnsol = GetEnableUnsolTask(context, @params, logger, app);
		this.timeSynchronization = GetTimeSyncTask(context, @params.timeSyncMode, logger, app);
	}

	public void Initialize(IMasterScheduler scheduler, IMasterTaskRunner runner)
	{
		foreach (var task in new List<opendnp3.IMasterTask>() {clearRestart, assignClass, startupIntegrity, eventScan, enableUnsol, disableUnsol, timeSynchronization})
		{
			if (task != null)
			{
				scheduler.Add(task, runner);
			}
		}

		foreach (var task in boundTasks)
		{
			scheduler.Add(task, runner);
		}
	}

	public bool DemandTimeSync()
	{
		return this.Demand(this.timeSynchronization);
	}

	public bool DemandEventScan()
	{
		return this.Demand(this.eventScan);
	}

	public bool DemandIntegrity()
	{
		return this.Demand(this.startupIntegrity);
	}

	public void OnRestartDetected()
	{
		this.Demand(this.clearRestart);
		this.Demand(this.assignClass);
		this.Demand(this.startupIntegrity);
		this.Demand(this.enableUnsol);
	}

	public void BindTask(IMasterTask task)
	{
		boundTasks.Add(task);
	}

	public readonly TaskContext context;

	private bool Demand(IMasterTask task)
	{
		if (task != null)
		{
			task.SetMinExpiration();
			return true;
		}
		else
		{
			return false;
		}
	}

	private static TaskBehavior RetryBehavior(in MasterParams @params)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return TaskBehavior::SingleImmediateExecutionWithRetry(params.taskRetryPeriod, params.maxTaskRetryPeriod);
		return new opendnp3.TaskBehavior(TaskBehavior.SingleImmediateExecutionWithRetry(@params.taskRetryPeriod, @params.maxTaskRetryPeriod));
	}

	private readonly IMasterTask clearRestart;
	private readonly IMasterTask assignClass;
	private readonly IMasterTask startupIntegrity;
	private readonly IMasterTask eventScan;
	private readonly IMasterTask disableUnsol;
	private readonly IMasterTask enableUnsol;
	private readonly IMasterTask timeSynchronization;

	private static IMasterTask GetTimeSyncTask(TaskContext context, TimeSyncMode mode, in Logger logger, IMasterApplication application)
	{
		switch (mode)
		{
		case (TimeSyncMode.NonLAN):
			return new SerialTimeSyncTask(context, application, logger);
		case (TimeSyncMode.LAN):
			return new LANTimeSyncTask(context, application, logger);
		default:
			return null;
		}
	}

	private static IMasterTask GetEnableUnsolTask(TaskContext context, in MasterParams @params, in Logger logger, IMasterApplication application)
	{
		return @params.unsolClassMask.HasEventClass() ? new EnableUnsolicitedTask(context, application, RetryBehavior(@params), @params.unsolClassMask, logger) : null;
	}

	private static IMasterTask GetDisableUnsolTask(TaskContext context, in MasterParams @params, in Logger logger, IMasterApplication application)
	{
		return @params.disableUnsolOnStartup ? new DisableUnsolicitedTask(context, application, TaskBehavior.SingleImmediateExecutionWithRetry(@params.taskRetryPeriod, @params.maxTaskRetryPeriod), logger) : null;
	}

	private List<IMasterTask> boundTasks = new List<IMasterTask>();
}

} // namespace opendnp3




