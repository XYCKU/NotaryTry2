using System;

namespace NotaryTry2 {
	class Money {
		private double value;

		public Money(double value) => Value = value;

		public double Value {
			get => value;
			set { this.value = value; }
		}

		public string ToShortString() {
			return $"";
		}

		public static Money operator +(Money a, Money b) => new Money(a.Value + b.Value);
	}
}
