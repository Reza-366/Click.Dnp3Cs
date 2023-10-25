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
    Includes additional parameters that should not be externally configurable
*/
public class LinkLayerConfig : LinkConfig
{
	public LinkLayerConfig(in LinkConfig config, bool respondToAnySource) : base(config != null)
	{
		this.respondToAnySource = respondToAnySource;
	}

	/**
	 * If true, the the link-layer will respond to any source address
	 * user data frames will be passed up to transport reassembly for these frames
	 */
	public bool respondToAnySource;
}

} // namespace opendnp3

