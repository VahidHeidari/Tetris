using System;
namespace Tetris
{
	internal class Tetrominoes
	{
		public enum Shapes
		{
			I,
			L,
			J,
			O,
			Z,
			T,
			S
		}
		private const byte OLen = 1;
		private const byte ILen = 2;
		private const byte Slen = 2;
		private const byte ZLen = 2;
		private const byte JLen = 4;
		private const byte LLen = 4;
		private const byte TLen = 4;
		private const byte NumberOfShapes = 7;
		public uint[] Shape;
		public uint[] Next_Shape;
		public int Len;
		public int Index;
		public int NextLen;
		public int NextIndex;
		private Random random = new Random();
		public int rand;
		private uint[] I = new uint[]
		{
			1u,
			1u,
			1u,
			1u,
			0u,
			0u,
			0u,
			15u
		};
		private uint[] J = new uint[]
		{
			0u,
			1u,
			1u,
			3u,
			0u,
			0u,
			4u,
			7u,
			0u,
			3u,
			2u,
			2u,
			0u,
			0u,
			7u,
			1u
		};
		private uint[] L = new uint[]
		{
			0u,
			2u,
			2u,
			3u,
			0u,
			0u,
			7u,
			4u,
			0u,
			3u,
			1u,
			1u,
			0u,
			0u,
			1u,
			7u
		};
		private uint[] O = new uint[]
		{
			0u,
			0u,
			3u,
			3u
		};
		private uint[] S = new uint[]
		{
			0u,
			0u,
			3u,
			6u,
			0u,
			2u,
			3u,
			1u
		};
		private uint[] T = new uint[]
		{
			0u,
			0u,
			7u,
			2u,
			0u,
			1u,
			3u,
			1u,
			0u,
			0u,
			2u,
			7u,
			0u,
			2u,
			3u,
			2u
		};
		private uint[] Z = new uint[]
		{
			0u,
			0u,
			6u,
			3u,
			0u,
			1u,
			3u,
			2u
		};
		public void Rotate()
		{
			this.Index = ++this.Index % this.Len;
		}
		public void Next()
		{
			this.rand = this.random.Next(7);
			this.Shape = this.Next_Shape;
			this.Index = this.NextIndex;
			this.Len = this.NextLen;
			switch (this.rand)
			{
			case 0:
				this.Next_Shape = this.I;
				this.NextLen = 2;
				break;
			case 1:
				this.Next_Shape = this.J;
				this.NextLen = 4;
				break;
			case 2:
				this.Next_Shape = this.L;
				this.NextLen = 4;
				break;
			case 3:
				this.Next_Shape = this.O;
				this.NextLen = 1;
				break;
			case 4:
				this.Next_Shape = this.S;
				this.NextLen = 2;
				break;
			case 5:
				this.Next_Shape = this.T;
				this.NextLen = 4;
				break;
			case 6:
				this.Next_Shape = this.Z;
				this.NextLen = 2;
				break;
			}
			this.NextIndex = this.random.Next(this.NextLen);
		}
	}
}
