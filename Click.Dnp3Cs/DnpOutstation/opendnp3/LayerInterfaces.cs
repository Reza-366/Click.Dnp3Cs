using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


namespace opendnp3
{

/**
 * Describes a layer that can be opened or closed in response to the
 * availability of the layer below it.
 */
public abstract class IUpDown : System.IDisposable
{

	public virtual void Dispose()
	{
	}

	// Called by a lower Layer when it is available to this layer
	// return false if the layer is already up
	public abstract bool OnLowerLayerUp();

	// Called by a lower layer when it is no longer available to this layer
	// return false if the layer is already down
	public abstract bool OnLowerLayerDown();
}

public abstract class IUpperLayer : IUpDown
{

	public override void Dispose()
	{
		base.Dispose();
	}

	// Called by the lower layer when data arrives
	// return false if the layer is down
	public abstract bool OnReceive(in Message message);

	// Called by the lower layer when it is ready to transmit more data
	public abstract bool OnTxReady();
}

public abstract class ILowerLayer : System.IDisposable
{

	public virtual void Dispose()
	{
	}

	public abstract bool BeginTransmit(in Message message);
}

public class HasLowerLayer
{

	public HasLowerLayer()
	{
		this.pLowerLayer = null;
	}

	// Called by the lower layer when data arrives

	public void SetLowerLayer(ILowerLayer lowerLayer)
	{
		Debug.Assert(!pLowerLayer);
		pLowerLayer = lowerLayer;
	}

	protected ILowerLayer pLowerLayer;
}

public class HasUpperLayer
{

	public HasUpperLayer()
	{
		this.pUpperLayer = null;
	}

	// Called by the lower layer when data arrives

	public void SetUpperLayer(IUpperLayer upperLayer)
	{
		Debug.Assert(!pUpperLayer);
		pUpperLayer = upperLayer;
	}

	protected IUpperLayer pUpperLayer;
}

} // namespace opendnp3

