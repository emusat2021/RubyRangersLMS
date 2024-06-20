using System.Text;

namespace RubyRangersLMS_Blazor.Entities
{
    public class TestStudent
    {
        public int Id { get; set; }

        public required ICollection<CurriculumEntity> CurriculumEntities { get; set; }

        public override string ToString()
        {
            var foo = new StringBuilder();

            foreach (var p in CurriculumEntities)
                foo.AppendLine(p.ToString());

            return foo.ToString();
        }
    }
}
