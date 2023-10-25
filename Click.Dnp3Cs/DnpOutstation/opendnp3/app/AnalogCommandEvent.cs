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
 * Occurs when an outstation receives and analog command. Maps to Group43.
 */
public class AnalogCommandEvent
{
	public AnalogCommandEvent()
	{
		this.value = 0;
		this.status =  opendnp3.CommandStatus.SUCCESS;
	}

	public AnalogCommandEvent(double value_, CommandStatus status_)
	{
		this.value = value_;
		this.status =  status_;
	}

	public AnalogCommandEvent(double value_, CommandStatus status_, DNPTime time_)
	{
		this.value = value_;
		this.status =  status_;
		this.time = new opendnp3.DNPTime(time_);
	}

	public double value;
	public CommandStatus status;
	public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const AnalogCommandEvent& rhs) const
	public static bool operator == (AnalogCommandEvent ImpliedObject, in AnalogCommandEvent rhs)
	{
		return (ImpliedObject.value == rhs.value) && (ImpliedObject.status == rhs.status) && (ImpliedObject.time == rhs.time);
	}
}

} // namespace opendnp3



