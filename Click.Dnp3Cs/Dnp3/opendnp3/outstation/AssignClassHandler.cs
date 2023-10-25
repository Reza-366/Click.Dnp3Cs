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

//#include "../../exe4cpp/IExecutor.h"

namespace opendnp3
{

public class AssignClassHandler : IAPDUHandler
{
	public AssignClassHandler(IOutstationApplication application, IClassAssigner assigner)
	{
		this.classHeader = -1;
		this.clazz = new opendnp3.PointClass.Class0;
		this.pApplication = application;
		this.pAssigner = assigner;
	}

	public override sealed bool IsAllowed(System.UInt32 headerCount, GroupVariation gv, QualifierCode qc)
	{
		return true;
	}

	private override IINField ProcessHeader(in AllObjectsHeader header)
	{
		if (IsExpectingAssignment())
		{
			switch (header.enumeration)
			{
			case (GroupVariation.Group1Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::BinaryInput, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.BinaryInput, clazz));
			case (GroupVariation.Group3Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::DoubleBinaryInput, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.DoubleBinaryInput, clazz));
			case (GroupVariation.Group10Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::BinaryOutputStatus, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.BinaryOutputStatus, clazz));
			case (GroupVariation.Group20Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::Counter, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.Counter, clazz));
			case (GroupVariation.Group21Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::FrozenCounter, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.FrozenCounter, clazz));
			case (GroupVariation.Group30Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::AnalogInput, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.AnalogInput, clazz));
			case (GroupVariation.Group40Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessAssignAll(AssignClassType::AnalogOutputStatus, clazz);
				return new opendnp3.IINField(this.ProcessAssignAll(AssignClassType.AnalogOutputStatus, clazz));
			default:
				return IINBit.FUNC_NOT_SUPPORTED;
			}
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->RecordClass(header.enumeration);
			return new opendnp3.IINField(this.RecordClass(header.enumeration));
		}
	}

	private override IINField ProcessHeader(in RangeHeader header)
	{
		if (IsExpectingAssignment())
		{
			switch (header.enumeration)
			{

			case (GroupVariation.Group1Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::BinaryInput, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.BinaryInput, clazz, header.range));
			case (GroupVariation.Group3Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::DoubleBinaryInput, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.DoubleBinaryInput, clazz, header.range));
			case (GroupVariation.Group10Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::BinaryOutputStatus, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.BinaryOutputStatus, clazz, header.range));
			case (GroupVariation.Group20Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::Counter, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.Counter, clazz, header.range));
			case (GroupVariation.Group21Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::FrozenCounter, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.FrozenCounter, clazz, header.range));
			case (GroupVariation.Group30Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::AnalogInput, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.AnalogInput, clazz, header.range));
			case (GroupVariation.Group40Var0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ProcessAssignRange(AssignClassType::AnalogOutputStatus, clazz, header.range);
				return new opendnp3.IINField(ProcessAssignRange(AssignClassType.AnalogOutputStatus, clazz, header.range));
			default:
				return IINBit.FUNC_NOT_SUPPORTED;
			}
		}
		else
		{
			return IINBit.PARAM_ERROR;
		}
	}

	private IINField RecordClass(GroupVariation gv)
	{
		classHeader = this.GetCurrentHeader();

		switch (gv)
		{
		case (GroupVariation.Group60Var1):
			clazz = PointClass.Class0;
			return new IINField();
		case (GroupVariation.Group60Var2):
			clazz = PointClass.Class1;
			return new IINField();
		case (GroupVariation.Group60Var3):
			clazz = PointClass.Class2;
			return new IINField();
		case (GroupVariation.Group60Var4):
			clazz = PointClass.Class3;
			return new IINField();
		default:
			classHeader = -1;
			return IINBit.PARAM_ERROR;
		}
	}

	private bool IsExpectingAssignment()
	{
		var current = (int32_t)this.GetCurrentHeader();

		if (current > 0 && ((current - 1) == this.classHeader))
		{
			this.classHeader = -1;
			return true;
		}

		return false;
	}

	private IINField ProcessAssignAll(AssignClassType type, PointClass clazz)
	{
		var full = pAssigner.AssignClassToAll(type, clazz);

		this.NotifyApplicationOfAssignment(type, clazz, full);

		return full.IsValid() ? new IINField() : IINBit.PARAM_ERROR;
	}

	private IINField ProcessAssignRange(AssignClassType type, PointClass clazz, in Range range)
	{
		var actual = pAssigner.AssignClassToRange(type, clazz, range);

		this.NotifyApplicationOfAssignment(type, clazz, actual);

		// if the range was clipped or invalid return parameter error
		return actual.Equals(range) ? new IINField() : IINBit.PARAM_ERROR;
	}

	private void NotifyApplicationOfAssignment(AssignClassType type, PointClass clazz, in Range range)
	{
		if (pApplication != null && range.IsValid())
		{
			pApplication.RecordClassAssignment(type, clazz, new UInt16(range.start), new UInt16(range.stop));
		}
	}

	private int32_t classHeader = new int32_t();
	private PointClass clazz;

	private IOutstationApplication pApplication;
	private IClassAssigner pAssigner;
}

} // namespace opendnp3



