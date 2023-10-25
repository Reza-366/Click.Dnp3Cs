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


namespace opendnp3
{

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class DecoderImpl;

// stand-alone DNP3 decoder
public class Decoder : System.IDisposable
{
	public Decoder(IDecoderCallbacks callbacks, in Logger logger)
	{
		this.impl = new DecoderImpl(callbacks, logger);
	}

	public void Dispose()
	{
		if (impl != null)
		{
			impl.Dispose();
		}
	}

	public void DecodeLPDU(in Buffer data)
	{
		ser4cpp.rseq_t rseqData = new ser4cpp.rseq_t(data.data, data.length);
		impl.DecodeLPDU(rseqData);
	}

	public void DecodeTPDU(in Buffer data)
	{
		ser4cpp.rseq_t rseqData = new ser4cpp.rseq_t(data.data, data.length);
		impl.DecodeTPDU(rseqData);
	}

	public void DecodeAPDU(in Buffer data)
	{
		ser4cpp.rseq_t rseqData = new ser4cpp.rseq_t(data.data, data.length);
		impl.DecodeAPDU(rseqData);
	}

	private DecoderImpl impl;
}

} // namespace opendnp3




