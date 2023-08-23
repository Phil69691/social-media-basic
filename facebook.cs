using System;
using System.Collections.Generic;

class Post
{
    public string Message { get; }
    public int Likes { get; private set; }
    public List<string> Comments { get; }

    public Post(string message)
    {
        Message = message;
        Likes = 0;
        Comments = new List<string>();
    }

    public void AddLike()
    {
        Likes++;
    }

    public void AddComment(string comment)
    {
        Comments.Add(comment);
    }

    public void Display()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Post: {Message}");
        Console.WriteLine($"Likes: {Likes}");
        Console.WriteLine($"Comments ({Comments.Count}):");
        for (int i = 0; i < Comments.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Comments[i]}");
        }
        Console.WriteLine("--------------------------");
    }
}

class Program
{
    static void Main()
    {
        List<Post> posts = new List<Post>();

        while (true)
        {
            Console.WriteLine("-------- Social Media App --------");
            Console.WriteLine("1. Add a post");
            Console.WriteLine("2. View all posts");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter your message: ");
                    string message = Console.ReadLine();
                    Post post = new Post(message);

                    // Add comments to the post
                    while (true)
                    {
                        Console.Write("Add a comment (or press Enter to finish): ");
                        string comment = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(comment))
                            break;
                        post.AddComment(comment);
                    }

                    posts.Add(post);
                    Console.WriteLine("Post added successfully!");
                    break;

                case 2:
                    Console.WriteLine("-------- All Posts --------");
                    foreach (Post p in posts)
                    {
                        p.Display();
                    }
                    Console.WriteLine("--------------------------");
                    break;

                case 3:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
