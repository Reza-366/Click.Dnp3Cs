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

public sealed class ReadHandler : IAPDUHandler
{
	public ReadHandler(IStaticSelector staticSelector, IEventSelector eventSelector)
	{
		this.pStaticSelector = staticSelector;
		this.pEventSelector = eventSelector;
	}

	public override sealed bool IsAllowed(System.UInt32 headerCount, GroupVariation gv, QualifierCode qc)
	{
		return true;
	}

	private override IINField ProcessHeader(in AllObjectsHeader header)
	{
		switch (header.type)
		{
		case (GroupVariationType.STATIC):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return pStaticSelector->SelectAll(header.enumeration);
			return new opendnp3.IINField(pStaticSelector.SelectAll(header.enumeration));
		case (GroupVariationType.EVENT):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return pEventSelector->SelectAll(header.enumeration);
			return new opendnp3.IINField(pEventSelector.SelectAll(header.enumeration));
		default:
			return new IINField(IINBit.FUNC_NOT_SUPPORTED);
		}
	}

	private override IINField ProcessHeader(in RangeHeader header)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return pStaticSelector->SelectRange(header.enumeration, header.range);
		return new opendnp3.IINField(pStaticSelector.SelectRange(header.enumeration, header.range));
	}

	private override IINField ProcessHeader(in CountHeader header)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return pEventSelector->SelectCount(header.enumeration, header.count);
		return new opendnp3.IINField(pEventSelector.SelectCount(header.enumeration, new UInt16(header.count)));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<UInt16> indices)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return pStaticSelector->SelectIndices(header.enumeration, indices);
		return new opendnp3.IINField(pStaticSelector.SelectIndices(header.enumeration, indices));
	}

	private IStaticSelector pStaticSelector;
	private IEventSelector pEventSelector;
}

} // namespace opendnp3



