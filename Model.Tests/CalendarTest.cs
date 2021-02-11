using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Linq;

namespace Model.Tests
{
    public class CalendarTest
    {


        /// <summary>
        /// Checks the data annotations of Models to make sure they aren't being violated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private IList<ValidationResult> ValidateModel(object model)
        {
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, result, true);
            // if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return result;
        }

        /// <summary>
        /// Validates the User Model works with proper data
        /// </summary>
        ///

        public void ValidateCalendar()
        {
            var calendar = new Calendar()
            {
                Location = "field",
                Description = "practice",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Message = "come"
            };

            var errorcount = ValidateModel(calendar).Count;
            Assert.Equal(0, errorcount);
        }
    }
}
