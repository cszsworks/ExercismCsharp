

public static class Tournament
{

    
    public class TeamResults : IEquatable<TeamResults>, IComparable<TeamResults>
    {
        private string _name;
        public string Name => _name;

        private int _wins = 0;
        private int _losses = 0;
        private int _draws = 0;

        public TeamResults(string name)
        {
            this._name = name;
        }

        public void AddWin() => this._wins++;
        public void AddLoss() => this._losses++;
        public void AddDraw() => this._draws++;

        public int GetWins() => this._wins;
        public int GetLosses() => this._losses;
        public int GetDraws() => this._draws;

        public int GetPoints()
        {
            return this._wins * 3 + this._draws;
        }

        // --- Equality overrides ---
        public override bool Equals(object? obj)
        {
            return Equals(obj as TeamResults);
        }


        public bool Equals(TeamResults? other)
        {
            if (other is null) return false;
            return string.Equals(this._name, other._name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return _name?.ToLowerInvariant().GetHashCode() ?? 0;
        }

        public int CompareTo(TeamResults? other)
        {
            if (other is null) return 1; // this > null

            // Compare points descending
            int pointComparison = other.GetPoints().CompareTo(this.GetPoints());
            if (pointComparison != 0) return pointComparison;

            // If equal, compare name ascending (alphabetical)
            return string.Compare(this._name, other._name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator ==(TeamResults left, TeamResults right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(TeamResults left, TeamResults right)
        {
            return !(left == right);
        }

        public string WriteResults()
        {
            return $"{this._name.PadRight(30)} |" +
          $"{(GetWins() + GetDraws() + GetLosses()).ToString().PadLeft(3)} |" +
          $"{GetWins().ToString().PadLeft(3)} |" +
          $"{GetDraws().ToString().PadLeft(3)} |" +
          $"{GetLosses().ToString().PadLeft(3)} |" +
          $"{GetPoints().ToString().PadLeft(3)}";
        }
    }


    public static List<TeamResults> teamList = new List<TeamResults>();
    public static void Tally(Stream inStream, Stream outStream)
    {
         teamList.Clear(); 


        string row1 = "Team                           | MP |  W |  D |  L |  P";


        using (var reader = new StreamReader(inStream))
        using (var writer = new StreamWriter(outStream, leaveOpen: true))
        {
            writer.Write(row1);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                string clubName1 = parts[0].Trim();
                string clubName2 = parts[1].Trim();
                string result = parts[2].Trim();
                if (!Tournament.teamList.Contains(new TeamResults(clubName1)))
                {
                    Tournament.teamList.Add(new TeamResults(clubName1));
                    Console.WriteLine($"adding team : {clubName1}");
                }
                if (!Tournament.teamList.Contains(new TeamResults(clubName2)))
                {
                    Tournament.teamList.Add(new TeamResults(clubName2));
                    Console.WriteLine($"adding team : {clubName2}");
                }
                var team1 = Tournament.teamList.First(t => t.Name == clubName1);
                var team2 = Tournament.teamList.First(t => t.Name == clubName2);
                if (result == "draw")
                {
                    team1.AddDraw();
                    team2.AddDraw();
                }
                if (result == "win")
                {
                    team1.AddWin();
                    team2.AddLoss();
                }
                if (result == "loss")
                {
                    team1.AddLoss();
                    team2.AddWin();
                }


                Console.WriteLine(parts[2]);

            }
            foreach (var team in Tournament.teamList.OrderBy(t => t)) // uses CompareTo
            {
                writer.WriteLine();
                writer.Write(team.WriteResults());
            }
        
        }
    }
}
