using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsApp
{
	class Hitter
	{
		#region Members

		

		#endregion

		#region Constructors



		#endregion

		#region Properties

		#region Offensive Categories

		public string Name { get; set; }
		public string Position { get; set; }
		public int Hits { get; set; }
		public int Singles { get; set; }
		public int Doubles { get; set; }
		public int Triples { get; set; }
		public int HomeRuns { get; set; }
		public int WalksDrawn { get; set; }
		public int IntentionalWalksDrawns { get; set; }
		public int SacBunts { get; set; }
		public int SacFlies { get; set; }
		public int AtBats { get; set; }
		public int PlateAppearances { get; set; }
		public int HitByPitch { get; set; }
		public int StolenBases { get; set; }
		public int CaughtStealing { get; set; }
		public int GroundedIntoDoublePlay { get; set; }
		public int ReachBaseOnError { get; set; }
		public int FlyBalls { get; set; }
		public int GroundBalls { get; set; }
		public int RunsScored { get; set; }

		#endregion

		#region Defensive Categories

		public int PutOuts { get; set; }
		public int Assists { get; set; }

		#endregion

		#endregion
	}
}
