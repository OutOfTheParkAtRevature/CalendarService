using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Linq;
using Models.DataTransfer;

namespace Model.Tests
{
    public class EventDtoTest
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

        public void ValidateEventDto()
        {
            var eventDto = new EventDto()
            {
                Description = "practice",
                Location = "field",
                Message = "come",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            };

            var errorcount = ValidateModel(eventDto).Count;
            Assert.Equal(0, errorcount);
        }
    }
}
