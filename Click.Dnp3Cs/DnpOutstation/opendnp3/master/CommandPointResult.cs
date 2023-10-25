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

/// Represents the result of a command operation on a particular point
public class CommandPointResult
{

	/// Fully construct based on all members
	public CommandPointResult(uint headerIndex_, ushort index_, CommandPointState state_, CommandStatus status_)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.headerIndex = headerIndex_;
		this.headerIndex.CopyFrom(headerIndex_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.index = index_;
		this.index.CopyFrom(index_);
		this.state = new opendnp3.CommandPointState(state_);
		this.status = new opendnp3.CommandStatus(status_);
	}

	/// Check the result for equality against another value
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Equals(const CommandPointResult& other) const
	public bool Equals(in CommandPointResult other)
	{
		return (headerIndex == other.headerIndex) && (index == other.index) && (state == other.state) && (status == other.status);
	}

	/// The index of the header when request was made (0-based)
	public uint headerIndex = new uint();

	/// The index of the command that was requested
	public ushort index = new ushort();

	/// The final state of the command operation on this point
	public CommandPointState state;

	/// The response value. This is only valid if state == SUCCESS or state == SELECT_FAIL
	public CommandStatus status;
}

} // namespace opendnp3

