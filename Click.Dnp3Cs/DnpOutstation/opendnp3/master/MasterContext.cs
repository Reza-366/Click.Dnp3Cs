using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

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

//#include "../../exe4cpp/asio/StrandExecutor.h"


namespace opendnp3
{
	/*
	    All of the mutable state and configuration for a master
	*/
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class MContext final : public IUpperLayer, public std::enable_shared_from_this<MContext>, private IMasterTaskRunner, private Uncopyable
	public sealed class MContext : IUpperLayer, IMasterTaskRunner, Uncopyable
	{
		private MContext(in Addresses addresses, in Logger logger, ILowerLayer lower, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, in MasterParams @params)
		{
			this.logger = new opendnp3.Logger(logger);
			this.lower = std::move(lower);
			this.addresses = new opendnp3.Addresses(addresses);
			this.@params = new opendnp3.MasterParams(@params);
			this.SOEHandler = SOEHandler;
			this.application = application;
			this.scheduler = std::move(scheduler);
			this.tasks = new opendnp3.MasterTasks(@params, logger, application, SOEHandler);
			this.txBuffer = new ser4cpp.Buffer(@params.maxTxFragSize);
			this.tstate = new opendnp3.MContext.TaskState.IDLE;
		}

		public enum TaskState
		{
			IDLE,
			TASK_READY,
			WAIT_FOR_RESPONSE
		}

		public static MContext Create(in Addresses addresses, in Logger logger, ILowerLayer lower, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, in MasterParams @params)
		{
			return new MContext(addresses, logger, lower, SOEHandler, application, scheduler, @params);
		}

		public Logger logger = new Logger();
		//const std::shared_ptr<exe4cpp::IExecutor> executor;
		public readonly ILowerLayer lower;

		// ------- configuration --------
		public readonly Addresses addresses = new Addresses();
		public readonly MasterParams @params = new MasterParams();
		public readonly ISOEHandler SOEHandler;
		public readonly IMasterApplication application;
		public readonly IMasterScheduler scheduler;

		// ------- dynamic state ---------
		public bool isOnline = false;
		public bool isSending = false;
		public AppSeqNum solSeq = new AppSeqNum();
		public AppSeqNum unsolSeq = new AppSeqNum();
		public IMasterTask activeTask;
		public exe4cpp.Timer responseTimer = new exe4cpp.Timer();

		public MasterTasks tasks = new MasterTasks();
		public LinkedList<APDUHeader> confirmQueue = new LinkedList<APDUHeader>();
		public ser4cpp.Buffer txBuffer = new ser4cpp.Buffer();
		public TaskState tstate;

		// --- implement  IUpperLayer ------

		public override bool OnLowerLayerUp()
		{
			if (isOnline)
			{
				return false;
			}

			isOnline = true;

			tasks.Initialize(this.scheduler, this);

			this.application.OnOpen();

			return true;
		}

		public override bool OnLowerLayerDown()
		{
			if (!isOnline)
			{
				return false;
			}

			tstate = TaskState.IDLE;
			responseTimer.cancel();
			solSeq = unsolSeq = 0;
			isOnline = isSending = false;
			activeTask.reset();

			this.scheduler.SetRunnerOffline(this);
			this.application.OnClose();

			return true;
		}

		public override bool OnReceive(in Message message)
		{
			if (!this.isOnline)
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.ERR))
				{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Ignorning rx data while offline");
				};
				return false;
			}

			if (message.addresses.destination != this.addresses.source)
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unknown destination address: %u",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return false;
			}

			if (message.addresses.source != this.addresses.destination)
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unexpected message source: %u",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return false;
			}

			var result = APDUHeaderParser.ParseResponse(message.payload, this.logger);
			if (!result.success)
			{
				return true;
			}

			logging.LogHeader(this.logger, opendnp3.flags.Globals.APP_HEADER_RX, result.header);

			this.OnParsedHeader(message.payload, result.header, result.objects);

			return true;
		}

		public override bool OnTxReady()
		{
			if (!this.isOnline || !this.isSending)
			{
				return false;
			}

			this.isSending = false;

			this.tstate = this.OnTransmitComplete();
			this.CheckConfirmTransmit();

			return true;
		}

		// additional virtual methods that can be overriden to implement secure authentication

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		virtual void OnParsedHeader(in RSeq</*size_t*/int> apdu, in APDUResponseHeader header, in RSeq</*size_t*/int> objects);

		public virtual void RecordLastRequest(in RSeq</*size_t*/int> apdu)
		{
		}

		// methods for initiating command sequences


		/// --- command handlers ----

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
		public void DirectOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config)
		{
			//const auto timeout = Timestamp(this->executor->get_time()) + params.taskStartTimeout;
			//this->ScheduleAdhocTask(CommandTask::CreateDirectOperate(this->tasks.context, std::move(commands),
			//                                                         this->params.controlQualifierMode, *application, callback,
			//                                                         timeout, config, logger));
		}

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
		public void SelectAndOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config)
		{
			//const auto timeout = Timestamp(this->executor->get_time()) + params.taskStartTimeout;
			//this->ScheduleAdhocTask(CommandTask::CreateSelectAndOperate(this->tasks.context, std::move(commands),
			//                                                            this->params.controlQualifierMode, *application,
			//                                                            callback, timeout, config, logger));
		}

		// -----  public methods used to add tasks -----

		public IMasterTask AddScan(TimeDuration period, in HeaderBuilderT builder, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
			var task = new UserPollTask(this.tasks.context, builder, TaskBehavior.ImmediatePeriodic(period, @params.taskRetryPeriod, @params.maxTaskRetryPeriod), true, application, soe_handler, logger, config);
			this.ScheduleRecurringPollTask(task);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return task;
			return new opendnp3.UserPollTask(task);
		}

		public IMasterTask AddAllObjectsScan(GroupVariationID gvId, TimeDuration period, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto build = [gvId](HeaderWriter& writer)->bool
			var build = (HeaderWriter writer) =>
			{
				return writer.WriteHeader(new opendnp3.GroupVariationID(gvId), QualifierCode.ALL_OBJECTS);
			};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->AddScan(period, build, soe_handler, config);
			return new opendnp3.IMasterTask(this.AddScan(new opendnp3.TimeDuration(period), build, soe_handler, new opendnp3.TaskConfig(config)));
		}

		public IMasterTask AddClassScan(in ClassField field, TimeDuration period, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto build = [field](HeaderWriter& writer)->bool
			var build = (HeaderWriter writer) =>
			{
				return build.WriteClassHeaders(writer, field);
			};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->AddScan(period, build, soe_handler, config);
			return new opendnp3.IMasterTask(this.AddScan(new opendnp3.TimeDuration(period), build, soe_handler, new opendnp3.TaskConfig(config)));
		}

		public IMasterTask AddRangeScan(GroupVariationID gvId, ushort start, ushort stop, TimeDuration period, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto build = [gvId, start, stop](HeaderWriter& writer)->bool
			var build = (HeaderWriter writer) =>
			{
				return writer.WriteRangeHeader<new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_START_STOP, gvId, start, stop);
			};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->AddScan(period, build, soe_handler, config);
			return new opendnp3.IMasterTask(this.AddScan(new opendnp3.TimeDuration(period), build, soe_handler, new opendnp3.TaskConfig(config)));
		}

		// ---- Single shot immediate scans ----

		public void Scan(in HeaderBuilderT builder, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
			//const auto timeout = Timestamp(this->executor->get_time()) + params.taskStartTimeout;

			//auto task
			//    = std::make_shared<UserPollTask>(this->tasks.context, builder, TaskBehavior::SingleExecutionNoRetry(timeout),
			//                                     false, *application, soe_handler, logger, config);

			//this->ScheduleAdhocTask(task);
		}

		public void ScanAllObjects(GroupVariationID gvId, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
			//auto configure
			//    = [gvId](HeaderWriter& writer) -> bool { return writer.WriteHeader(gvId, QualifierCode::ALL_OBJECTS); };
			//this->Scan(configure, soe_handler, config);
		}

		public void ScanClasses(in ClassField field, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
			//auto configure = [field](HeaderWriter& writer) -> bool { return build::WriteClassHeaders(writer, field); };
			//this->Scan(configure, soe_handler, config);
		}

		public void ScanRange(GroupVariationID gvId, ushort start, ushort stop, ISOEHandler soe_handler, TaskConfig config = TaskConfig.Default())
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto configure = [gvId, start, stop](HeaderWriter& writer)->bool
			var configure = (HeaderWriter writer) =>
			{
				return writer.WriteRangeHeader<new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_START_STOP, gvId, start, stop);
			};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this->Scan(configure, soe_handler, config);
			this.Scan(configure, soe_handler, new opendnp3.TaskConfig(config));
		}

		/// ---- Write tasks -----

		public void Write(in TimeAndInterval value, ushort index, TaskConfig config = TaskConfig.Default())
		{
			//auto builder = [value, index](HeaderWriter& writer) -> bool {
			//    return writer.WriteSingleIndexedValue<ser4cpp::UInt16, TimeAndInterval>(QualifierCode::UINT16_CNT_UINT16_INDEX,
			//                                                                            Group50Var4::Inst(), value, index);
			//};

			//const auto timeout = Timestamp(this->executor->get_time()) + params.taskStartTimeout;
			//auto task = std::make_shared<EmptyResponseTask>(this->tasks.context, *this->application, "WRITE TimeAndInterval",
			//                                                FunctionCode::WRITE, builder, timeout, this->logger, config);
			//this->ScheduleAdhocTask(task);
		}

		public void Restart(RestartType op, in RestartOperationCallbackT callback, TaskConfig config = TaskConfig.Default())
		{
			//const auto timeout = Timestamp(this->executor->get_time()) + params.taskStartTimeout;
			//auto task = std::make_shared<RestartOperationTask>(this->tasks.context, *this->application, timeout, op, callback,
			//                                                   this->logger, config);
			//this->ScheduleAdhocTask(task);
		}

		public void PerformFunction(in string name, FunctionCode func, in HeaderBuilderT builder, TaskConfig config = TaskConfig.Default())
		{
			//const auto timeout = Timestamp(this->executor->get_time()) + params.taskStartTimeout;
			//auto task = std::make_shared<EmptyResponseTask>(this->tasks.context, *this->application, name, func, builder,
			//                                                timeout, this->logger, config);
			//this->ScheduleAdhocTask(task);
		}

		/// public state manipulation actions

		public MContext.TaskState ResumeActiveTask()
		{
			APDURequest request = new APDURequest(this.txBuffer.as_wslice());

			/// try to build a requst for the task
			if (!this.activeTask.BuildRequest(request, new AppSeqNum(this.solSeq)))
			{
				activeTask.OnMessageFormatError(new Timestamp());
				this.CompleteActiveTask();
				return TaskState.IDLE;
			}

			this.StartResponseTimer();
			var apdu = request.ToRSeq();
			this.RecordLastRequest(apdu);
			this.Transmit(apdu);

			return TaskState.WAIT_FOR_RESPONSE;
		}

		public void CompleteActiveTask()
		{
			if (this.activeTask != null)
			{
				this.activeTask.reset();
				this.scheduler.CompleteCurrentFor(this);
			}
		}

		public void QueueConfirm(in APDUHeader header)
		{
			this.confirmQueue.AddLast(header);
			this.CheckConfirmTransmit();
		}

		public void StartResponseTimer()
		{
			//auto timeout = [self = shared_from_this()]() { self->OnResponseTimeout(); };
			//this->responseTimer = this->executor->start(this->params.responseTimeout.value, timeout);
		}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		void ProcessAPDU(in APDUResponseHeader header, in RSeq</*size_t*/int> objects);

		public bool CheckConfirmTransmit()
		{
			if (this.isSending || this.confirmQueue.Count == 0)
			{
				return false;
			}

			var confirm = this.confirmQueue.First.Value;
			APDUWrapper wrapper = new APDUWrapper(this.txBuffer.as_wslice());
			wrapper.SetFunction(confirm.function);
			wrapper.SetControl(confirm.control);
			this.Transmit(wrapper.ToRSeq());
			this.confirmQueue.RemoveFirst();
			return true;
		}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		void ProcessResponse(in APDUResponseHeader header, in RSeq</*size_t*/int> objects);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		void ProcessUnsolicitedResponse(in APDUResponseHeader header, in RSeq</*size_t*/int> objects);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		void Transmit(in RSeq</*size_t*/int> data);

		// --- implement  IMasterTaskRunner ------

		private bool Run(IMasterTask task)
		{
			if (this.activeTask != null || this.tstate != TaskState.IDLE)
			{
				return false;
			}

			this.tstate = TaskState.TASK_READY;
			this.activeTask = task;
			this.activeTask.OnStart();
			if (logger.is_enabled(opendnp3.flags.Globals.INFO))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Begining task: %s",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.INFO, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};

			if (!this.isSending)
			{
				this.tstate = this.ResumeActiveTask();
			}

			return true;
		}


		/// ------ private helpers ----------

		private void ScheduleRecurringPollTask(IMasterTask task)
		{
			this.tasks.BindTask(task);

			if (this.isOnline)
			{
				this.scheduler.Add(task, this);
			}
		}

		private void ProcessIIN(in IINField iin)
		{
			if (iin.IsSet(IINBit.DEVICE_RESTART) && !this.@params.ignoreRestartIIN)
			{
				this.tasks.OnRestartDetected();
				this.scheduler.Evaluate();
			}

			if (iin.IsSet(IINBit.EVENT_BUFFER_OVERFLOW) && this.@params.integrityOnEventOverflowIIN)
			{
				if (this.tasks.DemandIntegrity())
				{
					this.scheduler.Evaluate();
				}
			}

			if (iin.IsSet(IINBit.NEED_TIME))
			{
				if (this.tasks.DemandTimeSync())
				{
					this.scheduler.Evaluate();
				}
			}

			if ((iin.IsSet(IINBit.CLASS1_EVENTS) && this.@params.eventScanOnEventsAvailableClassMask.HasClass1()) || (iin.IsSet(IINBit.CLASS2_EVENTS) && this.@params.eventScanOnEventsAvailableClassMask.HasClass2()) || (iin.IsSet(IINBit.CLASS3_EVENTS) && this.@params.eventScanOnEventsAvailableClassMask.HasClass3()))
			{
				if (this.tasks.DemandEventScan())
				{
					this.scheduler.Evaluate();
				}
			}

			this.application.OnReceiveIIN(iin);
		}

		private void OnResponseTimeout()
		{
			if (isOnline)
			{
				this.tstate = this.OnResponseTimeoutEvent();
			}
		}

		protected void ScheduleAdhocTask(IMasterTask task)
		{
			//if (this->isOnline)
			//{
			//    this->scheduler->Add(task, *this);
			//}
			//else
			//{
			//    // can't run this task since we're offline so fail it immediately
			//    task->OnLowerLayerClose(Timestamp(this->executor->get_time()));
			//}
		}

		// state switch lookups


		//// --- State tables ---

		protected MContext.TaskState OnTransmitComplete()
		{
			switch (tstate)
			{
			case (TaskState.TASK_READY):
				return this.ResumeActiveTask();
			default:
				return tstate;
			}
		}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		TaskState OnResponseEvent(in APDUResponseHeader header, in RSeq</*size_t*/int> objects);
		protected MContext.TaskState OnResponseTimeoutEvent()
		{
			switch (tstate)
			{
			case (TaskState.WAIT_FOR_RESPONSE):
				return OnResponseTimeout_WaitForResponse();
			default:
				if (logger.is_enabled(opendnp3.flags.Globals.ERR))
				{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Unexpected response timeout");
				};
				return tstate;
			}
		}

		// --- state handling functions ----

		//// --- State actions ----

		protected MContext.TaskState StartTask_TaskReady()
		{
			if (this.isSending)
			{
				return TaskState.TASK_READY;
			}

			return this.ResumeActiveTask();
		}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//		TaskState OnResponse_WaitForResponse(in APDUResponseHeader header, in RSeq</*size_t*/int> objects);
		protected MContext.TaskState OnResponseTimeout_WaitForResponse()
		{
			if (logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Timeout waiting for response");
			};

			var now = new Timestamp();
			this.activeTask.OnResponseTimeout(now);
			this.solSeq.Increment();
			this.CompleteActiveTask();
			return TaskState.IDLE;
		}
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

namespace opendnp3
{







} // namespace opendnp3
