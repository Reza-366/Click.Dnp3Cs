namespace opendnp3
{

	public class LinkContext
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public RSeq</*size_t*/int> FormatPrimaryBufferWithUnconfirmed(in Addresses addr, in RSeq</*size_t*/int> tpdu)
		{
			var buffer = this.priTxBuffer.as_wseq();
			var output = LinkFrame.FormatUnconfirmedUserData(buffer, config.IsMaster, new ushort(addr.destination), new ushort(addr.source), new RSeq</*size_t*/int>(tpdu), logger);
			if (logger.is_enabled(opendnp3.flags.Globals.LINK_TX_HEX))
			{
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::LINK_TX_HEX, output, ' ', 10, 18);
				opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.LINK_TX_HEX), output, ' ', 10, 18);
			};
			return new ser4cpp.rseq_t(output);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void QueueTransmit(in RSeq</*size_t*/int> buffer, bool primary)
		{
			if (txMode == LinkTransmitMode.Idle)
			{
				txMode = primary ? LinkTransmitMode.Primary : LinkTransmitMode.Secondary;
				linktx.BeginTransmit(buffer, *pSession);
			}
			else
			{
				if (primary)
				{
					pendingPriTx.set(buffer);
				}
				else
				{
					pendingSecTx.set(buffer);
				}
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool OnFrame(in LinkHeaderFields header, in RSeq</*size_t*/int> userdata)
		{
			if (!isOnline)
			{
				if (logger.is_enabled(opendnp3.flags.Globals.ERR))
				{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.ERR, "__FILE__ ( __LINE__ )", "Layer is not online");
				};
				return false;
			}
        
			if (header.isFromMaster == config.IsMaster)
			{
				++statistics.numBadMasterBit;
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", (header.isFromMaster ? "Master frame received for master" : "Outstation frame received for outstation"));
				};
				return false;
			}
        
			if (header.addresses.destination != config.LocalAddr && !header.addresses.IsBroadcast())
			{
				++statistics.numUnknownDestination;
				this.listener.OnUnknownDestinationAddress(header.addresses.destination);
				return false;
			}
        
			if (header.addresses.source != config.RemoteAddr && !config.respondToAnySource)
			{
				++statistics.numUnknownSource;
				this.listener.OnUnknownSourceAddress(header.addresses.source);
				return false;
			}
        
			// Broadcast addresses can only be used for sending data.
			// If confirmed data is used, no response is sent back.
			if (header.addresses.IsBroadcast() && !(header.func == LinkFunction.PRI_UNCONFIRMED_USER_DATA || header.func == LinkFunction.PRI_CONFIRMED_USER_DATA))
			{
				if (logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Received invalid function (%s) with broadcast destination address",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				++statistics.numUnexpectedFrame;
				return false;
			}
        
			// reset the keep-alive timestamp
			this.RestartKeepAliveTimer();
        
			switch (header.func)
			{
			case (LinkFunction.SEC_ACK):
				pPriState = &pPriState.OnAck(this, header.fcvdfc);
				break;
			case (LinkFunction.SEC_NACK):
				pPriState = &pPriState.OnNack(this, header.fcvdfc);
				break;
			case (LinkFunction.SEC_LINK_STATUS):
				pPriState = &pPriState.OnLinkStatus(this, header.fcvdfc);
				break;
			case (LinkFunction.SEC_NOT_SUPPORTED):
				pPriState = &pPriState.OnNotSupported(this, header.fcvdfc);
				break;
			case (LinkFunction.PRI_TEST_LINK_STATES):
				pSecState = &pSecState.OnTestLinkStatus(this, header.addresses.source, header.fcb);
				break;
			case (LinkFunction.PRI_RESET_LINK_STATES):
				pSecState = &pSecState.OnResetLinkStates(this, header.addresses.source);
				break;
			case (LinkFunction.PRI_REQUEST_LINK_STATUS):
				pSecState = &pSecState.OnRequestLinkStatus(this, header.addresses.source);
				break;
			case (LinkFunction.PRI_CONFIRMED_USER_DATA):
				pSecState = &pSecState.OnConfirmedUserData(this, header.addresses.source, header.fcb, header.addresses.IsBroadcast(), new Message(header.addresses, userdata));
				break;
			case (LinkFunction.PRI_UNCONFIRMED_USER_DATA):
				this.PushDataUp(new Message(header.addresses, userdata));
				break;
			default:
				break;
			}
        
			return true;
		}
	}
}
