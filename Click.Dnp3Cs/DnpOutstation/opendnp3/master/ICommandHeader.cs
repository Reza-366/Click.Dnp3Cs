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

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class HeaderWriter;

public class CommandState
{
	public CommandState(ushort index_)
	{
		this.state = new opendnp3.CommandPointState.INIT;
		this.status = new opendnp3.CommandStatus.UNDEFINED;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.index = index_;
		this.index.CopyFrom(index_);
	}

	public CommandPointState state;
	public CommandStatus status;
	public ushort index = new ushort();
}

/**
 * Represents an object header of command objects (CROB or AO)
 */
public abstract class ICommandHeader : ICollection<CommandState>, System.IDisposable
{
	public virtual void Dispose()
	{
	}

	/// Write all of the headers to an ASDU
	public abstract bool Write(HeaderWriter UnnamedParameter, IndexQualifierMode mode);

	/// Ask if all of the individual commands have been selected
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool AreAllSelected() const = 0;
	public abstract bool AreAllSelected();

	// --- each overriden classs will only override one of these ---

	public virtual void ApplySelectResponse(QualifierCode code, in ICollection<Indexed<ControlRelayOutputBlock>> commands)
	{
	}
	public virtual void ApplySelectResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputInt16>> commands)
	{
	}
	public virtual void ApplySelectResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputInt32>> commands)
	{
	}
	public virtual void ApplySelectResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputFloat32>> commands)
	{
	}
	public virtual void ApplySelectResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputDouble64>> commands)
	{
	}

	// --- each overriden classs will only override one of these ---

	public virtual void ApplyOperateResponse(QualifierCode code, in ICollection<Indexed<ControlRelayOutputBlock>> commands)
	{
	}
	public virtual void ApplyOperateResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputInt16>> commands)
	{
	}
	public virtual void ApplyOperateResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputInt32>> commands)
	{
	}
	public virtual void ApplyOperateResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputFloat32>> commands)
	{
	}
	public virtual void ApplyOperateResponse(QualifierCode code, in ICollection<Indexed<AnalogOutputDouble64>> commands)
	{
	}
}

} // namespace opendnp3

