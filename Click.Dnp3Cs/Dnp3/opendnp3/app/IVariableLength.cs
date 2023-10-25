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

public abstract class IVariableLength : System.IDisposable
{

	public virtual void Dispose()
	{
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual GroupVariationID InstanceID() const = 0;
	public abstract GroupVariationID InstanceID();

	// The size of the object in its current configuration
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual size_t Size() const = 0;
	public abstract size_t Size();

	// attempt to write the object to the destination buffer
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool Write(WSeq<size_t>& dest) const = 0;
	public abstract bool Write(WSeq<size_t> dest);

	// attempt to read the object from the input buffer
	public abstract bool Read(in RSeq<size_t> input);
}

} // namespace opendnp3

