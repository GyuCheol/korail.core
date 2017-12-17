using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Attributes {
    public class FormDataName:Attribute {

        public readonly String ColumnName;

        public FormDataName(String name) {
            ColumnName = name;
        }

    }
}
