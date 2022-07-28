using System.ComponentModel.DataAnnotations;

namespace ModelsAndUtility.Model
{
    public class Competency
    {
        [Key]
        public int CompId { get; set; }
        public string Compname { get; set; }

    }
}