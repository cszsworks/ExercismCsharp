public class HighScores
{
    List<int> scores;
    public HighScores(List<int> list)
    {
        scores = list;
    }

    public List<int> Scores()
    {
        return this.scores;
    }

    public int Latest()
    {
        return this.scores[this.scores.Count-1];
    }

    public int PersonalBest()
    {
        return this.scores.Max();
    }

    public List<int> PersonalTopThree()
    {
        return this.scores
               .OrderByDescending(x => x)
               .Take(3)
               .ToList();
    }
}