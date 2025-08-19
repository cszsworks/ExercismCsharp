public class HighScores
{
    List<int> scores;
    public HighScores(List<int> list)
    {
        scores = list;
    }

    public List<int> Scores() => this.scores;

    public int Latest() => this.scores[this.scores.Count-1];

    public int PersonalBest() => this.scores.Max();

    public List<int> PersonalTopThree() => this.scores.OrderByDescending(x => x).Take(3).ToList();
}