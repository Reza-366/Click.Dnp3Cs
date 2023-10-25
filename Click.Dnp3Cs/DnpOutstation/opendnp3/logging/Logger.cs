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
 * A copyable facade over a LogRoot class
 */
public class Logger
{
	public class Settings
	{
		public Settings(ModuleId module, in string id, LogLevels levels)
		{
			this.module = new opendnp3.ModuleId(module);
			this.id = id;
			this.levels = new opendnp3.LogLevels(levels);
		}

		public ModuleId module = new ModuleId();
		public string id = "";
		public LogLevels levels = new LogLevels();
	}

	public Logger(ILogHandler backend, ModuleId moduleid, in string id, LogLevels levels)
	{
		this.backend = backend;
		this.settings = new Settings(moduleid, id, levels);
	}

	public static Logger empty()
	{
		return new Logger(null, new ModuleId(0), "", new LogLevels(0));
	}

	public void log(in LogLevel level, string location, string message)
	{
		if (backend != null)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: backend->log(this->settings->module, this->settings->id.c_str(), level, location, message);
			backend.log(new opendnp3.ModuleId(this.settings.module), this.settings.id, new opendnp3.LogLevel(level), location, message);
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Logger detach(const string& id) const
	public Logger detach(in string id)
	{
		return new Logger(this.backend, new Settings(this.settings.module, id, this.settings.levels));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Logger detach(const string& id, LogLevels levels) const
	public Logger detach(in string id, LogLevels levels)
	{
		return new Logger(this.backend, new Settings(this.settings.module, id, levels));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Logger detach(LogLevels levels) const
	public Logger detach(LogLevels levels)
	{
		return new Logger(this.backend, new Settings(this.settings.module, this.settings.id, levels));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool is_enabled(const LogLevel& level) const
	public bool is_enabled(in LogLevel level)
	{
		return backend != null && settings.levels.is_set(level);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LogLevels get_levels() const
	public LogLevels get_levels()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->settings->levels;
		return new opendnp3.LogLevels(this.settings.levels);
	}

	public void set_levels(in LogLevels filters)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->settings->levels = filters;
		this.settings.levels.CopyFrom(filters);
	}

	public void rename(in string id)
	{
		this.settings.id = id;
	}

	private Logger(ILogHandler backend, Settings settings)
	{
		this.backend = backend;
		this.settings = settings;
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	Logger() = delete;
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	Logger& operator =(const Logger&) = delete;

	private readonly ILogHandler backend;
	private readonly Settings settings;
}

} // namespace opendnp3

