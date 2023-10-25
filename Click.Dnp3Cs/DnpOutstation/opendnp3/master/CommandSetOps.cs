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
 *
 * Has private access to CommandSet
 *
 * Used to reduce the public API surface exposed in includes to users
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class CommandSetOps final : public IAPDUHandler, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class CommandSetOps : IAPDUHandler, Uncopyable
{
	private enum Mode : byte
	{
		Select,
		Operate
	}

	private CommandSetOps(Mode mode_, CommandSet commands_)
	{
		this.mode = new opendnp3.CommandSetOps.Mode(mode_);
		this.commands = commands_;
	}

	private Mode mode;

	public enum OperateResult : byte
	{
		OK,
		FAIL_PARSE
	}

	public enum SelectResult : byte
	{
		OK,
		FAIL_PARSE,
		FAIL_SELECT
	}

	/// Write the headers to an ASDU
	public static bool Write(in CommandSet set, HeaderWriter writer, IndexQualifierMode mode)
	{
		foreach (var header in set.m_headers)
		{
			if (!header.Write(writer, mode))
			{
				return false;
			}
		}

		return true;
	}

	/// Invoke the callback for a response
	public static void InvokeCallback(in CommandSet set, TaskCompletion result, in CommandResultCallbackT callback)
	{
		CommandTaskResult impl = new CommandTaskResult(result, set.m_headers);
		callback(impl);
	}

	/**
	 * parses a response to a select, applying each received header to the command set
	 *
	 * @return true if every object in every header was correctly selected, false otherwise
	 */
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static SelectResult ProcessSelectResponse(CommandSet set, in RSeq</*size_t*/int> headers, Logger logger);

	/**
	 * parses a response to an operate (or DO), applying each received header to the command set
	 *
	 * @return true if parsing was successful, the results are left in the set
	 */
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static OperateResult ProcessOperateResponse(CommandSet set, in RSeq</*size_t*/int> headers, Logger logger);

	private override bool IsAllowed(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		switch (qc)
		{
		case (QualifierCode.UINT8_CNT_UINT8_INDEX):
		case (QualifierCode.UINT16_CNT_UINT16_INDEX):
			break;
		default:
			return false;
		}

		switch (gv)
		{
		case (GroupVariation.Group12Var1): //    CROB
		case (GroupVariation.Group41Var1): //    4 kinds of AO
		case (GroupVariation.Group41Var2):
		case (GroupVariation.Group41Var3):
		case (GroupVariation.Group41Var4):
			return true;
		default:
			return false;
		}
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<ControlRelayOutputBlock>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, values);
		return new opendnp3.IINField(this.ProcessAny(header, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt16>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, values);
		return new opendnp3.IINField(this.ProcessAny(header, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt32>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, values);
		return new opendnp3.IINField(this.ProcessAny(header, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputFloat32>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, values);
		return new opendnp3.IINField(this.ProcessAny(header, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputDouble64>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, values);
		return new opendnp3.IINField(this.ProcessAny(header, values));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField ProcessAny<T>(in PrefixHeader header, in ICollection<Indexed<T>> values)
	{
		if (header.headerIndex >= commands.m_headers.size()) // more response headers than request headers
		{
			return IINBit.PARAM_ERROR;
		}

		if (mode == Mode.Select)
		{
			commands.m_headers[header.headerIndex].ApplySelectResponse(header.GetQualifierCode(), values);
		}
		else
		{
			commands.m_headers[header.headerIndex].ApplyOperateResponse(header.GetQualifierCode(), values);
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private CommandSet commands;
}

} // namespace opendnp3




namespace opendnp3
{



} // namespace opendnp3
