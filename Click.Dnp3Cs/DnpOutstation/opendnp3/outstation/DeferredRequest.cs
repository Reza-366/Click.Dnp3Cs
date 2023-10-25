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
 * Records metadata about deferred requests
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class DeferredRequest : private Uncopyable
public class DeferredRequest : Uncopyable
{

	public DeferredRequest(uint maxAPDUSize)
	{
		this.isSet = false;
		this.buffer = new ser4cpp.Buffer(maxAPDUSize);
	}

	public void Reset()
	{
		isSet = false;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsSet() const
	public bool IsSet()
	{
		return isSet;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: FunctionCode GetFunction() const
	public FunctionCode GetFunction()
	{
		return header.function;
	}

	public void Set(in ParsedRequest request)
	{
		this.isSet = true;

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->addresses = request.addresses;
		this.addresses.CopyFrom(request.addresses);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->header = request.header;
		this.header.CopyFrom(request.header);

		var dest = buffer.as_wslice();
		this.objects = dest.copy_from(request.objects);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Handler>
	public bool Process<Handler>(in Handler handler)
	{
		if (isSet)
		{
			bool processed = handler(new ParsedRequest(this.addresses, this.header, this.objects));
			isSet = !processed;
			return processed;
		}
		else
		{
			return false;
		}
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	DeferredRequest() = delete;

	private bool isSet;
	private Addresses addresses = new Addresses();
	private APDUHeader header = new APDUHeader();
	private ser4cpp.rseq_t objects = new ser4cpp.rseq_t();
	private ser4cpp.Buffer buffer = new ser4cpp.Buffer();
}

} // namespace opendnp3



