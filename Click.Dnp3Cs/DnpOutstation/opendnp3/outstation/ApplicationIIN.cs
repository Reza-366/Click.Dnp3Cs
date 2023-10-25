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
    Some IIN bits are necessarily controlled by the outstation application,
    not the underlying protocol stack. This structure describes the state of
    the bits controllable by the application.
*/
public class ApplicationIIN
{

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	ApplicationIIN() = default;

	// flags normally controlled by the application, not the stack
	public bool needTime = false;
	public bool localControl = false;
	public bool deviceTrouble = false;
	public bool configCorrupt = false;

	// this is only for appliactions that have an additional external event buffer that can overflow
	public bool eventBufferOverflow = false;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: IINField ToIIN() const
	public IINField ToIIN()
	{
		IINField ret = new IINField();
		ret.SetBitToValue(IINBit.NEED_TIME, needTime);
		ret.SetBitToValue((opendnp3.IINBit)IINBit.LOCAL_CONTROL, localControl);
		ret.SetBitToValue(IINBit.CONFIG_CORRUPT, configCorrupt);
		ret.SetBitToValue(IINBit.DEVICE_TROUBLE, deviceTrouble);
		ret.SetBitToValue(IINBit.EVENT_BUFFER_OVERFLOW, eventBufferOverflow);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.IINField(ret);
	}
}

} // namespace opendnp3



