﻿/*
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
 * Transactional interface that receives events
 */
public abstract class IEventReceiver : System.IDisposable
{
	public virtual void Dispose()
	{
	}

	public abstract void Update(in Event<BinarySpec> evt);

	public abstract void Update(in Event<DoubleBitBinarySpec> evt);

	public abstract void Update(in Event<AnalogSpec> evt);

	public abstract void Update(in Event<CounterSpec> evt);

	public abstract void Update(in Event<FrozenCounterSpec> evt);

	public abstract void Update(in Event<BinaryOutputStatusSpec> evt);

	public abstract void Update(in Event<AnalogOutputStatusSpec> evt);

	public abstract void Update(in Event<OctetStringSpec> evt);
}

} // namespace opendnp3

