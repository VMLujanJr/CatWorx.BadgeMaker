namespace CatWorx.BadgeMaker
{
    class Employee // 📦
    {
        private string FirstName; // Keith
        private string LastName; // Yanosy
        private int Id;
        private string PhotoUrl;
        // This is the constructor, for the most part, it must be public. Few use cases for keeping private.
        public Employee(string firstName, string lastName, int id, string photoUrl) { // 📥
            FirstName = firstName; // Keith
            LastName = lastName; // Yanosy
            Id = id;
            PhotoUrl = photoUrl;
        }
        public string GetFullName() {
            return FirstName + " " + LastName;
        }
        public int GetId() {
            return Id;
        }
        public string GetPhotoUrl() {
            return PhotoUrl;
        }
        public string GetCompanyName() {
            return "Cat Worx";
        }
    }
}