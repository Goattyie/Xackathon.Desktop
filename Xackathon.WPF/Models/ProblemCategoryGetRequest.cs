using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Xackathon.WPF.Models
{
    [Serializable]
    internal class ProblemCategoryGetRequest
    {
        public int Total { get; set; }
        public IEnumerable<ProblemCategory> Data { get; set; }
    }
}
