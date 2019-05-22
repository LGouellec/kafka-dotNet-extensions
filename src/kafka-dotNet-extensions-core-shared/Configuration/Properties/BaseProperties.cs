using System.ComponentModel;

namespace kafka_dotNet_extensions_core
{
    public class BaseProperties
    {
        public BaseProperties()
        {
            foreach(PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            {
                AttributeCollection attributes = property.Attributes;
                DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
                if(defaultValueAttribute != null)
                    property.SetValue(this, defaultValueAttribute.Value);
            }
        }
    }
}
