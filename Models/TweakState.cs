using System.Collections.Generic;

namespace AMD_DWORD_Viewer.Models
{
    public class TweakState
    {
        public bool IsApplied { get; set; }
        public List<TweakChangeState> Changes { get; set; } = new List<TweakChangeState>();
    }

    public class TweakChangeState
    {
        public string KeyName { get; set; } = string.Empty;
        public uint TargetValue { get; set; }
        public uint? OriginalValue { get; set; }
        public bool ExistedBefore { get; set; }
    }
}
