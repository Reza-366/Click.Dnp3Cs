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





namespace opendnp3
{

/// Settings structure for the serial port
public class SerialSettings
{

	/// Defaults to the familiar 9600 8/N/1, no flow control
	public SerialSettings()
	{
		this.baud = 9600;
		this.dataBits = 8;
		this.stopBits = new opendnp3.StopBits.One;
		this.parity = new opendnp3.Parity.None;
		this.flowType = new opendnp3.FlowControl.None;
		this.asyncOpenDelay = new opendnp3.TimeDuration(TimeDuration.Milliseconds(500));
//    	 baud=(9600);
//    	          dataBits=(8);
//    	          stopBits=(StopBits::One);
//    	          parity=(Parity::None);
//    	          flowType=(FlowControl::None);
//    	          asyncOpenDelay=TimeDuration::Milliseconds(500);
	}

	/// name of the port, i.e. "COM1" or "/dev/tty0"
	public string deviceName = "";

	/// Baud rate of the port, i.e. 9600 or 57600
	public int baud;

	/// Data bits, usually 8
	public int dataBits;

	/// Stop bits, usually set to 1
	public StopBits stopBits;

	/// Parity setting for the port, usually PAR_NONE
	public Parity parity;

	/// Flow control setting, usually FLOW_NONE
	public FlowControl flowType;

	/// Some physical layers need time to "settle" so that the first tx isn't lost
	public TimeDuration asyncOpenDelay = new TimeDuration();
}

} // namespace opendnp3

