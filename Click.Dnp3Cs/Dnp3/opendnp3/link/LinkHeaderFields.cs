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

public class LinkHeaderFields
{
	public LinkHeaderFields()
	{
		this.func = new opendnp3.LinkFunction.INVALID;
		this.isFromMaster = false;
		this.fcb = false;
		this.fcvdfc = false;
		this.addresses = new opendnp3.Addresses(new Addresses());
	}

	public LinkHeaderFields(LinkFunction func_, bool isMaster_, bool fcb_, bool fcvdfc_, Addresses addresses_)
	{
		this.func = new opendnp3.LinkFunction(func_);
		this.isFromMaster = isMaster_;
		this.fcb = fcb_;
		this.fcvdfc = fcvdfc_;
		this.addresses = new opendnp3.Addresses(addresses_);
	}

	public LinkFunction func;
	public bool isFromMaster;
	public bool fcb;
	public bool fcvdfc;
	public Addresses addresses = new Addresses();
}

} // namespace opendnp3



