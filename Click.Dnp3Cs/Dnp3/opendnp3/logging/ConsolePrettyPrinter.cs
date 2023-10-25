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


namespace opendnp3
{

/**
 * pretty prints log messages
 */
public sealed class ConsolePrettyPrinter : opendnp3.ILogHandler
{
	public class Settings
	{
		public Settings()
		{
		}

		public bool printId = true;
		public size_t max_id_size = 10;
	}

	public ConsolePrettyPrinter(in Settings settings = new Settings())
	{
		this.settings = new opendnp3.ConsolePrettyPrinter.Settings(settings);
	}

	public override void log(opendnp3.ModuleId module, string id, opendnp3.LogLevel level, string location, string message)
	{
		var now = std::chrono.high_resolution_clock.now();
		var millis = std::chrono.duration_cast<std::chrono.milliseconds>(now.time_since_epoch()).count();

		std::ostringstream oss = new std::ostringstream();

		oss << "ms(" << millis << ") ";

		string id_str = id;

		if (id_str.Length > settings.max_id_size)
		{
			id_str = id_str.Substring(0, settings.max_id_size);
		}
		else if (id_str.Length << settings.max_id_size)
		{
			id_str = id_str + new string(settings.max_id_size - id_str.Length, ' ');
		}

		if (settings.printId)
		{
			oss << id_str << " ";
		}

		oss << get_prefix(new int32_t(level.value)) << message;

		Console.Write(oss.str());
		Console.WriteLine();
	}

	private readonly Settings settings = new Settings();

	private static string get_prefix(int level)
	{
		switch (level)
		{
		case (1 << 0):
			return "event   ";
		case (1 << 1):
			return "error   ";
		case (1 << 2):
			return "warn    ";
		case (1 << 3):
			return "info    ";
		case (1 << 4):
			return "debug   ";
		case (1 << 5):
			return "<--     ";
		case (1 << 6):
			return "-->     ";
		default:
			return "            ";
		}
	}
}

} // namespace opendnp3

