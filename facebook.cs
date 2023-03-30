using System;
using System.Collections.Generic;

public class Post
{
    protected string message;
    protected List<string> comments;
    protected int likes;

    public Post(string message)
    {
        this.message = message;
        this.comments = new List<string>();
        this.likes = 0;
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }

    public void AddLike()
    {
        this.likes++;
    }

    public virtual void Display()
    {
        Console.WriteLine($"--------------------------");
        Console.WriteLine($"Post: {message}");
        Console.WriteLine($"Likes: {likes}");
        Console.WriteLine($"Comments ({comments.Count}):");
        foreach (string comment in comments)
        {
            Console.WriteLine($"- {comment}");
        }
        Console.WriteLine($"--------------------------");
    }
}

public class ImagePost : Post
{
    protected string imageFileName;

    public ImagePost(string message, string imageFileName) : base(message)
    {
        this.imageFileName = imageFileName;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Image: {imageFileName}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Post> posts = new List<Post>();

        while (true)
        {
            Console.WriteLine($"-------- Social Media App --------");
            Console.WriteLine($"1. Add a text post");
            Console.WriteLine($"2. Add an image post");
            Console.WriteLine($"3. View all posts");
            Console.WriteLine($"4. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter your message: ");
                    string message = Console.ReadLine();
                    Post messagePost = new Post(message);
                    posts.Add(messagePost);
                    Console.WriteLine($"Post added successfully!");
                    break;

                case 2:
                    Console.Write("Enter your message: ");
                    string imageMessage = Console.ReadLine();
                    Console.Write("Enter image file name: ");
                    string imageFileName = Console.ReadLine();
                    ImagePost imagePost = new ImagePost(imageMessage, imageFileName);
                    posts.Add(imagePost);
                    Console.WriteLine($"Post added successfully!");
                    break;

                case 3:
                    Console.WriteLine($"-------- All Posts --------");
                    foreach (Post post in posts)
                    {
                        post.Display();
                    }
                    Console.WriteLine($"--------------------------");
                    break;

                case 4:
                    Console.WriteLine($"Exiting program...");
                    return;

                default:
                    Console.WriteLine($"Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
