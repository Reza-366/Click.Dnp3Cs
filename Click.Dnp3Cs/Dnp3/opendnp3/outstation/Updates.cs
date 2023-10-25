﻿/*
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

public delegate void update_func_t(IUpdateHandler UnnamedParameter);

public class Updates
{
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class UpdateBuilder;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: void Apply(IUpdateHandler& handler) const
	public void Apply(IUpdateHandler handler)
	{
		if (updates == null)
		{
			return;
		}

		foreach (var update in * updates)
		{
			update(handler);
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsEmpty() const
	public bool IsEmpty()
	{
		return updates != null ? updates.empty() : true;
	}

	private Updates(shared_updates_t updates)
	{
		this.updates = std::move(updates);
	}

	private readonly shared_updates_t updates;
}

} // namespace opendnp3
