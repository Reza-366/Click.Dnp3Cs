using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace asio
{
	namespace serial_port_base
	{

		public enum stop_bits : byte
		{
			one = 1,
			onepointfive = 2,
			two = 3,
			none = 0
		}


		///**
		//  Enumeration for setting serial port flow control
		//*/
		//enum class FlowControl : byte
		//{
		//  Hardware = 1,
		//  XONXOFF = 2,
		//  None = 0
		//};

		//struct FlowControlSpec
		//{
		//  using enum_type_t = FlowControl;
		//
		//  static byte to_type(FlowControl arg);
		//  static FlowControl from_type(byte arg);
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
		public enum flow_control : byte
		{
			none = 0,
			software = 1,
			hardware = 2
		}


		public enum baud_rate : byte
		{
			none = 0,
			software = 1,
			hardware = 2
		}

		public enum parity : byte
		{
			none = 0,
			even = 1,
			odd = 2
		}

		public enum character_size : byte
		{
			none = 0,
			even = 1,
			odd = 2
		}
	}
}

