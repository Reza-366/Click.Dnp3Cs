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

///
/// Represent all of the mutable state in an outstation
///
public class OContext : IUpperLayer
{
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class StateIdle;
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class StateSolicitedConfirmWait;
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class StateUnsolicitedConfirmWait;
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class StateNullUnsolicitedConfirmWait;

	public OContext(in Addresses addresses, in OutstationConfig config, in DatabaseConfig db_config, in Logger logger, ILowerLayer lower, ICommandHandler commandHandler, IOutstationApplication application)
	{
		this.addresses = new opendnp3.Addresses(addresses);
		this.logger = new opendnp3.Logger(logger);
		this.lower = std::move(lower);
		this.commandHandler = std::move(commandHandler);
		this.application = std::move(application);
		this.eventBuffer = new opendnp3.EventBuffer(config.eventBufferConfig);
		this.database = new opendnp3.Database(db_config, eventBuffer, this.application, config.@params.typesAllowedInClass0);
		this.rspContext = new opendnp3.ResponseContext(database, eventBuffer);
		this.@params = new opendnp3.OutstationParams(config.@params);
		this.isOnline = false;
		this.isTransmitting = false;
		this.staticIIN = new opendnp3.IINField(IINBit.DEVICE_RESTART);
		this.deferred = new opendnp3.DeferredRequest(config.@params.maxRxFragSize);
		this.sol = new opendnp3.OutstationSolState(config.@params.maxTxFragSize);
		this.unsol = new opendnp3.OutstationUnsolState(config.@params.maxTxFragSize);
		this.unsolRetries = new opendnp3.NumRetries(config.@params.numUnsolRetries);
		this.shouldCheckForUnsolicited = false;
	}

	/// ----- Implement IUpperLayer ------

	public override bool OnLowerLayerUp()
	{
		if (isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "already online");
			};
			return false;
		}

		isOnline = true;
		this.shouldCheckForUnsolicited = true;
		this.CheckForTaskStart();
		return true;
	//	return true;
	}

	public override bool OnLowerLayerDown()
	{
		if (!isOnline)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "already offline");
			};
			return false;
		}

		this.state = StateIdle.Inst();

		isOnline = false;
		isTransmitting = false;

		sol.Reset();
		unsol.Reset();
		history.Reset();
		deferred.Reset();
		eventBuffer.Unselect();
		rspContext.Reset();
		//confirmTimer.cancel();

		return true;
	//	return true;
	}

	public override bool OnTxReady()
	{
		if (!isOnline || !isTransmitting)
		{
			return false;
		}

		this.isTransmitting = false;
		this.CheckForTaskStart();
		return true;
	//	return true;
	}

	public override bool OnReceive(in Message message)
	{
		if (!this.isOnline)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.ERR))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "ignoring received data while offline");
			};
			return false;
		}

		this.ProcessMessage(message);

		this.CheckForTaskStart();

		return true;
	//	return true;
	}

	/// --- Other public members ----

	public void HandleNewEvents()
	{
		this.shouldCheckForUnsolicited = true;
		this.CheckForTaskStart();
	}

	public IUpdateHandler GetUpdateHandler()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->database;
		return new opendnp3.Database(this.database);
	}

	public void SetRestartIIN()
	{
		this.staticIIN.SetBit(IINBit.DEVICE_RESTART);
	}

	/// ---- Helper functions that operate on the current state, and may return a new state ----

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	OutstationState ContinueMultiFragResponse(in Addresses addresses, in AppSeqNum seq);

	private OutstationState RespondToReadRequest(in ParsedRequest request)
	{
		this.history.RecordLastProcessedRequest(request.header, request.objects);

		var response = this.sol.tx.Start();
		var writer = response.GetWriter();
		response.SetFunction(FunctionCode.RESPONSE);
		var result = this.HandleRead(request.objects, writer);
		result.second.SEQ = request.header.control.SEQ;
		response.SetControl(result.second);
		response.SetIIN(result.first | this.GetResponseIIN());

		return this.BeginResponseTx(new ushort(request.addresses.source), response);
	}

	private OutstationState ProcessNewRequest(in ParsedRequest request)
	{
		this.sol.seq.num = request.header.control.SEQ;

		if (request.header.function == FunctionCode.READ)
		{
			return this.state.OnNewReadRequest(this, request);
		}

		return this.state.OnNewNonReadRequest(this, request);
	}

	private OutstationState OnReceiveSolRequest(in ParsedRequest request)
	{
		// analyze this request to see how it compares to the last request
		if (this.history.HasLastRequest())
		{
			if (this.sol.seq.num.Equals(request.header.control.SEQ))
			{
				if (this.history.FullyEqualsLastRequest(request.header, request.objects))
				{
					if (request.header.function == FunctionCode.READ)
					{
						return this.state.OnRepeatReadRequest(this, request);
					}

					return this.state.OnRepeatNonReadRequest(this, request);
				}
				else // new operation with same SEQ
				{
					return this.ProcessNewRequest(request);
				}
			}
			else // completely new sequence #
			{
				return this.ProcessNewRequest(request);
			}
		}
		else
		{
			return this.ProcessNewRequest(request);
		}
	}

	private OutstationState RespondToNonReadRequest(in ParsedRequest request)
	{
		this.history.RecordLastProcessedRequest(request.header, request.objects);

		var response = this.sol.tx.Start();
		var writer = response.GetWriter();
		response.SetFunction(FunctionCode.RESPONSE);
		response.SetControl(new AppControlField(true, true, false, false, request.header.control.SEQ));
		var iin = this.HandleNonReadResponse(request.header, request.objects, writer);
		response.SetIIN(iin | this.GetResponseIIN());
		return this.BeginResponseTx(new ushort(request.addresses.source), response);
	}

	// ---- Processing functions --------

	private bool ProcessMessage(in Message message)
	{
		// is the message addressed to this outstation
		if (message.addresses.destination != this.addresses.source && !message.addresses.IsBroadcast())
		{
			return false;
		}

		// is the message coming from the expected master?
		if (!this.@params.respondToAnyMaster && (message.addresses.source != this.addresses.destination))
		{
			return false;
		}

		if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEX_RX))
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: opendnp3::HexLogging::log(this->logger, flags::APP_HEX_RX, message.payload, ' ', 18, 18);
			opendnp3.HexLogging.log(this.logger, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_HEX_RX), message.payload, ' ', 18, 18);
		};

		if (message.addresses.IsBroadcast())
		{
			UpdateLastBroadcastMessageReceived(new ushort(message.addresses.destination));
		}

		var result = APDUHeaderParser.ParseRequest(message.payload, this.logger);
		if (!result.success)
		{
			return false;
		}

		logging.LogHeader(this.logger, opendnp3.flags.Globals.APP_HEADER_RX, result.header);

		if (!result.header.control.IsFirAndFin())
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Ignoring fragment. Requests must have FIR/FIN == 1");
			};
			return false;
		}

		if (result.header.control.CON)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Ignoring fragment. Requests cannot request confirmation");
			};
			return false;
		}

		return this.ProcessObjects(new ParsedRequest(message.addresses, result.header, result.objects));
	}

	private bool ProcessObjects(in ParsedRequest request)
	{
		if (request.addresses.IsBroadcast())
		{
			this.state = this.state.OnBroadcastMessage(this, request);
			return true;
		}

		if (Functions.IsNoAckFuncCode(request.header.function))
		{
			// this is the only request we process while we are transmitting
			// because it doesn't require a response of any kind
			return this.ProcessRequestNoAck(request);
		}

		if (this.isTransmitting)
		{
			this.deferred.Set(request);
			return true;
		}

		if (request.header.function == FunctionCode.CONFIRM)
		{
			return this.ProcessConfirm(request);
		}

		return this.ProcessRequest(request);
	}

	private bool ProcessRequest(in ParsedRequest request)
	{
		if (request.header.control.UNS)
		{
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Ignoring unsol with invalid function code: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return false;
		}

		this.state = this.OnReceiveSolRequest(request);
		return true;
	}


	//// ----------------------------- function handlers -----------------------------

	private bool ProcessBroadcastRequest(in ParsedRequest request)
	{
		switch (request.header.function)
		{
		case (FunctionCode.WRITE):
			this.HandleWrite(request.objects);
			return true;
		case (FunctionCode.DIRECT_OPERATE_NR):
			this.HandleDirectOperate(request.objects, OperateType.DirectOperateNoAck, null);
			return true;
		case (FunctionCode.IMMED_FREEZE_NR):
			this.HandleFreeze(request.objects);
			return true;
		case (FunctionCode.FREEZE_CLEAR_NR):
			this.HandleFreezeAndClear(request.objects);
			return true;
		case (FunctionCode.ASSIGN_CLASS):
		{
			if (this.application.SupportsAssignClass())
			{
				this.HandleAssignClass(request.objects);
				return true;
			}
			else
			{
				return false;
			}
		}
//C++ TO C# CONVERTER TASK: C# does not allow fall-through from a non-empty 'case':
		case (FunctionCode.RECORD_CURRENT_TIME):
		{
			if (request.objects.is_not_empty())
			{
				this.HandleRecordCurrentTime();
				return true;
			}
			else
			{
				return false;
			}
		}
//C++ TO C# CONVERTER TASK: C# does not allow fall-through from a non-empty 'case':
		case (FunctionCode.DISABLE_UNSOLICITED):
		{
			if (this.@params.allowUnsolicited)
			{
				this.HandleDisableUnsolicited(request.objects, null);
				return true;
			}
			else
			{
				return false;
			}
		}
//C++ TO C# CONVERTER TASK: C# does not allow fall-through from a non-empty 'case':
		case (FunctionCode.ENABLE_UNSOLICITED):
		{
			if (this.@params.allowUnsolicited)
			{
				this.HandleEnableUnsolicited(request.objects, null);
				return true;
			}
			else
			{
				return false;
			}
		}
//C++ TO C# CONVERTER TASK: C# does not allow fall-through from a non-empty 'case':
		default:
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Ignoring broadcast on function code: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return false;
		}
	}

	private bool ProcessRequestNoAck(in ParsedRequest request)
	{
		switch (request.header.function)
		{
		case (FunctionCode.DIRECT_OPERATE_NR):
			this.HandleDirectOperate(request.objects, OperateType.DirectOperateNoAck, null); // no object writer, this is a no ack code
			return true;
		case (FunctionCode.IMMED_FREEZE_NR):
			this.HandleFreeze(request.objects);
			return true;
		case (FunctionCode.FREEZE_CLEAR_NR):
			this.HandleFreezeAndClear(request.objects);
			return true;
		default:
			if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Ignoring NR function code: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return false;
		}
	}

	private bool ProcessConfirm(in ParsedRequest request)
	{
		this.state = this.state.OnConfirm(this, request);
		return true;
	}

	// ---- common helper methods ----

	private OutstationState BeginResponseTx(ushort destination, APDUResponse response)
	{
		CheckForBroadcastConfirmation(response);

		var data = response.ToRSeq();
		this.sol.tx.Record(response.GetControl(), data);
		this.sol.seq.confirmNum = response.GetControl().SEQ;
		this.BeginTx(new ushort(destination), data);

		if (response.GetControl().CON)
		{
			this.RestartSolConfirmTimer();
			return StateSolicitedConfirmWait.Inst();
		}

		return StateIdle.Inst();
	}

	private void BeginRetransmitLastResponse(ushort destination)
	{
		this.BeginTx(new ushort(destination), this.sol.tx.GetLastResponse());
	}

	private void BeginRetransmitLastUnsolicitedResponse()
	{
		this.BeginTx(new ushort(this.addresses.destination), this.unsol.tx.GetLastResponse());
	}

	private void BeginUnsolTx(APDUResponse response)
	{
		CheckForBroadcastConfirmation(response);

		var data = response.ToRSeq();
		this.unsol.tx.Record(response.GetControl(), data);
		this.unsol.seq.confirmNum = this.unsol.seq.num;
		this.unsol.seq.num.Increment();
		this.BeginTx(new ushort(this.addresses.destination), data);
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void BeginTx(ushort destination, in RSeq/*<size_t>*/ message);

	private void CheckForTaskStart()
	{
		// do these checks in order of priority
		this.CheckForDeferredRequest();
		this.CheckForUnsolicitedNull();
		if (this.shouldCheckForUnsolicited)
		{
			this.CheckForUnsolicited();
		}
	}

	private void CheckForDeferredRequest()
	{
		if (this.CanTransmit() && this.deferred.IsSet())
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto handler = [this](const ParsedRequest& request)
			var handler = (in ParsedRequest request) =>
			{
				return this.ProcessDeferredRequest(request);
			};
			this.deferred.Process(handler);
		}
	}

	private void CheckForUnsolicitedNull()
	{
		if (this.CanTransmit() && this.state.IsIdle() && this.@params.allowUnsolicited)
		{
			if (this.unsol.completedNull == 0)
			{
				// send a NULL unsolcited message
				var response = this.unsol.tx.Start();
				build.NullUnsolicited(response, this.unsol.seq.num, this.GetResponseIIN());
				this.RestartUnsolConfirmTimer();
				this.state = this.@params.noDefferedReadDuringUnsolicitedNullResponse ? StateNullUnsolicitedConfirmWait.Inst() : StateUnsolicitedConfirmWait.Inst();
				this.BeginUnsolTx(response);
			}
		}
	}

	private void CheckForUnsolicited()
	{
		if (this.shouldCheckForUnsolicited && this.CanTransmit() && this.state.IsIdle() && this.@params.allowUnsolicited)
		{
			this.shouldCheckForUnsolicited = false;

			if (this.unsol.completedNull != 0)
			{
				// are there events to be reported?
				if (this.@params.unsolClassMask.Intersects(this.eventBuffer.UnwrittenClassField()))
				{

					var response = this.unsol.tx.Start();
					var writer = response.GetWriter();

					this.unsolRetries.Reset();
					this.eventBuffer.Unselect();
					this.eventBuffer.SelectAllByClass(this.@params.unsolClassMask);
					this.eventBuffer.Load(writer);

					build.NullUnsolicited(response, this.unsol.seq.num, this.GetResponseIIN());
					this.RestartUnsolConfirmTimer();
					this.state = StateUnsolicitedConfirmWait.Inst();
					this.BeginUnsolTx(response);
				}
			}
		}
	}

	private bool ProcessDeferredRequest(in ParsedRequest request)
	{
		if (request.header.function == FunctionCode.CONFIRM)
		{
			this.ProcessConfirm(request);
			return true;
		}

		if (request.header.function == FunctionCode.READ)
		{
			if (this.state.IsIdle())
			{
				this.ProcessRequest(request);
				return true;
			}

			return false;
		}
		else
		{
			this.ProcessRequest(request);
			return true;
		}
	}

	private void RestartSolConfirmTimer()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var timeout = () =>
		{
			this.state = this.state.OnConfirmTimeout(this);
			this.CheckForTaskStart();
		};

		//this->confirmTimer.cancel();
		//this->confirmTimer = this->executor->start(this->params.solConfirmTimeout.value, timeout);
	}

	private void RestartUnsolConfirmTimer()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var timeout = () =>
		{
			this.state = this.state.OnConfirmTimeout(this);
			this.CheckForTaskStart();
		};

	 //   this->confirmTimer.cancel();
		//this->confirmTimer = this->executor->start(this->params.unsolConfirmTimeout.value, timeout);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool CanTransmit() const
	private bool CanTransmit()
	{
		return isOnline && !isTransmitting;
	}

	private IINField GetResponseIIN()
	{
		return this.staticIIN | this.GetDynamicIIN() | this.application.GetApplicationIIN().ToIIN();
	}

	private IINField GetDynamicIIN()
	{
		var classField = this.eventBuffer.UnwrittenClassField();

		IINField ret = new IINField();
		ret.SetBitToValue(IINBit.CLASS1_EVENTS, classField.HasClass1());
		ret.SetBitToValue(IINBit.CLASS2_EVENTS, classField.HasClass2());
		ret.SetBitToValue(IINBit.CLASS3_EVENTS, classField.HasClass3());
		ret.SetBitToValue(IINBit.EVENT_BUFFER_OVERFLOW, this.eventBuffer.IsOverflown());

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.IINField(ret);
	}

	private void UpdateLastBroadcastMessageReceived(ushort destination)
	{
		switch (destination)
		{
		case LinkBroadcastAddress.DontConfirm:
			lastBroadcastMessageReceived.set(LinkBroadcastAddress.DontConfirm);
			break;
		case LinkBroadcastAddress.ShallConfirm:
			lastBroadcastMessageReceived.set(LinkBroadcastAddress.ShallConfirm);
			break;
		case LinkBroadcastAddress.OptionalConfirm:
			lastBroadcastMessageReceived.set(LinkBroadcastAddress.OptionalConfirm);
			break;
		default:
			lastBroadcastMessageReceived.clear();
			break;
		}
	}

	private void CheckForBroadcastConfirmation(APDUResponse response)
	{
		if (lastBroadcastMessageReceived.is_set())
		{
			response.SetIIN(response.GetIIN() | new IINField(IINBit.BROADCAST));

			if (lastBroadcastMessageReceived.get() != LinkBroadcastAddress.ShallConfirm)
			{
				lastBroadcastMessageReceived.clear();
			}
			else
			{
				// The broadcast address requested a confirmation
				var control = response.GetControl();
				control.CON = true;
				response.SetControl(control);
			}
		}
	}

	/// --- methods for handling app-layer functions ---

	/// Handles non-read function codes that require a response. builds the response using the supplied writer.
	/// @return An IIN field indicating the validity of the request, and to be returned in the response.
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleNonReadResponse(in APDUHeader header, in RSeq/*<size_t>*/ objects, HeaderWriter writer);

	/// Handles read function codes. May trigger an unsolicited response
	/// @return an IIN field and a partial AppControlField (missing sequence info)
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	ser4cpp::Pair<IINField, AppControlField> HandleRead(in RSeq/*<size_t>*/ objects, HeaderWriter writer);

	// ------ Function Handlers ------

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleWrite(in RSeq/*<size_t>*/ objects);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleSelect(in RSeq/*<size_t>*/ objects, HeaderWriter writer);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleOperate(in RSeq/*<size_t>*/ objects, HeaderWriter writer);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleDirectOperate(in RSeq/*<size_t>*/ objects, OperateType opType, HeaderWriter pWriter);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleDelayMeasure(in RSeq/*<size_t>*/ objects, HeaderWriter writer);
	private IINField HandleRecordCurrentTime()
	{
		this.time.RecordCurrentTime(this.sol.seq.num, new Timestamp());
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleRestart(in RSeq/*<size_t>*/ objects, bool isWarmRestart, HeaderWriter pWriter);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleAssignClass(in RSeq/*<size_t>*/ objects);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleDisableUnsolicited(in RSeq/*<size_t>*/ objects, HeaderWriter writer);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleEnableUnsolicited(in RSeq/*<size_t>*/ objects, HeaderWriter writer);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleCommandWithConstant(in RSeq/*<size_t>*/ objects, HeaderWriter writer, CommandStatus status);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleFreeze(in RSeq/*<size_t>*/ objects);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField HandleFreezeAndClear(in RSeq/*<size_t>*/ objects);

	// ------ resources --------
	private readonly Addresses addresses = new Addresses();
	private Logger logger = new Logger();
	//const std::shared_ptr<exe4cpp::IExecutor> executor;
	private readonly ILowerLayer lower;
	private readonly ICommandHandler commandHandler;
	private readonly IOutstationApplication application;

	// ------ Database, event buffer, and response tracking
	private EventBuffer eventBuffer = new EventBuffer();
	private Database database = new Database();
	private ResponseContext rspContext = new ResponseContext();

	// ------ Static configuration -------
	private OutstationParams @params = new OutstationParams();

	// ------ Shared dynamic state --------
	private bool isOnline;
	private bool isTransmitting;
	private IINField staticIIN = new IINField();
	//exe4cpp::Timer confirmTimer; //REZA
	private RequestHistory history = new RequestHistory();
	private DeferredRequest deferred = new DeferredRequest();

	// ------ Dynamic state related to controls ------
	private ControlState control = new ControlState();

	// ------ Dynamic state related to time synchronization ------
	private TimeSyncState time = new TimeSyncState();

	// ------ Dynamic state related to solicited and unsolicited modes ------
	private OutstationSolState sol = new OutstationSolState();
	private OutstationUnsolState unsol = new OutstationUnsolState();
	private NumRetries unsolRetries = new NumRetries();
	private bool shouldCheckForUnsolicited;
	private OutstationState state = StateIdle.Inst();

	// ------ Dynamic state related to broadcast messages ------
	private ser4cpp.Settable<LinkBroadcastAddress> lastBroadcastMessageReceived = new ser4cpp.Settable<LinkBroadcastAddress>();
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
