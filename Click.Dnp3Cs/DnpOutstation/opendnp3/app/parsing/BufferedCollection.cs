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

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class ReadFunc>
public class BufferedCollection <T, ReadFunc> : ICollection<T>
{
	public BufferedCollection(in RSeq</*size_t*/int> buffer, /*size_t*/int count, in ReadFunc readFunc)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.buffer = buffer;
		this.buffer.CopyFrom(buffer);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.COUNT = count;
		this.COUNT.CopyFrom(count);
		this.readFunc = readFunc;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual /*size_t*/int Count() const override final
	public override sealed /*size_t*/int Count()
	{
		return new /*size_t*/int(COUNT);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void Foreach(IVisitor<T>& visitor) const final
	public sealed override void Foreach(IVisitor<T> visitor)
	{
		RSeq</*size_t*/int> copy = new RSeq</*size_t*/int>(buffer);

		for (uint pos = 0; pos < COUNT; ++pos)
		{
			visitor.OnValue(readFunc(copy, pos));
		}
	}

	private RSeq</*size_t*/int> buffer = new RSeq</*size_t*/int>();
	private readonly /*size_t*/int COUNT = new /*size_t*/int();
	private ReadFunc readFunc = default(ReadFunc);
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class ReadFunc>

} // namespace opendnp3

