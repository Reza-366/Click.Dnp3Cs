using System;

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

public class PrintingCommandResultCallback : StaticOnly
{

	public static CommandResultCallbackT Get()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		return (in ICommandTaskResult result) =>
		{
			Console.Write("Received command result w/ summary: ");
			Console.Write(TaskCompletionSpec.to_human_string(result.summary));
			Console.WriteLine();
			var print = (in CommandPointResult res) =>
			{
				Console.Write("Header: ");
				Console.Write(res.headerIndex);
				Console.Write(" Index: ");
				Console.Write(res.index);
				Console.Write(" State: ");
				Console.Write(CommandPointStateSpec.to_human_string(res.state));
				Console.Write(" Status: ");
				Console.Write(CommandStatusSpec.to_human_string(res.status));
			};
			result.ForeachItem(print);
		};
	}
}

} // namespace opendnp3




