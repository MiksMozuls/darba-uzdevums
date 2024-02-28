namespace DarbaUzdevumaProjekts.Domain
{
    // Apraksta Pašas Ziņas
    public class NewsPiece
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NewsSource Source { get; set; }
    }

}
