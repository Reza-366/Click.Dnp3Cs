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

//#include "../../exe4cpp/asio/StrandExecutor.h"


namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class IAsyncChannel : public std::enable_shared_from_this<IAsyncChannel>, private Uncopyable
public abstract class IAsyncChannel : Uncopyable
{
	public IAsyncChannel()
	{
	}

	public override void Dispose()
	{
		base.Dispose();
	}

	public void SetCallbacks(IChannelCallbacks callbacks)
	{
		Debug.Assert(callbacks);
		this.callbacks = callbacks;
	}

	public bool BeginRead(in WSeq</*size_t*/int> buffer)
	{
		Debug.Assert(callbacks);
		if (this.CanRead())
		{
			this.reading = true;
			this.BeginReadImpl(new WSeq</*size_t*/int>(buffer));
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool BeginWrite(in RSeq</*size_t*/int> buffer)
	{
		Debug.Assert(callbacks);
		if (this.CanWrite())
		{
			this.writing = true;
			this.BeginWriteImpl(buffer);
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool Shutdown()
	{
		if (this.is_shutting_down)
		{
			return false;
		}

		this.is_shutting_down = true;

		this.ShutdownImpl();

		// keep the channel alive until it's not reading or writing
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto action = [self = this]()
		var action = () =>
		{
			self.CheckForShutdown(self);
		};

		//this->executor->post(action);

		return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool CanRead() const
	public bool CanRead()
	{
		return callbacks != null && !is_shutting_down && !reading;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool CanWrite() const
	public bool CanWrite()
	{
		return callbacks != null && !is_shutting_down && !writing;
	}

	//const std::shared_ptr<exe4cpp::StrandExecutor> executor;

	protected void OnReadCallback(in std::error_code ec, /*size_t*/int num)
	{
		this.reading = false;
		if (this.callbacks != null && !is_shutting_down)
		{
			this.callbacks.OnReadComplete(ec, new /*size_t*/int(num));
		}
	}

	protected void OnWriteCallback(in std::error_code ec, /*size_t*/int num)
	{
		this.writing = false;
		if (this.callbacks != null && !is_shutting_down)
		{
			this.callbacks.OnWriteComplete(ec, new /*size_t*/int(num));
		}
	}

	private void CheckForShutdown(IAsyncChannel self)
	{
		if (self.reading || self.writing)
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto action = [self]()
			var action = () =>
			{
				self.CheckForShutdown(self);
			};

			//self->executor->post(action);
		}
		else
		{
			self.callbacks.reset(); // drop the callbacks
		}
	}

	private IChannelCallbacks callbacks;

	private bool is_shutting_down = false;
	private bool reading = false;
	private bool writing = false;

	private abstract void BeginReadImpl(WSeq</*size_t*/int> buffer);
	private abstract void BeginWriteImpl(in RSeq</*size_t*/int> buffer);
	private abstract void ShutdownImpl();
}

} // namespace opendnp3

