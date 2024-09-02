using System.ComponentModel.DataAnnotations;

namespace CRUD.Model
{
    public class PersonModel
    {
        public class CreateModel
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string MiddleName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public int Age { get; set; }
        }

        public class UpdateModel
        {
            public int ID { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string MiddleName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public int Age { get; set; }
        }
        public class DeleteModel
        {
            [Required]
            public int ID { get; set; }
        }
    }
}
