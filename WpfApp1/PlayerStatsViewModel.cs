using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatisticsApp
{
	public class PlayerStatsViewModel : INotifyPropertyChanged
	{
		#region Members

		private int m_hits;
		public int m_earnedRuns;
		public float m_inningsPitched;
		private float m_result;
		private List<Hitter> m_hitters = new List<Hitter>();
		private DelegateCommand m_commandOne;
		private DelegateCommand m_commandTwo;
		private float m_onBasePercentage;
		private float m_sluggingPercentage;
		private float m_onBasePlusSlugging;
		private float m_isolatedPower;
		private float m_battingAverage;
		private float m_secondaryAverage;
		private int m_totalBases;
		private float m_baseRuns;
		private float m_battingAverageOnBallsInPlay;
		private float m_defenseIndependentComponentEarnedRunAverage;
		private float m_fieldingIndependentPitching;
		private float m_expectedFieldingIndependentPitching;
		private float m_equivalentAverage;
		private float m_runsCreated;
		private float m_runsCreatedStolenBases;
		private float m_runsCreatedTechnical;

		#endregion

		#region Constructors

		public PlayerStatsViewModel()
		{
			m_earnedRuns = 9;
			m_inningsPitched = 38.1f;
			m_hitters.Add(new Hitter() { Assists = 3, AtBats = 100, CaughtStealing = 3, Doubles = 44, FlyBalls = 70, GroundBalls = 20, GroundedIntoDoublePlay = 4, HitByPitch = 2, Hits = 100, HomeRuns = 13, IntentionalWalksDrawns = 3, Name = "Eric", PlateAppearances = 125, Position = "Shortstop", PutOuts = 32, ReachBaseOnError = 5, RunsScored = 77, SacBunts = 9, SacFlies = 12, Singles = 45, StolenBases = 60, Triples = 8, WalksDrawn = 23});
			m_commandOne = new DelegateCommand(() => EarnedRunAverage(4, 9.0f));
			m_commandTwo = new DelegateCommand(() => ComputeStatistics());
		}

		public ICommand Command1 => m_commandOne;

		public ICommand Command2 => m_commandTwo;

		public event PropertyChangedEventHandler PropertyChanged;

		public float Result
		{
			get { return m_result; }
			set
			{
				if (value != m_result)
				{
					m_result = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
				}
			}
		}

		public int Hits
		{
			get { return m_hitters.Sum(i => i.Singles + i.Doubles + i.Triples + i.HomeRuns); }
		}

		#endregion

		#region Methods

		public void ComputeStatistics()
		{

		}

		public int UpdateHits(int Singles, int Doubles, int Triples, int HomeRuns)
		{
			var hits = Singles + Doubles + Triples + HomeRuns;
			Result = hits;
			return hits;
		}

		public float EarnedRunAverage(int RunsScored, float InningsPitched)
		{
			var earnedRunAverage = (RunsScored / InningsPitched) * 9;
			Result = earnedRunAverage;
			return earnedRunAverage;
		}

		public float OnBasePercentage(int Hits, int WalksDrawn, int HitByPitch, int SacFlys, int AtBats)
		{
			var onBasePercentage = (Hits + WalksDrawn + HitByPitch) / (AtBats + WalksDrawn + HitByPitch + SacFlys);
			m_onBasePercentage = onBasePercentage;
			return onBasePercentage;
		}

		public float SluggingPercentage(int Singles, int Doubles, int Triples, int HomeRuns, int AtBats)
		{
			var sluggingPercentage = (Singles + (Doubles * 2) + (Triples * 3) + (HomeRuns * 4)) / AtBats;
			m_sluggingPercentage = sluggingPercentage;
			return sluggingPercentage;
		}

		public float OnBasePlusSlugging()
		{
			var onBasePlusSlugging = m_onBasePercentage + m_sluggingPercentage;
			m_onBasePlusSlugging = onBasePlusSlugging;
			return onBasePlusSlugging;
		}

		public float IsolatedPower(int Doubles, int Triples, int HomeRuns, int AtBats)
		{
			var isolatedPower = Doubles + (Triples * 2) + (HomeRuns * 3) / AtBats;
			m_isolatedPower = isolatedPower;
			return isolatedPower;
		}

		public float SecondaryAverage(int TotalBases, int Hits, int WalksDrawn, int AtBats)
		{
			var secondaryAverage = (TotalBases - Hits + WalksDrawn) / AtBats;
			m_secondaryAverage = secondaryAverage;
			return secondaryAverage;
		}

		public float BattingAverage(int Hits, int AtBats)
		{
			var battingAverage = Hits / AtBats;
			m_battingAverage = battingAverage;
			return battingAverage;
		}

		public int TotalBases(int Singles, int Doubles, int Triples, int HomeRuns)
		{
			var totalBases = Singles + (Doubles * 2) + (Triples * 3) + (HomeRuns * 4);
			m_totalBases = totalBases;
			return totalBases;
		}

		public float BaseRuns(int Hits, int WalksDrawn, int HomeRuns, int TotalBases)
		{
			var baseRuns = (Hits + WalksDrawn - HomeRuns) * (((1.4f * TotalBases) - (0.6f * Hits) - (3f * HomeRuns) + (0.1f * WalksDrawn) * 1.02f));
			m_baseRuns = baseRuns;
			return baseRuns;
		}

		public float BattingAverageOnBallsInPlay(int Hits, int HomeRuns, int AtBats, int Strikeouts, int SacFlies)
		{
			var battingAverageOnBallsInPlay = (Hits + HomeRuns) / (AtBats - Strikeouts - HomeRuns + SacFlies);
			m_battingAverageOnBallsInPlay = battingAverageOnBallsInPlay;
			return battingAverageOnBallsInPlay;
		}

		public float DefenseIndependentComponentEarnedRunAverage(int HomeRuns, int WalksDrawn, int HitByPitch, int Strikeouts, int InningsPitched)
		{
			var defenseIndependentComponentEarnedRunAverage = 3.00f + (((13 * HomeRuns) + (3 * (WalksDrawn + HitByPitch)) - (2 * Strikeouts) / InningsPitched));
			m_defenseIndependentComponentEarnedRunAverage = defenseIndependentComponentEarnedRunAverage;
			return defenseIndependentComponentEarnedRunAverage;
		}

		public float FieldingIndependentPitching(int HomeRuns, int WalksDrawn, int HitByPitch, int Strikeouts, int InningsPitched)
		{
			var fieldingIndependentPitching = (((13 * HomeRuns) + (3 * (WalksDrawn + HitByPitch)) - (2 * Strikeouts) / InningsPitched));
			m_fieldingIndependentPitching = fieldingIndependentPitching;
			return fieldingIndependentPitching;
		}

		public float ExpectedFieldingIndependentPitching(int HomeRuns, int WalksDrawn, int HitByPitch, int Strikeouts, int InningsPitched)
		{
			var expectedFieldingIndependentPitching = (((13 * HomeRuns) + (3 * (WalksDrawn + HitByPitch)) - (2 * Strikeouts) / InningsPitched));
			m_expectedFieldingIndependentPitching = expectedFieldingIndependentPitching;
			return expectedFieldingIndependentPitching;
		}

		public float EquivalentAverage(int Hits, int TotalBases, int WalksDrawn, int HitByPitch, int StolenBases, int SacBunts, int SacFlies, int AtBats, int CaughtStealing)
		{
			var equivalentAverage = (Hits + TotalBases + (1.5f * (WalksDrawn + HitByPitch)) + StolenBases + SacBunts + SacFlies) / (AtBats + WalksDrawn + HitByPitch + SacBunts + SacFlies + CaughtStealing + StolenBases);
			m_equivalentAverage = equivalentAverage;
			return equivalentAverage;
		}

		public float RunsCreated(int Hits, int WalksDrawn, int TotalBases, int AtBats)
		{
			var runsCreated = ((Hits + WalksDrawn) * TotalBases) / (AtBats + WalksDrawn);
			m_runsCreated = runsCreated;
			return runsCreated;
		}

		public float RunsCreatedStolenBases(int Hits, int WalksDrawn, int TotalBases, int AtBats, int StolenBases, int CaughtStealing)
		{
			var runsCreatedStolenBases = ((Hits + WalksDrawn - CaughtStealing) * (TotalBases + (.55f * StolenBases))) / (AtBats + WalksDrawn);
			m_runsCreatedStolenBases = runsCreatedStolenBases;
			return runsCreatedStolenBases;
		}

		public float RunsCreatedTechnical(int Hits, int WalksDrawn, int TotalBases, int AtBats, int StolenBases, int CaughtStealing, int HitByPitch, int GroundedIntoDoublePlay, int IntentionalWalksDrawn, int SacBunts, int SacFlies)
		{
			var runsCreatedTechnical = ((Hits + WalksDrawn - CaughtStealing + HitByPitch - GroundedIntoDoublePlay) * (TotalBases + (.26f * (WalksDrawn - IntentionalWalksDrawn + HitByPitch)))) + (.52f * ( SacBunts + SacFlies + StolenBases))/ (AtBats + WalksDrawn + HitByPitch + SacBunts + SacFlies);
			m_runsCreatedTechnical = runsCreatedTechnical;
			return runsCreatedTechnical;
		}

		#endregion

	}
}