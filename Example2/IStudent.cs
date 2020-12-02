using System;
using System.Collections.Generic;
using System.Text;

namespace Example2
{
    public interface IStudent
    {
        // <History, 12>...
        List<Dictionary<string, double>> Scores { get; set; }

        Double GetScore(string lesson);
    }
}
