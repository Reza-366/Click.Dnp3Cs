using ser4cpp;

namespace opendnp3
{

	public class DecoderImpl
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void DecodeLPDU(in RSeq</*size_t*/int> data)
		{
			Indent i = new Indent(callbacks);
        
			RSeq</*size_t*/int> remaining = new RSeq</*size_t*/int>(data);
        
			while (remaining.is_not_empty())
			{
				var dest = this.link.WriteBuff();
        
				var NUM = (remaining.length() > dest.length()) ? dest.length() : remaining.length();
        
				dest.copy_from(remaining.take(NUM));
				link.OnRead(NUM, this);
        
				remaining.advance(NUM);
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void DecodeTPDU(in RSeq</*size_t*/int> data)
		{
			Indent i = new Indent(callbacks);
			if (logger.is_enabled(opendnp3.flags.Globals.TRANSPORT_RX))
			{
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::TRANSPORT_RX, data, ' ', 18, 18);
				opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.TRANSPORT_RX), data, ' ', 18, 18);
			};
        
			var result = transportRx.ProcessReceive(new Message(new Addresses(), data));
			if (result.payload.is_not_empty())
			{
				this.DecodeAPDU(result.payload);
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void DecodeAPDU(in RSeq</*size_t*/int> data)
		{
			Indent i = new Indent(callbacks);
        
			if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEX_RX))
			{
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: opendnp3::HexLogging::log(this->logger, flags::APP_HEX_RX, data, ' ', 18, 18);
				opendnp3.HexLogging.log(this.logger, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_HEX_RX), data, ' ', 18, 18);
			};
        
			if (IsResponse(data))
			{
				var result = APDUHeaderParser.ParseResponse(data, logger);
				if (result.success)
				{
					logging.LogHeader(this.logger, opendnp3.flags.Globals.APP_HEADER_RX, result.header);
        
					if ((result.header.IIN.LSB & 0x01) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.0 - Broadcast");
						};
					}
					if ((result.header.IIN.LSB & 0x02) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.1 - Class 1 events");
						};
					}
					if ((result.header.IIN.LSB & 0x04) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.2 - Class 2 events");
						};
					}
					if ((result.header.IIN.LSB & 0x08) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.3 - Class 3 events");
						};
					}
					if ((result.header.IIN.LSB & 0x10) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.4 - Need time");
						};
					}
					if ((result.header.IIN.LSB & 0x20) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.5 - Local control");
						};
					}
					if ((result.header.IIN.LSB & 0x40) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.6 - Device trouble");
						};
					}
					if ((result.header.IIN.LSB & 0x80) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN1.7 - Device restart");
						};
					}
					if ((result.header.IIN.MSB & 0x01) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.0 - Function code not supported");
						};
					}
					if ((result.header.IIN.MSB & 0x02) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.1 - Object unknown");
						};
					}
					if ((result.header.IIN.MSB & 0x04) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.2 - Parameter error");
						};
					}
					if ((result.header.IIN.MSB & 0x08) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.3 - Event buffer overflow");
						};
					}
					if ((result.header.IIN.MSB & 0x10) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.4 - Already executing");
						};
					}
					if ((result.header.IIN.MSB & 0x20) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.5 - Configuration corrupt");
						};
					}
					if ((result.header.IIN.MSB & 0x40) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.6 - Reserved 1");
						};
					}
					if ((result.header.IIN.MSB & 0x80) != 0)
					{
						if (this.logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_RX))
						{
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
						this.logger.log(opendnp3.flags.Globals.APP_HEADER_RX, "__FILE__ ( __LINE__ )", "IIN2.7 - Reserved 2");
						};
					}
        
					Indent i = new Indent(callbacks);
					LoggingHandler handler = new LoggingHandler(logger, callbacks);
					APDUParser.ParseSinglePass(result.objects, logger, handler, null, ParserSettings.Default());
				}
			}
			else
			{
				var result = APDUHeaderParser.ParseRequest(data, logger);
				if (result.success)
				{
					logging.LogHeader(this.logger, opendnp3.flags.Globals.APP_HEADER_RX, result.header);
        
					Indent i = new Indent(callbacks);
					LoggingHandler handler = new LoggingHandler(logger, callbacks);
					var settings = (result.header.function == FunctionCode.READ) ? ParserSettings.NoContents() : ParserSettings.Default();
					APDUParser.ParseSinglePass(result.objects, logger, handler, null, settings);
				}
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool IsResponse(in RSeq</*size_t*/int> data)
		{
			if (data.length() < 2)
			{
				return false;
			}
        
			switch (FunctionCodeSpec.from_type(data[1]))
			{
			case (FunctionCode.RESPONSE):
			case (FunctionCode.UNSOLICITED_RESPONSE):
			case (FunctionCode.AUTH_RESPONSE):
				return true;
			default:
				return false;
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public bool OnFrame(in LinkHeaderFields header, in RSeq</*size_t*/int> userdata)
		{
			if (header.func == LinkFunction.PRI_CONFIRMED_USER_DATA || header.func == LinkFunction.PRI_UNCONFIRMED_USER_DATA)
			{
				this.DecodeTPDU(userdata);
			}
        
			return true;
		}
	}
}
