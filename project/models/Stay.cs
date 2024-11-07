namespace project.models
{
    public class Stay
    {
        private int id
        private string type
        private string adress
        private int price
        private string status
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Type
    {
        get => type;
        get => type = value;
    }

    public string Adress
    {
        get => adress;
        set => adress = value;
    }

    public int Price
    {
        get => prince;
        set => price = value;
    }

    public string Status
    {
        get => status;
        set => status = value;
    }

    public Stay (int id, string type, string adress, int price, string status)
    {
        this.id = id;
        this.type = type;
        this.adress = adress;
        this.price = price;
        this.status = status;
    }

    public override string ToString()
    {
        return $"Stay: {id}, {type}, {adress}, {price}, {status}";
    }
}