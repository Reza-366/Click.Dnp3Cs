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

// Base class with machinery for performing command operations
public class CommandTask : IMasterTask
{

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public CommandTask(TaskContext context, CommandSet && commands, IndexQualifierMode mode, IMasterApplication app, CommandResultCallbackT callback, in Timestamp startExpiration, in TaskConfig config, in Logger logger) : base(context, app, TaskBehavior.SingleExecutionNoRetry(startExpiration), logger, config)
	{
		this.statusResult = new opendnp3.CommandStatus.UNDEFINED;
		this.commandCallback = std::move(callback);
		this.commands = new opendnp3.CommandSet(std::move(commands));
		this.mode = new opendnp3.IndexQualifierMode(mode);
	}

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public static IMasterTask CreateDirectOperate(TaskContext context, CommandSet && set, IndexQualifierMode mode, IMasterApplication app, in CommandResultCallbackT callback, in Timestamp startExpiration, in TaskConfig config, Logger logger)
	{
		var task = new CommandTask(context, std::move(set), mode, app, callback, startExpiration, config, logger);
		task.LoadDirectOperate();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return task;
		return new opendnp3.CommandTask(task);
	}

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public static IMasterTask CreateSelectAndOperate(TaskContext context, CommandSet && set, IndexQualifierMode mode, IMasterApplication app, in CommandResultCallbackT callback, in Timestamp startExpiration, in TaskConfig config, Logger logger)
	{
		var task = new CommandTask(context, std::move(set), mode, app, callback, startExpiration, config, logger);
		task.LoadSelectAndOperate();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return task;
		return new opendnp3.CommandTask(task);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual char const* Name() const override final
	public override sealed string Name()
	{
		return "Command Task";
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual int Priority() const override final
	public override sealed int Priority()
	{
		return opendnp3.priority.Globals.COMMAND;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool BlocksLowerPriority() const override final
	public override sealed bool BlocksLowerPriority()
	{
		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsRecurring() const override final
	public override sealed bool IsRecurring()
	{
		return false;
	}

	public override bool BuildRequest(APDURequest request, System.Byte seq)
	{
		if (functionCodes.Count > 0)
		{
			request.SetFunction(functionCodes.First.Value);
			functionCodes.RemoveFirst();
			request.SetControl(AppControlField.Request(new System.Byte(seq)));
			var writer = request.GetWriter();
			return CommandSetOps.Write(commands, writer, this.mode);
		}

		return false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool IsEnabled() const override final
	private override sealed bool IsEnabled()
	{
		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual MasterTaskType GetTaskType() const override final
	private override sealed MasterTaskType GetTaskType()
	{
		return MasterTaskType.USER_TASK;
	}

	private override void Initialize()
	{
		statusResult = CommandStatus.UNDEFINED;
	}

	private override IMasterTask.ResponseResult ProcessResponse(in APDUResponseHeader header, in ser4cpp.rseq_t objects)
	{
		return ValidateSingleResponse(header) ? ProcessResponse(objects) : ResponseResult.ERROR_BAD_RESPONSE;
	}

	private override void OnTaskComplete(TaskCompletion result, Timestamp now)
	{
		CommandSetOps.InvokeCallback(commands, result, this.commandCallback);
	}

	private IMasterTask.ResponseResult ProcessResponse(in ser4cpp.rseq_t objects)
	{
		if (functionCodes.Count == 0)
		{
			var result = CommandSetOps.ProcessOperateResponse(commands, objects, logger);
			return (result == CommandSetOps.OperateResult.FAIL_PARSE) ? ResponseResult.ERROR_BAD_RESPONSE : ResponseResult.OK_FINAL;
		}

		var result = CommandSetOps.ProcessSelectResponse(commands, objects, logger);

		switch (result)
		{
		case (CommandSetOps.SelectResult.OK):
			return ResponseResult.OK_REPEAT; // proceed to OPERATE
		case (CommandSetOps.SelectResult.FAIL_SELECT):
			return ResponseResult.OK_FINAL; // end the task, let the user examine each command point
		default:
			return ResponseResult.ERROR_BAD_RESPONSE;
		}
	}

	private void LoadSelectAndOperate()
	{
		functionCodes.Clear();
		functionCodes.AddLast(FunctionCode.SELECT);
		functionCodes.AddLast(FunctionCode.OPERATE);
	}

	private void LoadDirectOperate()
	{
		functionCodes.Clear();
		functionCodes.AddLast(FunctionCode.DIRECT_OPERATE);
	}

	private LinkedList<FunctionCode> functionCodes = new LinkedList<FunctionCode>();

	private CommandStatus statusResult;
	private readonly CommandResultCallbackT commandCallback;
	private CommandSet commands = new CommandSet();
	private readonly IndexQualifierMode mode;
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

