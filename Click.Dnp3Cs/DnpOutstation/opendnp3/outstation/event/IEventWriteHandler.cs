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

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public interface IEventWriter <T>
{
	bool Write(in T meas, ushort index);
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public interface IEventCollection <T>
{
	ushort WriteSome(IEventWriter<T> handler);
}

public interface IEventWriteHandler
{
	ushort Write(EventBinaryVariation variation, in Binary first, IEventCollection<Binary> items);
	ushort Write(EventDoubleBinaryVariation variation, in DoubleBitBinary first, IEventCollection<DoubleBitBinary> items);
	ushort Write(EventCounterVariation variation, in Counter first, IEventCollection<Counter> items);
	ushort Write(EventFrozenCounterVariation variation, in FrozenCounter first, IEventCollection<FrozenCounter> items);
	ushort Write(EventAnalogVariation variation, in Analog first, IEventCollection<Analog> items);
	ushort Write(EventBinaryOutputStatusVariation variation, in BinaryOutputStatus first, IEventCollection<BinaryOutputStatus> items);
	ushort Write(EventAnalogOutputStatusVariation variation, in AnalogOutputStatus first, IEventCollection<AnalogOutputStatus> items);
	ushort Write(EventOctetStringVariation variation, in OctetString first, IEventCollection<OctetString> items);
}
} // namespace opendnp3

