using System.Collections.Generic;
using System.Reflection;

namespace LearnerRater.Tests.Utils
{
    public class ModelHelpers
    {
        public static T CreateModelWithPropertiesExceedingMaxLength<T, S>(T model, S maxLengthModel)
        {
            var type = model.GetType();
            var maxLengthType = maxLengthModel.GetType();
            var props = new List<PropertyInfo>(maxLengthType.GetProperties());

            foreach (var prop in props)
            {
                var propertyInfo = type.GetProperty(prop.Name);
                var value = prop.GetValue(maxLengthModel, null);

                propertyInfo.SetValue(model, ((int)value).CreateLargeString());
            }

            return model;
        }
    }
}
