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



//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include "ILinkContextPars.h"

namespace opendnp3
{


//	@section desc Implements the contextual state of DNP3 Data Link Layer
public class LinkContextPars : ILinkContextPars
{
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	LinkContextPars(in Logger logger, IUpperLayer UnnamedParameter, ILinkListener UnnamedParameter2, ILinkSession session, in LinkLayerConfig UnnamedParameter3);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static LinkContextPars Create(in Logger logger, IUpperLayer UnnamedParameter, ILinkListener UnnamedParameter2, ILinkSession session, in LinkLayerConfig UnnamedParameter3);

	// ---- helpers for dealing with the FCB bits ----

	public void ResetReadFCB()
	{
		nextReadFCB = true;
	}
	public void ToggleReadFCB()
	{
		nextReadFCB = !nextReadFCB;
	}

	// --- helpers for dealing with layer state transitations ---
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool OnLowerLayerUp();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool OnLowerLayerDown();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool OnTxReady();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool SetTxSegment(ITransportSegment segments);

	// --- helpers for formatting user data messages ---
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	ser4cpp::RSeq FormatPrimaryBufferWithUnconfirmed(in Addresses addr, in ser4cpp::RSeq tpdu);

	// --- Helpers for queueing frames ---
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void QueueAck(ushort destination);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void QueueLinkStatus(ushort destination);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void QueueRequestLinkStatus(ushort destination);

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void QueueTransmit(in ser4cpp::RSeq buffer, bool primary);

	// --- public members ----

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void PushDataUp(in Message message);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void CompleteSendOperation();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void TryStartTransmission();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void OnKeepAliveTimeout();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void OnResponseTimeout();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void StartResponseTimer();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void RestartKeepAliveTimer();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void CancelTimer();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void FailKeepAlive(bool timeout);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void CompleteKeepAlive();
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool OnFrame(in LinkHeaderFields header, in ser4cpp::RSeq userdata);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool TryPendingTx(ser4cpp::Settable<ser4cpp::RSeq> pending, bool primary);

	// buffers used for primary and secondary requests
	//ser4cpp::StaticBuffer<LPDU_MAX_FRAME_SIZE> priTxBuffer;
	//ser4cpp::StaticBuffer<LPDU_HEADER_SIZE> secTxBuffer;

	//ser4cpp::Settable<ser4cpp::RSeq> pendingPriTx;
	//ser4cpp::Settable<ser4cpp::RSeq> pendingSecTx;

	//Logger logger;
	//const LinkLayerConfig config;
	//ITransportSegment* pSegments;
	//LinkTransmitMode txMode;


	//exe4cpp::Timer rspTimeoutTimer;
	//exe4cpp::Timer keepAliveTimer;
	//bool nextReadFCB;
	//bool isOnline;
	//bool keepAliveTimeout;
	//Timestamp lastMessageTimestamp;
	//StackStatistics::Link statistics;

	//ILinkTx* linktx = nullptr;

	//PriStateBase* pPriState;
	//SecStateBase* pSecState;

	//const std::shared_ptr<ILinkListener> listener;
	//const std::shared_ptr<IUpperLayer> upper;

	//ILinkSession* pSession;
}

} // namespace opendnp3

