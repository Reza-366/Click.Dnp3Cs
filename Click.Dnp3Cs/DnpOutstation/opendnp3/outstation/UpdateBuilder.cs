using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

public sealed class UpdateBuilder : IUpdateHandler
{

	public override bool Update(in Binary meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool Update(in DoubleBitBinary meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool Update(in Analog meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool Update(in Counter meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool FreezeCounter(ushort index, bool clear, EventMode mode = EventMode.Detect)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: this->Add([=](IUpdateHandler& handler)
		this.Add((IUpdateHandler handler) =>
		{
			handler.FreezeCounter(new ushort(index), clear, mode);
		});
		return true;
	}

	public override bool Update(in BinaryOutputStatus meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool Update(in AnalogOutputStatus meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool Update(in OctetString meas, ushort index, EventMode mode = EventMode.Detect)
	{
		return this.AddMeas(meas, new ushort(index), mode);
	}

	public override bool Update(in TimeAndInterval meas, ushort index)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: return this->Add([=](IUpdateHandler& handler)
		return this.Add((IUpdateHandler handler) =>
		{
			handler.Update(meas, new ushort(index));
		});
	}

	public override bool Modify(FlagsType type, ushort start, ushort stop, byte flags)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: return this->Add([=](IUpdateHandler& handler)
		return this.Add((IUpdateHandler handler) =>
		{
			handler.Modify(type, new ushort(start), new ushort(stop), new byte(flags));
		});
	}

	public Updates Build()
	{
		return new Updates(std::move(this.updates));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private bool AddMeas<T>(in T meas, ushort index, EventMode mode)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: return this->Add([=](IUpdateHandler& handler)
		return this.Add((IUpdateHandler handler) =>
		{
			handler.Update(meas, index, mode);
		});
	}

	private bool Add(in update_func_t fun)
	{
		if (this.updates == null)
		{
			this.updates = new List<update_func_t>();
		}

		updates.push_back(fun);

		return true;
	}

	private shared_updates_t updates;
}

} // namespace opendnp3



