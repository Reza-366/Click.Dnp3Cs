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
 * String manipulation
 */
public class Strings
{
	// Append anything together that can be used w/ ostringstream
//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename... Args>
	public static string concatenate(Args... args)
	{
		std::ostringstream oss = new std::ostringstream();
		append(oss, args...);
		return oss.str();
	}

//C++ TO C# CONVERTER TASK: There is no equivalent in C# to C++ variadic templates:
//ORIGINAL LINE: template<typename T, typename... Args>
	private static void append<T>(std::ostringstream oss, in T first, Args... args)
	{
		oss << first;
		append(oss, args...);
	}

	private static void append(std::ostringstream oss)
	{
	}
}

} // namespace opendnp3

