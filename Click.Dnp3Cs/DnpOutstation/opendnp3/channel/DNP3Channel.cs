using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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

public sealed class DNP3Channel : IChannel
{

	public DNP3Channel(in Logger logger, IOHandler iohandler, IResourceManager manager)
	{
		this.logger = new opendnp3.Logger(logger);
		this.scheduler = new MasterSchedulerBackend();
		this.iohandler = std::move(iohandler);
		this.manager = std::move(manager);
		this.resources = ResourceManager.Create();
	}

	public static DNP3Channel Create(in Logger logger, IOHandler iohandler, IResourceManager manager)
	{
		return new DNP3Channel(logger, iohandler, manager);
	}

	public new void Dispose()
	{
		this.ShutdownImpl();
		base.Dispose();
	}

	// ----------------------- Implement IChannel -----------------------


	// comes from the outside, so we need to post
	public override void Shutdown()
	{
		ShutdownImpl();
		//auto shutdown = [self = shared_from_this()]() { self->ShutdownImpl(); };
		//this->executor->block_until_and_flush(shutdown); //REZA
	}

	//LinkStatistics GetStatistics() final;


	//LinkStatistics DNP3Channel::GetStatistics()
	//{
	//    //auto get = [this]() { return this->iohandler->Statistics(); };
	//    //return this->executor->return_from<LinkStatistics>(get); //REZA
	//    //LinkStatistics rrr;
	//    return statics;
	//}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LogLevels GetLogFilters() const
	public override LogLevels GetLogFilters()
	{
	   // auto get = [this]() { return this->logger.get_levels(); };
		//return this->executor->return_from<LogLevels>(get); //REZA
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->logger.get_levels();
		return new opendnp3.LogLevels(this.logger.get_levels());
	}

	public override void SetLogFilters(in LogLevels filters)
	{
		//auto set = [self = this->shared_from_this(), filters]() { self->logger.set_levels(filters); };
		//this->executor->post(set);
		logger.set_levels(filters);
	}

	public override IMaster AddMaster(in string id, ISOEHandler SOEHandler, IMasterApplication application, in MasterStackConfig config)
	{
		var stack = MasterStack.Create(this.logger.detach(id), SOEHandler, application, this.scheduler, this.iohandler, this.resources, config);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->AddStack(config.link, stack);
		return new opendnp3.MasterStack(this.AddStack(config.link, stack));
	}

	public override IOutstation AddOutstation(in string id, ICommandHandler commandHandler, IOutstationApplication application, in OutstationStackConfig config)
	{
		var stack = OutstationStack.Create(this.logger.detach(id), commandHandler, application, this.iohandler, this.resources, config);
		//auto s = this->AddStack(config.link, stack);
		OutstationStacks.Add(stack);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return stack;
		return new opendnp3.OutstationStack(stack);

		//outstationStack = stack;
		//return outstationStack;
	}

	public List< OutstationStack> OutstationStacks = new List< OutstationStack>();

	private void ShutdownImpl()
	{
		if (this.resources == null)
		{
			return;
		}

		// shutdown the IO handler
		this.iohandler.Shutdown();
		this.iohandler.reset();

		this.scheduler.Shutdown();
		this.scheduler.reset();

		// shutdown any remaining stacks
		this.resources.Shutdown();
		this.resources.reset();

		// posting ensures that we run this after
		// and callbacks created by calls above
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto detach = [self = this]
		var detach = () =>
		{
			self.manager.Detach(self);
			self.manager.reset();
		};

		//this->executor->post(detach);
	}

	// ----- generic method for adding a stack ------
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private T AddStack<T>(in LinkConfig link, T stack)
	{
		//REZA Simplified
		Addresses route = new Addresses(link.RemoteAddr, link.LocalAddr);
		var self = this.this;
		var result = self.iohandler.AddContext(stack, route);
		return this.resources.Bind<T>(stack);


	   //     auto create = [stack, route = Addresses(link.RemoteAddr, link.LocalAddr), self = this->shared_from_this()]() {
	   //     auto add = [stack, route, self]() -> bool { return self->iohandler->AddContext(stack, route); };
	   //     //return self->executor->return_from<bool>(add) ? stack : nullptr;
	   //     //return self->return_from<bool>(add) ? stack : nullptr;
	   //     add();
	   //};
	   //     create();
	   // return this->resources->Bind<T>(create);

	}

	private Logger logger = new Logger();
	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private IMasterScheduler scheduler;
	private IOHandler iohandler;
	private IResourceManager manager;
	private ResourceManager resources;
}

} // namespace opendnp3


//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define STRINGIFY(x) #x
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define TOSTRING(x) STRINGIFY(x)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOCATION __FILE__ "(" TOSTRING(__LINE__) ")"
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, length_, format, ...) _snprintf_s(dest, length_, _TRUNCATE, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, size, format, ...) snprintf(dest, size, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOG_FORMAT(logger, levels, format, ...) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOG_BLOCK(logger, levels, message) if (logger.is_enabled(levels)) { logger.log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOGGER_BLOCK(pLogger, levels, message) if (pLogger && pLogger->is_enabled(levels)) { pLogger->log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOG_BLOCK(logger, levels, format, ...) if (logger.is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOGGER_BLOCK(pLogger, levels, format, ...) if (pLogger && pLogger->is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); pLogger->log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_HEX_BLOCK(logger, levels, buffer, firstSize, otherSize) if (logger.is_enabled(levels)) { opendnp3::HexLogging::log(logger, levels, buffer, ' ', firstSize, otherSize); }

