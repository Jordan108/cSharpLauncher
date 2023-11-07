using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CoverPadLauncher.Clases.Controles
{
    public class WindowsComparator : IComparer<string>
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string x, string y);

        public int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}
