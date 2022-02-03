using System;

namespace Xackathon.WPF.Models
{
    [Serializable]
    public class ProblemCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MnemonicName { get; set; }
        public string HashTag { get; set; }
    }
}
