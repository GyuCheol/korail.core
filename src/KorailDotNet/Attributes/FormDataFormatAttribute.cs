using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Attributes {
    public class FormDataFormatAttribute : Attribute {

        public readonly String Format;

        public FormDataFormatAttribute(String format) {
            Format = format;
        }

    }
}
