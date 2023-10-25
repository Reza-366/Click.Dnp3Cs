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

public sealed class FreezeRequestHandler : IAPDUHandler
{
	public FreezeRequestHandler(bool clear, Database database)
	{
		this.clear = clear;
		this.database = new opendnp3.Database(database);
	}

	public bool IsAllowed(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		if (gv != GroupVariation.Group20Var0)
		{
			return false;
		}

		switch (qc)
		{
		case QualifierCode.ALL_OBJECTS:
		case QualifierCode.UINT8_START_STOP:
		case QualifierCode.UINT16_START_STOP:
			return true;
		default:
			return false;
		}
	}

	private new IINField ProcessHeader(in AllObjectsHeader record)
	{
		this.database.SelectAll(record.enumeration);
		this.database.FreezeSelectedCounters(clear);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private new IINField ProcessHeader(in RangeHeader header)
	{
		this.database.SelectRange(header.enumeration, header.range);
		this.database.FreezeSelectedCounters(clear);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private bool clear;
	private Database database;
}

} // namespace opendnp3



