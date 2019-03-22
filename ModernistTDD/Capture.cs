using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModernistTDD
{
    class Capture : IDisposable
    {
        private readonly TextWriter consoleOut;
        private readonly StringWriter stringWriter;

        public Capture()
        {
            this.consoleOut = Console.Out;
            this.stringWriter = new StringWriter();
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Console.SetOut(this.stringWriter);
        }

        public override string ToString()
        {
            return this.stringWriter.ToString();
        }

        ~Capture()
        {
            this.Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            Console.SetOut (this.consoleOut);
            this.stringWriter.Dispose();
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
