﻿using System;
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
 * A bitfield that describes a subset of all static types, e.g. { Binary, Analog } or {Analog, Counter, FrozenCounter }
 */
public class StaticTypeBitField
{
	public StaticTypeBitField()
	{
		this.mask = 0;
	}

	public StaticTypeBitField(ushort mask)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.mask = mask;
		this.mask.CopyFrom(mask);
	}

	public static StaticTypeBitField AllTypes()
	{
		return new StaticTypeBitField(~0);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsSet(StaticTypeBitmask type) const
	public bool IsSet(StaticTypeBitmask type)
	{
		return (mask & (ushort)type) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: StaticTypeBitField Except(StaticTypeBitmask type) const
	public StaticTypeBitField Except(StaticTypeBitmask type)
	{
		return new StaticTypeBitField(mask & ~(ushort)type);
	}

	private ushort mask = new ushort();
}

} // namespace opendnp3
