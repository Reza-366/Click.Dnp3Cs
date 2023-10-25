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

/**
 * An interface for Sequence-Of-Events (SOE) callbacks from a master stack to
 * the application layer.
 *
 * A call is made to the appropriate member method for every measurement value in an ASDU.
 * The HeaderInfo class provides information about the object header associated with the value.
 *
 */
public abstract class ISOEHandler : System.IDisposable
{

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	virtual ~ISOEHandler() = default;

	public abstract void BeginFragment(in ResponseInfo info);
	public abstract void EndFragment(in ResponseInfo info);

	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<Binary>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<DoubleBitBinary>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<Analog>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<Counter>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<FrozenCounter>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<BinaryOutputStatus>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<AnalogOutputStatus>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<OctetString>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<TimeAndInterval>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<BinaryCommandEvent>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<Indexed<AnalogCommandEvent>> values);
	public abstract void Process(in HeaderInfo info, in ICollection<DNPTime> values);
}

} // namespace opendnp3

