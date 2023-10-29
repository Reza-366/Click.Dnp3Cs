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

//#include "../../exe4cpp/asio/StrandExecutor.h"


namespace opendnp3
{

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class LinkSession;

/**
 * Interface that represents an ephemeral master session
 */
public sealed partial class MasterSessionStack : IMasterSession
{
	public static MasterSessionStack Create(in Logger logger, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, LinkSession session, ILinkTx linktx, in MasterStackConfig config)
	{
		return new MasterSessionStack(logger, SOEHandler, application, scheduler, session, linktx, config);
	}

	public void OnLowerLayerUp()
	{
		stack.link.OnLowerLayerUp();
	}

	public void OnLowerLayerDown()
	{
		stack.link.OnLowerLayerDown();
	}

	public bool OnFrame(in LinkHeaderFields header, in RSeq/*<size_t>*/ userdata)
	{
		return stack.link.OnFrame(header, userdata);
	}

	public void OnTxReady()
	{
		this.stack.link.OnTxReady();
	}

	public override void SetLogFilters(in LogLevels filters)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto set = [this, filters]()
		var set = () =>
		{
			this.session.SetLogFilters(filters);
		};
		//this->executor->post(set);
	}

	/// --- IGPRSMaster ---

	public override void BeginShutdown()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto shutdown = [this]()
		var shutdown = () =>
		{
			if (scheduler != null)
			{
				scheduler.Shutdown();
				scheduler.reset();
			}

			// now we can release the socket session
			if (session != null)
			{
				session.Shutdown();
				session.reset();
			}
		};

		//executor->post(shutdown);
	}

	/// --- ICommandOperations ---

	public override StackStatistics GetStackStatistics()
	{
		//auto get = [self = shared_from_this()]() -> StackStatistics { return self->CreateStatistics(); };
		//return executor->return_from<StackStatistics>(get);//REZA
		StackStatistics stat = new StackStatistics();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return stat;
		return new opendnp3.StackStatistics(stat);
	}

	public override IMasterScan AddScan(TimeDuration period, in List<Header> headers, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto builder = ConvertToLambda(headers);
	//    auto get = [self = shared_from_this(), soe_handler, period, builder, config]() {
	//        return self->context->AddScan(period, builder, std::move(soe_handler), config);
	//    };
		//return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(get), this->scheduler);
		IMasterScan rrr;
		return rrr;
	}

	public override IMasterScan AddAllObjectsScan(GroupVariationID gvId, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto get = [self = shared_from_this(), soe_handler, gvId, period, config] {
	//        return self->context->AddAllObjectsScan(gvId, period, std::move(soe_handler), config);
	//    };
		//return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(get), this->scheduler);
		IMasterScan rrr;
		return rrr;
	}

	public override IMasterScan AddClassScan(in ClassField field, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto get = [self = shared_from_this(), soe_handler, field, period, config] {
	//        return self->context->AddClassScan(field, period, std::move(soe_handler), config);
	//    };
		//    return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(get), this->scheduler);
		IMasterScan rrr;
		return rrr;
	}

	public override IMasterScan AddRangeScan(GroupVariationID gvId, ushort start, ushort stop, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto get = [self = shared_from_this(), soe_handler, gvId, start, stop, period, config] {
	//        return self->context->AddRangeScan(gvId, start, stop, period, std::move(soe_handler), config);
	//    };
	   // return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(get), this->scheduler);
		IMasterScan rrr;
		return rrr;
	}

	public override void Scan(in List<Header> headers, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto builder = ConvertToLambda(headers);
	//    auto action = [self = shared_from_this(), soe_handler, builder, config]() -> void {
	//        self->context->Scan(builder, std::move(soe_handler), config);
	//    };
	//    return executor->post(action);
	}

	public override void ScanAllObjects(GroupVariationID gvId, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto action = [self = shared_from_this(), soe_handler, gvId, config]() -> void {
	//        self->context->ScanAllObjects(gvId, std::move(soe_handler), config);
	//    };
	//    return executor->post(action);
	}

	public override void ScanClasses(in ClassField field, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto action = [self = shared_from_this(), soe_handler, field, config]() -> void {
	//        self->context->ScanClasses(field, std::move(soe_handler), config);
	//    };
	//    return executor->post(action);
	}

	public override void ScanRange(GroupVariationID gvId, ushort start, ushort stop, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto action = [self = shared_from_this(), soe_handler, gvId, start, stop, config]() -> void {
	//        self->context->ScanRange(gvId, start, stop, std::move(soe_handler), config);
	//    };
	//    return executor->post(action);
	}

	public override void Write(in TimeAndInterval value, ushort index, in TaskConfig config)
	{
	//    auto action
	//        = [self = shared_from_this(), value, index, config]() -> void { self->context->Write(value, index, config); };
	//    return executor->post(action);
	}

	public override void Restart(RestartType op, in RestartOperationCallbackT callback, TaskConfig config)
	{
	//    auto action
	//        = [self = shared_from_this(), op, callback, config]() -> void { self->context->Restart(op, callback, config); };
	//    return executor->post(action);
	}

	public override void PerformFunction(in string name, FunctionCode func, in List<Header> headers, in TaskConfig config)
	{
	//    auto builder = ConvertToLambda(headers);
	//    auto action = [self = shared_from_this(), name, func, builder, config]() -> void {
	//        self->context->PerformFunction(name, func, builder, config);
	//    };
	//    return executor->post(action);
	}

	/// --- ICommandProcessor ---


	/// --- ICommandProcessor ---

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public override void SelectAndOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config)
	{
		// this is required b/c move capture not supported in C++11
	//    auto set = std::make_shared<CommandSet>(std::move(commands));
	//
	//    auto action = [self = shared_from_this(), set, config, callback]() -> void {
	//        self->context->SelectAndOperate(std::move(*set), callback, config);
	//    };
	//    executor->post(action);
	}

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public override void DirectOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config)
	{
		// this is required b/c move capture not supported in C++11
	//    auto set = std::make_shared<CommandSet>(std::move(commands));
	//
	//    auto action = [self = shared_from_this(), set, config, callback]() -> void {
	//        self->context->DirectOperate(std::move(*set), callback, config);
	//    };
	//    executor->post(action);
	}

	public MasterSessionStack(in Logger logger, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, LinkSession session, ILinkTx linktx, in MasterStackConfig config)
	{
		this.scheduler = scheduler;
		this.session = std::move(session);
		this.stack = new opendnp3.TransportStack(logger, application, config.master.maxRxFragSize, new LinkLayerConfig(config.link, false));
		this.context = MContext.Create(new Addresses(config.link.LocalAddr, config.link.RemoteAddr), logger, stack.transport, SOEHandler, application, scheduler, config.master);
		stack.link.SetRouter(linktx);
		stack.transport.SetAppLayer(context);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: StackStatistics CreateStatistics() const
	private StackStatistics CreateStatistics()
	{
		//return StackStatistics(this->stack.link->GetStatistics(), this->stack.transport->GetStatistics());
		StackStatistics rrr = new StackStatistics();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return rrr;
		return new opendnp3.StackStatistics(rrr);
	}

	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private IMasterScheduler scheduler;
	private LinkSession session;
	private TransportStack stack = new TransportStack();
	private MContext context;
}

} // namespace opendnp3



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

//#include "../../exe4cpp/asio/StrandExecutor.h"


namespace opendnp3
{

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class LinkSession;

/**
 * Interface that represents an ephemeral master session
 */
public sealed partial class MasterSessionStack : IMasterSession
{
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static MasterSessionStack Create(in Logger logger, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, LinkSession session, ILinkTx linktx, in MasterStackConfig config);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void OnLowerLayerUp();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void OnLowerLayerDown();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool OnFrame(in LinkHeaderFields header, in RSeq/*<size_t>*/ userdata);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void OnTxReady();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void SetLogFilters(in opendnp3::LogLevels filters);

	/// --- IGPRSMaster ---

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void BeginShutdown();

	/// --- ICommandOperations ---

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed StackStatistics GetStackStatistics();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed IMasterScan AddScan(TimeDuration period, in System.Collections.Generic.List<Header> headers, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed IMasterScan AddAllObjectsScan(GroupVariationID gvId, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed IMasterScan AddClassScan(in ClassField field, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed IMasterScan AddRangeScan(GroupVariationID gvId, ushort start, ushort stop, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void Scan(in System.Collections.Generic.List<Header> headers, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void ScanAllObjects(GroupVariationID gvId, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void ScanClasses(in ClassField field, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void ScanRange(GroupVariationID gvId, ushort start, ushort stop, ISOEHandler soe_handler, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void Write(in TimeAndInterval value, ushort index, in TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void Restart(RestartType op, in RestartOperationCallbackT callback, TaskConfig config);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void PerformFunction(in string name, FunctionCode func, in System.Collections.Generic.List<Header> headers, in TaskConfig config);

	/// --- ICommandProcessor ---

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void SelectAndOperate(CommandSet&& commands, in CommandResultCallbackT callback, in TaskConfig config);
//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	sealed void DirectOperate(CommandSet&& commands, in CommandResultCallbackT callback, in TaskConfig config);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	MasterSessionStack(in Logger logger, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, LinkSession session, ILinkTx linktx, in MasterStackConfig config);

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: StackStatistics CreateStatistics() const;
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	StackStatistics CreateStatistics();

	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;
	private IMasterScheduler scheduler;
	private LinkSession session;
	private TransportStack stack = new TransportStack();
	private MContext context;
}

} // namespace opendnp3



