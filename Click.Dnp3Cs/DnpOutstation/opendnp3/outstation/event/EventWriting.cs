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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class EventWriting : private StaticOnly
public class EventWriting : StaticOnly
{

	public static uint Write(EventLists lists, IEventWriteHandler handler)
	{
		uint total_num_written = 0;

		var iterator = lists.events.Iterate();

		while (true)
		{
			// continue calling WriteSome(..) until it fails to make progress
			var num_written = WriteSome(iterator, lists, handler);

			if (num_written == 0)
			{
				return new uint(total_num_written);
			}

			total_num_written += num_written;
		}
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static EventRecord FindNextSelected(event_iter_t iter, EventType type);

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static ushort WriteSomeOfType<T>(event_iter_t iterator, EventLists lists, IEventWriteHandler handler);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static ushort WriteSome<T>(event_iter_t iterator, EventLists lists, IEventWriteHandler handler);
}

} // namespace opendnp3




namespace opendnp3
{



} // namespace opendnp3
