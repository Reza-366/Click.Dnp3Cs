using System.Diagnostics;

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

//	@section desc Implements the contextual state of DNP3 Data Link Layer
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class LinkLayer : ILinkLayer, ILinkSession
{

	public LinkLayer(in Logger logger, IUpperLayer upper, ILinkListener listener, in LinkLayerConfig config)
	{
		this.ctx = LinkContext.Create(logger, upper, listener, this, config);
	}

	public void SetRouter(ILinkTx router)
	{
		Debug.Assert(!ctx.linktx);
		ctx.linktx = router;
	}

	// ---- Events from below: ILinkSession / IFrameSink  ----


	////////////////////////////////
	// ILinkSession
	////////////////////////////////

	public override bool OnLowerLayerUp()
	{
		return ctx.OnLowerLayerUp();
	}

	public override bool OnLowerLayerDown()
	{
		return ctx.OnLowerLayerDown();
	}

	public override bool OnTxReady()
	{
		var ret = ctx.OnTxReady();

		if (ret)
		{
			ctx.TryStartTransmission();
		}

		return true;
	}


	////////////////////////////////
	// IFrameSink
	////////////////////////////////

	public override bool OnFrame(in LinkHeaderFields header, in ser4cpp.rseq_t userdata)
	{
		var ret = this.ctx.OnFrame(header, userdata);

		if (ret)
		{
			this.ctx.TryStartTransmission();
		}

		return ret;
	}

	// ---- Events from above: ILinkLayer ----


	////////////////////////////////
	// ILowerLayer
	////////////////////////////////

	public override bool Send(ITransportSegment segments)
	{
		if (!ctx.isOnline)
		{
			return false;
		}

		if (ctx.SetTxSegment(segments))
		{
			ctx.TryStartTransmission();
		}

		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const StackStatistics::Link& GetStatistics() const
	public StackStatistics.Link GetStatistics()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ctx->statistics;
		return new opendnp3.StackStatistics.Link(this.ctx.statistics);
	}

	// The full state
	private LinkContext ctx; //std::shared_ptr<LinkContext> ctx;

}

} // namespace opendnp3



