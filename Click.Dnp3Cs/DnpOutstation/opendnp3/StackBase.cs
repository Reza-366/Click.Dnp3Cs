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

//#include "../exe4cpp/asio/StrandExecutor.h"


namespace opendnp3
{

/**
 * Base class for masters or outstations
 */
public class StackBase
{

	protected StackBase(in Logger logger, ILinkListener listener, IOHandler iohandler, IResourceManager manager, uint maxRxFragSize, in LinkLayerConfig config)
	{
		this.logger = new opendnp3.Logger(logger);
		this.iohandler = iohandler;
		this.manager = manager;
		this.tstack = new opendnp3.TransportStack(logger, listener, maxRxFragSize, config);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: StackStatistics CreateStatistics() const
	protected StackStatistics CreateStatistics()
	{
		return new StackStatistics(tstack.link.GetStatistics(), tstack.transport.GetStatistics());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	protected void PerformShutdown<T>(T self)
	{
		//auto shutdown = [self] {
		//    self->iohandler->Remove(self);

		//    // since posting to a strand from the strand is ordered, posting
		//    // this forces the MasterStack to hang around long enough for
		//    // any previously submitted post operations on the strand to complete
		//    auto detach = [self]() { self->manager->Detach(self); };
		//    self->executor->post(detach);
		//};
		// this->executor->block_until_and_flush(shutdown); //REZA
		//REZA
		//shutdown();
	}

	protected Logger logger = new Logger();
	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	protected readonly IOHandler iohandler;
	protected readonly IResourceManager manager;
	protected TransportStack tstack = new TransportStack();
}
} // namespace opendnp3

