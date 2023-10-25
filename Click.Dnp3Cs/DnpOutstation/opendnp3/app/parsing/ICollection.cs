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
 * Abstract way of visiting elements of a collection
 *
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public interface IVisitor <T>
{
	void OnValue(in T value);
}

/**
 * A visitor implemented as an abstract functor
 *
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class Fun>
public class FunctorVisitor <T, Fun> : IVisitor<T>
{

	public FunctorVisitor(in Fun fun_)
	{
		this.fun = fun_;
	}

	public override sealed void OnValue(in T value)
	{
		fun(value);
	}

	private Fun fun = default(Fun);
}

/**
 * An interface representing an abstract immutable collection of things of type T.
 *
 * The user can only read these values via callback to receive each element.
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public abstract class ICollection <T>
{
	/**
	 * The number of elements in the collection
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual /*size_t*/int Count() const = 0;
	public abstract /*size_t*/int Count();

	/**
	 * Visit all the elements of a collection
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void Foreach(IVisitor<T>& visitor) const = 0;
	public abstract void Foreach(IVisitor<T> visitor);

	/**
	    visit all of the elements of a collection
	*/
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Fun>
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: void ForeachItem(const Fun& fun) const
	public void ForeachItem<Fun>(in Fun fun)
	{
		FunctorVisitor<T, Fun> visitor = new FunctorVisitor<T, Fun>(fun);
		this.Foreach(visitor);
	}

	/**
	    Retrieve the only value from the collection.
	*/
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool ReadOnlyValue(T& value) const
	public bool ReadOnlyValue(ref T value)
	{
		if (this.Count() == 1)
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
			var assignValue = (in T item) =>
			{
				value = item;
			};
			this.ForeachItem(assignValue);
			return true;
		}
		else
		{
			return false;
		}
	}
}

} // namespace opendnp3

