namespace TesteSeusConhecimentos.Entities
{
    public class DtoBase
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual bool IsNew() { return true; }
    }
}