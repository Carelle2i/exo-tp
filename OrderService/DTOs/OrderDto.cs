public class OrderDTO
{
    public int OrderId { get; set; }          // Identifiant unique de la commande
    public int ProductId { get; set; }        // Identifiant du produit associé à la commande
    public string ProductName { get; set; }   // Nom du produit associé à la commande
    public decimal ProductPrice { get; set; } // Prix du produit
    public int UserId { get; set; }           // Identifiant de l'utilisateur qui a passé la commande
    public string UserName { get; set; }      // Nom de l'utilisateur qui a passé la commande
    public int Quantity { get; set; }         // Quantité de produit commandée
    public DateTime OrderDate { get; set; }   // Date et heure de la commande
}
