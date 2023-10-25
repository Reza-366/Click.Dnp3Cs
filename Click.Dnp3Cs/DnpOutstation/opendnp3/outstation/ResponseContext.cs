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

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Database;

/**
 *  Coordinates the event & static response contexts to do multi-fragments responses
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class ResponseContext : private Uncopyable
public class ResponseContext : Uncopyable
{

	public ResponseContext(IResponseLoader staticLoader, IResponseLoader eventLoader)
	{
		this.fragmentCount = 0;
		this.pStaticLoader = staticLoader;
		this.pEventLoader = eventLoader;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasSelection() const
	public bool HasSelection()
	{
		return pStaticLoader.HasAnySelection() || pEventLoader.HasAnySelection();
	}

	public void Reset()
	{
		fragmentCount = 0;
	}

	public AppControlField LoadResponse(HeaderWriter writer)
	{
		bool fir = fragmentCount == 0;
		++fragmentCount;

		var startingSize = writer.Remaining();
		bool notFull = pEventLoader.Load(writer);
		bool someEventsWritten = writer.Remaining() < startingSize;

		if (notFull)
		{
			var fin = pStaticLoader.Load(writer);
			var con = !fin || someEventsWritten;
			return new AppControlField(fir, fin, con, false);
		}

		return new AppControlField(fir, false, true, false);
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static AppControlField GetControl(bool fir, bool fin, bool hasEvents);

	private ushort fragmentCount = new ushort();
	private IResponseLoader pStaticLoader;
	private IResponseLoader pEventLoader;
}

} // namespace opendnp3



