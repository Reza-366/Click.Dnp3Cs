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

//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public abstract class MasterStack : IMaster, ILinkSession, ILinkTx, StackBase
{
	public MasterStack(in Logger logger, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, IOHandler iohandler, IResourceManager manager, in MasterStackConfig config) : base(logger, application, iohandler, manager, config.master.maxRxFragSize, new LinkLayerConfig(config.link, false))
	{
		this.mcontext = MContext.Create(new Addresses(config.link.LocalAddr, config.link.RemoteAddr), logger, tstack.transport, SOEHandler, application, scheduler, config.master);
		tstack.transport.SetAppLayer(mcontext);
	}

	public static MasterStack Create(in Logger logger, ISOEHandler SOEHandler, IMasterApplication application, IMasterScheduler scheduler, IOHandler iohandler, IResourceManager manager, in MasterStackConfig config)
	{
		var ret = new MasterStack(logger, SOEHandler, application, scheduler, iohandler, manager, config);

		ret.tstack.link.SetRouter(ret);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.MasterStack(ret);
	}

	// --------- Implement IStack ---------

	public override bool Enable()
	{
	//    auto action = [self = shared_from_this()] { return self->iohandler->Enable(self); };
		//return this->executor->return_from<bool>(action); //REZA
		return true;
	}

	public override bool Disable()
	{
	//    auto action = [self = shared_from_this()] { return self->iohandler->Disable(self); };
	   // return this->executor->return_from<bool>(action); //REZA
		return true;
	}

	public override void Shutdown()
	{
	//    this->PerformShutdown(shared_from_this());
	}

	public override StackStatistics GetStackStatistics()
	{
	//    auto get = [self = shared_from_this()]() -> StackStatistics { return self->CreateStatistics(); };
		//return this->executor->return_from<StackStatistics>(get); //REZA
		StackStatistics rrr = new StackStatistics();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return rrr;
		return new opendnp3.StackStatistics(rrr);
	}

	// --------- Implement ILinkSession ---------

	public override bool OnTxReady()
	{
		return this.tstack.link.OnTxReady();
	}

	public override bool OnLowerLayerUp()
	{
		return this.tstack.link.OnLowerLayerUp();
	}

	public override bool OnLowerLayerDown()
	{
		return this.tstack.link.OnLowerLayerDown();
	}

	public override bool OnFrame(in LinkHeaderFields header, in RSeq</*size_t*/int> userdata)
	{
		return this.tstack.link.OnFrame(header, userdata);
	}

	public override void BeginTransmit(in RSeq</*size_t*/int> buffer, ILinkSession context)
	{
		this.iohandler.BeginTransmit(this, buffer);
	}

	// --------- Implement IMasterOperations ---------

	public override void SetLogFilters(in LogLevels filters)
	{
	//    auto set = [self = this->shared_from_this(), filters]() { self->logger.set_levels(filters); };
	//
	//    this->executor->post(set);
	}

	public override IMasterScan AddScan(TimeDuration period, in List<Header> headers, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto builder = ConvertToLambda(headers);
	//    auto self = shared_from_this();
	//    auto add = [self, soe_handler, builder, period, config]() {
	//        return self->mcontext->AddScan(period, builder, std::move(soe_handler), config);
	//    };
		//return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(add), mcontext->scheduler);
		MasterScan rrr;
		return rrr;
	}

	public override IMasterScan AddAllObjectsScan(GroupVariationID gvId, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto self = shared_from_this();
	//    auto add = [self, soe_handler, gvId, period, config]() {
	//        return self->mcontext->AddAllObjectsScan(gvId, period, std::move(soe_handler), config);
	//    };
		//return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(add), mcontext->scheduler); //REZA
		MasterScan rrr;
		return rrr;
	}

	public override IMasterScan AddClassScan(in ClassField field, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto self = shared_from_this();
	//    auto add = [self, soe_handler, field, period, config]() {
	//        return self->mcontext->AddClassScan(field, period, std::move(soe_handler), config);
	//    };
	   // return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(add), mcontext->scheduler);
		MasterScan rrr;
		return rrr;
	}

	public override IMasterScan AddRangeScan(GroupVariationID gvId, ushort start, ushort stop, TimeDuration period, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), soe_handler, gvId, start, stop, period, config]() {
	//        return self->mcontext->AddRangeScan(gvId, start, stop, period, std::move(soe_handler), config);
	//    };
		//return MasterScan::Create(executor->return_from<std::shared_ptr<IMasterTask>>(add), mcontext->scheduler);
		MasterScan rrr;
		return rrr;
	}

	public override void Scan(in List<Header> headers, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), soe_handler, builder = ConvertToLambda(headers), config]() {
	//        return self->mcontext->Scan(builder, std::move(soe_handler), config);
	//    };
	//    return this->executor->post(add);
	}

	public override void ScanAllObjects(GroupVariationID gvId, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), soe_handler, gvId, config]() {
	//        return self->mcontext->ScanAllObjects(gvId, std::move(soe_handler), config);
	//    };
	//    return this->executor->post(add);
	}

	public override void ScanClasses(in ClassField field, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), soe_handler, field, config]() {
	//        return self->mcontext->ScanClasses(field, std::move(soe_handler), config);
	//    };
	//    return this->executor->post(add);
	}

	public override void ScanRange(GroupVariationID gvId, ushort start, ushort stop, ISOEHandler soe_handler, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), soe_handler, gvId, start, stop, config]() {
	//        return self->mcontext->ScanRange(gvId, start, stop, std::move(soe_handler), config);
	//    };
	//    return this->executor->post(add);
	}

	public override void Write(in TimeAndInterval value, ushort index, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), value, index, config]() {
	//        return self->mcontext->Write(value, index, config);
	//    };
	//    return this->executor->post(add);
	}

	public override void Restart(RestartType op, in RestartOperationCallbackT callback, TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), op, callback, config]() {
	//        return self->mcontext->Restart(op, callback, config);
	//    };
	//    return this->executor->post(add);
	}

	public override void PerformFunction(in string name, FunctionCode func, in List<Header> headers, in TaskConfig config)
	{
	//    auto add = [self = this->shared_from_this(), name, func, builder = ConvertToLambda(headers), config]() {
	//        return self->mcontext->PerformFunction(name, func, builder, config);
	//    };
	//    return this->executor->post(add);
	}

	// ------- implement ICommandProcessor ---------

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public override void SelectAndOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config)
	{
		/// this is to work around the fact that c++11 doesn't have generic move capture
	//    auto set = std::make_shared<CommandSet>(std::move(commands));
	//
	//    auto action = [self = this->shared_from_this(), set, config, callback]() {
	//        self->mcontext->SelectAndOperate(std::move(*set), callback, config);
	//    };
	//
	//    this->executor->post(action);
	}

//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public override void DirectOperate(CommandSet && commands, in CommandResultCallbackT callback, in TaskConfig config)
	{
		/// this is to work around the fact that c++11 doesn't have generic move capture
	//    auto set = std::make_shared<CommandSet>(std::move(commands));
	//
	//    auto action = [self = this->shared_from_this(), set, config, callback]() {
	//        self->mcontext->DirectOperate(std::move(*set), callback, config);
	//    };
	//
	//    this->executor->post(action);
	}

	protected MContext mcontext;
}

} // namespace opendnp3




