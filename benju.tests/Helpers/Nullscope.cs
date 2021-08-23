using System;
using System.Collections.Generic;
using System.Text;

namespace benju.tests.Helpers
{
    public class Nullscope : IDisposable
    {
        public static Nullscope Instance { get; set; }
        public void Dispose() {  }
        private Nullscope() { }
    }
}
