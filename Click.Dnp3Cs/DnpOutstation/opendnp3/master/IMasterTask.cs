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

//#include "../../exe4cpp/IExecutor.h"

namespace opendnp3
{

/**
 * A generic interface for defining master request/response style tasks
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class IMasterTask : private Uncopyable
public abstract class IMasterTask : Uncopyable
{

	public enum ResponseResult : byte
	{
		/// The response was bad, the task has failed
		ERROR_BAD_RESPONSE,

		/// The response was good and the task is complete
		OK_FINAL,

		/// The response was good and the task should repeat the format, transmit, and await response sequence
		OK_REPEAT,

		/// The response was good and the task should continue executing. Restart the response timer, and increment
		/// expected SEQ#.
		OK_CONTINUE
	}

	public IMasterTask(TaskContext context, IMasterApplication app, TaskBehavior behavior, in Logger logger, TaskConfig config)
	{
		this.context = std::move(context);
		this.application = app;
		this.logger = new opendnp3.Logger(logger);
		this.config = new opendnp3.TaskConfig(config);
		this.behavior = new opendnp3.TaskBehavior(std::move(behavior));
	}

	public override void Dispose()
	{
		context.RemoveBlock(this);

		if (config.pCallback != null)
		{
			config.pCallback.OnDestroyed();
		}
		base.Dispose();
	}

	/**
	 *
	 * @return	the name of the task
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const = 0;
	public abstract string Name();

	/**
	 * The task's priority. Lower numbers are higher priority.
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const = 0;
	public abstract int Priority();

	/**
	 * Indicates if the task should be rescheduled (true) or discarded
	 * after a single execution (false)
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const = 0;
	public abstract bool IsRecurring();

	/**
	 * The time when this task can run again.
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Timestamp ExpirationTime() const
	public Timestamp ExpirationTime()
	{
		return this.IsEnabled() ? this.behavior.GetExpiration() : Timestamp.Max();
	}

	/**
	 * Helper to test if the task is expired
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsExpired(const Timestamp& now) const
	public bool IsExpired(in Timestamp now)
	{
		return now >= this.ExpirationTime();
	}

	/**
	 * The time when this task expires if it is unable to start
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Timestamp StartExpirationTime() const
	public Timestamp StartExpirationTime()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->behavior.GetStartExpiration();
		return new opendnp3.Timestamp(this.behavior.GetStartExpiration());
	}

	/**
	 * Build a request APDU.
	 *
	 * Return false if some kind of internal error prevents the task for formatting the request.
	 */
	public abstract bool BuildRequest(APDURequest request, byte seq);

	/**
	 * Handler for responses
	 */
	public IMasterTask.ResponseResult OnResponse(in APDUResponseHeader response, in ser4cpp.RSeq objects, Timestamp now)
	{
		var result = this.ProcessResponse(response, objects);

		switch (result)
		{
		case (ResponseResult.ERROR_BAD_RESPONSE):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->CompleteTask(TaskCompletion::FAILURE_BAD_RESPONSE, now);
			this.CompleteTask(TaskCompletion.FAILURE_BAD_RESPONSE, new opendnp3.Timestamp(now));
			break;
		case (ResponseResult.OK_FINAL):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->CompleteTask(TaskCompletion::SUCCESS, now);
			this.CompleteTask(TaskCompletion.SUCCESS, new opendnp3.Timestamp(now));
			break;
		default:
			break;
		}

		return result;
	}

	/**
	 * Called when a response times out
	 */
	public void OnResponseTimeout(Timestamp now)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->CompleteTask(TaskCompletion::FAILURE_RESPONSE_TIMEOUT, now);
		this.CompleteTask(TaskCompletion.FAILURE_RESPONSE_TIMEOUT, new opendnp3.Timestamp(now));
	}

	/**
	 * Called when the layer closes while the task is executing.
	 */
	public void OnLowerLayerClose(Timestamp now)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->CompleteTask(TaskCompletion::FAILURE_NO_COMMS, now);
		this.CompleteTask(TaskCompletion.FAILURE_NO_COMMS, new opendnp3.Timestamp(now));
	}

	/**
	 * The start timeout expired before the task could be run
	 */
	public void OnStartTimeout(Timestamp now)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->CompleteTask(TaskCompletion::FAILURE_START_TIMEOUT, now);
		this.CompleteTask(TaskCompletion.FAILURE_START_TIMEOUT, new opendnp3.Timestamp(now));
	}

	/**
	 * Called when the master is unable to format the request associated with the task
	 */
	public void OnMessageFormatError(Timestamp now)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->CompleteTask(TaskCompletion::FAILURE_MESSAGE_FORMAT_ERROR, now);
		this.CompleteTask(TaskCompletion.FAILURE_MESSAGE_FORMAT_ERROR, new opendnp3.Timestamp(now));
	}

	/**
	 * Called when the task first starts, before the first request is formatted
	 */
	public void OnStart()
	{
		if (config.pCallback != null)
		{
			config.pCallback.OnStart();
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->application->OnTaskStart(this->GetTaskType(), config.taskId);
		this.application.OnTaskStart(this.GetTaskType(), new opendnp3.TaskId(config.taskId));

		this.Initialize();
	}

	/**
	 * Set the expiration time to minimum. The scheduler must also be informed
	 */
	public void SetMinExpiration()
	{
		this.behavior.Reset();
	}

	/**
	 * Check if the task is blocked from executing by another task
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsBlocked() const
	public bool IsBlocked()
	{
		return this.context.IsBlocked(this);
	}

	// called during OnStart() to initialize any state for a new run
	protected virtual void Initialize()
	{
	}

	protected abstract ResponseResult ProcessResponse(in APDUResponseHeader response, in ser4cpp.RSeq objects);

	protected void CompleteTask(TaskCompletion result, Timestamp now)
	{
		switch (result)
		{

		// retry immediately when the comms come back online
		case (TaskCompletion.FAILURE_NO_COMMS):
			this.behavior.Reset();
			break;

		// back-off exponentially using the task retry
		case (TaskCompletion.FAILURE_RESPONSE_TIMEOUT):
		{
			this.behavior.OnResponseTimeout(now);
			if (this.BlocksLowerPriority())
			{
				this.context.AddBlock(this);
			}
			break;
		}

		case (TaskCompletion.SUCCESS):
			this.behavior.OnSuccess(now);
			this.context.RemoveBlock(this);
			break;

		/**
		FAILURE_BAD_RESPONSE
		FAILURE_START_TIMEOUT
		FAILURE_MESSAGE_FORMAT_ERROR
		*/
		default:
		{
			this.behavior.Disable();
			if (this.BlocksLowerPriority())
			{
				this.context.AddBlock(this);
			}
		}
		break;
		}

		if (config.pCallback != null)
		{
			config.pCallback.OnComplete(result);
		}

		// notify the application
		this.application.OnTaskComplete(new TaskInfo(this.GetTaskType(), result, config.taskId));

		// notify any super class implementations
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->OnTaskComplete(result, now);
		this.OnTaskComplete(result, new opendnp3.Timestamp(now));
	}

	protected virtual void OnTaskComplete(TaskCompletion result, Timestamp now)
	{
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const
	protected virtual bool IsEnabled()
	{
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const = 0;
	protected abstract MasterTaskType GetTaskType();

	protected readonly TaskContext context;
	protected readonly IMasterApplication application;
	protected Logger logger = new Logger();

	// Validation helpers for various behaviors to avoid deep inheritance
	protected bool ValidateSingleResponse(in APDUResponseHeader header)
	{
		if (header.control.FIR && header.control.FIN)
		{
			return true;
		}

		if (logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Ignoring unexpected response FIR/FIN not set");
		};
		return false;
	}

	protected bool ValidateNullResponse(in APDUResponseHeader header, in ser4cpp.RSeq objects)
	{
		return ValidateSingleResponse(header) && ValidateNoObjects(objects) && ValidateInternalIndications(header);
	}

	protected bool ValidateNoObjects(in ser4cpp.RSeq objects)
	{
		if (objects.is_empty())
		{
			return true;
		}

		if (logger.is_enabled(opendnp3.flags.Globals.WARN))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Received unexpected response object headers for task: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};
		return false;
	}

	protected bool ValidateInternalIndications(in APDUResponseHeader header)
	{
		if (header.IIN.HasRequestError())
		{
			if (logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Task was explicitly rejected via response with error IIN bit(s): %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return false;
		}

		return true;
	}

	/**
	 * Allows tasks to enter a blocking mode where lower priority
	 * tasks cannot run until this task completes
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const = 0;
	private abstract bool BlocksLowerPriority();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IMasterTask();

	private TaskConfig config = new TaskConfig();
	private TaskBehavior behavior = new TaskBehavior();
}

} // namespace opendnp3



//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define STRINGIFY(x) #x
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define TOSTRING(x) STRINGIFY(x)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOCATION __FILE__ "(" TOSTRING(__LINE__) ")"
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, length_, format, ...) _snprintf_s(dest, length_, _TRUNCATE, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, size, format, ...) snprintf(dest, size, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOG_FORMAT(logger, levels, format, ...) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOG_BLOCK(logger, levels, message) if (logger.is_enabled(levels)) { logger.log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOGGER_BLOCK(pLogger, levels, message) if (pLogger && pLogger->is_enabled(levels)) { pLogger->log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOG_BLOCK(logger, levels, format, ...) if (logger.is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOGGER_BLOCK(pLogger, levels, format, ...) if (pLogger && pLogger->is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); pLogger->log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_HEX_BLOCK(logger, levels, buffer, firstSize, otherSize) if (logger.is_enabled(levels)) { opendnp3::HexLogging::log(logger, levels, buffer, ' ', firstSize, otherSize); }

