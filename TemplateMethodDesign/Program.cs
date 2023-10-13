using System;
using static System.Formats.Asn1.AsnWriter;

namespace TemplateMethodDesign
{
    public class Program
    {
        public static void Main()
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Mans");
            algorithm = new MensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));


            Console.WriteLine("Women");
            algorithm = new WomesScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));


            Console.WriteLine("Women");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }
}
public abstract class ScoringAlgorithm
{
    public int GenerateScore(int hits,TimeSpan time)
    {
        int score = CaculateBaseScore(hits);
        int reduction = CaculateReduction(time);
        return CaculateOverallScore(score, reduction);
    }

    public abstract int CaculateOverallScore(int score, int reduction);
    public abstract int CaculateReduction(TimeSpan time);
    public abstract int CaculateBaseScore(int hits);
}
public class MensScoringAlgorithm : ScoringAlgorithm
{
    public override int CaculateBaseScore(int hits)
    {
        return hits * 100;
    }

    public override int CaculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CaculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 5;
    }
}
public class WomesScoringAlgorithm : ScoringAlgorithm
{
    public override int CaculateBaseScore(int hits)
    {
        return hits * 100;
    }

    public override int CaculateOverallScore(int score, int reduction)
    {
        return score - reduction;

    }

    public override int CaculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 3;
    }
}
public class ChildrenScoringAlgorithm : ScoringAlgorithm
{
    public override int CaculateBaseScore(int hits)
    {
        return hits * 100;
    }

    public override int CaculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }


    public override int CaculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 2;
    }
}