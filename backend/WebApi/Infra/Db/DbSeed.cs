using WebApi.Domain;

namespace WebApi.Infra.Db;

public static class DbSeed
{
    public static List<Book> GetBooks() =>
    [
        new Book(0, "Pride and Prejudice", "Jane", "Austen", 100, 80, "Hardcover", "1234567891", "Fiction"),
        new Book(0, "To Kill a Mockingbird", "Harper", "Lee", 75, 65, "Paperback", "1234567892", "Fiction"),
        new Book(0, "The Catcher in the Rye", "J.D.", "Salinger", 50, 45, "Hardcover", "1234567893", "Fiction"),
        new Book(0, "The Great Gatsby", "F. Scott", "Fitzgerald", 50, 22, "Hardcover", "1234567894", "Non-Fiction"),
        new Book(0, "The Alchemist", "Paulo", "Coelho", 50, 35, "Hardcover", "1234567895", "Biography"),
        new Book(0, "The Book Thief", "Markus", "Zusak", 75, 11, "Hardcover", "1234567896", "Mystery"),
        new Book(0, "The Chronicles of Narnia", "C.S.", "Lewis", 100, 14, "Paperback", "1234567897", "Sci-Fi"),
        new Book(0, "The Da Vinci Code", "Dan", "Brown", 50, 40, "Paperback", "1234567898", "Sci-Fi"),
        new Book(0, "The Grapes of Wrath", "John", "Steinbeck", 50, 35, "Hardcover", "1234567899", "Fiction"),
        new Book(0, "The Hitchhiker's Guide to the Galaxy", "Douglas", "Adams", 50, 35, "Paperback", "1234567900", "Non-Fiction"),
        new Book(0, "Moby-Dick", "Herman", "Melville", 30, 8, "Hardcover", "8901234567", "Fiction"),
        new Book(0, "To Kill a Mockingbird", "Harper", "Lee", 20, 0, "Paperback", "9012345678", "Non-Fiction"),
        new Book(0, "The Catcher in the Rye", "J.D.", "Salinger", 10, 1, "Hardcover", "0123456789", "Non-Fiction")
    ];
}
