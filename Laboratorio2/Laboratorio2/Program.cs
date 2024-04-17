using System;
using System.Collections.Generic;
using Spectre.Console;

namespace SocialMediaManager
{
    // Enum para representar las distintas redes sociales
    public enum SocialMedia
    {
        Facebook,
        Instagram,
        Twitter
    }

    // Interface para la gestión de posts
    public interface IPostManager
    {
        void AddPost(Post post);
        void EditPost(Post post);
        void DeletePost(Post post);
        void ViewPosts(User user);
    }

    // Interface para la gestión de comentarios
    public interface ICommentManager
    {
        void AddComment(Post post, Comment comment);
        void EditComment(Post post, Comment comment);
    }

    // Clase para representar un usuario
    public record User(string Email, string Password, bool IsAdmin = false);

    // Clase para representar un post
    public record Post(string Content, DateTime PostedAt, User Author, SocialMedia SocialMedia);

    // Clase para representar un comentario
    public record Comment(string Content, DateTime CommentedAt, User Author);

    // Excepción personalizada para manejar errores en el programa
    public class SocialMediaManagerException : Exception
    {
        public SocialMediaManagerException(string message) : base(message)
        {
        }
    }

    // Clase principal del programa
    public class Program
    {
        private static List<User> users = new List<User>
        {
            new User("usuario1@gmail.com", "password1", true),
            new User("yulissa.hernandez@gmail.com", "usuario1"),
            new User("juan.lopez@gmail.com", "usuario2"),
            new User("luis.zelaya@gmail.com", "usuario3"),
            new User("usuario2@gmail.com", "password2"),
            new User("cuenta.ejemplo@gmail.com", "usuario5")
            
        };

        static void Main(string[] args)
        {
            // Crear algunos usuarios
            var user1 = new User("usuario1@gmail.com", "password1");
            var user2 = new User("usuario2@gmail.com", "password2");

            // Crear un post
            var post = new Post("¡Hola mundo!", DateTime.Now, user1, SocialMedia.Twitter);

            // Crear un comentario
            var comment = new Comment("¡Hola! Este es un comentario de ejemplo.", DateTime.Now, user2);

            // Crear instancias de los managers
            var postManager = new postmanager();
            var commentManager = new CommentManager();

            // Agregar el post
            postManager.AddPost(post);

            // Agregar un comentario al post
            commentManager.AddComment(post, comment);

            // Ver los posts de un usuario
            postManager.ViewPosts(user1);

            // Editar el post
            post = new Post("¡Hola mundo! Esto es una actualización.", DateTime.Now, user1, SocialMedia.Twitter);
            postManager.EditPost(post);

            // Editar el comentario
            comment = new Comment("¡Hola! Este es un comentario editado.", DateTime.Now, user2);
            commentManager.EditComment(post, comment);

            // Borrar el post
            postManager.DeletePost(post);
        }
    }
}
