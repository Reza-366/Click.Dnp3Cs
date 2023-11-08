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

public enum Error : int
{
	SHUTTING_DOWN,
	NO_TLS_SUPPORT,
	UNABLE_TO_BIND_SERVER
}

public class ErrorSpec
{
	public static string to_string(Error err)
	{
		switch (err)
		{
		case Error.SHUTTING_DOWN:
			return "The operation was requested while the resource was shutting down";
		case Error.NO_TLS_SUPPORT:
			return "Not built with TLS support";
		case Error.UNABLE_TO_BIND_SERVER:
			return "Unable to bind server to the specified port";
		default:
			return "unknown error";
		};
	}
}

public sealed class DNP3Error : System.Exception
{
	public DNP3Error(Error err) : base(ErrorSpec.to_string(err))
	{
	}

	public DNP3Error(Error err, /*std::error_code*/ int ec) : base(ErrorSpec.to_string(err) + ": " + ec.message())
	{
	}
}

} // namespace opendnp3

