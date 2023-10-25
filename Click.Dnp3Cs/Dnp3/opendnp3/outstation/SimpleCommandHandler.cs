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

/**
 * Mock ICommandHandler used for examples and demos
 */
public class SimpleCommandHandler : ICommandHandler
{
	/**
	 * @param status The status value to return in response to all commands
	 */
	public SimpleCommandHandler(CommandStatus status)
	{
		this.status = new opendnp3.CommandStatus(status);
		this.numOperate = 0;
		this.numSelect = 0;
		this.numStart = 0;
		this.numEnd = 0;
	}

	public override void Begin()
	{
		++numStart;
	}

	public override void End()
	{
		++numEnd;
	}

	public override CommandStatus Select(in ControlRelayOutputBlock command, UInt16 index)
	{
		this.DoSelect(command, new UInt16(index));
		++numSelect;
		return status;
	}

	public override CommandStatus Operate(in ControlRelayOutputBlock command, UInt16 index, IUpdateHandler handler, OperateType opType)
	{
		this.DoOperate(command, new UInt16(index), opType);
		++numOperate;
		return status;
	}

	public override CommandStatus Select(in AnalogOutputInt16 command, UInt16 index)
	{
		this.DoSelect(command, new UInt16(index));
		++numSelect;
		return status;
	}

	public override CommandStatus Operate(in AnalogOutputInt16 command, UInt16 index, IUpdateHandler handler, OperateType opType)
	{
		this.DoOperate(command, new UInt16(index), opType);
		++numOperate;
		return status;
	}

	public override CommandStatus Select(in AnalogOutputInt32 command, UInt16 index)
	{
		this.DoSelect(command, new UInt16(index));
		++numSelect;
		return status;
	}

	public override CommandStatus Operate(in AnalogOutputInt32 command, UInt16 index, IUpdateHandler handler, OperateType opType)
	{
		this.DoOperate(command, new UInt16(index), opType);
		++numOperate;
		return status;
	}

	public override CommandStatus Select(in AnalogOutputFloat32 command, UInt16 index)
	{
		this.DoSelect(command, new UInt16(index));
		++numSelect;
		return status;
	}

	public override CommandStatus Operate(in AnalogOutputFloat32 command, UInt16 index, IUpdateHandler handler, OperateType opType)
	{
		this.DoOperate(command, new UInt16(index), opType);
		++numOperate;
		return status;
	}

	public override CommandStatus Select(in AnalogOutputDouble64 command, UInt16 index)
	{
		this.DoSelect(command, new UInt16(index));
		++numSelect;
		return status;
	}

	public override CommandStatus Operate(in AnalogOutputDouble64 command, UInt16 index, IUpdateHandler handler, OperateType opType)
	{
		this.DoOperate(command, new UInt16(index), opType);
		++numOperate;
		return status;
	}

	protected virtual void DoSelect(in ControlRelayOutputBlock command, UInt16 index)
	{
	}
	protected virtual void DoOperate(in ControlRelayOutputBlock command, UInt16 index, OperateType opType)
	{
	}

	protected virtual void DoSelect(in AnalogOutputInt16 command, UInt16 index)
	{
	}
	protected virtual void DoOperate(in AnalogOutputInt16 command, UInt16 index, OperateType opType)
	{
	}

	protected virtual void DoSelect(in AnalogOutputInt32 command, UInt16 index)
	{
	}
	protected virtual void DoOperate(in AnalogOutputInt32 command, UInt16 index, OperateType opType)
	{
	}

	protected virtual void DoSelect(in AnalogOutputFloat32 command, UInt16 index)
	{
	}
	protected virtual void DoOperate(in AnalogOutputFloat32 command, UInt16 index, OperateType opType)
	{
	}

	protected virtual void DoSelect(in AnalogOutputDouble64 command, UInt16 index)
	{
	}
	protected virtual void DoOperate(in AnalogOutputDouble64 command, UInt16 index, OperateType opType)
	{
	}

	protected CommandStatus status;

	public System.UInt32 numOperate = new System.UInt32();
	public System.UInt32 numSelect = new System.UInt32();
	public System.UInt32 numStart = new System.UInt32();
	public System.UInt32 numEnd = new System.UInt32();
}

/**
 * A singleton command handler that always returns success
 */
public class SuccessCommandHandler : SimpleCommandHandler
{
	public static ICommandHandler Create()
	{
		return new SuccessCommandHandler();
	}

	public SuccessCommandHandler() : base(CommandStatus.SUCCESS)
	{
	}
}

} // namespace opendnp3



