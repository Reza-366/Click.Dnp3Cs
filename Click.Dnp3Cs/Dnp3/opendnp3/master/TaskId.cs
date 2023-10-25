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
 * Interface that represents a running master.
 */
public class TaskId
{
	public static TaskId Defined(int id)
	{
		return new TaskId(id, true);
	}
	public static TaskId Undefined()
	{
		return new TaskId(-1, false);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: int GetId() const
	public int GetId()
	{
		return id;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsDefined() const
	public bool IsDefined()
	{
		return isDefined;
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	TaskId() = delete;

	private TaskId(int id_, bool isDefined_)
	{
		this.id = id_;
		this.isDefined = isDefined_;
	}

	private int id;
	private bool isDefined;
}

} // namespace opendnp3

