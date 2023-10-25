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
 * Base class used to handle APDU object headers
 */
public class IAPDUHandler : IWhiteList
{
	public IAPDUHandler()
	{
		this.numTotalHeaders = 0;
		this.numIgnoredHeaders = 0;
	}

	// read any accumulated errors
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: IINField Errors() const
	public IINField Errors()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return errors;
		return new opendnp3.IINField(errors);
	}

	public void OnHeader(in AllObjectsHeader header)
	{
		Record(header, this.ProcessHeader(header));
	}

	public void OnHeader(in RangeHeader header)
	{
		Record(header, this.ProcessHeader(header));
	}

	public void OnHeader(in CountHeader header)
	{
		Record(header, this.ProcessHeader(header));
	}

	public void OnHeader(in CountHeader header, in ICollection<Group50Var1> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in CountHeader header, in ICollection<Group50Var3> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in CountHeader header, in ICollection<Group51Var1> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in CountHeader header, in ICollection<Group51Var2> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in CountHeader header, in ICollection<Group52Var1> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in CountHeader header, in ICollection<Group52Var2> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<IINValue>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<Binary>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<Counter>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<Analog>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<OctetString>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in RangeHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	// events


	// --- index prefixes ----

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<Binary>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<Counter>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<Analog>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<OctetString>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<BinaryCommandEvent>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<AnalogCommandEvent>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	// adhoc read by index
	public void OnHeader(in PrefixHeader header, in ICollection<ushort> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	// commands


	// --- controls ----

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<ControlRelayOutputBlock>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt16>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt32>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputFloat32>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	public void OnHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputDouble64>> values)
	{
		Record(header, this.ProcessHeader(header, values));
	}

	protected void Reset()
	{
		numTotalHeaders = 0;
		numIgnoredHeaders = 0;
		errors.Clear();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint NumIgnoredHeaders() const
	protected uint NumIgnoredHeaders()
	{
		return new uint(numIgnoredHeaders);
	}

	protected uint GetCurrentHeader()
	{
		return new uint(numTotalHeaders);
	}

	protected bool IsFirstHeader()
	{
		return numTotalHeaders == 0;
	}

	protected virtual IINField ProcessHeader(in AllObjectsHeader record)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in CountHeader header)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}


	/// ---- counts -----

	protected virtual IINField ProcessHeader(in CountHeader header, in ICollection<Group50Var1> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in CountHeader header, in ICollection<Group50Var3> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in CountHeader header, in ICollection<Group51Var1> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in CountHeader header, in ICollection<Group51Var2> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var1> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var2> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}


	/// ---- ranges -----

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<IINValue>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Binary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Counter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Analog>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}


	/// ---- index prefixes -----

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Counter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Binary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Analog>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<BinaryCommandEvent>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogCommandEvent>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	// adhoc read by index
	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<ushort> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}


	//// --- controls ----

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<ControlRelayOutputBlock>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt16>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt32>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputFloat32>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	protected virtual IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputDouble64>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessUnsupportedHeader();
		return new opendnp3.IINField(ProcessUnsupportedHeader());
	}

	// overridable to receive post processing events for every header
	protected virtual void OnHeaderResult(in HeaderRecord record, in IINField result)
	{
	}

	private void Record(in HeaderRecord record, in IINField result)
	{
		errors |= result;
		++numTotalHeaders;
		this.OnHeaderResult(record, result);
	}

	private IINField ProcessUnsupportedHeader()
	{
		++numIgnoredHeaders;
		return new IINField(IINBit.FUNC_NOT_SUPPORTED);
	}

	private IINField errors = new IINField();
	private uint numTotalHeaders = new uint();
	private uint numIgnoredHeaders = new uint();
}

} // namespace opendnp3



