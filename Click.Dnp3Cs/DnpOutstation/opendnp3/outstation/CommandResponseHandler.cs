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

public class CommandResponseHandler : IAPDUHandler
{
	public CommandResponseHandler(uint maxCommands_, ICommandAction pCommandAction_, HeaderWriter pWriter_)
	{
		this.pCommandAction = pCommandAction_;
		this.numRequests = 0;
		this.numSuccess = 0;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.maxCommands = maxCommands_;
		this.maxCommands.=(maxCommands_);
		this.pWriter = pWriter_;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool AllCommandsSuccessful() const
	public bool AllCommandsSuccessful()
	{
		return numRequests == numSuccess;
	}

	public override bool IsAllowed(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		if (!(qc == QualifierCode.UINT8_CNT_UINT8_INDEX || qc == QualifierCode.UINT16_CNT_UINT16_INDEX))
		{
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

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<ControlRelayOutputBlock>> meas)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, meas);
		return new opendnp3.IINField(this.ProcessAny(header, meas));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt16>> meas)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, meas);
		return new opendnp3.IINField(this.ProcessAny(header, meas));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt32>> meas)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, meas);
		return new opendnp3.IINField(this.ProcessAny(header, meas));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputFloat32>> meas)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, meas);
		return new opendnp3.IINField(this.ProcessAny(header, meas));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputDouble64>> meas)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAny(header, meas);
		return new opendnp3.IINField(this.ProcessAny(header, meas));
	}

	private IINField ProcessIndexPrefixTwoByte(in HeaderRecord record, in ICollection<Indexed<ControlRelayOutputBlock>> meas)
	{
		return this.RespondToHeader<ControlRelayOutputBlock, new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_CNT_UINT16_INDEX, Group12Var1.Inst(), meas);
	}

	private IINField ProcessIndexPrefixTwoByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputInt16>> meas)
	{
		return this.RespondToHeader<AnalogOutputInt16, new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_CNT_UINT16_INDEX, Group41Var2.Inst(), meas);
	}

	private IINField ProcessIndexPrefixTwoByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputInt32>> meas)
	{
		return this.RespondToHeader<AnalogOutputInt32, new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_CNT_UINT16_INDEX, Group41Var1.Inst(), meas);
	}

	private IINField ProcessIndexPrefixTwoByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputFloat32>> meas)
	{
		return this.RespondToHeader<AnalogOutputFloat32, new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_CNT_UINT16_INDEX, Group41Var3.Inst(), meas);
	}

	private IINField ProcessIndexPrefixTwoByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputDouble64>> meas)
	{
		return this.RespondToHeader<AnalogOutputDouble64, new ser4cpp.Globals.Bit16<ushort, 0, 1>>(QualifierCode.UINT16_CNT_UINT16_INDEX, Group41Var4.Inst(), meas);
	}

	private IINField ProcessIndexPrefixOneByte(in HeaderRecord record, in ICollection<Indexed<ControlRelayOutputBlock>> meas)
	{
		return this.RespondToHeader<ControlRelayOutputBlock, ser4cpp.UInt8>(QualifierCode.UINT8_CNT_UINT8_INDEX, Group12Var1.Inst(), meas);
	}

	private IINField ProcessIndexPrefixOneByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputInt16>> meas)
	{
		return this.RespondToHeader<AnalogOutputInt16, ser4cpp.UInt8>(QualifierCode.UINT8_CNT_UINT8_INDEX, Group41Var2.Inst(), meas);
	}

	private IINField ProcessIndexPrefixOneByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputInt32>> meas)
	{
		return this.RespondToHeader<AnalogOutputInt32, ser4cpp.UInt8>(QualifierCode.UINT8_CNT_UINT8_INDEX, Group41Var1.Inst(), meas);
	}

	private IINField ProcessIndexPrefixOneByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputFloat32>> meas)
	{
		return this.RespondToHeader<AnalogOutputFloat32, ser4cpp.UInt8>(QualifierCode.UINT8_CNT_UINT8_INDEX, Group41Var3.Inst(), meas);
	}

	private IINField ProcessIndexPrefixOneByte(in HeaderRecord record, in ICollection<Indexed<AnalogOutputDouble64>> meas)
	{
		return this.RespondToHeader<AnalogOutputDouble64, ser4cpp.UInt8>(QualifierCode.UINT8_CNT_UINT8_INDEX, Group41Var4.Inst(), meas);
	}

	private ICommandAction pCommandAction;
	private uint numRequests = new uint();
	private uint numSuccess = new uint();
	private readonly uint maxCommands = new uint();
	private HeaderWriter pWriter;

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField ProcessAny<T>(in HeaderRecord record, in ICollection<Indexed<T>> meas)
	{
		if (record.GetQualifierCode() == QualifierCode.UINT8_CNT_UINT8_INDEX)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessIndexPrefixOneByte(record, meas);
			return new opendnp3.IINField(ProcessIndexPrefixOneByte(record, meas));
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessIndexPrefixTwoByte(record, meas);
			return new opendnp3.IINField(ProcessIndexPrefixTwoByte(record, meas));
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class IndexType>
	private IINField RespondToHeader<Target, IndexType>(QualifierCode qualifier, in DNP3Serializer<Target> serializer, in ICollection<Indexed<Target>> values)
	{
		if (pWriter != null)
		{
			var iter = pWriter.IterateOverCountWithPrefix<IndexType, Target>(qualifier, serializer);
			return this.RespondToHeaderWithIterator<Target, IndexType>(qualifier, serializer, values, iter);
		}
		else
		{
			return this.RespondToHeaderWithIterator<Target, IndexType>(qualifier, serializer, values);
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class IndexType>
	private IINField RespondToHeaderWithIterator<Target, IndexType>(QualifierCode qualifier, in DNP3Serializer<Target> serializer, in ICollection<Indexed<Target>> values, PrefixedWriteIterator<IndexType, Target> pIterator = null)
	{
		IINField ret = new IINField();

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto process = [this, pIterator, &ret](const Indexed<Target>& pair)
		var process = (in Indexed<Target> pair) =>
		{
			Target response = new Target(pair.value);
			response.status = this.ProcessCommand(pair.value, new ushort(pair.index));

			switch (response.status)
			{
			case (CommandStatus.SUCCESS):
				++this.numSuccess;
				break;
			case (CommandStatus.NOT_SUPPORTED):
				ret.SetBit(IINBit.PARAM_ERROR);
				break;
			default:
				break;
			}

			if (pIterator != null)
			{
				pIterator.Write(response, (typename IndexType.type_t)pair.index);
			}
		};

		values.ForeachItem(process);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.IINField(ret);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target>
	private CommandStatus ProcessCommand<Target>(in Target command, ushort index)
	{
		if (numRequests < maxCommands)
		{
			++numRequests;
			return pCommandAction.Action(command, index);
		}
		else
		{
			return CommandStatus.TOO_MANY_OPS;
		}
	}
}

} // namespace opendnp3



