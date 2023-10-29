namespace opendnp3
{

	public class OContext
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public void BeginTx(ushort destination, in ser4cpp.RSeq message)
		{
			logging.ParseAndLogResponseTx(this.logger, message);
			this.isTransmitting = true;
			this.lower.BeginTransmit(new Message(new Addresses(this.addresses.source, destination), message));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public OutstationState ContinueMultiFragResponse(in Addresses addresses, in SequenceNum<byte, 16> seq)
		{
			var response = this.sol.tx.Start();
			var writer = response.GetWriter();
			response.SetFunction(FunctionCode.RESPONSE);
			var control = this.rspContext.LoadResponse(writer);
			control.SEQ = seq;
			response.SetControl(control);
			response.SetIIN(this.GetResponseIIN());
        
			return this.BeginResponseTx(addresses.source, response);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleNonReadResponse(in APDUHeader header, in ser4cpp.RSeq objects, HeaderWriter writer)
		{
			switch (header.function)
			{
			case (FunctionCode.WRITE):
				return this.HandleWrite(objects);
			case (FunctionCode.SELECT):
				return this.HandleSelect(objects, writer);
			case (FunctionCode.OPERATE):
				return this.HandleOperate(objects, writer);
			case (FunctionCode.DIRECT_OPERATE):
				return this.HandleDirectOperate(objects, OperateType.DirectOperate, writer);
			case (FunctionCode.COLD_RESTART):
				return this.HandleRestart(objects, false, writer);
			case (FunctionCode.WARM_RESTART):
				return this.HandleRestart(objects, true, writer);
			case (FunctionCode.ASSIGN_CLASS):
				return this.HandleAssignClass(objects);
			case (FunctionCode.DELAY_MEASURE):
				return this.HandleDelayMeasure(objects, writer);
			case (FunctionCode.RECORD_CURRENT_TIME):
				return objects.is_empty() ? this.HandleRecordCurrentTime() : new IINField(IINBit.PARAM_ERROR);
			case (FunctionCode.DISABLE_UNSOLICITED):
				return this.@params.allowUnsolicited ? this.HandleDisableUnsolicited(objects, writer) : new IINField(IINBit.FUNC_NOT_SUPPORTED);
			case (FunctionCode.ENABLE_UNSOLICITED):
				return this.@params.allowUnsolicited ? this.HandleEnableUnsolicited(objects, writer) : new IINField(IINBit.FUNC_NOT_SUPPORTED);
			case (FunctionCode.IMMED_FREEZE):
				return this.HandleFreeze(objects);
			case (FunctionCode.FREEZE_CLEAR):
				return this.HandleFreezeAndClear(objects);
			default:
				return new IINField(IINBit.FUNC_NOT_SUPPORTED);
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ser4cpp.Pair<IINField, AppControlField> HandleRead(in ser4cpp.RSeq objects, HeaderWriter writer)
		{
			this.rspContext.Reset();
			this.eventBuffer.Unselect(); // always un-select any previously selected points when we start a new read request
			this.database.Unselect();
        
			ReadHandler handler = new ReadHandler(this.database, this.eventBuffer);
			var result = APDUParser.Parse(objects, handler, this.logger, ParserSettings.NoContents()); // don't expect range/count context on a READ
			if (result == ParseResult.OK)
			{
				var control = this.rspContext.LoadResponse(writer);
				return ser4cpp.Pair<IINField, AppControlField>(handler.Errors(), control);
			}
        
			this.rspContext.Reset();
			return ser4cpp.Pair<IINField, AppControlField>(IINFromParseResult(result), new AppControlField(true, true, false, false));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleWrite(in ser4cpp.RSeq objects)
		{
			WriteHandler handler = new WriteHandler(this.application, this.time, this.sol.seq.num, new Timestamp(), this.staticIIN);
			var result = APDUParser.Parse(objects, handler, this.logger);
			return (result == ParseResult.OK) ? handler.Errors() : IINFromParseResult(result);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleDirectOperate(in ser4cpp.RSeq objects, OperateType opType, HeaderWriter pWriter)
		{
			// since we're echoing, make sure there's enough size before beginning
			if (pWriter != null && (objects.length() > pWriter.Remaining()))
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Igonring command request due to oversized payload size of %zu",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return new IINField(IINBit.PARAM_ERROR);
			}
        
			CommandActionAdapter adapter = new CommandActionAdapter(this.commandHandler, false, this.database, opType);
			CommandResponseHandler handler = new CommandResponseHandler(this.@params.maxControlsPerRequest, adapter, pWriter);
			var result = APDUParser.Parse(objects, handler, this.logger);
			this.shouldCheckForUnsolicited = true;
			return (result == ParseResult.OK) ? handler.Errors() : IINFromParseResult(result);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleSelect(in ser4cpp.RSeq objects, HeaderWriter writer)
		{
			// since we're echoing, make sure there's enough size before beginning
			if (objects.length() > writer.Remaining())
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Igonring command request due to oversized payload size of %zu",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return new IINField(IINBit.PARAM_ERROR);
			}
        
			// the 'OperateType' is just ignored  since it's a select
			CommandActionAdapter adapter = new CommandActionAdapter(this.commandHandler, true, this.database, OperateType.DirectOperate);
			CommandResponseHandler handler = new CommandResponseHandler(this.@params.maxControlsPerRequest, adapter, writer);
			var result = APDUParser.Parse(objects, handler, this.logger);
			if (result == ParseResult.OK)
			{
				if (handler.AllCommandsSuccessful())
				{
					this.control.Select(this.sol.seq.num, new Timestamp(), objects);
				}
        
				return handler.Errors();
			}
        
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINFromParseResult(result);
			return new opendnp3.IINField(IINFromParseResult(result));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleOperate(in ser4cpp.RSeq objects, HeaderWriter writer)
		{
			// since we're echoing, make sure there's enough size before beginning
			if (objects.length() > writer.Remaining())
			{
				if (this.logger.is_enabled(opendnp3.flags.Globals.WARN))
				{
					string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
					SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Igonring command request due to oversized payload size of %zu",__VA_ARGS__);
		//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					this.logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
				};
				return new IINField(IINBit.PARAM_ERROR);
			}
        
			var now = new Timestamp();
			var result = this.control.ValidateSelection(this.sol.seq.num, now, this.@params.selectTimeout, objects);
        
			if (result == CommandStatus.SUCCESS)
			{
				CommandActionAdapter adapter = new CommandActionAdapter(this.commandHandler, false, this.database, OperateType.SelectBeforeOperate);
				CommandResponseHandler handler = new CommandResponseHandler(this.@params.maxControlsPerRequest, adapter, writer);
				var result = APDUParser.Parse(objects, handler, this.logger);
				this.shouldCheckForUnsolicited = true;
				return (result == ParseResult.OK) ? handler.Errors() : IINFromParseResult(result);
			}
			else
			{
				this.control.Unselect();
			}
        
			return this.HandleCommandWithConstant(objects, writer, result);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleDelayMeasure(in ser4cpp.RSeq objects, HeaderWriter writer)
		{
			if (objects.is_empty())
			{
				Group52Var2 value = new Group52Var2();
				value.time = 0; // respond with 0 time delay
				writer.WriteSingleValue<ser4cpp.UInt8, Group52Var2>(QualifierCode.UINT8_CNT, value);
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINField::Empty();
				return new opendnp3.IINField(IINField.Empty());
			}
        
			// there shouldn't be any trailing headers in delay measure request, no need to even parse
			return new IINField(IINBit.PARAM_ERROR);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleRestart(in ser4cpp.RSeq objects, bool isWarmRestart, HeaderWriter pWriter)
		{
			if (objects.is_not_empty())
			{
				return new IINField(IINBit.PARAM_ERROR);
			}
        
			var mode = isWarmRestart ? this.application.WarmRestartSupport() : this.application.ColdRestartSupport();
        
			switch (mode)
			{
			case (RestartMode.UNSUPPORTED):
				return new IINField(IINBit.FUNC_NOT_SUPPORTED);
			case (RestartMode.SUPPORTED_DELAY_COARSE):
			{
				var delay = isWarmRestart ? this.application.WarmRestart() : this.application.ColdRestart();
				if (pWriter != null)
				{
					Group52Var1 coarse = new Group52Var1();
					coarse.time = delay;
					pWriter.WriteSingleValue<ser4cpp.UInt8>(QualifierCode.UINT8_CNT, coarse);
				}
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINField::Empty();
				return new opendnp3.IINField(IINField.Empty());
			}
			default:
			{
				var delay = isWarmRestart ? this.application.WarmRestart() : this.application.ColdRestart();
				if (pWriter != null)
				{
					Group52Var2 fine = new Group52Var2();
					fine.time = delay;
					pWriter.WriteSingleValue<ser4cpp.UInt8>(QualifierCode.UINT8_CNT, fine);
				}
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINField::Empty();
				return new opendnp3.IINField(IINField.Empty());
			}
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleAssignClass(in ser4cpp.RSeq objects)
		{
			if (this.application.SupportsAssignClass())
			{
				AssignClassHandler handler = new AssignClassHandler(this.application, this.database);
				var result = APDUParser.Parse(objects, handler, this.logger, ParserSettings.NoContents());
				return (result == ParseResult.OK) ? handler.Errors() : IINFromParseResult(result);
			}
        
			return new IINField(IINBit.FUNC_NOT_SUPPORTED);
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleDisableUnsolicited(in ser4cpp.RSeq objects, HeaderWriter UnnamedParameter)
		{
			ClassBasedRequestHandler handler = new ClassBasedRequestHandler();
			var result = APDUParser.Parse(objects, handler, this.logger);
			if (result == ParseResult.OK)
			{
				this.@params.unsolClassMask.Clear(handler.GetClassField());
				return handler.Errors();
			}
        
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINFromParseResult(result);
			return new opendnp3.IINField(IINFromParseResult(result));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleEnableUnsolicited(in ser4cpp.RSeq objects, HeaderWriter UnnamedParameter)
		{
			ClassBasedRequestHandler handler = new ClassBasedRequestHandler();
			var result = APDUParser.Parse(objects, handler, this.logger);
			if (result == ParseResult.OK)
			{
				this.@params.unsolClassMask.Set(handler.GetClassField());
				this.shouldCheckForUnsolicited = true;
				return handler.Errors();
			}
        
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINFromParseResult(result);
			return new opendnp3.IINField(IINFromParseResult(result));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleCommandWithConstant(in ser4cpp.RSeq objects, HeaderWriter writer, CommandStatus status)
		{
			ConstantCommandAction constant = new ConstantCommandAction(status);
			CommandResponseHandler handler = new CommandResponseHandler(this.@params.maxControlsPerRequest, constant, writer);
			var result = APDUParser.Parse(objects, handler, this.logger);
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINFromParseResult(result);
			return new opendnp3.IINField(IINFromParseResult(result));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleFreeze(in ser4cpp.RSeq objects)
		{
			FreezeRequestHandler handler = new FreezeRequestHandler(false, database);
			var result = APDUParser.Parse(objects, handler, this.logger, ParserSettings.NoContents());
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINFromParseResult(result);
			return new opendnp3.IINField(IINFromParseResult(result));
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public IINField HandleFreezeAndClear(in ser4cpp.RSeq objects)
		{
			FreezeRequestHandler handler = new FreezeRequestHandler(true, database);
			var result = APDUParser.Parse(objects, handler, this.logger, ParserSettings.NoContents());
		//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//ORIGINAL LINE: return IINFromParseResult(result);
			return new opendnp3.IINField(IINFromParseResult(result));
		}
	}
}
