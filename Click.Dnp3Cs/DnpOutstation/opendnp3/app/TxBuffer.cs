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

public class TxBuffer
{
	public TxBuffer(uint maxTxSize)
	{
		this.buffer = new ser4cpp.Buffer(maxTxSize);
	}

	public APDUResponse Start()
	{
		APDUResponse response = new APDUResponse(buffer.as_wslice());
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return response;
		return new opendnp3.APDUResponse(response);
	}

	public void Record(in AppControlField control, in RSeq/*<size_t>*/ view)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->control = control;
		this.control.CopyFrom(control);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->lastResponse = view;
		this.lastResponse.CopyFrom(view);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const RSeq/*<size_t>*/& GetLastResponse() const
	public RSeq/*<size_t>*/ GetLastResponse()
	{
		return new RSeq/*<size_t>*/(lastResponse);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const AppControlField& GetLastControl() const
	public AppControlField GetLastControl()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return control;
		return new opendnp3.AppControlField(control);
	}

	private RSeq/*<size_t>*/ lastResponse = new RSeq/*<size_t>*/();
	private AppControlField control = new AppControlField();

	private ser4cpp.Buffer buffer = new ser4cpp.Buffer();
}

} // namespace opendnp3

