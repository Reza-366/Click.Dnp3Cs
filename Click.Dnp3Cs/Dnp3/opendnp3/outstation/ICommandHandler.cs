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
 * Interface used to dispatch SELECT / OPERATE / DIRECT OPERATE (Binary/Analog output) from the outstation to
 * application code.
 *
 * The ITransactable sub-interface is used to determine the start and end of an ASDU containing commands.
 */
public abstract class ICommandHandler : System.IDisposable
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	virtual ~ICommandHandler() = default;

	/**
	 * called when a command APDU begins processing
	 */
	public abstract void Begin();

	/**
	 * called when a command APDU ends processing
	 */
	public abstract void End();

	/**
	 * Ask if the application supports a ControlRelayOutputBlock - group 12 variation 1
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @return result of request
	 */
	public abstract CommandStatus Select(in ControlRelayOutputBlock command, UInt16 index);

	/**
	 * Operate a ControlRelayOutputBlock - group 12 variation 1
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @param handler interface for loading measurement changes
	 * @param opType the operation type the outstation received.
	 * @return result of request
	 */
	public abstract CommandStatus Operate(in ControlRelayOutputBlock command, UInt16 index, IUpdateHandler handler, OperateType opType);

	/**
	 * Ask if the application supports a 16 bit analog output - group 41 variation 2
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @return result of request
	 */
	public abstract CommandStatus Select(in AnalogOutputInt16 command, UInt16 index);

	/**
	 * Ask if the application supports a 16 bit analog output - group 41 variation 2
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @param handler interface for loading measurement changes
	 * @param opType the operation type the outstation received.
	 * @return result of request
	 */
	public abstract CommandStatus Operate(in AnalogOutputInt16 command, UInt16 index, IUpdateHandler handler, OperateType opType);

	/**
	 * Ask if the application supports a 32 bit analog output - group 41 variation 1
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @return result of request
	 */
	public abstract CommandStatus Select(in AnalogOutputInt32 command, UInt16 index);

	/**
	 * Operate a 32 bit analog output - group 41 variation 1
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @param handler interface for loading measurement changes
	 * @param opType the operation type the outstation received.
	 * @return result of request
	 */
	public abstract CommandStatus Operate(in AnalogOutputInt32 command, UInt16 index, IUpdateHandler handler, OperateType opType);

	/**
	 * Ask if the application supports a single precision, floating point analog output - group 41 variation 3
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @return result of request
	 */
	public abstract CommandStatus Select(in AnalogOutputFloat32 command, UInt16 index);

	/**
	 * Operate a single precision, floating point analog output - group 41 variation 3
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @param handler interface for loading measurement changes
	 * @param opType the operation type the outstation received.
	 * @return result of request
	 */
	public abstract CommandStatus Operate(in AnalogOutputFloat32 command, UInt16 index, IUpdateHandler handler, OperateType opType);

	/**
	 * Ask if the application supports a double precision, floating point analog output - group 41 variation 4
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @return result of request
	 */
	public abstract CommandStatus Select(in AnalogOutputDouble64 command, UInt16 index);

	/**
	 * Operate a double precision, floating point analog output - group 41 variation 4
	 *
	 * @param command command to operate
	 * @param index index of the command
	 * @param handler interface for loading measurement changes
	 * @param opType the operation type the outstation received.
	 * @return result of request
	 */
	public abstract CommandStatus Operate(in AnalogOutputDouble64 command, UInt16 index, IUpdateHandler handler, OperateType opType);
}

} // namespace opendnp3

