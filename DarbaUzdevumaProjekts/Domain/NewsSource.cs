namespace DarbaUzdevumaProjekts.Domain
{
    // Apraksta Ziņu avotu
    public class NewsSource
    {
        public Guid SourceID { get; set; }
        public string SourceName { get; set; } 
        public string SourceLink { get; set; } 
        public ICollection<NewsPiece> NewsPieces { get; set; } = new List<NewsPiece>(); 
     }

}
