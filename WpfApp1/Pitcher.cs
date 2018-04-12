using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsApp
{
	class Pitcher
	{
		#region Members



		#endregion

		#region Constructors



		#endregion

		#region Properties

		public int HitsAllowed { get; set; }
		public int WalksIssued { get; set; }
		public int IntentionalWalksIssued { get; set; }
		public int EarnedRunsAllowed { get; set; }
		public int HitBatters { get; set; }
		public int SinglesAllowed { get; set; }
		public int DoublesAllowed { get; set; }
		public int TriplesAllowed { get; set; }
		public int HomeRunsAllowed { get; set; }
		public int FlyBallsAllowed { get; set; }
		public int GroundBallsAllowed { get; set; }
		public int Strikeouts { get; set; }
		public float InningsPitched { get; set; }
		
		#endregion
	}
}
