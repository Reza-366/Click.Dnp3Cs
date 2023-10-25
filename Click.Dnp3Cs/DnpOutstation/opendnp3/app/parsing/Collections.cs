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

/**
 * A simple collection derived from an underlying array
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class ArrayCollection <T> : ICollection<T>
{
	public ArrayCollection(T pArray_, /*size_t*/int count)
	{
		this.pArray = pArray_;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.COUNT = count;
		this.COUNT.CopyFrom(count);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual /*size_t*/int Count() const override final
	public override sealed /*size_t*/int Count()
	{
		return new /*size_t*/int(COUNT);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void Foreach(IVisitor<T>& visitor) const override final
	public override sealed void Foreach(IVisitor<T> visitor)
	{
		for (uint i = 0; i < COUNT; ++i)
		{
			visitor.OnValue(pArray[i]);
		}
	}

	private readonly T[] pArray;
	private readonly /*size_t*/int COUNT = new /*size_t*/int();
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class U, class Transform>
public class TransformedCollection <T, U, Transform> : ICollection<U>
{
	public TransformedCollection(in ICollection<T> input, Transform transform)
	{
		this.input = new opendnp3.ICollection<T>(input);
		this.transform = transform;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual /*size_t*/int Count() const override final
	public override sealed /*size_t*/int Count()
	{
		return input.Count();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void Foreach(IVisitor<U>& visitor) const override final
	public override sealed void Foreach(IVisitor<U> visitor)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto process = [this, &visitor](const T& elem)
		var process = (in T elem) =>
		{
			visitor.OnValue(transform(elem));
		};
		input.ForeachItem(process);
	}

	private readonly ICollection<T>[] input;
	private Transform transform = default(Transform);
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class U, class Transform>

} // namespace opendnp3

