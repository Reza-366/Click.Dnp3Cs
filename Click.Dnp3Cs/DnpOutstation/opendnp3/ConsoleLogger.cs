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
 * LogHandler that prints all log messages to the console
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class ConsoleLogger final : public opendnp3::ILogHandler, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class ConsoleLogger : opendnp3.ILogHandler, Uncopyable
{

	public override void log(ModuleId module, string id, LogLevel level, string location, string message)
	{
		var time = std::chrono.high_resolution_clock.now();
		var num = std::chrono.duration_cast<std::chrono.milliseconds>(time.time_since_epoch()).count();

		std::ostringstream oss = new std::ostringstream();

		oss << "ms(" << num << ") " << LogFlagToString(level);
		oss << " " << id;
		if (printLocation)
		{
			oss << " - " << location;
		}
		oss << " - " << message;

		//std::unique_lock<std::mutex> lock(mutex);
		//std::cout << oss.str() << std::endl;
		printf(oss.str().c_str());
	}

	public static opendnp3.ILogHandler Create(bool printLocation = false)
	{
		return new ConsoleLogger(printLocation);
	}

	public ConsoleLogger(bool printLocation)
	{
		this.printLocation = printLocation;
	}

	private bool printLocation;
//    std::mutex mutex; //REZA
}

} // namespace opendnp3



