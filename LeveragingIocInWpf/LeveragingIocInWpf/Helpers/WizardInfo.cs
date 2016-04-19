using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeveragingIocInWpf.Helpers
{
    public class WizardInfo
    {
        public string Text { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public bool IsPreviousEnabled { get; set; }

        public string NextButtonText { get; set; }

        public bool IsPrinterVisible { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
