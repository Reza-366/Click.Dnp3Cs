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


//#include "../../exe4cpp/IExecutor.h"

namespace opendnp3
{

/**
 * A stack object for an outstation
 */
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public static class OutstationStack : IOutstation, ILinkSession, ILinkTx, StackBase
{
	public OutstationStack(in Logger logger, ICommandHandler commandHandler, IOutstationApplication application, IOHandler iohandler, IResourceManager manager, in OutstationStackConfig config) : base(logger, application, iohandler, manager, config.outstation.@params.maxRxFragSize, new LinkLayerConfig(config.link, config.outstation.@params.respondToAnyMaster))
	{
		this.ocontext = new opendnp3.OContext(new Addresses(config.link.LocalAddr, config.link.RemoteAddr), config.outstation, config.database, logger, tstack.transport, commandHandler, application);
		this.tstack.transport.SetAppLayer(ocontext);
	}

	public static OutstationStack Create(in Logger logger, ICommandHandler commandHandler, IOutstationApplication application, IOHandler iohandler, IResourceManager manager, in OutstationStackConfig config)
	{
		var ret = new OutstationStack(logger, commandHandler, application, iohandler, manager, config);

		ret.tstack.link.SetRouter(ret);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.OutstationStack(ret);
	}

	// --------- Implement IStack ---------

	public override bool Enable()
	{

		return this.iohandler.Enable(this);
		//auto action = [self = shared_from_this()] { return self->iohandler->Enable(self); };
		//return action();

		//return this->executor->return_from<bool>(action);//REZA
		//return true;
	}

	public override bool Disable()
	{
		var self = this;
		return self.iohandler.Disable(self);

		//auto action = [self = shared_from_this()] { return self->iohandler->Disable(self); };
		//return action();

		//return this->executor->return_from<bool>(action); //REZA
	}

	public override void Shutdown()
	{
		var self = this;
		self.PerformShutdown(self);
	}

	public override StackStatistics GetStackStatistics()
	{

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->CreateStatistics();
		return new opendnp3.StackStatistics(this.CreateStatistics());

		//auto get = [self = shared_from_this()] { return self->CreateStatistics(); };
		//return get();
		//return this->executor->return_from<StackStatistics>(get);
	}

	// --------- Implement ILinkSession ---------

	public override sealed bool OnTxReady()
	{
		return this.tstack.link.OnTxReady();
	}

	public override sealed bool OnLowerLayerUp()
	{
		return this.tstack.link.OnLowerLayerUp();
	}

	public override sealed bool OnLowerLayerDown()
	{
		return this.tstack.link.OnLowerLayerDown();
	}

	public override sealed bool OnFrame(in LinkHeaderFields header, in RSeq/*<size_t>*/ userdata)
	{
		return this.tstack.link.OnFrame(header, userdata);
	}

	public override sealed void BeginTransmit(in RSeq/*<size_t>*/ buffer, ILinkSession context)
	{
		this.iohandler.BeginTransmit(this, buffer);
	}

	// --------- Implement IOutstation ---------

	public override void SetLogFilters(in LogLevels filters)
	{

		this.logger.set_levels(filters);

		//auto set = [self = this->shared_from_this(), filters]() { self->logger.set_levels(filters); };
		//this->executor->post(set);
		//set();
	}

	public override void SetRestartIIN()
	{
		// this doesn't need to be synchronous, just post it
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto set = [self = this->this]()
	  var set = () =>
	  {
		  self.ocontext.SetRestartIIN();
	  };
	   // this->executor->post(set);
	  set();
	}

	public override void Apply(in Updates updates)
	{
		if (updates.IsEmpty())
		{
			return;
		}

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto task = [self = this->this, updates]()
		var task = () =>
		{
			updates.Apply(self.ocontext.GetUpdateHandler());
			self.ocontext.HandleNewEvents(); // force the outstation to check for updates
		};
		task();
		//this->executor->post(task);
	}

	private OContext ocontext = new OContext();
}

} // namespace opendnp3



