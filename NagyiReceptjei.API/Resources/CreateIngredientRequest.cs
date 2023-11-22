namespace NagyiReceptjei.API.Resources;

public class CreateIngredientRequest
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public string Unit { get; set; }
}
