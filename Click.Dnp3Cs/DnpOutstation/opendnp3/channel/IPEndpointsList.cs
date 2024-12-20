﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

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

public sealed class IPEndpointsList : System.IDisposable
{
	public IPEndpointsList(in List<IPEndpoint> endpoints)
	{
		this.endpoints = new List<IPEndpoint>(endpoints);
		this.currentEndpoint = this.endpoints.GetEnumerator();
		Debug.Assert(endpoints.Count > 0);
	}

	public IPEndpointsList(in IPEndpointsList rhs)
	{
		this.endpoints = new List<IPEndpoint>(rhs.endpoints);
		this.currentEndpoint = this.endpoints.GetEnumerator();
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	~IPEndpointsList() = default;

	public IPEndpoint GetCurrentEndpoint()
	{
		return new List<IPEndpoint>.Enumerator(this.currentEndpoint);
	}

	public void Next()
	{
//C++ TO C# CONVERTER TASK: Iterators are only converted within the context of 'while' and 'for' loops:
		++this.currentEndpoint;
		if (this.currentEndpoint == this.endpoints.end())
		{
			Reset();
		}
	}

	public void Reset()
	{
		this.currentEndpoint = this.endpoints.GetEnumerator();
	}

	private readonly List<IPEndpoint> endpoints = new List<IPEndpoint>();
	private List<IPEndpoint>.Enumerator currentEndpoint;
}

} // namespace opendnp3




