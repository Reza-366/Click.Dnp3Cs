namespace opendnp3
{

	public class EmptyResponseTask
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public EmptyResponseTask(TaskContext context, IMasterApplication app, string name, FunctionCode func, Func<HeaderWriter , bool> format, Timestamp startExpiration, in Logger logger, in TaskConfig config)
		{
			this.IMasterTask = new <type missing>(context, app, TaskBehavior.SingleExecutionNoRetry(startExpiration), logger, config);
			this.name = std::move(name);
			this.func = new opendnp3.FunctionCode(func);
			this.format = std::move(format);
		}
	}
}
