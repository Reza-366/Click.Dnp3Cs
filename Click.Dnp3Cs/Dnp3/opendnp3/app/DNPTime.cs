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

public class DNPTime
{
	public DNPTime()
	{
		this.value = 0;
		this.quality = new opendnp3.TimestampQuality.INVALID;
	}
	public DNPTime(uint64_t value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
		this.quality = new opendnp3.TimestampQuality.SYNCHRONIZED;
	}
	public DNPTime(uint64_t value, TimestampQuality quality)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
		this.quality = new opendnp3.TimestampQuality(quality);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const DNPTime& rhs) const
	public static bool operator == (DNPTime ImpliedObject, in DNPTime rhs)
	{
		return ImpliedObject.value == rhs.value && ImpliedObject.quality == rhs.quality;
	}

	public uint64_t value = new uint64_t();
	public TimestampQuality quality;
}

} // namespace opendnp3

