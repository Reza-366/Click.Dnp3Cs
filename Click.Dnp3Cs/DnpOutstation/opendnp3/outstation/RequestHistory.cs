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

/// Tracks the state of the last request ASDU
public class RequestHistory
{
	public RequestHistory()
	{
		this.hasLast = false;
		this.lastDigest = 0;
		this.lastObjectsLength = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasLastRequest() const
	public bool HasLastRequest()
	{
		return hasLast;
	}

	public void Reset()
	{
		hasLast = false;
	}

	public void RecordLastProcessedRequest(in APDUHeader header, in RSeq</*size_t*/int> objects)
	{
		hasLast = true;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: lastHeader = header;
		lastHeader.CopyFrom(header);
		lastObjectsLength = objects.length();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: lastDigest = CRC::CalcCrc(objects);
		lastDigest.CopyFrom(CRC.CalcCrc(objects));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: APDUHeader GetLastHeader() const
	public APDUHeader GetLastHeader()
	{
		return hasLast ? lastHeader : new APDUHeader();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool EqualsLastObjects(const RSeq</*size_t*/int>& objects) const
	public bool EqualsLastObjects(in RSeq</*size_t*/int> objects)
	{
		return hasLast && (lastObjectsLength == objects.length()) && (lastDigest == CRC.CalcCrc(objects));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool FullyEqualsLastRequest(const APDUHeader& header, const RSeq</*size_t*/int>& objects) const
	public bool FullyEqualsLastRequest(in APDUHeader header, in RSeq</*size_t*/int> objects)
	{
		return lastHeader.Equals(header) && EqualsLastObjects(objects);
	}

	private bool hasLast;
	private APDUHeader lastHeader = new APDUHeader();
	private ushort lastDigest = new ushort();
	private /*size_t*/int lastObjectsLength = new /*size_t*/int();
}

} // namespace opendnp3




