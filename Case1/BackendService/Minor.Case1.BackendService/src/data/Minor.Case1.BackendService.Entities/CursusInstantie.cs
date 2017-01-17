using System;
namespace Minor.Case1.BackendService.Entities
{
    public class CursusInstantie
    {
        public CursusInstantie()
        {
        }
        public int Id { get; set; }
        public string CursusId { get; set; }
        public DateTime StartDatum { get; set; }
        public Cursus Cursus { get; set; }
    }
}