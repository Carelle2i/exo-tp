public class Order
{
    public int Id { get; set; }               // Identifiant unique de la commande
    public int ProductId { get; set; }        // Référence au produit (clé étrangère)
    public int UserId { get; set; }           // Référence à l'utilisateur (clé étrangère)
    public int Quantity { get; set; }         // Quantité commandée
    public DateTime OrderDate { get; set; }   // Date de la commande
    public decimal TotalPrice { get; set; }   // Montant total de la commande (peut être calculé)
    
    // Navigation properties (pour Entity Framework, si utilisé)
    public ProductService.Models.Product Product { get; set; }      // Objet Product associé à la commande
    public required User User { get; set; }            // Objet User associé à la commande
}
