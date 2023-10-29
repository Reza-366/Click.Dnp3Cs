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

public class ParsedRequest
{
	public ParsedRequest(in Addresses addresses, in APDUHeader header, in RSeq/*<size_t>*/ objects)
	{
		this.addresses = new opendnp3.Addresses(addresses);
		this.header = new opendnp3.APDUHeader(header);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.objects = objects;
		this.objects.CopyFrom(objects);
	}

	public readonly Addresses addresses = new Addresses();
	public readonly APDUHeader header = new APDUHeader();
	public readonly RSeq/*<size_t>*/ objects = new RSeq/*<size_t>*/();
}

} // namespace opendnp3

