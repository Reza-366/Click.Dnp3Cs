using opendnp3;


using System;

public class State
{
	public uint count = 0;
	public double value = 0;
	public bool binary = false;
	public DoubleBit dbit = DoubleBit.DETERMINED_OFF;
	public byte octetStringValue = 1;
}

public class ParsOutstation : System.IDisposable
{
	public static void ThreadStart(uint i)
	{
	}

	public static void ThreadStop(uint i)
	{
	}

	public ParsOutstation()
	{
		// TODO Auto-generated constructor stub
		ConfigureDatabase();

		// Specify what log levels to use. NORMAL is warning and above
		// You can add all the comms logging by uncommenting below.


			// This is the main point of interaction with the stack
			// Allocate a single thread to the pool since this is a single outstation
			// Log messages to the console

		opendnp3.ILogHandler logger = ConsoleLogger.Create();
		Action<uint> ts = ThreadStart;
		Action<uint> te = ThreadStop;
		DNP3Manager manager = new DNP3Manager(1, logger,ts,te);
		ChannelRetry retry = ChannelRetry.Default();
		SerialSettings setting = new SerialSettings();
		setting.baud = 115200;
		//std::make_shared<IChannelListener>  lis;
		var level = (int)(opendnp3.levels.Globals.NORMAL | opendnp3.levels.Globals.ALL_COMMS);
		logLevels = level; // levels::NORMAL | levels::ALL_COMMS;
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: IChannel *channel = manager.AddSerial("Com1", *logLevels, retry, setting, null);
		IChannel channel = manager.AddSerial("Com1", logLevels, retry, new opendnp3.SerialSettings(setting), null);
		OutstationStackConfig outStackConfig = new OutstationStackConfig(config);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: outStackConfig.outstation.eventBufferConfig = EventBufferConfig::AllTypes(100);
		outStackConfig.outstation.eventBufferConfig.CopyFrom(EventBufferConfig.AllTypes(100));
		IOutstationApplication app = DefaultOutstationApplication.Create();


		// you can override an default outstation parameters here
		// in this example, we've enabled the oustation to use unsolicted reporting
		// if the master enables it
		outStackConfig.outstation.@params.allowUnsolicited = true;

		// You can override the default link layer settings here
		// in this example we've changed the default link layer addressing
		outStackConfig.link.LocalAddr = 10;
		outStackConfig.link.RemoteAddr = 1;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: outStackConfig.link.KeepAliveTimeout = TimeDuration::Max();
		outStackConfig.link.KeepAliveTimeout.CopyFrom(TimeDuration.Max());

		// Create a new outstation with a log level, command handler, and
		// config info this	returns a thread-safe interface used for
		// updating the outstation's database.
		var success = SuccessCommandHandler.Create();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: IOutstation *outstation = channel->AddOutstation("outstation", success, app, outStackConfig);
		IOutstation outstation = channel.AddOutstation("outstation", new opendnp3.ICommandHandler(success), app, outStackConfig);
		var stat = channel.GetStatistics();
		outstation.Enable();

		//
		// Enable the outstation and start communications
		//outstation->Enable();


			//return this->AddStack(config.link, stack);

	}

	public virtual void AddUpdates(UpdateBuilder builder, State state, in string arguments)
	{
		//    for (const char& c : arguments)
		//    {
		//        switch (c)
		//        {
		//        case ('c'):
		//        {
		//            builder.Update(Counter(state.count), 0);
		//            ++state.count;
		//            break;
		//        }
		//        case ('f'):
		//        {
		//            builder.FreezeCounter(0, false);
		//            break;
		//        }
		//        case ('a'):
		//        {
		//            builder.Update(Analog(state.value), 0);
		//            state.value += 1;
		//            break;
		//        }
		//        case ('b'):
		//        {
		//            builder.Update(Binary(state.binary, Flags(0x01), app->Now()), 0);
		//            state.binary = !state.binary;
		//            break;
		//        }
		//        case ('d'):
		//        {
		//            builder.Update(DoubleBitBinary(state.dbit), 0);
		//            state.dbit
		//                = (state.dbit == DoubleBit::DETERMINED_OFF) ? DoubleBit::DETERMINED_ON : DoubleBit::DETERMINED_OFF;
		//            break;
		//        }
		//        case ('o'):
		//        {
		//            OctetString value(Buffer(&state.octetStringValue, 1));
		//            builder.Update(value, 0);
		//            state.octetStringValue += 1;
		//            break;
		//        }
		//        default:
		//            break;
		//        }
		//    }
	}

	public virtual void Run()
	{

	//	long long g;
	//	g = 555l;
	//
		// variables used in example loop
	//	string input;
	//	State state;

	//	std::cout << "Enter one or more measurement changes then press <enter>" << std::endl;
	//	std::cout << "c = counter, b = binary, d = doublebit, a = analog, o = octet string, 'quit' = exit" << std::endl;
	//	std::cin >> input;
	//
	//	if (input == "quit")
	//		return 0; // DNP3Manager destructor cleanups up everything automatically
	//	else
	//	{
	//		// update measurement values based on input string
	//		UpdateBuilder builder;
	//		AddUpdates(builder, state, input);
	//		outstation->Apply(builder.Build());
	//	}


	}

	public virtual void Dispose()
	{
	}

	//std::shared_ptr<IOutstationApplication> app = DefaultOutstationApplication::Create();
	private void ConfigureDatabase()
	{
		// 10 of each type with default settings
		//DatabaseConfig config;
		config.analog_input[0].clazz = PointClass.Class2;
		config.analog_input[0].svariation = StaticAnalogVariation.Group30Var5;
		config.analog_input[0].evariation = EventAnalogVariation.Group32Var7;
		//
		//    return config;
	}

	private DatabaseConfig config = new DatabaseConfig();
	private readonly LogLevels logLevels;
}

