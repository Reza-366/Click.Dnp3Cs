namespace opendnp3
{

	public class LinkFrame
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatAck(ser4cpp.wseq_t buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, false, aIsRcvBuffFull, LinkFunction.SEC_ACK, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatNack(ser4cpp.wseq_t buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, false, aIsRcvBuffFull, LinkFunction.SEC_NACK, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatLinkStatus(ser4cpp.wseq_t buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, false, aIsRcvBuffFull, LinkFunction.SEC_LINK_STATUS, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatNotSupported(ser4cpp.wseq_t buffer, bool aIsMaster, bool aIsRcvBuffFull, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, false, aIsRcvBuffFull, LinkFunction.SEC_NOT_SUPPORTED, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatResetLinkStates(ser4cpp.wseq_t buffer, bool aIsMaster, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, false, false, LinkFunction.PRI_RESET_LINK_STATES, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatRequestLinkStatus(ser4cpp.wseq_t buffer, bool aIsMaster, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, false, false, LinkFunction.PRI_REQUEST_LINK_STATUS, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatTestLinkStatus(ser4cpp.wseq_t buffer, bool aIsMaster, bool aFcb, ushort aDest, ushort aSrc, Logger pLogger)
		{
			return FormatHeader(buffer, 0, aIsMaster, aFcb, true, LinkFunction.PRI_TEST_LINK_STATES, aDest, aSrc, pLogger);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatConfirmedUserData(ser4cpp.wseq_t buffer, bool aIsMaster, bool aFcb, ushort aDest, ushort aSrc, ser4cpp.rseq_t user_data, Logger pLogger)
		{
			if (user_data.length() > LPDU_MAX_USER_DATA_SIZE)
			{
				return ser4cpp.rseq_t.empty();
			}
        
			var userDataSize = CalcUserDataSize(user_data.length());
			var ret = buffer.@readonly().take(userDataSize + LPDU_HEADER_SIZE);
			FormatHeader(buffer, (byte)user_data.length(), aIsMaster, aFcb, true, LinkFunction.PRI_CONFIRMED_USER_DATA, aDest, aSrc, pLogger);
			WriteUserData(user_data, buffer, user_data.length());
			buffer.advance(userDataSize);
			return ret;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatUnconfirmedUserData(ser4cpp.wseq_t buffer, bool aIsMaster, ushort aDest, ushort aSrc, ser4cpp.rseq_t user_data, Logger pLogger)
		{
			if (user_data.length() > LPDU_MAX_USER_DATA_SIZE)
			{
				return ser4cpp.rseq_t.empty();
			}
        
			var userDataSize = CalcUserDataSize(user_data.length());
			var ret = buffer.@readonly().take(userDataSize + LPDU_HEADER_SIZE);
			FormatHeader(buffer, (byte)user_data.length(), aIsMaster, false, false, LinkFunction.PRI_UNCONFIRMED_USER_DATA, aDest, aSrc, pLogger);
			WriteUserData(user_data, buffer, user_data.length());
			buffer.advance(userDataSize);
			return ret;
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.rseq_t FormatHeader(ser4cpp.wseq_t buffer, byte aDataLength, bool aIsMaster, bool aFcb, bool aFcvDfc, LinkFunction aFuncCode, ushort aDest, ushort aSrc, Logger pLogger)
		{
			if (buffer.length() < LPDU_HEADER_SIZE)
			{
				return ser4cpp.rseq_t.empty();
			}
        
			LinkHeader header = new LinkHeader(aDataLength + LPDU_MIN_LENGTH, aSrc, aDest, aIsMaster, aFcvDfc, aFcb, aFuncCode);
        
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.LINK_TX))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Function: %s Dest: %u Source: %u Length: %u",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.LINK_TX, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
        
			header.Write(new ser4cpp.wseq_t(buffer));
			var ret = buffer.@readonly().take(10);
			buffer.advance(10);
			return ret;
		}
	}
}
