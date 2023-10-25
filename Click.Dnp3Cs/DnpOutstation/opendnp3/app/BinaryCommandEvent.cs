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



namespace opendnp3
{

/**
Maps to Group13Var1/2
*/
public class BinaryCommandEvent
{
	public BinaryCommandEvent()
	{
		this.value = false;
		this.status = new opendnp3.CommandStatus.SUCCESS;
		this.time = new opendnp3.DNPTime(0);
	}

	public BinaryCommandEvent(Flags flags)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this.value = GetValueFromFlags(flags);
		this.value = GetValueFromFlags(new opendnp3.Flags(flags));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this.status = new opendnp3.CommandStatus(GetStatusFromFlags(flags));
		this.status = new opendnp3.CommandStatus(GetStatusFromFlags(new opendnp3.Flags(flags)));
	}

	public BinaryCommandEvent(Flags flags, DNPTime time)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this.value = GetValueFromFlags(flags);
		this.value = GetValueFromFlags(new opendnp3.Flags(flags));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: this.status = new opendnp3.CommandStatus(GetStatusFromFlags(flags));
		this.status = new opendnp3.CommandStatus(GetStatusFromFlags(new opendnp3.Flags(flags)));
		this.time = new opendnp3.DNPTime(time);
	}

	public BinaryCommandEvent(bool value, CommandStatus status)
	{
		this.value = value;
		this.status = new opendnp3.CommandStatus(status);
	}

	public BinaryCommandEvent(bool value, CommandStatus status, DNPTime time)
	{
		this.value = value;
		this.status = new opendnp3.CommandStatus(status);
		this.time = new opendnp3.DNPTime(time);
	}

	public bool value;
	public CommandStatus status;
	public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Flags GetFlags() const
	public Flags GetFlags()
	{
		return new Flags(((byte)value << 7) | (CommandStatusSpec.to_type(status)));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const BinaryCommandEvent& rhs) const
	public static bool operator == (BinaryCommandEvent ImpliedObject, in BinaryCommandEvent rhs)
	{
		return ImpliedObject.value == rhs.value && ImpliedObject.status == rhs.status && ImpliedObject.time == rhs.time;
	}

	private const byte ValueMask = 0x80;
	private const byte StatusMask = 0x7F;

	private static bool GetValueFromFlags(Flags flags)
	{
		return (flags.value & ValueMask) == ValueMask;
	}

	private static CommandStatus GetStatusFromFlags(Flags flags)
	{
		return CommandStatusSpec.from_type(new byte(flags.value & StatusMask));
	}
}

} // namespace opendnp3



