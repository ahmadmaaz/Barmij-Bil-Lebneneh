using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Functionality
{
    public static class RegexPatterns
    {
        public static readonly string DefineVarPattern = @"^ra2m\s+[a-zA-Z]+\s*=\s*\d+\s*$";
        public static readonly string ForStatementPattern = @"^min\s+[a-zA-Z0-9]+\s+la\s+[a-zA-Z0-9]+\s*$";
        public static readonly string varAdditionPattern = @"^zid( (?:\*|[^\n\r])+)?(?:, (?:\*|[^\n\r])+)*\s3a\s+[a-zA-Z]+\s*$";
        public static readonly string varSubtractionPattern = @"^na2es( (?:\*|[^\n\r])+)?(?:, (?:\*|[^\n\r])+)*\smn\s+[a-zA-Z]+\s*$";
        public static readonly string TwoVarAdditionPattern = @"^[a-zA-Z]+\s+besewe\s+[a-zA-Z0-9]+\s+zi2ed\s+[a-zA-Z0-9]+$";
        public static readonly string TwoVarSubtractionPattern = @"^[a-zA-Z]+\s+besewe\s+[a-zA-Z0-9]+\s+na2es\s+[a-zA-Z0-9]+$";
    }
}
