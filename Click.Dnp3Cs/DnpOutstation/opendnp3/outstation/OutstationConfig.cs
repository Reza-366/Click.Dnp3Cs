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

/** Configuration information for a dnp3 outstation (outstation)

Used as both input describing the startup configuration of the outstation, and as configuration state of mutable
properties (i.e. unsolicited responses).

Major feature areas are unsolicited responses, time synchronization requests, event buffer limits, and the DNP3
object/variations to use by default when the master requests class data or variation 0.

*/
public class OutstationConfig
{
	/// Various parameters that govern outstation behavior
	public OutstationParams @params = new OutstationParams();

	/// Describes the sizes in the event buffer
	public EventBufferConfig eventBufferConfig = new EventBufferConfig();
}

} // namespace opendnp3

