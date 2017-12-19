using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Attributes {
    public class FormDataAttribute:Attribute {

        public readonly String ColumnName;

        public FormDataAttribute(String name) {
            ColumnName = name;
        }

    }
}
