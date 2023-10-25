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

public class ClassBasedRequestHandler : IAPDUHandler
{
	public ClassBasedRequestHandler()
	{
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ClassField GetClassField() const
	public ClassField GetClassField()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return classField;
		return new opendnp3.ClassField(classField);
	}

	public override sealed bool IsAllowed(System.UInt32 headerCount, GroupVariation gv, QualifierCode qc)
	{
		return true;
	}

	private override IINField ProcessHeader(in AllObjectsHeader header)
	{
		switch (header.enumeration)
		{
		case (GroupVariation.Group60Var2):
			classField.Set(PointClass.Class1);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		case (GroupVariation.Group60Var3):
			classField.Set(PointClass.Class2);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		case (GroupVariation.Group60Var4):
			classField.Set(PointClass.Class3);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
			return new opendnp3.IINField(IINField.Empty());
		default:
			return new IINField(IINBit.FUNC_NOT_SUPPORTED);
		}
	}

	private ClassField classField = new ClassField();
}

} // namespace opendnp3



