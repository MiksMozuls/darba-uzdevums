namespace DarbaUzdevumaProjekts.Domain
{
    
    // Apraksta Pašas Ziņas
    public class NewsPiece
    {
        public Guid NewsID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Guid NewsSourceID { get; set; }
        public NewsSource NewsSource { get; set; }

    }

}
