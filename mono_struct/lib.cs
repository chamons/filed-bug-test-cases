namespace Test
{
	public class Lib
	{
		public ValueHolder [] ValueHolderArr { get; } = new [] { new ValueHolder (1), new ValueHolder (2), new ValueHolder (3) };
		public ValueType [] ValueTypeArr { get; } = new [] { new ValueType (1), new ValueType (2), new ValueType (3) };
	}

	public class ValueHolder {
		public int IntValue { get; private set; }
		public ValueHolder (int intValue)
		{
			IntValue = intValue;
		}
	}

	public struct ValueType {
		public int IntValue;

		public ValueType(int intValue)
		{
			IntValue = intValue;
		}
	}
}

