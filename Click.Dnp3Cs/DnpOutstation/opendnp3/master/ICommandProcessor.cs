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


namespace opendnp3
{

/**
 * Interface used to dispatch SELECT / OPERATE / DIRECT OPERATE from application code to a master
 */
public abstract class ICommandProcessor
{
	/**
	 * Select and operate a set of commands
	 *
	 * @param commands Set of command headers
	 * @param callback callback that will be invoked upon completion or failure
	 * @param config optional configuration that controls normal callbacks and allows the user to be specified for SA
	 */
//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public abstract void SelectAndOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config = TaskConfig.Default());

	/**
	 * Direct operate a set of commands
	 *
	 * @param commands Set of command headers
	 * @param callback callback that will be invoked upon completion or failure
	 * @param config optional configuration that controls normal callbacks and allows the user to be specified for SA
	 */
//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public abstract void DirectOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config = TaskConfig.Default());

	/**
	 * Select/operate a single command
	 *
	 * @param command Command to operate
	 * @param index of the command
	 * @param callback callback that will be invoked upon completion or failure
	 * @param config optional configuration that controls normal callbacks and allows the user to be specified for SA
	 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public void SelectAndOperate<T>(in T command, ushort index, in CommandResultCallbackT callback, in TaskConfig config = TaskConfig.Default())
	{
		CommandSet commands = new CommandSet({opendnp3.Globals.WithIndex(command, new ushort(index))});
		this.SelectAndOperate(std::move(commands), callback, config);
	}

	/**
	 * Direct operate a single command
	 *
	 * @param command Command to operate
	 * @param index of the command
	 * @param callback callback that will be invoked upon completion or failure
	 * @param config optional configuration that controls normal callbacks and allows the user to be specified for SA
	 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public void DirectOperate<T>(in T command, ushort index, in CommandResultCallbackT callback, in TaskConfig config = TaskConfig.Default())
	{
		CommandSet commands = new CommandSet({opendnp3.Globals.WithIndex(command, new ushort(index))});
		this.DirectOperate(std::move(commands), callback, config);
	}
}

} // namespace opendnp3

