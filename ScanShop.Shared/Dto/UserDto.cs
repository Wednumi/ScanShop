namespace ScanShop.Shared.Dto
{
    public class UserDto
    {
        public string Email { get; set; }
        public float Discount { get; set; }
        public float Bonuses { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
