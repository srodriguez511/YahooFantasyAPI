using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace YahooService
{
    [XmlRoot(ElementName = "fantasy_content", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class fantasy_content
    {
        [XmlAttribute(AttributeName = "xml:lang")]
        public string Lang { get; set; }

        [XmlAttribute(AttributeName = "uri", Namespace = "http://www.yahooapis.com/v1/base.rng")]
        public string Uri { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }

        [XmlAttribute(AttributeName = "copyright")]
        public string Copyright { get; set; }

        [XmlAttribute(AttributeName = "refresh_rate")]
        public string RefreshRate { get; set; }

        [XmlElement(ElementName = "users")]
        public List<Users> UsersSection { get; set; }

        [XmlElement(ElementName = "league")]
        public League LeagueSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Fantasy Content\n");
            sb.Append("=========\n");
            sb.Append(String.Format("Lang: {0}\n", Lang));
            sb.Append(String.Format("Uri: {0}\n", Uri));
            sb.Append(String.Format("Time: {0}\n", Time));
            sb.Append(String.Format("Copyright: {0}\n", Copyright));
            sb.Append(String.Format("Refreshrate: {0}\n", RefreshRate));
            if (UsersSection != null)
            {
                foreach (var user in UsersSection)
                {
                    sb.Append(user);
                }
            }
            if (LeagueSection != null)
            {
                sb.Append(LeagueSection);
            }
            return sb.ToString();
        }
    }

    public class Users
    {
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlElement(ElementName = "user")]
        public User UserSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Users\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Count {0}\n", Count));
            if (UserSection != null)
            {
                sb.Append(UserSection);
            }
            return sb.ToString();
        }

    }

    public class User
    {
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }

        [XmlElement(ElementName = "games")]
        public Games Games { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("User\n");
            sb.Append("=============\n");
            sb.Append(String.Format("guid {0}\n", Guid));
            if (Games != null)
            {
                sb.Append(Games);
            }
            return sb.ToString();
        }
    }

    public class Games
    {
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlElement(ElementName = "game")]
        public List<Game> GameList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Games\n");
            sb.Append("=============\n");
            if (GameList != null)
            {
                foreach (var g in GameList)
                {
                    sb.Append(g);
                }
            }
            return sb.ToString();
        }
    }

    public class Game
    {
        [XmlElement(ElementName = "game_key")]
        public string GameKey { get; set; }

        [XmlElement(ElementName = "game_id")]
        public string GameId { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "season")]
        public string Season { get; set; }

        [XmlElement(ElementName = "leagues")]
        public Leagues LeaguesSection { get; set; }

        [XmlElement(ElementName = "teams")]
        public Teams TeamsSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Game\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Gamekey: {0}\n", GameKey));
            sb.Append(String.Format("GameId: {0}\n", GameId));
            sb.Append(String.Format("Name: {0}\n", Name));
            sb.Append(String.Format("Code: {0}\n", Code));
            sb.Append(String.Format("Type: {0}\n", Type));
            sb.Append(String.Format("Url: {0}\n", Url));
            sb.Append(String.Format("Season: {0}\n", Season));

            if (LeaguesSection != null)
            {
                sb.Append(LeaguesSection);
            }

            if (TeamsSection != null)
            {
                sb.Append(TeamsSection);
            }

            return sb.ToString();
        }

    }

    public class Leagues
    {
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlElement(ElementName = "league")]
        public List<League> LeagueList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Leagues\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Count: {0}\n", Count));
            if (LeagueList != null)
            {
                foreach (var l in LeagueList)
                {
                    sb.Append(l);
                }
            }
            return sb.ToString();
        }
    }

    public class League
    {
        [XmlElement(ElementName = "league_key")]
        public string LeagueKey { get; set; }

        [XmlElement(ElementName = "league_id")]
        public string LeagueId { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "draft_status")]
        public string DraftStatus { get; set; }

        [XmlElement(ElementName = "num_teams")]
        public string NumTeams { get; set; }

        [XmlElement(ElementName = "edit_key")]
        public string EditKey { get; set; }

        [XmlElement(ElementName = "weekly_deadline")]
        public string WeeklyDeadline { get; set; }

        [XmlElement(ElementName = "league_update_timestamp")]
        public string LeagueUpdateTimestamp { get; set; }

        [XmlElement(ElementName = "scoring_type")]
        public string ScoringType { get; set; }

        [XmlElement(ElementName = "league_type")]
        public string LeagueType { get; set; }

        [XmlElement(ElementName = "is_pro_league")]
        public string IsProLeague { get; set; }

        [XmlElement(ElementName = "current_week")]
        public string CurrentWeek { get; set; }

        [XmlElement(ElementName = "start_week")]
        public string StartWeek { get; set; }

        [XmlElement(ElementName = "end_week")]
        public string EndWeek { get; set; }

        [XmlElement(ElementName = "is_finished")]
        public string IsFinished { get; set; }

        [XmlElement(ElementName = "standings")]
        public Standings StandingsSection { get; set; }

        [XmlElement(ElementName = "settings")]
        public Settings SettingsSection { get; set; }  

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("League\n");
            sb.Append("=============\n");
            sb.Append(String.Format("LeagueKey: {0}\n", LeagueKey));
            sb.Append(String.Format("LeagueId: {0}\n", LeagueId));
            sb.Append(String.Format("Name: {0}\n", Name));
            sb.Append(String.Format("Url: {0}\n", Url));
            sb.Append(String.Format("DraftStatus: {0}\n", DraftStatus));
            sb.Append(String.Format("NumTeams: {0}\n", NumTeams));
            sb.Append(String.Format("EditKey: {0}\n", EditKey));
            sb.Append(String.Format("WeeklyDeadline: {0}\n", WeeklyDeadline));
            sb.Append(String.Format("LeagueUpdateTimestamp: {0}\n", LeagueUpdateTimestamp));
            sb.Append(String.Format("ScoringType: {0}\n", ScoringType));
            sb.Append(String.Format("LeagueType: {0}\n", LeagueType));
            sb.Append(String.Format("IsProLeague: {0}\n", IsProLeague));
            sb.Append(String.Format("CurrentWeek: {0}\n", CurrentWeek));
            sb.Append(String.Format("StartWeek: {0}\n", StartWeek));
            sb.Append(String.Format("EndWeek: {0}\n", EndWeek));
            sb.Append(String.Format("IsFinished: {0}\n", IsFinished));
            if (StandingsSection != null)
            {
                sb.Append(StandingsSection);
            }
            if (SettingsSection != null)
            {
                sb.Append(SettingsSection);
            }
            return sb.ToString();
        }
    }

    public class Standings
    {
        [XmlElement(ElementName = "teams")]
        public Teams TeamsSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Standings\n");
            sb.Append("=============\n");
            if (TeamsSection != null)
            {
                sb.Append(TeamsSection);
            }
            return sb.ToString();
        }
    }

    public class Teams
    {
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlElement(ElementName = "team")]
        public List<Team> TeamsList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Teams\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Count: {0}\n", Count));
            if (TeamsList != null)
            {
                foreach (var t in TeamsList)
                {
                    sb.Append(t);
                }
            }
            return sb.ToString();
        }
    }

    public class Team
    {
        [XmlElement(ElementName = "team_key")]
        public string TeamKey { get; set; }

        [XmlElement(ElementName = "team_id")]
        public string TeamId { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "is_owned_by_current_login")]
        public string IsOwnedByCurrentLogin { get; set; }

        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "team_logos")]
        public TeamLogos TeamsLogosSection { get; set; }

        [XmlElement(ElementName = "waiver_priority")]
        public string WaiverPriority { get; set; }

        [XmlElement(ElementName = "number_of_moves")]
        public string NumberOfMoves { get; set; }

        [XmlElement(ElementName = "clinched_playoffs")]
        public string ClinchedPlayoffs { get; set; }

        [XmlElement(ElementName = "managers")]
        public Managers ManagersSection { get; set; }

        [XmlElement(ElementName = "team_points")]
        public TeamsPoints TeamPointsSection { get; set; }

        [XmlElement(ElementName = "team_standings")]
        public TeamStandings TeamStandingsSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Team\n");
            sb.Append("=============\n");
            sb.Append(String.Format("TeamKey: {0}\n", TeamKey));
            sb.Append(String.Format("TeamId: {0}\n", TeamId));
            sb.Append(String.Format("Name: {0}\n", Name));
            sb.Append(String.Format("IsOwnedByCurrentLogin: {0}\n", IsOwnedByCurrentLogin));
            sb.Append(String.Format("Url: {0}\n", Url));
            if (TeamsLogosSection != null)
            {
                sb.Append(TeamsLogosSection);
            }
            sb.Append(String.Format("WaiverPriority: {0}\n", WaiverPriority));
            sb.Append(String.Format("NumberOfMoves: {0}\n", NumberOfMoves));
            sb.Append(String.Format("ClinchedPlayoffs: {0}\n", ClinchedPlayoffs));
            if (ManagersSection != null)
            {
                sb.Append(ManagersSection);
            }
            if (TeamPointsSection != null)
            {
                sb.Append(TeamPointsSection);
            }
            if (TeamStandingsSection != null)
            {
                sb.Append(TeamStandingsSection);
            }
            return sb.ToString();
        }
    }

    public class TeamsPoints
    {
        [XmlElement(ElementName = "coverage_type")]
        public string CoverageType { get; set; }

        [XmlElement(ElementName = "season")]
        public string Season { get; set; }

        [XmlElement(ElementName = "total")]
        public string Total { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Team Points\n");
            sb.Append("=============\n");
            sb.Append(String.Format("CoverageType: {0}\n", CoverageType));
            sb.Append(String.Format("Season: {0}\n", Season));
            sb.Append(String.Format("Total: {0}\n", Total));

            return sb.ToString();
        }
    }

    public class TeamStandings
    {
        [XmlElement(ElementName = "rank")]
        public string Rank { get; set; }

        [XmlElement(ElementName = "outcome_totals")]
        public OutcomeTotals OutcomeTotalsSection { get; set; }

        [XmlElement(ElementName = "streak")]
        public Streak StreakSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Team Standings\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Rank: {0}\n", Rank));
            if (OutcomeTotalsSection != null)
            {
                sb.Append(OutcomeTotalsSection);
            }
            if (StreakSection != null)
            {
                sb.Append(StreakSection);
            }
            return sb.ToString();
        }
    }

    public class OutcomeTotals
    {
        [XmlElement(ElementName = "wins")]
        public string Wins { get; set; }

        [XmlElement(ElementName = "losses")]
        public string Losses { get; set; }

        [XmlElement(ElementName = "ties")]
        public string Ties { get; set; }

        [XmlElement(ElementName = "percentage")]
        public string Percentage { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("OutcomeTotals\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Wins: {0}\n", Wins));
            sb.Append(String.Format("Losses: {0}\n", Losses));
            sb.Append(String.Format("Ties: {0}\n", Ties));
            sb.Append(String.Format("Percentage: {0}\n", Percentage));
            return sb.ToString();
        }
    }

    public class Streak
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "value")]
        public string Value { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Streak   \n");
            sb.Append("=============\n");
            sb.Append(String.Format("Type: {0}\n", Type));
            sb.Append(String.Format("Value: {0}\n", Value));
            return sb.ToString();
        }
    }

    public class TeamLogos
    {
        [XmlElement(ElementName = "team_logo")]
        public List<TeamLogo> TeamLogoList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("TeamLogos\n");
            sb.Append("=============\n");
            if (TeamLogoList != null)
            {
                foreach (var tl in TeamLogoList)
                {
                    sb.Append(tl);
                }
            }
            return sb.ToString();
        }
    }

    public class TeamLogo
    {
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("TeamLogo\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Size: {0}\n", Size));
            sb.Append(String.Format("Url: {0}\n", Url));
            return sb.ToString();
        }
    }

    public class Managers
    {
        [XmlElement(ElementName = "manager")]
        public List<Manager> ManagersList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Managers\n");
            sb.Append("=============\n");
            if (ManagersList != null)
            {
                foreach (var ml in ManagersList)
                {
                    sb.Append(ml);
                }
            }
            return sb.ToString();
        }
    }

    public class Manager
    {
        [XmlElement(ElementName = "manager_id")]
        public string ManagerId { get; set; }

        [XmlElement(ElementName = "nickname")]
        public string NickName { get; set; }

        [XmlElement(ElementName = "is_current_login")]
        public string IsCurrentLogin { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Manager\n");
            sb.Append("=============\n");
            sb.Append(String.Format("ManagerId: {0}\n", ManagerId));
            sb.Append(String.Format("NickName: {0}\n", NickName));
            sb.Append(String.Format("IsCurrentLogin: {0}\n", IsCurrentLogin));
            return sb.ToString();
        }
    }

    public class Settings
    {
        [XmlElement(ElementName = "draft_type")]
        public string DraftType { get; set; }

        [XmlElement(ElementName = "scoring_type")]
        public string ScoringType { get; set; }

        [XmlElement(ElementName = "uses_playoff")]
        public string UsesPlayoff { get; set; }

        [XmlElement(ElementName = "playoff_start_week")]
        public string PlayoffStartWeek { get; set; }

        [XmlElement(ElementName = "uses_playoff_reseeding")]
        public string UsesPlayoffReseeding { get; set; }

        [XmlElement(ElementName = "uses_lock_eliminated_teams")]
        public string UsesLockEliminatedTeams { get; set; }

        [XmlElement(ElementName = "waiver_rule")]
        public string WaiverRule { get; set; }

        [XmlElement(ElementName = "uses_faab")]
        public string UsesFaab { get; set; }

        [XmlElement(ElementName = "waiver_time")]
        public string WaiverTime { get; set; }

        [XmlElement(ElementName = "trade_end_date")]
        public string TradeEndDate { get; set; }

        [XmlElement(ElementName = "trade_ratify_type")]
        public string TradeRatifyType { get; set; }

        [XmlElement(ElementName = "trade_reject_time")]
        public string TradeRejectTime { get; set; }

        [XmlElement(ElementName = "player_pool")]
        public string PlayerPool { get; set; }

        [XmlElement(ElementName = "roster_positions")]
        public RosterPositions RosterPositionsSection { get; set; }

        [XmlElement(ElementName = "stat_categories")]
        public StatCategories StatCategoriesSection { get; set; }

        [XmlElement(ElementName = "stat_modifiers")]
        public StatModifiers StatModifiersSection { get; set; }     

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Settings\n");
            sb.Append("=============\n");
            sb.Append(String.Format("DraftType: {0}\n", DraftType));
            sb.Append(String.Format("ScoringType: {0}\n", ScoringType));
            sb.Append(String.Format("UsesPlayoff: {0}\n", UsesPlayoff));
            sb.Append(String.Format("PlayoffStartWeek: {0}\n", PlayoffStartWeek));
            sb.Append(String.Format("UsesPlayoffReseeding: {0}\n", UsesPlayoffReseeding));
            sb.Append(String.Format("UsesLockEliminatedTeams: {0}\n", UsesLockEliminatedTeams));
            sb.Append(String.Format("WaiverRule: {0}\n", WaiverRule));
            sb.Append(String.Format("UsesFaab: {0}\n", UsesFaab));
            sb.Append(String.Format("WaiverTime: {0}\n", WaiverTime));
            sb.Append(String.Format("TradeEndDate: {0}\n", TradeEndDate));
            sb.Append(String.Format("TradeRatifyType: {0}\n", TradeRatifyType));
            sb.Append(String.Format("TradeRejectTime: {0}\n", TradeRejectTime));
            sb.Append(String.Format("PlayerPool: {0}\n", PlayerPool));
            if (RosterPositionsSection != null)
            {
                sb.Append(RosterPositionsSection);
            }
            if (StatCategoriesSection != null)
            {
                sb.Append(StatCategoriesSection);
            }
            if (StatModifiersSection != null)
            {
                sb.Append(StatModifiersSection);
            }
            return sb.ToString();
        }
    }

    public class RosterPositions
    {
        [XmlElement(ElementName = "roster_position")]
        public List<RosterPosition> RosterPositionList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("RosterPositions\n");
            sb.Append("=============\n");
            if (RosterPositionList != null)
            {
                foreach (var p in RosterPositionList)
                {
                    sb.Append(p);
                }
            }
            return sb.ToString();
        }
    }

    public class RosterPosition
    {
        [XmlElement(ElementName = "position")]
        public string Position { get; set; }

        [XmlElement(ElementName = "position_type")]
        public string PositionType { get; set; }

        [XmlElement(ElementName = "count")]
        public string Count { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("RosterPosition\n");
            sb.Append("=============\n");
            sb.Append(String.Format("Position: {0}\n", Position));
            sb.Append(String.Format("PositionType: {0}\n", PositionType));
            sb.Append(String.Format("Count: {0}\n", Count));
            return sb.ToString();
        }
    }

    public class StatCategories
    {
        [XmlElement(ElementName = "stats")]
        public Stats StatsSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("StatCategories\n");
            sb.Append("=============\n");
            if (StatsSection != null)
            {
                sb.Append(StatsSection);
            }
            return sb.ToString();
        }
    }

    public class StatModifiers
    {
        [XmlElement(ElementName = "stats")]
        public Stats StatsSection { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("StatModifiers\n");
            sb.Append("=============\n");
            if (StatsSection != null)
            {
                sb.Append(StatsSection);
            }
            return sb.ToString();
        }
    }

    public class Stats
    {
        [XmlElement(ElementName = "stat")]
        public List<Stat> StatList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Stats\n");
            sb.Append("=============\n");
            if (StatList != null)
            {
                foreach (var s in StatList)
                {
                    sb.Append(s);
                }
            }
            return sb.ToString();
        }
    }

    public class Stat
    {
        [XmlElement(ElementName = "stat_id")]
        public string StatId { get; set; }

        [XmlElement(ElementName = "enabled")]
        public string Enabled { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "display_name")]
        public string DisplayName { get; set; }

        [XmlElement(ElementName = "sort_order")]
        public string SortOrder { get; set; }

        [XmlElement(ElementName = "position_type")]
        public string PositionType { get; set; }

        [XmlElement(ElementName = "value")]
        public string Value { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Stat\n");
            sb.Append("=============\n");
            sb.Append(String.Format("StatId: {0}\n", StatId));
            sb.Append(String.Format("Enabled: {0}\n", Enabled));
            sb.Append(String.Format("Name: {0}\n", Name));
            sb.Append(String.Format("DisplayName: {0}\n", DisplayName));
            sb.Append(String.Format("SortOrder: {0}\n", SortOrder));
            sb.Append(String.Format("PositionType: {0}\n", PositionType));
            sb.Append(String.Format("Value: {0}\n", Value));
            return sb.ToString();
        }
    }
}
