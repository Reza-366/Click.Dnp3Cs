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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class CommandTaskResult final : public ICommandTaskResult, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class CommandTaskResult : ICommandTaskResult, Uncopyable
{
	public CommandTaskResult(TaskCompletion result, in List<ICommandHeader> vector) : base(result)
	{
		this.m_vector = vector;
	}

	/// --- Implement ICollection<CommandResult> ----


	/// --- Implement ICollection<CommandResult> ----

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual size_t Count() const override
	public override size_t Count()
	{
		size_t count = 0;
		foreach (var header in * m_vector)
		{
			count += header.Count();
		}
		return new size_t(count);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void Foreach(IVisitor<CommandPointResult>& visitor) const override
	public override void Foreach(IVisitor<CommandPointResult> visitor)
	{
		System.UInt32 headerIndex = 0;

		foreach (var header in * m_vector)
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
			var visit = (in CommandState state) =>
			{
				visitor.OnValue(new CommandPointResult(headerIndex, state.index, state.state, state.status));
			};

			header.ForeachItem(visit);
			++headerIndex;
		}
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	CommandTaskResult() = delete;

	private readonly List<ICommandHeader> m_vector;
}

} // namespace opendnp3




