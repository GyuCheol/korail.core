using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KorailDotNet.Param {
    public class ParamToFormData {

        public static String TransferFormData(BaseParam param) {
            var sb = new StringBuilder();
            var type = param.GetType();
            var properties = type.GetProperties();
            
            foreach (var property in properties) {
                var attributes = property.GetCustomAttributes(typeof(FormDataAttribute), false);

                if (attributes.Length == 1) {
                    var formData = attributes[0] as FormDataAttribute;
                    var value = property.GetValue(param);
                    sb.Append(formData.ColumnName);
                    sb.Append("=");

                    // Enum은 int화하여 넣는다.
                    if(property.PropertyType.BaseType.Name == "Enum") {
                        int? integer = Convert.ChangeType(value, typeof(int)) as int?;

                        if(integer != null) {
                            sb.Append(integer.Value.ToString());
                        }

                    } else {
                        sb.Append(HttpUtility.UrlEncode(value.ToString()));
                    }

                    sb.Append("&");
                }
            }
            
            return sb.ToString();
        }

    }
}
