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
 * Interface used to dispatch an abstract action using a command
 */
public sealed class CommandActionAdapter : ICommandAction
{

	public CommandActionAdapter(ICommandHandler handler, bool is_select, IUpdateHandler updates, OperateType op_type)
	{
		this.handler = new opendnp3.ICommandHandler(handler);
		this.is_select = is_select;
		this.updates = new opendnp3.IUpdateHandler(updates);
		this.op_type = new opendnp3.OperateType(op_type);
	}

	public new void Dispose()
	{
		if (this.is_started)
		{
			handler.End();
		}
		base.Dispose();
	}

	public override CommandStatus Action(in ControlRelayOutputBlock command, UInt16 index)
	{
		if (command.IsQUFlagSet())
		{
			return CommandStatus.NOT_SUPPORTED;
		}

		return this.ActionT(command, new UInt16(index));
	}

	public override CommandStatus Action(in AnalogOutputInt16 command, UInt16 index)
	{
		return this.ActionT(command, new UInt16(index));
	}

	public override CommandStatus Action(in AnalogOutputInt32 command, UInt16 index)
	{
		return this.ActionT(command, new UInt16(index));
	}

	public override CommandStatus Action(in AnalogOutputFloat32 command, UInt16 index)
	{
		return this.ActionT(command, new UInt16(index));
	}

	public override CommandStatus Action(in AnalogOutputDouble64 command, UInt16 index)
	{
		return this.ActionT(command, new UInt16(index));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private CommandStatus ActionT<T>(in T command, UInt16 index)
	{
		this.CheckStart();
		return is_select ? this.handler.Select(command, index) : this.handler.Operate(command, index, this.updates, this.op_type);
	}

	private void CheckStart()
	{
		if (!this.is_started)
		{
			this.is_started = true;
			handler.Begin();
		}
	}

	private bool is_started = false;

	private ICommandHandler handler;
	private bool is_select;
	private IUpdateHandler updates;
	private OperateType op_type;
}

} // namespace opendnp3



