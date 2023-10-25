using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace asio
{
	namespace serial_port_base
	{

		public enum stop_bits : System.Byte
		{
			one = 1,
			onepointfive = 2,
			two = 3,
			none = 0
		}


		///**
		//  Enumeration for setting serial port flow control
		//*/
		//enum class FlowControl : System.Byte
		//{
		//  Hardware = 1,
		//  XONXOFF = 2,
		//  None = 0
		//};

		//struct FlowControlSpec
		//{
		//  using enum_type_t = FlowControl;
		//
		//  static System.Byte to_type(FlowControl arg);
		//  static FlowControl from_type(System.Byte arg);
		//  static char const* to_string(FlowControl arg);
		//  static char const* to_human_string(FlowControl arg);
		//  static FlowControl from_string(const std::string& arg);
		//};

		/*
		 *
		 *
		 *
		 *
		 */
		public enum flow_control : System.Byte
		{
			none = 0,
			software = 1,
			hardware = 2
		}


		public enum baud_rate : System.Byte
		{
			none = 0,
			software = 1,
			hardware = 2
		}

		public enum parity : System.Byte
		{
			none = 0,
			even = 1,
			odd = 2
		}

		public enum character_size : System.Byte
		{
			none = 0,
			even = 1,
			odd = 2
		}
	}
}

