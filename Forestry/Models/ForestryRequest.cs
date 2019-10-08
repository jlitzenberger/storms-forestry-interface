using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forestry.Models
{
    public class ForestryRequest : IValidatableObject
    {
        public string CorellationId { get; set; }
        public CodeModel Origin { get; set; }
        public string Timestamp { get; set; }
        public Forestry Model { get; set; }
        public string Method { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            //if (!whatever1.Contains(' '))
            //{
            //    results.Add(new ValidationResult("Requires a space", new List<string>() { "whatever1" }));
            //}

            if (string.IsNullOrEmpty(Model.Id))
            {
                results.Add(new ValidationResult("id a is null", new List<string>() { "id" }));
            }
            if (string.IsNullOrEmpty(Model.Status))
            {
                results.Add(new ValidationResult("status is null", new List<string>() { "status" }));
            }

            if (results.Count > 0)
            {
                // yield return results[0];
            }
            else
            {
                // yield return null;
            }

            return results;
        }
    }
}
